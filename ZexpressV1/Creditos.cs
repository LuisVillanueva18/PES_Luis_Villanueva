//Librerias----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;
//--------------------------------------------------------------------------------

namespace ZexpressV1
{
    public partial class Creditos: KryptonForm
    {
        //Variables-----------------------------------------------------------------
        private string connectionString = @"Server=.\SQLEXPRESS;Database=Zexpress;Integrated Security=True;";
        private int creditoId = -1;
        //-------------------------------------------------------------------------

        public Creditos()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.AcceptButton = btnGuardar;
            contextMenuCreditos = new ContextMenuStrip();
            var itemEditar = new ToolStripMenuItem("Editar");
            itemEditar.Click += EditarCreditoContextMenu_Click;
            contextMenuCreditos.Items.Add(itemEditar);
            var itemEliminar = new ToolStripMenuItem("Eliminar");
            itemEliminar.Click += EliminarCreditoContextMenu_Click;
            contextMenuCreditos.Items.Add(itemEliminar);
            var itemCambiarEstado = new ToolStripMenuItem("Cambiar Estado");
            itemCambiarEstado.Click += CambiarEstadoContextMenu_Click;
            contextMenuCreditos.Items.Add(itemCambiarEstado);
            dgvCreditos.ContextMenuStrip = contextMenuCreditos;
        }

        //Eventos-------------------------------------------------------------------
        private void Creditos_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarEstados();
            CargarEmpleados();
        }
        //-------------------------------------------------------------------------

        //Metodos-------------------------------------------------------------------
        private void CargarEstados()
        {
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Pagado");
            cmbEstado.SelectedIndex = 0; 
        }
        //-------------------------------------------------------------------------

        //Boton Guardar------------------------------------------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtMonto.Text, out decimal monto))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int clienteId = (int)cmbClientes.SelectedValue;
            DateTime fecha = dtpFecha.Value;
            string estado = cmbEstado.SelectedItem.ToString();
            string descripcion = txtDescripcion.Text;
            int empleadoId = (int)cmbEmpleados.SelectedValue;

            string query;
            if (creditoId > 0)
            {
                query = @"UPDATE Creditos SET 
                 ClienteId = @ClienteId, 
                 EmpleadoId = @EmpleadoId, 
                 Monto = @Monto, 
                 Fecha = @Fecha, 
                 Estado = @Estado,
                 Descripcion = @Descripcion 
                 WHERE Id = @Id";
            }
            else
            {
                query = @"INSERT INTO Creditos 
                (ClienteId, EmpleadoId, Monto, Fecha, Estado, Descripcion) 
                VALUES 
                (@ClienteId, @EmpleadoId, @Monto, @Fecha, @Estado, @Descripcion)";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClienteId", clienteId);
                        command.Parameters.AddWithValue("@Monto", monto);
                        command.Parameters.AddWithValue("@Fecha", fecha);
                        command.Parameters.AddWithValue("@Estado", estado);
                        command.Parameters.AddWithValue("@EmpleadoId", empleadoId);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);


                        if (creditoId > 0)
                        {
                            command.Parameters.AddWithValue("@Id", creditoId);
                        }

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show(creditoId > 0 ? "Crédito actualizado correctamente." : "Crédito registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarCreditos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el crédito: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //-------------------------------------------------------------------------

        //Boton Cambiar Estado-----------------------------------------------------
        private void CambiarEstadoContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvCreditos.SelectedRows.Count == 0 && dgvCreditos.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un crédito para cambiar estado",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvCreditos.SelectedRows.Count > 0
                ? dgvCreditos.SelectedRows[0]
                : dgvCreditos.Rows[dgvCreditos.SelectedCells[0].RowIndex];

            int creditoId = Convert.ToInt32(fila.Cells["Id"].Value);
            string estadoActual = fila.Cells["Estado"].Value.ToString();
            string nuevoEstado = estadoActual == "Pendiente" ? "Pagado" : "Pendiente";

            CambiarEstadoCredito(creditoId, nuevoEstado);
        }

        private void CambiarEstadoCredito(int id, string nuevoEstado)
        {
            string query = "UPDATE Creditos SET Estado = @Estado WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Estado", nuevoEstado);
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Estado cambiado a '{nuevoEstado}' correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCreditos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cambiar el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //-------------------------------------------------------------------------

        //Boton Editar-------------------------------------------------------------
        private void EditarCreditoContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvCreditos.SelectedRows.Count == 0 && dgvCreditos.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un crédito para editar",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvCreditos.SelectedRows.Count > 0
                ? dgvCreditos.SelectedRows[0]
                : dgvCreditos.Rows[dgvCreditos.SelectedCells[0].RowIndex];

            creditoId = Convert.ToInt32(fila.Cells["Id"].Value);
            cmbClientes.SelectedValue = Convert.ToInt32(fila.Cells["ClienteId"].Value);
            txtMonto.Text = fila.Cells["Monto"].Value.ToString();
            dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);
            cmbEstado.SelectedItem = fila.Cells["Estado"].Value.ToString();
            cmbEmpleados.SelectedValue = fila.Cells["EmpleadoId"].Value != DBNull.Value ?
                                       Convert.ToInt32(fila.Cells["EmpleadoId"].Value) : -1;
            txtDescripcion.Text = fila.Cells["Descripcion"].Value != DBNull.Value ?
                                fila.Cells["Descripcion"].Value.ToString() : "";

        }
        //-------------------------------------------------------------------------

        //Boton Eliminar-----------------------------------------------------------
        private void EliminarCreditoContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvCreditos.SelectedRows.Count == 0 && dgvCreditos.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un crédito para eliminar",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvCreditos.SelectedRows.Count > 0
                ? dgvCreditos.SelectedRows[0]
                : dgvCreditos.Rows[dgvCreditos.SelectedCells[0].RowIndex];

            string estado = fila.Cells["Estado"].Value.ToString();
            if (estado == "Pendiente")
            {
                MessageBox.Show("No se puede eliminar un crédito en estado 'Pendiente'.",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("¿Está seguro que desea eliminar este crédito?",
                              "Confirmar eliminación",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(fila.Cells["Id"].Value);
                EliminarCredito(id);
            }
        }
        private void EliminarCredito(int id)
        {
            string query = "DELETE FROM Creditos WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Crédito eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCreditos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el crédito: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //-------------------------------------------------------------------------

        //Cargar Clientes------------------------------------------------------------
        private void CargarClientes()
        {
            string query = "SELECT Id, Nombre FROM Clientes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cmbClientes.DataSource = dt;
                    cmbClientes.DisplayMember = "Nombre";
                    cmbClientes.ValueMember = "Id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //-------------------------------------------------------------------------

        //Cargar Empleados---------------------------------------------------------
        private void CargarEmpleados()
        {
            string query = "SELECT Id, Nombre FROM Trabajadores";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbEmpleados.DataSource = dt;
                    cmbEmpleados.DisplayMember = "Nombre";
                    cmbEmpleados.ValueMember = "Id";
                    cmbEmpleados.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los empleados: " + ex.Message,
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //-------------------------------------------------------------------------

        //Cargo los creditos-------------------------------------------------------
        private void CargarCreditos(int? clienteId = null)
        {
            string query = @"
        SELECT c.Id, c.ClienteId, cl.Nombre AS Cliente, 
               c.EmpleadoId, t.Nombre AS Empleado,
               c.Monto, c.Fecha, c.Estado, c.Descripcion
        FROM Creditos c
        INNER JOIN Clientes cl ON c.ClienteId = cl.Id
        LEFT JOIN Trabajadores t ON c.EmpleadoId = t.Id";

            if (clienteId.HasValue)
            {
                query += " WHERE c.ClienteId = @ClienteId";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    if (clienteId.HasValue)
                    {
                        command.Parameters.AddWithValue("@ClienteId", clienteId.Value);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCreditos.DataSource = dt;

                    dgvCreditos.Columns["Id"].Visible = false;
                    dgvCreditos.Columns["ClienteId"].Visible = false;
                    dgvCreditos.Columns["EmpleadoId"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los créditos: " + ex.Message,
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //-------------------------------------------------------------------------

        //Limpiar Campos-----------------------------------------------------------
        private void LimpiarCampos()
        {
            creditoId = -1;
            cmbClientes.SelectedIndex = 0;
            cmbEmpleados.SelectedIndex = -1;
            txtMonto.Clear();
            txtDescripcion.Clear();
            dtpFecha.Value = DateTime.Now;
            cmbEstado.SelectedIndex = 0;
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != null && cmbClientes.SelectedValue is int)
            {
                int clienteId = (int)cmbClientes.SelectedValue;
                CargarCreditos(clienteId);
            }
            else
            {
                CargarCreditos(); 
            }
        }
        //-------------------------------------------------------------------------
    }
}

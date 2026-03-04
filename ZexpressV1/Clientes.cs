//Librerias---------------------------------------------------------------
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
//------------------------------------------------------------------------

namespace ZexpressV1
{
    public partial class Clientes: KryptonForm
    {
        //Conexión a la base de datos-------------------------------------
        private string connectionString = @"Server=.\SQLEXPRESS;Database=Zexpress;Integrated Security=True;";
        //----------------------------------------------------------------

        public Clientes()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.AcceptButton = btnGuardar;
            contextMenuClientes = new ContextMenuStrip();
            var itemEditar = new ToolStripMenuItem("Editar");
            itemEditar.Click += EditarClienteContextMenu_Click;
            contextMenuClientes.Items.Add(itemEditar);
            var itemEliminar = new ToolStripMenuItem("Eliminar");
            itemEliminar.Click += EliminarClienteContextMenu_Click;
            contextMenuClientes.Items.Add(itemEliminar);
            dgvClientes.ContextMenuStrip = contextMenuClientes;
        }
        //Evento Load-----------------------------------------------------
        private void Clientes_Load(object sender, EventArgs e)
        {
             CargarClientes();
        }
        //----------------------------------------------------------------

        //Boton Guardar---------------------------------------------------
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && txtTelefono.Text.Replace("-", "").Length != 8)
            {
                MessageBox.Show("El teléfono debe tener 8 dígitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string opcional = txtOpcional.Text;

            int clienteId = (dgvClientes.SelectedRows.Count > 0) ? Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["Id"].Value) : -1;

            string query;
            if (clienteId > 0)
            {
                query = "UPDATE Clientes SET Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono, Opcional = @Opcional WHERE Id = @Id";
            }
            else
            {
                query = "INSERT INTO Clientes (Nombre, Direccion, Telefono, Opcional) VALUES (@Nombre, @Direccion, @Telefono, @Opcional)";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Direccion", direccion);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@Opcional", opcional);

                        if (clienteId > 0)
                        {
                            command.Parameters.AddWithValue("@Id", clienteId);
                        }

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show(clienteId > 0 ? "Cliente actualizado correctamente." : "Cliente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //----------------------------------------------------------------

        //Boton Editar----------------------------------------------------
        private void EditarClienteContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0 && dgvClientes.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente para editar",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvClientes.SelectedRows.Count > 0
                ? dgvClientes.SelectedRows[0]
                : dgvClientes.Rows[dgvClientes.SelectedCells[0].RowIndex];

            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtDireccion.Text = fila.Cells["Direccion"].Value.ToString(); 
            txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
            txtOpcional.Text = fila.Cells["Opcional"].Value.ToString();
        }
        //----------------------------------------------------------------

        //Boton Eliminar--------------------------------------------------
        private void EliminarClienteContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0 && dgvClientes.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvClientes.SelectedRows.Count > 0
                ? dgvClientes.SelectedRows[0]
                : dgvClientes.Rows[dgvClientes.SelectedCells[0].RowIndex];

            if (MessageBox.Show("¿Está seguro que desea eliminar este cliente?",
                              "Confirmar eliminación",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(fila.Cells["Id"].Value);
                EliminarCliente(id);
            }
        }

        private void EliminarCliente(int id)
        {
            string checkTransaccionesQuery = "SELECT COUNT(*) FROM Transacciones WHERE ClienteId = @ClienteId";
            int transaccionesCount;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand checkCmd = new SqlCommand(checkTransaccionesQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@ClienteId", id);
                    transaccionesCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                }

                if (transaccionesCount > 0)
                {
                    var result = MessageBox.Show($"Este cliente tiene {transaccionesCount} transacción asociada. " +
                                              "¿Desea eliminar también todas sus transacciones?",
                                              "Confirmar eliminación",
                                              MessageBoxButtons.YesNoCancel,
                                              MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        SqlTransaction transaction = connection.BeginTransaction();
                        try
                        {
                            string deleteTransaccionesQuery = "DELETE FROM Transacciones WHERE ClienteId = @ClienteId";
                            using (SqlCommand deleteTransCmd = new SqlCommand(deleteTransaccionesQuery, connection, transaction))
                            {
                                deleteTransCmd.Parameters.AddWithValue("@ClienteId", id);
                                deleteTransCmd.ExecuteNonQuery();
                            }

                            string deleteClienteQuery = "DELETE FROM Clientes WHERE Id = @Id";
                            using (SqlCommand deleteClienteCmd = new SqlCommand(deleteClienteQuery, connection, transaction))
                            {
                                deleteClienteCmd.Parameters.AddWithValue("@Id", id);
                                deleteClienteCmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Cliente y transacciones eliminados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarClientes();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show("No se borraron ninguna transaccion o cliente.",
                                      "Cancelado",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                }
                else
                {
                    string deleteClienteQuery = "DELETE FROM Clientes WHERE Id = @Id";
                    using (SqlCommand deleteClienteCmd = new SqlCommand(deleteClienteQuery, connection))
                    {
                        deleteClienteCmd.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = deleteClienteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarClientes();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el cliente especificado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }
        //----------------------------------------------------------------

        //Limpiar Campos-------------------------------------------------
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtOpcional.Clear();
        }
        //----------------------------------------------------------------

        //Cargar Clientes------------------------------------------------
        private void CargarClientes()
        {
            string query = "SELECT Id, Nombre, Direccion, Telefono, Opcional FROM Clientes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvClientes.DataSource = dt;
                    dgvClientes.Columns["Id"].Visible = false;
                    dgvClientes.Columns["Nombre"].HeaderText = "Nombre";
                    dgvClientes.Columns["Direccion"].HeaderText = "Dirección"; 
                    dgvClientes.Columns["Telefono"].HeaderText = "Teléfono";
                    dgvClientes.Columns["Opcional"].HeaderText = "Opcional";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //----------------------------------------------------------------

        //Colocar guiones en el telefono---------------------------------
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text;

            telefono = telefono.Replace("-", "");

            if (telefono.Length > 8)
            {
                telefono = telefono.Substring(0, 8);
            }

            if (telefono.Length > 4)
            {
                telefono = telefono.Insert(4, "-");
            }
            txtTelefono.Text = telefono;
            txtTelefono.SelectionStart = txtTelefono.Text.Length;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }
        //----------------------------------------------------------------


        //Filtrar Clientes---------------------------------------------
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            if (dgvClientes.DataSource is DataTable dt)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(filtro))
                    {
                        dt.DefaultView.RowFilter = "";
                    }
                    else
                    {
                        string filterExpression = "";
                        List<string> columnFilters = new List<string>();

                        foreach (DataColumn column in dt.Columns)
                        {
                            if (column.DataType == typeof(string) && column.ColumnName != "Id")
                            {
                                columnFilters.Add($"[{column.ColumnName}] LIKE '%{filtro.Replace("'", "''")}%'");
                            }
                        }

                        if (columnFilters.Count > 0)
                        {
                            filterExpression = string.Join(" OR ", columnFilters);
                            dt.DefaultView.RowFilter = filterExpression;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al filtrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //------------------------------------------------------------
    }
}

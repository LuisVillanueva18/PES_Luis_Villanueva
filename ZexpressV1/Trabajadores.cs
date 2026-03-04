//Librerias----------------------------------------------------------------------------
using Krypton.Toolkit;
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
//--------------------------------------------------------------------------------------

namespace ZexpressV1
{
    public partial class Trabajadores: KryptonForm
    {
        //Variables-----------------------------------------------------------------------
        private string connectionString = @"Server=.\SQLEXPRESS;Database=Zexpress;Integrated Security=True;";
        private int trabajadorId = -1;
        //--------------------------------------------------------------------------------

        public Trabajadores()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            contextMenuTrabajadores = new ContextMenuStrip();
            var itemEditar = new ToolStripMenuItem("Editar");
            itemEditar.Click += EditarTrabajadorContextMenu_Click;
            contextMenuTrabajadores.Items.Add(itemEditar);
            var itemEliminar = new ToolStripMenuItem("Eliminar");
            itemEliminar.Click += EliminarTrabajadorContextMenu_Click;
            contextMenuTrabajadores.Items.Add(itemEliminar);
            dgvTrabajadores.ContextMenuStrip = contextMenuTrabajadores;
        }

        //Funciones-----------------------------------------------------------------------
        private void Trabajadores_Load(object sender, EventArgs e)
        {
            CargarTrabajadores();
        }
        //--------------------------------------------------------------------------------

        //Boton Guardar------------------------------------------------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del Empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Por favor, ingrese la cédula del Empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombre = txtNombre.Text;
            string cedula = txtCedula.Text;
            string telefono = txtTelefono.Text;
            string query;

            if (trabajadorId > 0)
            {
                query = "UPDATE Trabajadores SET Nombre = @Nombre, Cedula = @Cedula, Telefono = @Telefono WHERE Id = @Id";
            }
            else
            {
                query = "INSERT INTO Trabajadores (Nombre, Cedula, Telefono) VALUES (@Nombre, @Cedula, @Telefono)";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Cedula", cedula);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        if (trabajadorId > 0)
                        {
                            command.Parameters.AddWithValue("@Id", trabajadorId);
                        }
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show(trabajadorId > 0 ? "Empleado actualizado correctamente" : "Empleado registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarTrabajadores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el trabajador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //--------------------------------------------------------------------------------

        //Boton Editar-------------------------------------------------------------------
        private void EditarTrabajadorContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvTrabajadores.SelectedRows.Count == 0 && dgvTrabajadores.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un trabajador para editar",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvTrabajadores.SelectedRows.Count > 0
                ? dgvTrabajadores.SelectedRows[0]
                : dgvTrabajadores.Rows[dgvTrabajadores.SelectedCells[0].RowIndex];

            trabajadorId = Convert.ToInt32(fila.Cells["Id"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtCedula.Text = fila.Cells["Cedula"].Value.ToString();
            txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
        }
        //--------------------------------------------------------------------------------

        //Boton Eliminar-----------------------------------------------------------------
        private void EliminarTrabajadorContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvTrabajadores.SelectedRows.Count == 0 && dgvTrabajadores.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un trabajador para eliminar",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvTrabajadores.SelectedRows.Count > 0
                ? dgvTrabajadores.SelectedRows[0]
                : dgvTrabajadores.Rows[dgvTrabajadores.SelectedCells[0].RowIndex];

            if (MessageBox.Show("¿Está seguro que desea eliminar este trabajador?",
                              "Confirmar eliminación",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(fila.Cells["Id"].Value);
                EliminarTrabajador(id);
            }
        }

        private void EliminarTrabajador(int id)
        {
            string query = "DELETE FROM Trabajadores WHERE Id = @Id";

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

                    MessageBox.Show("Trabajador eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTrabajadores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el trabajador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //--------------------------------------------------------------------------------

        //Cargar Trabajadores------------------------------------------------------------
        private void CargarTrabajadores()
        {
            string query = "SELECT Id, Nombre, Cedula, Telefono FROM Trabajadores";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTrabajadores.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los trabajadores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //--------------------------------------------------------------------------------

        //Limpiar Campos-----------------------------------------------------------------
        private void LimpiarCampos()
        {
            trabajadorId = -1;
            txtNombre.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }
        //--------------------------------------------------------------------------------
    }
}

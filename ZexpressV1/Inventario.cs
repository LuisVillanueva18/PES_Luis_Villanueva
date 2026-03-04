//Librerias-----------------------------------------------------------------------------
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
//---------------------------------------------------------------------------------------

namespace ZexpressV1
{
    public partial class Inventario: KryptonForm
    {
        //Variables-----------------------------------------------------------------------
        private string connectionString = @"Server=.\SQLEXPRESS;Database=Zexpress;Integrated Security=True;";
        private int inventarioId = -1;
        //--------------------------------------------------------------------------------

        public Inventario()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.AcceptButton = btnGuardar;
            contextMenuInventario = new ContextMenuStrip();
            var itemEditar = new ToolStripMenuItem("Editar");
            itemEditar.Click += EditarInventarioContextMenu_Click;
            contextMenuInventario.Items.Add(itemEditar);
            var itemEliminar = new ToolStripMenuItem("Eliminar");
            itemEliminar.Click += EliminarInventarioContextMenu_Click;
            contextMenuInventario.Items.Add(itemEliminar);
            dgvInventario.ContextMenuStrip = contextMenuInventario;
        }

        //Eventos-------------------------------------------------------------------------
        private void Inventario_Load(object sender, EventArgs e)
        {
            CargarInventario();
        }
        //--------------------------------------------------------------------------------

        //Boton Guardar------------------------------------------------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, ingrese la descripción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtUnidadesDisponibles.Text, out int unidadesDisponibles))
            {
                MessageBox.Show("Por favor, ingrese un valor válido para unidades disponibles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtLlenos.Text, out int llenos))
            {
                MessageBox.Show("Por favor, ingrese un valor válido para llenos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtVacios.Text, out int vacios))
            {
                MessageBox.Show("Por favor, ingrese un valor válido para vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string descripcion = txtDescripcion.Text;
            string query;

            if (inventarioId > 0)
            {
                query = "UPDATE Inventario SET Descripcion = @Descripcion, UnidadesDisponibles = @UnidadesDisponibles, Llenos = @Llenos, Vacios = @Vacios WHERE Id = @Id";
            }
            else
            {
                query = "INSERT INTO Inventario (Descripcion, UnidadesDisponibles, Llenos, Vacios) VALUES (@Descripcion, @UnidadesDisponibles, @Llenos, @Vacios)";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Descripcion", descripcion);
                        command.Parameters.AddWithValue("@UnidadesDisponibles", unidadesDisponibles);
                        command.Parameters.AddWithValue("@Llenos", llenos);
                        command.Parameters.AddWithValue("@Vacios", vacios);

                        if (inventarioId > 0)
                        {
                            command.Parameters.AddWithValue("@Id", inventarioId);
                        }

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show(inventarioId > 0 ? "Registro actualizado correctamente" : "Registro agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarInventario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //--------------------------------------------------------------------------------

        //Boton Editar-------------------------------------------------------------------
        private void EditarInventarioContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count == 0 && dgvInventario.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un item del inventario para editar",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvInventario.SelectedRows.Count > 0
                ? dgvInventario.SelectedRows[0]
                : dgvInventario.Rows[dgvInventario.SelectedCells[0].RowIndex];

            inventarioId = Convert.ToInt32(fila.Cells["Id"].Value);
            txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
            txtUnidadesDisponibles.Text = fila.Cells["UnidadesDisponibles"].Value.ToString();
            txtLlenos.Text = fila.Cells["Llenos"].Value.ToString();
            txtVacios.Text = fila.Cells["Vacios"].Value.ToString();
        }
        //--------------------------------------------------------------------------------

        //Boton Eliminar-----------------------------------------------------------------
        private void EliminarInventarioContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count == 0 && dgvInventario.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un item del inventario para eliminar",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvInventario.SelectedRows.Count > 0
                ? dgvInventario.SelectedRows[0]
                : dgvInventario.Rows[dgvInventario.SelectedCells[0].RowIndex];

            if (MessageBox.Show("¿Está seguro que desea eliminar este item del inventario?",
                              "Confirmar eliminación",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(fila.Cells["Id"].Value);
                EliminarItemInventario(id);
            }
        }

        private void EliminarItemInventario(int id)
        {
            string query = "DELETE FROM Inventario WHERE Id = @Id";

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

                    MessageBox.Show("Item eliminado correctamente del inventario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarInventario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //--------------------------------------------------------------------------------

        //Cargo el inventario------------------------------------------------------------
        private void CargarInventario()
        {
            string query = "SELECT Id, Descripcion, UnidadesDisponibles, Llenos, Vacios FROM Inventario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvInventario.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //--------------------------------------------------------------------------------

        //Limpiar campos-----------------------------------------------------------------
        private void LimpiarCampos()
        {
            inventarioId = -1;
            txtDescripcion.Clear();
            txtUnidadesDisponibles.Clear();
            txtLlenos.Clear();
            txtVacios.Clear();
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }
        //--------------------------------------------------------------------------------
    }
}

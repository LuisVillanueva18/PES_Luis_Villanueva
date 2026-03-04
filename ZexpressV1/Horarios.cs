//Librerias----------------------------------------------------------------------------------------------------------------
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextFont = iTextSharp.text.Font;
using Krypton.Toolkit;
//-------------------------------------------------------------------------------------------------------------------------

namespace ZexpressV1
{
    public partial class Horarios: KryptonForm
    {
        //Variables--------------------------------------------------------------------------------------------------------
        private string connectionString = @"Server=.\SQLEXPRESS;Database=Zexpress;Integrated Security=True;";
        private int trabajadorId = -1;
        //-----------------------------------------------------------------------------------------------------------------

        public Horarios()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            dgvTrabajadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrabajadores.MultiSelect = false;
            dgvTrabajadores.CellClick += dgvTrabajadores_CellClick;
            var contextMenu = new ContextMenuStrip();
            var itemEliminar = new ToolStripMenuItem("Eliminar registro");
            itemEliminar.Click += EliminarRegistroActivoContextMenu_Click;
            contextMenu.Items.Add(itemEliminar);
            dgvTrabajadoresActivos.ContextMenuStrip = contextMenu;
            dgvTrabajadoresActivos.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Right)
                {
                    var hitTest = dgvTrabajadoresActivos.HitTest(e.X, e.Y);
                    if (hitTest.RowIndex < 0 || dgvTrabajadoresActivos.Rows[hitTest.RowIndex].IsNewRow)
                    {
                        contextMenu.Visible = false;
                    }
                }
            };
        }

        //Evento Load-----------------------------------------------------------------------------------------------------
        private void Horarios_Load(object sender, EventArgs e)
        {
            CargarTrabajadores();
            CargarTrabajadoresActivos();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Boton generar reporte-------------------------------------------------------------------------------------------
        private void btnGenerarReporteHorarios_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFechaReporte.Value;
            GenerarReporteHorariosPDF(fechaSeleccionada);
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Boton marcar entrada---------------------------------------------------------------------------------------------
        private void btnMarcarEntrada_Click_1(object sender, EventArgs e)
        {
            if (trabajadorId == -1)
            {
                MessageBox.Show("Por favor, seleccione un trabajador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime fechaActual = DateTime.Now;
            string queryInsertar = "INSERT INTO RegistroHorarios (TrabajadorId, Fecha, HoraEntrada) VALUES (@TrabajadorId, @Fecha, @HoraEntrada)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(queryInsertar, connection))
                    {
                        command.Parameters.AddWithValue("@TrabajadorId", trabajadorId);
                        command.Parameters.AddWithValue("@Fecha", fechaActual.Date);
                        command.Parameters.AddWithValue("@HoraEntrada", fechaActual);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Entrada registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTrabajadoresActivos();
                    VerificarEstadoTrabajador();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar la entrada: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Boton marcar salida----------------------------------------------------------------------------------------------
        private void btnMarcarSalida_Click_1(object sender, EventArgs e)
        {
            if (trabajadorId == -1)
            {
                MessageBox.Show("Por favor, seleccione un trabajador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime fechaActual = DateTime.Now;
            string queryActualizar = "UPDATE RegistroHorarios SET HoraSalida = @HoraSalida WHERE TrabajadorId = @TrabajadorId AND Fecha = @Fecha AND HoraSalida IS NULL";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(queryActualizar, connection))
                    {
                        command.Parameters.AddWithValue("@TrabajadorId", trabajadorId);
                        command.Parameters.AddWithValue("@Fecha", fechaActual.Date);
                        command.Parameters.AddWithValue("@HoraSalida", fechaActual);

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Salida registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTrabajadoresActivos();
                    VerificarEstadoTrabajador();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar la salida: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Boton eliminar registro------------------------------------------------------------------------------------------
        private void EliminarRegistroActivoContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvTrabajadoresActivos.SelectedRows.Count == 0 &&
                dgvTrabajadoresActivos.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un trabajador para eliminar su registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvTrabajadoresActivos.SelectedRows.Count > 0
                ? dgvTrabajadoresActivos.SelectedRows[0]
                : dgvTrabajadoresActivos.Rows[dgvTrabajadoresActivos.SelectedCells[0].RowIndex];

            int trabajadorId = Convert.ToInt32(fila.Cells["Id"].Value);
            string nombreTrabajador = fila.Cells["Nombre"].Value.ToString();

            if (MessageBox.Show($"¿Está seguro que desea eliminar el registro de horario de {nombreTrabajador}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EliminarRegistroHorario(trabajadorId);
            }
        }

        private void EliminarRegistroHorario(int trabajadorId)
        {
            string query = "DELETE FROM RegistroHorarios WHERE TrabajadorId = @TrabajadorId AND Fecha = @Fecha";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrabajadorId", trabajadorId);
                        command.Parameters.AddWithValue("@Fecha", DateTime.Now.Date);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarTrabajadoresActivos(); 
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el registro a eliminar.",
                                          "Advertencia",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Cargo trabajadores------------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------------------------

        //Cargo trabajadores activos----------------------------------------------------------------------------------------
        private void CargarTrabajadoresActivos()
        {
            string query = @"
                SELECT t.Id, t.Nombre, t.Cedula, t.Telefono, r.HoraEntrada
                FROM Trabajadores t
                INNER JOIN RegistroHorarios r ON t.Id = r.TrabajadorId
                WHERE r.Fecha = @Fecha AND r.HoraSalida IS NULL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Fecha", DateTime.Now.Date);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTrabajadoresActivos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los trabajadores activos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Verificar estado trabajador----------------------------------------------------------------------------------------
        private void VerificarEstadoTrabajador()
        {
            string query = @"
                SELECT HoraEntrada, HoraSalida
                FROM RegistroHorarios
                WHERE TrabajadorId = @TrabajadorId AND Fecha = @Fecha";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrabajadorId", trabajadorId);
                        command.Parameters.AddWithValue("@Fecha", DateTime.Now.Date);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["HoraSalida"] == DBNull.Value)
                                {
                                    btnMarcarEntrada.Enabled = false;
                                    btnMarcarSalida.Enabled = true;
                                }
                                else
                                {
                                    btnMarcarEntrada.Enabled = false;
                                    btnMarcarSalida.Enabled = false;
                                }
                            }
                            else
                            {
                                btnMarcarEntrada.Enabled = true;
                                btnMarcarSalida.Enabled = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar el estado del trabajador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Evento seleccionar trabajador-------------------------------------------------------------------------------------
        private void dgvTrabajadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTrabajadores.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvTrabajadores.SelectedRows[0];
                if (fila.Cells["Id"].Value != null && fila.Cells["Nombre"].Value != null)
                {
                    trabajadorId = Convert.ToInt32(fila.Cells["Id"].Value);
                    VerificarEstadoTrabajador();
                }
            }
            else
            {
                trabajadorId = -1;
                btnMarcarEntrada.Enabled = false;
                btnMarcarSalida.Enabled = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Generar reporte---------------------------------------------------------------------------------------------------
        public void GenerarReporteHorariosPDF(DateTime fecha)
        {
            string query = @"
        SELECT t.Nombre, t.Cedula, t.Telefono, r.HoraEntrada, r.HoraSalida
        FROM RegistroHorarios r
        INNER JOIN Trabajadores t ON r.TrabajadorId = t.Id
        WHERE r.Fecha = @Fecha";

            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Reporte_Horarios_{fecha:yyyy-MM-dd}.pdf");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Fecha", fecha.Date);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            Document document = new Document(PageSize.A4, 40, 40, 100, 60);
                            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(rutaArchivo, FileMode.Create));
                            document.Open();

                            string logoPath = Path.Combine(Application.StartupPath, "Resources", "Zexpress1.png");
                            if (File.Exists(logoPath))
                            {
                                try
                                {
                                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                                    logo.ScaleToFit(80f, 80f);
                                    logo.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                                    logo.SetAbsolutePosition(
                                        (document.PageSize.Width - logo.ScaledWidth) / 2,
                                        document.PageSize.Height - logo.ScaledHeight - 35
                                    );
                                    document.Add(logo);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error al cargar el logo: {ex.Message}");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No se encontró el logo en: {logoPath}");
                            }

                            iTextFont tituloFont = new iTextFont(iTextFont.FontFamily.HELVETICA, 18, iTextFont.BOLD, BaseColor.DARK_GRAY);
                            Paragraph titulo = new Paragraph("Zexpress - Reporte de Horarios", tituloFont);
                            titulo.Alignment = Element.ALIGN_CENTER;
                            titulo.SpacingAfter = 10f;
                            document.Add(titulo);

                            iTextFont fechaFont = new iTextFont(iTextFont.FontFamily.HELVETICA, 12, iTextFont.NORMAL, BaseColor.GRAY);
                            Paragraph fechaReporte = new Paragraph($"Fecha: {fecha:dd/MM/yyyy}", fechaFont);
                            fechaReporte.Alignment = Element.ALIGN_CENTER;
                            fechaReporte.SpacingAfter = 20f;
                            document.Add(fechaReporte);

                            PdfPTable tabla = new PdfPTable(6);
                            tabla.WidthPercentage = 100;
                            tabla.SpacingBefore = 15f;
                            tabla.SpacingAfter = 20f;
                            BaseColor headerColor = new BaseColor(4, 3, 26);
                            iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
                            string[] columnas = { "Nombre", "Cédula", "Teléfono", "Hora Entrada", "Hora Salida", "Horas Trabajadas" };
                            foreach (string columna in columnas)
                            {
                                PdfPCell headerCell = new PdfPCell(new Phrase(columna, headerFont));
                                headerCell.BackgroundColor = headerColor;
                                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                headerCell.Padding = 8f;
                                headerCell.BorderWidth = 1f;
                                headerCell.BorderColor = BaseColor.WHITE;
                                tabla.AddCell(headerCell);
                            }

                            iTextSharp.text.Font dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                            foreach (DataRow fila in dt.Rows)
                            {
                                PdfPCell nombreCell = new PdfPCell(new Phrase(fila["Nombre"].ToString(), dataFont));
                                nombreCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                nombreCell.Padding = 5f;
                                tabla.AddCell(nombreCell);
                                PdfPCell cedulaCell = new PdfPCell(new Phrase(fila["Cedula"].ToString(), dataFont));
                                cedulaCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cedulaCell.Padding = 5f;
                                tabla.AddCell(cedulaCell);
                                PdfPCell telefonoCell = new PdfPCell(new Phrase(fila["Telefono"].ToString(), dataFont));
                                telefonoCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                telefonoCell.Padding = 5f;
                                tabla.AddCell(telefonoCell);
                                PdfPCell entradaCell = new PdfPCell(new Phrase(Convert.ToDateTime(fila["HoraEntrada"]).ToString("HH:mm"), dataFont));
                                entradaCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                entradaCell.Padding = 5f;
                                tabla.AddCell(entradaCell);
                                string horaSalida = (fila["HoraSalida"] != DBNull.Value) ? Convert.ToDateTime(fila["HoraSalida"]).ToString("HH:mm") : "N/A";
                                PdfPCell salidaCell = new PdfPCell(new Phrase(horaSalida, dataFont));
                                salidaCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                salidaCell.Padding = 5f;
                                tabla.AddCell(salidaCell);
                                string horasTrabajadas = "N/A";
                                if (fila["HoraEntrada"] != DBNull.Value && fila["HoraSalida"] != DBNull.Value)
                                {
                                    TimeSpan diferencia = Convert.ToDateTime(fila["HoraSalida"]) - Convert.ToDateTime(fila["HoraEntrada"]);
                                    horasTrabajadas = $"{diferencia.Hours}:{diferencia.Minutes:00}";
                                }
                                PdfPCell horasCell = new PdfPCell(new Phrase(horasTrabajadas, dataFont));
                                horasCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                horasCell.Padding = 5f;
                                tabla.AddCell(horasCell);
                            }
                            document.Add(tabla);
                            iTextFont footerFont = new iTextFont(iTextFont.FontFamily.HELVETICA, 8, iTextFont.ITALIC, BaseColor.GRAY);
                            Paragraph footer = new Paragraph($"Página {writer.PageNumber} • Generado el {DateTime.Now:dd/MM/yyyy HH:mm} • Zexpress", footerFont);
                            footer.Alignment = Element.ALIGN_CENTER;
                            footer.SpacingBefore = 30f;
                            Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.5f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -1)));
                            document.Add(linea);

                            document.Add(footer);

                            document.Close();
                        }
                    }

                    MessageBox.Show($"Reporte generado correctamente en:\n{rutaArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}

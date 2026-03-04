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
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace ZexpressV1
{
    public partial class CajaChica: KryptonForm
    {
        //Variables------------------------------------------------------
        private string connectionString = @"Server=.\SQLEXPRESS;Database=Zexpress;Integrated Security=True;";
        private int registroId = -1;
        //----------------------------------------------------------------

        public CajaChica()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.AcceptButton = btnAgregar;
            contextMenuGrid = new ContextMenuStrip();
            var itemEditar = new ToolStripMenuItem("Editar");
            contextMenuGrid.Items.Add(itemEditar);
            dgvCajaChica.ContextMenuStrip = contextMenuGrid;
            itemEditar.Click += EditarRegistroContextMenu_Click;

        }

        private void CajaChica_Load(object sender, EventArgs e)
        {
            CargarDenominaciones();
            CargarCajaChica();
        }


        //Agregar registro------------------------------------------------
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (cmbDenominacion.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una denominación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int denominacionId = (int)cmbDenominacion.SelectedValue;
            decimal total = CalcularTotal(denominacionId, cantidad);
            string query;
            if (registroId == -1)
            {
                query = @"INSERT INTO CajaChica (Fecha, DenominacionId, Cantidad, Total) VALUES (@Fecha, @DenominacionId, @Cantidad, @Total)";
            }
            else
            {
                query = @"UPDATE CajaChica SET DenominacionId = @DenominacionId, Cantidad = @Cantidad, Total = @Total WHERE Id = @Id";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Fecha", DateTime.Now);
                        command.Parameters.AddWithValue("@DenominacionId", denominacionId);
                        command.Parameters.AddWithValue("@Cantidad", cantidad);
                        command.Parameters.AddWithValue("@Total", total);

                        if (registroId != -1)
                        {
                            command.Parameters.AddWithValue("@Id", registroId);
                        }

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show(registroId == -1 ? "Registro agregado correctamente." : "Registro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                    CargarCajaChica();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //----------------------------------------------------------------


        //Editar registro------------------------------------------------
        private void EditarRegistroContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvCajaChica.SelectedRows.Count == 0 && dgvCajaChica.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un registro para editar",
                               "Advertencia",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvCajaChica.SelectedRows.Count > 0
                ? dgvCajaChica.SelectedRows[0]
                : dgvCajaChica.Rows[dgvCajaChica.SelectedCells[0].RowIndex];

            registroId = Convert.ToInt32(fila.Cells["Id"].Value);
            string denominacion = fila.Cells["Denominacion"].Value.ToString();
            int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);

            cmbDenominacion.SelectedValue = ObtenerIdDenominacion(denominacion);
            txtCantidad.Text = cantidad.ToString();
            CargarCajaChica();
        }
        //----------------------------------------------------------------


        //Calcular total--------------------------------------------------
        private decimal CalcularTotal(int denominacionId, int cantidad)
        {
            string query = "SELECT Valor FROM Denominaciones WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", denominacionId);
                    decimal valor = (decimal)command.ExecuteScalar();
                    return valor * cantidad;
                }
            }
        }
        //----------------------------------------------------------------

        //Limpiar controles------------------------------------------------
        private void LimpiarControles()
        {
            registroId = -1;
            cmbDenominacion.SelectedIndex = 0;
            txtCantidad.Clear();
        }
        //----------------------------------------------------------------

        //Obtener denominación------------------------------------------------
        private int ObtenerIdDenominacion(string nombreDenominacion)
        {
            string query = "SELECT Id FROM Denominaciones WHERE Nombre = @Nombre";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreDenominacion);
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener la denominación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }
        //----------------------------------------------------------------

        //Caja chica-----------------------------------------------------
        private void CargarDenominaciones()
        {
            string query = "SELECT Id, Nombre FROM Denominaciones";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cmbDenominacion.DisplayMember = "Nombre";
                    cmbDenominacion.ValueMember = "Id";
                    cmbDenominacion.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las denominaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //----------------------------------------------------------------

        //Regresar-------------------------------------------------------
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }
        //----------------------------------------------------------

        //Cargar caja chica-----------------------------------------
        private void CargarCajaChica()
        {
            DateTime fechaActual = DateTime.Today;

            string query = @"
                            SELECT 
                                cc.Id, 
                                d.Nombre AS Denominacion, 
                                cc.Cantidad, 
                                cc.Total,
                                cc.Fecha 
                            FROM CajaChica cc
                            INNER JOIN Denominaciones d ON cc.DenominacionId = d.Id
                            WHERE cc.Fecha >= @FechaInicio AND cc.Fecha < @FechaFin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FechaInicio", fechaActual);
                    command.Parameters.AddWithValue("@FechaFin", fechaActual.AddDays(1));

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvCajaChica.DataSource = dt;

                    // Configuración básica de columnas
                    if (dgvCajaChica.Columns.Count > 0)
                    {
                        dgvCajaChica.Columns["Id"].Visible = false;
                        dgvCajaChica.Columns["Total"].DefaultCellStyle.Format = "C2";
                    }
                    CalcularTotalGeneral(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los registros de Caja Chica: " + ex.Message,
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }
        //----------------------------------------------------------

        //Calcular total general----------------------------------------
        private void CalcularTotalGeneral(DataTable dt)
        {
            decimal totalGeneral = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Total"] != DBNull.Value)
                {
                    totalGeneral += Convert.ToDecimal(row["Total"]);
                }
            }
            lblTotalGeneral.Text = $"Total General: {totalGeneral:C2}";

        }
        //----------------------------------------------------------------

        //Generar reporte------------------------------------------------
        private void btnReporteCajaChica_Click(object sender, EventArgs e)
        {
            GenerarReporteCajaChicaPDF(DateTime.Today);
        }

        public void GenerarReporteCajaChicaPDF(DateTime fecha)
        {
            bool reporteDiario = chkCajaChicaDiaria.Checked;
            string tipoReporte = reporteDiario ? "Diario" : "Usuario";

            string query = @"
                SELECT 
                    d.Nombre AS Denominacion, 
                    cc.Cantidad, 
                    d.Valor,
                    cc.Total
                FROM CajaChica cc
                INNER JOIN Denominaciones d ON cc.DenominacionId = d.Id
                WHERE cc.Fecha >= @FechaInicio AND cc.Fecha < @FechaFin";

            if (!reporteDiario)
            {
                query += " AND cc.UsuarioId = @UsuarioId";
            }

            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Reporte_CajaChica_{fecha:yyyy-MM-dd}_{tipoReporte}.pdf");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FechaInicio", fecha.Date);
                        command.Parameters.AddWithValue("@FechaFin", fecha.Date.AddDays(1));

                        if (!reporteDiario)
                        {
                            command.Parameters.AddWithValue("@UsuarioId", Sesion.UsuarioId);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            decimal totalGeneral = dt.AsEnumerable()
                                .Sum(row => row.Field<decimal>("Total"));

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

                            iTextFont tituloFont = new iTextFont(iTextFont.FontFamily.HELVETICA, 18, iTextFont.BOLD, BaseColor.DARK_GRAY);
                            Paragraph titulo = new Paragraph("Zexpress - Reporte de Caja Chica", tituloFont);
                            titulo.Alignment = Element.ALIGN_CENTER;
                            titulo.SpacingAfter = 10f;
                            document.Add(titulo);

                            iTextFont fechaFont = new iTextFont(iTextFont.FontFamily.HELVETICA, 12, iTextFont.NORMAL, BaseColor.GRAY);
                            Paragraph fechaReporte = new Paragraph($"Fecha: {fecha:dd/MM/yyyy}", fechaFont);
                            fechaReporte.Alignment = Element.ALIGN_CENTER;
                            fechaReporte.SpacingAfter = 20f;
                            document.Add(fechaReporte);

                            PdfPTable tabla = new PdfPTable(4);
                            tabla.WidthPercentage = 100;
                            tabla.SpacingBefore = 15f;
                            tabla.SpacingAfter = 20f;

                            BaseColor headerColor = new BaseColor(4, 3, 26);
                            iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);

                            string[] columnas = { "Denominación", "Cantidad", "Valor Unitario", "Total" };
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
                                PdfPCell denomCell = new PdfPCell(new Phrase(fila["Denominacion"].ToString(), dataFont));
                                denomCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                denomCell.Padding = 5f;
                                tabla.AddCell(denomCell);

                                PdfPCell cantCell = new PdfPCell(new Phrase(fila["Cantidad"].ToString(), dataFont));
                                cantCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cantCell.Padding = 5f;
                                tabla.AddCell(cantCell);

                                PdfPCell valorCell = new PdfPCell(new Phrase(Convert.ToDecimal(fila["Valor"]).ToString("C2"), dataFont));
                                valorCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                valorCell.Padding = 5f;
                                tabla.AddCell(valorCell);

                                PdfPCell totalCell = new PdfPCell(new Phrase(Convert.ToDecimal(fila["Total"]).ToString("C2"), dataFont));
                                totalCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                totalCell.Padding = 5f;
                                tabla.AddCell(totalCell);
                            }
                            document.Add(tabla);

                            PdfPTable tablaTotal = new PdfPTable(2);
                            tablaTotal.WidthPercentage = 50;
                            tablaTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                            tablaTotal.SpacingBefore = 20f;

                            PdfPCell celdaTotalTexto = new PdfPCell(new Phrase("TOTAL GENERAL:", headerFont));
                            celdaTotalTexto.BackgroundColor = headerColor;
                            celdaTotalTexto.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            celdaTotalTexto.HorizontalAlignment = Element.ALIGN_RIGHT;
                            tablaTotal.AddCell(celdaTotalTexto);

                            PdfPCell celdaTotalValor = new PdfPCell(new Phrase(totalGeneral.ToString("C2"), headerFont));
                            celdaTotalValor.BackgroundColor = headerColor;
                            celdaTotalValor.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            celdaTotalValor.HorizontalAlignment = Element.ALIGN_CENTER;
                            tablaTotal.AddCell(celdaTotalValor);

                            document.Add(tablaTotal);
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
        //----------------------------------------------------------------
    }
}

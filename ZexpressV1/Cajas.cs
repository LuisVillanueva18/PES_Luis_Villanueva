//Librerias----------------------------------------------------------------------------
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
using System.Drawing.Drawing2D;
//-------------------------------------------------------------------------------------

namespace ZexpressV1
{
    public partial class Cajas: KryptonForm
    {
        //Conexión a la base de datos--------------------------------------------------
        private string connectionString = @"Server=.\SQLEXPRESS;Database=Zexpress;Integrated Security=True;";
        private int transaccionId = -1;
        //-----------------------------------------------------------------------------

        public Cajas()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.AcceptButton = btnGuardar;
            contextMenuTransacciones = new ContextMenuStrip();
            var itemEditar = new ToolStripMenuItem("Editar");
            itemEditar.Click += EditarTransaccionContextMenu_Click;
            contextMenuTransacciones.Items.Add(itemEditar);
            var itemEliminar = new ToolStripMenuItem("Eliminar");
            itemEliminar.Click += EliminarTransaccionContextMenu_Click;
            contextMenuTransacciones.Items.Add(itemEliminar);
            dgvTransacciones.ContextMenuStrip = contextMenuTransacciones;
        }

        //Clase Cliente---------------------------------------------------------------- 
        public class Cliente
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }
        //-----------------------------------------------------------------------------

        //Eventos----------------------------------------------------------------------
        private void Cajas_Load_1(object sender, EventArgs e)
        {
            CargarMetodos();
            CargarClientes();
            dtpFecha.Value = DateTime.Now;
            CargarTransacciones();
            CalcularTotalVentas();
        }
        //-------------------------------------------------------------------------------

        //Metodos-------------------------------------------------------------------------
        private void CargarMetodos()
        {
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Sinpe");
            cmbMetodoPago.Items.Add("Tarjeta");
            cmbMetodoPago.SelectedIndex = 0;
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = 0;
            txtMonto.Clear();
            cmbMetodoPago.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
            transaccionId = -1;
        }
        //---------------------------------------------------------------------------------

        //Metodos de cargar datos----------------------------------------------------------
        private void CargarTransacciones()
        {
            DateTime fechaActual = DateTime.Today;

            string query = @"
        SELECT 
            t.Id, 
            c.Nombre AS Cliente, 
            t.Monto, 
            t.MetodoPago, 
            t.Fecha 
        FROM Transacciones t
        INNER JOIN Clientes c ON t.ClienteId = c.Id
        WHERE t.Fecha >= @FechaInicio AND t.Fecha < @FechaFin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@FechaInicio", fechaActual);
                    adapter.SelectCommand.Parameters.AddWithValue("@FechaFin", fechaActual.AddDays(1));
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvTransacciones.DataSource = dt;
                    dgvTransacciones.Columns["Id"].Visible = false;
                    dgvTransacciones.Columns["Cliente"].HeaderText = "Cliente";
                    dgvTransacciones.Columns["Monto"].HeaderText = "Monto";
                    dgvTransacciones.Columns["MetodoPago"].HeaderText = "Método de Pago";
                    dgvTransacciones.Columns["Fecha"].HeaderText = "Fecha";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las transacciones: " + ex.Message,
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }
        //---------------------------------------------------------------------------------

        //Metodos de carga de datos--------------------------------------------------------
        private void CargarClientes()
        {
            string query = "SELECT Id, Nombre FROM Clientes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            cmbCliente.Items.Clear();
                            var clientes = new List<Cliente>();

                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string nombre = reader.GetString(1);
                                clientes.Add(new Cliente { Id = id, Nombre = nombre });
                            }

                            cmbCliente.DataSource = clientes;
                            cmbCliente.DisplayMember = "Nombre";
                            cmbCliente.ValueMember = "Id";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //---------------------------------------------------------------------------------

        //Metodo de calcular total de ventas------------------------------------------------
        private void CalcularTotalVentas()
        {
            DateTime fechaActual = DateTime.Now.Date;
            string query = "SELECT SUM(Monto) AS TotalVentas FROM Transacciones WHERE Fecha >= @FechaInicio AND Fecha < @FechaFin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FechaInicio", fechaActual);
                        command.Parameters.AddWithValue("@FechaFin", fechaActual.AddDays(1));

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            decimal totalVentas = Convert.ToDecimal(result);
                            lblTotalVentas.Text = $"Total de ventas hoy: {totalVentas:C}";
                        }
                        else
                        {
                            lblTotalVentas.Text = "Total de ventas hoy: ₡0.00";                                                       
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al calcular el total de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //---------------------------------------------------------------------------------

        //Metodo de generar reporte--------------------------------------------------------
        public void GenerarReportePDF(DateTime fecha)
        {
            bool reporteDiario = chkReporteDiario.Checked;
            string query = @"
        SELECT t.Id, c.Nombre AS Cliente, t.Monto, t.MetodoPago, t.Fecha 
        FROM Transacciones t
        INNER JOIN Clientes c ON t.ClienteId = c.Id
        WHERE t.Fecha >= @FechaInicio AND t.Fecha < @FechaFin";

            if (!reporteDiario)
            {
                query += " AND t.UsuarioId = @UsuarioId";
            }

            string tipoReporte = reporteDiario ? "Diario" : "Usuario";
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Reporte_Ventas_{fecha:yyyy-MM-dd}_{tipoReporte}.pdf");

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
                            decimal totalVentas = dt.AsEnumerable().Sum(row => Convert.ToDecimal(row["Monto"]));
                            Document document = new Document(PageSize.A4, 40, 40, 100, 60);
                            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(rutaArchivo, FileMode.Create));
                            document.Open();

                            //Logo--------------------------------------------------------------------------------
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
                            //----------------------------------------------------------------------------------

                            //Título principal-------------------------------------------------
                            iTextFont tituloFont = new iTextFont(iTextFont.FontFamily.HELVETICA, 18, iTextFont.BOLD, BaseColor.DARK_GRAY);
                            Paragraph titulo = new Paragraph("Zexpress - Reporte de Ventas", tituloFont);
                            titulo.Alignment = Element.ALIGN_CENTER;
                            titulo.SpacingAfter = 10f;
                            document.Add(titulo);
                            //----------------------------------------------------------------

                            iTextFont fechaFont = new iTextFont(iTextFont.FontFamily.HELVETICA, 12, iTextFont.NORMAL, BaseColor.GRAY);
                            Paragraph fechaReporte = new Paragraph($"Fecha: {fecha:dd/MM/yyyy}", fechaFont);
                            fechaReporte.Alignment = Element.ALIGN_CENTER;
                            fechaReporte.SpacingAfter = 20f;

                            document.Add(fechaReporte);
                            PdfPTable tabla = new PdfPTable(dt.Columns.Count);
                            tabla.WidthPercentage = 100;
                            tabla.SpacingBefore = 15f;
                            tabla.SpacingAfter = 20f;

                            //Encabezado de la tabla------------------------------------------------
                            BaseColor headerColor = new BaseColor(4, 3, 26);
                            iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
                            foreach (DataColumn columna in dt.Columns)
                            {
                                PdfPCell headerCell = new PdfPCell(new Phrase(columna.ColumnName, headerFont));
                                headerCell.BackgroundColor = headerColor;
                                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                headerCell.Padding = 8f;
                                headerCell.BorderWidth = 1f;
                                headerCell.BorderColor = BaseColor.WHITE;
                                tabla.AddCell(headerCell);
                            }
                            //-------------------------------------------------------------------

                            iTextSharp.text.Font dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                            foreach (DataRow fila in dt.Rows)
                            {
                                foreach (DataColumn columna in dt.Columns)
                                {
                                    PdfPCell dataCell = new PdfPCell(new Phrase(fila[columna].ToString(), dataFont));
                                    dataCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    dataCell.Padding = 5f;
                                    dataCell.BorderWidth = 0.5f;
                                    dataCell.BorderColor = new BaseColor(220, 220, 220);
                                    tabla.AddCell(dataCell);
                                }
                            }
                            document.Add(tabla);

                            //Total de ventas---------------------------------------------------------------------------------
                            PdfPTable tablaTotal = new PdfPTable(2);
                            tablaTotal.WidthPercentage = 50;
                            tablaTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                            tablaTotal.SpacingBefore = 20f;
                            PdfPCell celdaTotalTexto = new PdfPCell(new Phrase("TOTAL DE VENTAS:", headerFont));
                            celdaTotalTexto.BackgroundColor = headerColor;
                            celdaTotalTexto.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            celdaTotalTexto.HorizontalAlignment = Element.ALIGN_RIGHT;
                            tablaTotal.AddCell(celdaTotalTexto);
                            PdfPCell celdaTotalValor = new PdfPCell(new Phrase(totalVentas.ToString("C2"), headerFont));
                            celdaTotalValor.BackgroundColor = headerColor;
                            celdaTotalValor.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            celdaTotalValor.HorizontalAlignment = Element.ALIGN_CENTER;
                            tablaTotal.AddCell(celdaTotalValor);
                            document.Add(tablaTotal);
                            //--------------------------------------------------------------------------------------------------

                            //Pie de pagina ---------------------------------------------------------------------------------------------
                            iTextFont footerFont = new iTextFont(iTextFont.FontFamily.HELVETICA, 8, iTextFont.ITALIC, BaseColor.GRAY);
                            Paragraph footer = new Paragraph($"Página {writer.PageNumber} • Generado el {DateTime.Now:dd/MM/yyyy HH:mm} • Zexpress", footerFont);
                            footer.Alignment = Element.ALIGN_CENTER;
                            footer.SpacingBefore = 30f;
                            Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.5f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -1)));
                            document.Add(linea);
                            document.Add(footer);
                            //------------------------------------------------------------------------------------------------------------
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
        //---------------------------------------------------------------------------------

        //Boton de generar reporte---------------------------------------------------------
        private void btnReporte_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFechaReporte.Value;
            GenerarReportePDF(fechaSeleccionada);
        }
        //---------------------------------------------------------------------------------

        //Boton de guardar--------------------------------------------------------------
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out decimal monto))
            {
                MessageBox.Show("Por favor, ingrese un monto válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbMetodoPago.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un método de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int clienteId = (int)cmbCliente.SelectedValue;
            string metodoPago = cmbMetodoPago.SelectedItem.ToString();
            DateTime fecha = dtpFecha.Value;
            int userId = Sesion.UsuarioId;

            string query;
            if (transaccionId > 0)
            {
                query = @"UPDATE Transacciones SET 
                ClienteId = @ClienteId, 
                Monto = @Monto, 
                MetodoPago = @MetodoPago, 
                Fecha = @Fecha
                WHERE Id = @Id";
            }
            else
            {
                query = @"INSERT INTO Transacciones 
                (ClienteId, Monto, MetodoPago, Fecha, UsuarioId) 
                VALUES (@ClienteId, @Monto, @MetodoPago, @Fecha, @UsuarioId)";
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
                        command.Parameters.AddWithValue("@MetodoPago", metodoPago);
                        command.Parameters.AddWithValue("@Fecha", fecha);

                        if (transaccionId <= 0)
                        {
                            command.Parameters.AddWithValue("@UsuarioId", userId);
                        }

                        if (transaccionId > 0)
                        {
                            command.Parameters.AddWithValue("@Id", transaccionId);
                        }
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show(transaccionId > 0 ? "Transacción actualizada correctamente" : "Transacción registrada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarTransacciones();
                    CalcularTotalVentas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la transacción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Boton de limpiar campos-----------------------------------------------------------------------------------------------
        private void EditarTransaccionContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvTransacciones.SelectedRows.Count == 0 && dgvTransacciones.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una transacción para editar",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow fila = dgvTransacciones.SelectedRows.Count > 0
                ? dgvTransacciones.SelectedRows[0]
                : dgvTransacciones.Rows[dgvTransacciones.SelectedCells[0].RowIndex];

            transaccionId = Convert.ToInt32(fila.Cells["Id"].Value);
            cmbCliente.SelectedValue = ObtenerIdCliente(fila.Cells["Cliente"].Value.ToString());
            txtMonto.Text = fila.Cells["Monto"].Value.ToString();
            cmbMetodoPago.SelectedItem = fila.Cells["MetodoPago"].Value.ToString();
            dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);
        }
        //-----------------------------------------------------------------------------------------------------------------------

        //Boton de eliminar transaccion---------------------------------------------------
        private void EliminarTransaccionContextMenu_Click(object sender, EventArgs e)
        {
            if (dgvTransacciones.SelectedRows.Count == 0 && dgvTransacciones.SelectedCells.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una transacción para eliminar",
                              "Advertencia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvTransacciones.SelectedRows.Count > 0
                ? dgvTransacciones.SelectedRows[0]
                : dgvTransacciones.Rows[dgvTransacciones.SelectedCells[0].RowIndex];

            if (MessageBox.Show("¿Está seguro de que desea eliminar esta transacción?",
                              "Confirmar eliminación",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(fila.Cells["Id"].Value);
                EliminarTransaccion(id);
            }
        }
        //---------------------------------------------------------------------------------

        //Metodo de eliminar transaccion---------------------------------------------------
        private void EliminarTransaccion(int id)
        {
            string query = "DELETE FROM Transacciones WHERE Id = @Id";

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
                    MessageBox.Show("Transacción eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTransacciones();
                    CalcularTotalVentas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la transacción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //---------------------------------------------------------------------------------

        //Metodo de obtener id de cliente---------------------------------------------------
        private int ObtenerIdCliente(string nombreCliente)
        {
            string query = "SELECT Id FROM Clientes WHERE Nombre = @Nombre";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreCliente);
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }
        //---------------------------------------------------------------------------------

        //Boton de regresar---------------------------------------------------------------
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }
        //---------------------------------------------------------------------------------
    }
}

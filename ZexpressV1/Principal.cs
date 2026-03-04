//Librerias----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Krypton.Toolkit;
//------------------------------------------------------------------------

namespace ZexpressV1
{
    public partial class Principal : KryptonForm
    {
        //Variables------------------------------------------------------
        private Timer timer;
        private string connectionString = @"Server=.\SQLEXPRESS;Database=Zexpress;Integrated Security=True;";
        //----------------------------------------------------------------
        public Principal()
        {
            InitializeComponent();
            //Inicializar timer-------------------------------------------
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.MaximizeBox = false;
            FechaTarjeta.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FechaTarjeta1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //------------------------------------------------------------
        }

        //Evento Load---------------------------------------------------
        private void Principal_Load(object sender, EventArgs e)
        {
            ChartVentas.Series.Clear();
            ChartVentas.Titles.Clear();
            ChartVentas.ChartAreas.Clear();
            TotalVentas();
            ConteoTransacciones();
            TotalCajaChica();
            CargarGraficoVentas();
        }
        //----------------------------------------------------------------

        //Botones de la interfaz-------------------------------------------
        private void btnCaja_Click_1(object sender, EventArgs e)
        {
            Cajas cajas = new Cajas();
            cajas.Show();
            this.Hide();
        }

        private void btnCajaChica_Click(object sender, EventArgs e)
        {
            CajaChica cajachica = new CajaChica();
            cajachica.Show();
            this.Hide();
        }

        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.Show();
            this.Hide();
        }

        private void btnHorario_Click_1(object sender, EventArgs e)
        {
            Horarios horarios = new Horarios();
            horarios.Show();
            this.Hide();
        }

        private void btnCreditos_Click_1(object sender, EventArgs e)
        {
            Creditos creditos = new Creditos();
            creditos.Show();
            this.Hide();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            Trabajadores trabajadores = new Trabajadores();
            trabajadores.Show();
            this.Hide();
        }

        private void btnInventario_Click_1(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.Show();
            this.Hide();
        }
        //----------------------------------------------------------------

        //Reloj a tiempo real---------------------------------------------
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            string fechaHora = DateTime.Now.ToString("HH:mm:ss tt");
            lblFechaHora.Text = fechaHora;
        }
        //----------------------------------------------------------------


        //Cargar caja actual----------------------------------------------
        private void TotalVentas()
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
                        decimal totalVentas = (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                        btnTotalVentas.Text = $"₡{totalVentas:N0}";
                        btnTotalVentas.Tag = totalVentas;
                    }
                }
                catch (Exception ex)
                {
                    btnTotalVentas.Text = "₡0";
                    MessageBox.Show("Error al calcular ventas: " + ex.Message, "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //----------------------------------------------------------------

        //Total de viajes---------------------------------------------------
        private void ConteoTransacciones()
        {
            DateTime fechaActual = DateTime.Today;
            string query = @"
        SELECT COUNT(*) 
        FROM Transacciones 
        WHERE Fecha >= @FechaInicio AND Fecha < @FechaFin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FechaInicio", fechaActual);
                        command.Parameters.AddWithValue("@FechaFin", fechaActual.AddDays(1));

                        int conteo = (int)command.ExecuteScalar();
                        btnTransaccionesHoy.Text = $"{conteo}";
                    }
                }
                catch (Exception ex)
                {
                    btnTransaccionesHoy.Text = "0";
                    MessageBox.Show("Error al contar transacciones: " + ex.Message,
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //----------------------------------------------------------------

        //Total de caja chica---------------------------------------------------
        private void TotalCajaChica()
        {
            DateTime fechaActual = DateTime.Today;
            string query = @"
        SELECT SUM(Total) 
        FROM CajaChica 
        WHERE Fecha >= @FechaInicio AND Fecha < @FechaFin";
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
                        decimal totalCaja = (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                        btnTotalCajaChica.Text = $"₡{totalCaja:N0}";
                    }
                }
                catch (Exception ex)
                {
                    btnTotalCajaChica.Text = "₡0";
                    MessageBox.Show("Error al calcular caja chica: " + ex.Message,
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //----------------------------------------------------------------

        //Grafico de ventas---------------------------------------------------
        private void CargarGraficoVentas()
        {
            ChartVentas.Series.Clear();
            ChartVentas.Titles.Clear();
            ChartVentas.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("AreaPrincipal");
            chartArea.BackColor = Color.Transparent;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 11);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 11);
            ChartVentas.ChartAreas.Add(chartArea);
            Series series = new Series("Ventas");
            series.ChartType = SeriesChartType.Column;
            series.XValueType = ChartValueType.Date;
            series.YValueType = ChartValueType.Double;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "₡#,##0";
            series.Font = new Font("Segoe UI", 9);
            series.Color = Color.FromArgb(255, 4, 3, 26);
            series.BorderColor = Color.FromArgb(255, 20, 15, 80);
            series.BorderWidth = 2;
            series.BackSecondaryColor = Color.FromArgb(255, 10, 8, 40);
            series.BackGradientStyle = GradientStyle.DiagonalRight;
            DateTime fechaFin = DateTime.Today;
            DateTime fechaInicio = fechaFin.AddDays(-6);

            string query = @"SELECT CAST(Fecha AS DATE) AS FechaDia, SUM(Monto) AS TotalVentas
            FROM Transacciones
            WHERE Fecha >= @FechaInicio AND Fecha <= @FechaFin
            GROUP BY CAST(Fecha AS DATE)
            ORDER BY FechaDia";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime fecha = reader.GetDateTime(0);
                            decimal total = reader.GetDecimal(1);
                            series.Points.AddXY(fecha, total);
                        }
                    }
                }
                ChartVentas.Series.Add(series);
                ChartVentas.Titles.Clear();
                ChartVentas.Titles.Add("Ventas de los últimos 7 días");
                ChartVentas.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del gráfico: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres cerrar la sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Sesion.UsuarioId = 0;
                Sesion.NombreUsuario = null;
                Login loginForm = new Login();
                loginForm.Show();
                this.Close();
            }
        }
        //----------------------------------------------------------------
    }
}

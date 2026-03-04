//Librerias-----------------------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;
namespace ZexpressV1
//----------------------------------------------------------------------------------------------------------------------------------------------------------
{

    public partial class Login: KryptonForm
    {
        //Conexión a la base de datos--------------------------------------------------------------------------------------------------------------------------
        private string connectionString = @"Server=.\SQLEXPRESS;Database=Zexpress;Integrated Security=True;Column Encryption Setting=Enabled;";
        //-----------------------------------------------------------------------------------------------------------------------------------------------------
        public Login()
        {
            InitializeComponent();
            //Quitar bordes de la ventana-----------------------------------------------------------------------------------------------------------------------
            this.StateCommon.Border.Width = 0;
            //--------------------------------------------------------------------------------------------------------------------------------------------------

            //Evento para mover la ventana con el mouse---------------------------------------------------------------------------------------------------------
            this.MouseDown += MainForm_MouseDown;
            //--------------------------------------------------------------------------------------------------------------------------------------------------
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text;
            string contraseña = txtPass.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, ingresa usuario y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = @"SELECT Id, Usuario FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = usuario;
                    command.Parameters.Add("@Contraseña", SqlDbType.NVarChar, 100).Value = contraseña;


                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                Sesion.UsuarioId = reader.GetInt32(0);
                                Sesion.NombreUsuario = reader.GetString(1);
                                MessageBox.Show($"Bienvenido {Sesion.NombreUsuario}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Principal principal = new Principal();
                                principal.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos.", "Error",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al conectar con la base de datos: " + ex.Message,
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Mover la ventana con el mouse----------------------------------------------------------------------------------------------------------------------
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------

        //Funciones para mover la ventana con el mouse-------------------------------------------------------------------------------------------------------
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        //--------------------------------------------------------------------------------------------------------------------------------------------------

        //Cerrar la aplicación------------------------------------------------------------------------------------------------------------------------------
        private void btnCerrrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "¿Estás seguro de que quieres cerrar la aplicación?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------


    }
    public static class Sesion
    {
        public static int UsuarioId { get; set; }
        public static string NombreUsuario { get; set; }
    }
}

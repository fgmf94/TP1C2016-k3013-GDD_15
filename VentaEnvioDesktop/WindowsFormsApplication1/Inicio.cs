using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

using MercadoEnvio.Utils;

namespace WindowsFormsApplication1
{
    public partial class Inicio : Form
    {

        private string username, password;
        Elegir_Rol.EleccionRol eleccion;

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
           // CompletadorDeTablas.hacerQuery("select top 6 * from gd_esquema.Maestra", ref dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
         
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }  

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            username = txtNombre.Text;
        }
            

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = txtPass.Text;
        }

        private void BotonLogin_Click(object sender, EventArgs e)
        {

            string quey = "SELECT C_PASSWORD FROM GDD_15.USUARIOS WHERE C_USUARIO_WEB = 'admin'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(quey);
            String passwordSistema = dt.Rows[0][0].ToString();
            MessageBox.Show(passwordSistema);
            MessageBox.Show(getSha256(password));
            if (getSha256(password) == passwordSistema) MessageBox.Show("Funcionó");

            /*if (username == null || password == null)
            {
                MessageBox.Show("Debe ingresar su nombre de usuario y contraseña");
            }
            else
            {
                try
                {

                    if (username == "fede" && password == "1234")
                    {
                        /*Sesion.iniciar(username, getSha256(password), "Administrador General");
                        Redireccionador redirec = new Redireccionador();
                        redirec.setFunciones(Sesion.getFuncionalidadesDisponibles);
                        redirec.Show();
                        this.Hide(); * /
                        eleccion = new Elegir_Rol.EleccionRol();
                        eleccion.Show();
                    }
                    else{
                        MessageBox.Show("Nombre de usuario o contraseña incorrecta");
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message); //para los errores de la base de datos (la sesion la deberiamos iniciar con un stored procedure)
                }

            }*/
        }
            public String getSha256(String input)
            {
            SHA256Managed encriptador = new SHA256Managed();
            byte[] inputEnBytes = Encoding.UTF8.GetBytes(input);
            byte[] inputHashBytes = encriptador.ComputeHash(inputEnBytes);
            return BitConverter.ToString(inputHashBytes).Replace("-", String.Empty).ToLower();
            }

        }
}


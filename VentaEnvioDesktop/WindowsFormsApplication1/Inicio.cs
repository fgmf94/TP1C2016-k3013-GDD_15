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
        Elegir_Funcionalidad.EleccionFuncionalidad funcionalidades;

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

            if (username == null || password == null)
            {
                MessageBox.Show("Debe ingresar su nombre de usuario y contraseña");
            }
            else
            {
                string query = "SELECT C_PASSWORD FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + username + "'";
                DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
                String passwordSistema = dt.Rows[0][0].ToString();
                try
                {
                    if (getSha256(password) == passwordSistema)
                    {
                        /*Sesion.iniciar(username, getSha256(password), "Administrador General");
                        Redireccionador redirec = new Redireccionador();
                        redirec.setFunciones(Sesion.getFuncionalidadesDisponibles);
                        redirec.Show();
                        this.Hide(); */
                        string query2 = "SELECT COUNT(*) FROM GDD_15.ROLES_USUARIOS ROLES JOIN GDD_15.USUARIOS USUARIOS ON (USUARIOS.N_ID_USUARIO = ROLES.N_ID_USUARIO) WHERE USUARIOS.C_USUARIO_NOMBRE = '" + username + "' AND ROLES.F_BAJA IS NULL";
                        DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
                        string cantidadRoles = dt2.Rows[0][0].ToString();
                        if (cantidadRoles == "1"){ 
                            funcionalidades = new Elegir_Funcionalidad.EleccionFuncionalidad();
                            funcionalidades.Show();
                        } else {
                            eleccion = new Elegir_Rol.EleccionRol(username);
                            eleccion.Show();
                        }
                    }
                    else{
                        MessageBox.Show("Nombre de usuario o contraseña incorrecta");
                        //debería sumarse un intento fallido...
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message); //para los errores de la base de datos (la sesion la deberiamos iniciar con un stored procedure)
                }

            }
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


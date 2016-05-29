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
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Nombre de usuario incorrecto");
                } else {

                    String passwordSistema = dt.Rows[0][0].ToString();            
                    if (getSha256(password) == passwordSistema)
                    {
                        string query2 = "SELECT COUNT(*) FROM GDD_15.ROLES_USUARIOS ROLES JOIN GDD_15.USUARIOS USUARIOS ON (USUARIOS.N_ID_USUARIO = ROLES.N_ID_USUARIO) WHERE USUARIOS.C_USUARIO_NOMBRE = '" + username + "' AND ROLES.F_BAJA IS NULL";
                        DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
                        string cantidadRoles = dt2.Rows[0][0].ToString();
                        if (cantidadRoles == "1"){
                            DataTable dt3 = (new ConexionSQL()).cargarTablaSQL("SELECT R.C_ROL FROM GDD_15.ROLES_USUARIOS RU JOIN GDD_15.USUARIOS U ON (U.N_ID_USUARIO = RU.N_ID_USUARIO) JOIN GDD_15.ROLES R ON (R.N_ID_ROL = RU.N_ID_ROL) WHERE U.C_USUARIO_NOMBRE = '" + username + "' AND R.F_BAJA IS NULL AND RU.F_BAJA IS NULL ");
                            string rol = dt3.Rows[0][0].ToString();
                            funcionalidades = new Elegir_Funcionalidad.EleccionFuncionalidad(rol,username);
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


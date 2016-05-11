using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MercadoEnvio.Utils;

namespace WindowsFormsApplication1
{
    public partial class Inicio : Form
    {

        private string username, password;

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
                try
                {
                    if (username == "fede" || password == "1234")
                        /*Sesion.iniciar(username, getSha256(password), "Administrador General");
                        Redireccionador redirec = new Redireccionador();
                        redirec.setFunciones(Sesion.getFuncionalidadesDisponibles);
                        redirec.Show();
                        this.Hide();*/
                        MessageBox.Show("Iniciaste sesion");
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }

            }
        }
    }
}

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
using MercadoEnvio.Dominio;

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class CrearUsuario : Form
    {
        ABM_Usuario.CrearCliente crearCliente;
        ABM_Usuario.CrearEmpresa crearEmpresa;

        public CrearUsuario()
        {
            InitializeComponent();
            
        }

        private void comboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!validaciones())
            {
                return;
            }

            Usuario usuario = new Usuario(txtNombreUsuario.Text, txtPass1.Text, comboBoxRoles.Text);

            if (comboBoxRoles.Text == "Cliente")
            {
                crearCliente = new ABM_Usuario.CrearCliente(usuario,this);
                crearCliente.Show();
            }
            else if (comboBoxRoles.Text == "Empresa")
            {
                crearEmpresa = new ABM_Usuario.CrearEmpresa(usuario,this);
                crearEmpresa.Show();
            }

        }

        private bool validaciones()
        {
            if (txtNombreUsuario.Text == "" || txtPass1.Text == "" || txtPass2.Text == "" || comboBoxRoles.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPass1.Text != txtPass2.Text)
            {
                MessageBox.Show("Las contraseñas ingresadas son distintas", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string comando = "SELECT * FROM  GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + txtNombreUsuario.Text + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);
            if (dt.Rows.Count != 0)
            {
                MessageBox.Show("El nombre de usuario ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}

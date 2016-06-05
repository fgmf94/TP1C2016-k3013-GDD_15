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
using MercadoEnvio.Dominio;

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class ModificarContraseña : Form
    {
        String nombre;
        ABM_Usuario.ElegirModificar form1;
        Form form2;
        public ModificarContraseña(String usuarioPasado, ABM_Usuario.ElegirModificar formPasado, Form formPasado2)
        {
            InitializeComponent();

            txtNombreUsuario.Text = usuarioPasado;
            nombre = usuarioPasado;
            form1 = formPasado;
            form2 = formPasado2;
        }

        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (!validaciones())
            {
                return;
            }

            if ((MessageBox.Show("¿Realmente desea modificar la contraseña?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                string query = "UPDATE GDD_15.USUARIOS SET C_PASSWORD = '" + getSha256(txtPass1.Text) + "' WHERE C_USUARIO_NOMBRE = '" + nombre + "'";
                (new ConexionSQL()).ejecutarComandoSQL(query);
                MessageBox.Show("Contraseña modificada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
                form1.Close();
                form2.Close();
            }
        }

        public String getSha256(String input)
        {
            SHA256Managed encriptador = new SHA256Managed();
            byte[] inputEnBytes = Encoding.UTF8.GetBytes(input);
            byte[] inputHashBytes = encriptador.ComputeHash(inputEnBytes);
            return BitConverter.ToString(inputHashBytes).Replace("-", String.Empty).ToLower();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validaciones()
        {
            if (txtNombreUsuario.Text == "" || txtPass1.Text == "" || txtPass2.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPass1.Text != txtPass2.Text)
            {
                MessageBox.Show("Las contraseñas ingresadas son distintas", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtNombreUsuario.Text != nombre)
            {
                string comando = "SELECT * FROM  GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + txtNombreUsuario.Text + "'";
                DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("El nombre de usuario ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }
    }
}

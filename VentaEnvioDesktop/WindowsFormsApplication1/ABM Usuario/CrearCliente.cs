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
    public partial class CrearCliente : Form
    {
        ABM_Usuario.CrearUsuario form;
        Usuario usuario;

        public CrearCliente(Usuario usuarioPasado, ABM_Usuario.CrearUsuario formPasada)
        {
            InitializeComponent();
            form = formPasada;
            usuario = usuarioPasado;
        }

        private void CrearCliente_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("¿Realmente desea cancelar la creación del Usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                form.Close();
                this.Close();
            }
            
        }

        private void buttonAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!validaciones())
            {
                return;
            }
        }

        private bool validaciones()
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtCalle.Text == "" || comboBoxTipoDoc.Text == "" || txtNumDoc.Text == "" || txtMail.Text == "" || txtTel.Text == "" || txtCalle.Text == "" || txtNumeroCalle.Text == "" || txtCodPost.Text == "" || dateFechaNac.Value.ToString() == "")
            {
                MessageBox.Show("Debe completar todos los campos obligatorios", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPiso.Text == "" ^ txtDepto.Text == "")
            {
                MessageBox.Show("Debe completar el campo Piso y Departamento si hay alguno completado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPiso.Text == "" && txtDepto.Text == ""){
                usuario.piso = "-1";
                usuario.depto = "-1";
            }

            if (txtNumDoc.TextLength > 100)
            {
                MessageBox.Show("El número de documento no debe superar los 100 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int numDoc;

            try
            {
                numDoc = Convert.ToInt32(txtNumDoc.Text);
            }
            catch
            {
                MessageBox.Show("El número de documento debe ser un entero menor a 1000000000", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numDoc < 1){
                MessageBox.Show("El número de documento debe ser mayor o igual a 1", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Int64 numTel;
            try
            {
                numTel = Convert.ToInt64(txtTel.Text);
            }
            catch
            {
                MessageBox.Show("El número de téléfono debe ser un entero menor a 100000000000000", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numDoc < 1)
            {
                MessageBox.Show("El número de teléfono debe ser mayor o igual a 1", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}

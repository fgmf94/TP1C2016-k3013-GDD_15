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

        public CrearCliente(Usuario usuario, ABM_Usuario.CrearUsuario formPasada)
        {
            InitializeComponent();
            form = formPasada;
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
    }
}

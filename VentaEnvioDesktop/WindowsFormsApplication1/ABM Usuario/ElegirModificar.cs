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

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class ElegirModificar : Form
    {
        String username;
        Form form;
        String rol;

        public ElegirModificar(String usuarioPasado, Form formPasada, String rolPasado)
        {
            InitializeComponent();
            username = usuarioPasado;
            form = formPasada;
            rol = rolPasado;
        }

        private void ElegirModificar_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            ABM_Usuario.ModificarContraseña modifContra = new ABM_Usuario.ModificarContraseña(username,this,form);
            modifContra.Show();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (rol == "Cliente" || rol == "Empresa")
            {
                if (rol == "Cliente")
                {
                    ABM_Usuario.ModificarDatosCliente modifCliente = new ABM_Usuario.ModificarDatosCliente(username);
                    modifCliente.Show();
                }
                else if (rol == "Empresa")
                {
                    ABM_Usuario.ModificarDatosEmpresa modifEmpresa = new ABM_Usuario.ModificarDatosEmpresa(username);
                    modifEmpresa.Show();
                }
            }
            else
            {
                MessageBox.Show("Sólo se pueden modificar los datos de Clientes y Empresas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}

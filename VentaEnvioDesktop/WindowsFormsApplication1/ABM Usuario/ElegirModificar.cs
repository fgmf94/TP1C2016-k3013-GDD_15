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

            if (rolPasado != "Administrativo")
            {
                buttonHabilitar.Hide();
            }
        }

        private void ElegirModificar_Load(object sender, EventArgs e)
        {

        }

        private void buttonModificar_Click_1(object sender, EventArgs e)
        {
            ABM_Usuario.ModificarContraseña modifContra = new ABM_Usuario.ModificarContraseña(username, this, form);
            modifContra.Show();
        }

        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            if (rol == "Cliente" || rol == "Empresa")
            {
                if (rol == "Cliente")
                {
                    ABM_Usuario.ModificarDatosCliente modifCliente = new ABM_Usuario.ModificarDatosCliente(username,this,form);
                    modifCliente.Show();
                }
                else if (rol == "Empresa")
                {
                    ABM_Usuario.ModificarDatosEmpresa modifEmpresa = new ABM_Usuario.ModificarDatosEmpresa(username,this,form);
                    modifEmpresa.Show();
                }
            }
            else
            {
                MessageBox.Show("Sólo Clientes y Empresas pueden modificar sus propios datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query2 = "SELECT COUNT(*) FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + username + "' AND F_BAJA IS NULL";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string habilitado = dt2.Rows[0][0].ToString();
            if (habilitado == "1")
            {
                MessageBox.Show("El usuario ya está habilitado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if ((MessageBox.Show("¿Realmente desea habilitar al usuario "+ username +"?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    //Modificar Usuario habilitar (to do)
                    MessageBox.Show("Usuario habilitado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    form.Close();
                }
                else
                {
                    return;
                }
            }
        }
    }
}

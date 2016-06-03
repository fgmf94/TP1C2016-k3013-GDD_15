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
    public partial class ElegirUsuario : Form
    {
        ABM_Usuario.FiltroCliente filtroCliente;
        ABM_Usuario.FiltroEmpresa filtroEmpresa;
        ABM_Usuario.ElegirModificar modifElegir;
        String formato;

        public ElegirUsuario(String formatoPasado, String usuarioPasado)
        {
            InitializeComponent();
            label1.Text = formatoPasado;
            buttonGuardar.Text = formatoPasado;
            formato = formatoPasado;
            txtNombreUsuario.Text = usuarioPasado;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text == "")
            {
                MessageBox.Show("Ingrese un nombre de usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string comando = "SELECT * FROM  GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + txtNombreUsuario.Text + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("El nombre de usuario no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (formato == "Modificar Usuario")
            {
                modifElegir = new ABM_Usuario.ElegirModificar(txtNombreUsuario.Text,this,"Administrativo");
                modifElegir.Show();
            }
            else if (formato == "Eliminar Usuario")
            {
                if ((MessageBox.Show("¿Realmente desea dar de baja el usuario " + txtNombreUsuario.Text + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    //dar de baja usuario (to do)
                    MessageBox.Show("Usuario " + txtNombreUsuario.Text + " eliminado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
                else
                {
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            filtroCliente = new ABM_Usuario.FiltroCliente();
            filtroCliente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            filtroEmpresa = new ABM_Usuario.FiltroEmpresa();
            filtroEmpresa.Show();
        }
    }
}

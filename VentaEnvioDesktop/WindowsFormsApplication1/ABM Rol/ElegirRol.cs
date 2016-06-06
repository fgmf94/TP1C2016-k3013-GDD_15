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

namespace WindowsFormsApplication1.ABM_Rol
{
    public partial class ElegirRol : Form
    {
        String elegirFormato;
        ABM_Rol.ModificarRol modificarRol;

        public ElegirRol(String formato)
        {
            elegirFormato = formato;
            InitializeComponent();
            label1.Text = formato;
            buttonGuardar.Text = formato;

            if (elegirFormato == "Eliminar Rol")
            {
                string query = "SELECT C_ROL FROM GDD_15.ROLES WHERE N_HABILITADO = 1";
                DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
                comboBoxRol.DataSource = dt.DefaultView;
                comboBoxRol.ValueMember = "C_ROL";
            }
            else if (elegirFormato == "Modificar Rol")
            {
                string query = "SELECT C_ROL FROM GDD_15.ROLES";
                DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
                comboBoxRol.DataSource = dt.DefaultView;
                comboBoxRol.ValueMember = "C_ROL";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (elegirFormato == "Eliminar Rol")
            {
                if ((MessageBox.Show("¿Realmente desea dar de baja el rol " + comboBoxRol.Text + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string query = "UPDATE GDD_15.ROLES SET N_HABILITADO = 0 WHERE C_ROL = '" + comboBoxRol.Text + "'";
                    DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
                    MessageBox.Show("Rol " + comboBoxRol.Text + " eliminado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
                else
                {
                    return;
                }
            } 
            else if (elegirFormato == "Modificar Rol")
            {
                modificarRol = new ABM_Rol.ModificarRol(comboBoxRol.Text,this);
                modificarRol.Show();
            }
        }

        private void btFiltro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No implementado por ahora", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

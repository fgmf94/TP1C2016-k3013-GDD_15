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

namespace WindowsFormsApplication1.ABM_Visibilidad
{
    public partial class ElegirVisibilidad : Form
    {
        String formato;
        ABM_Visibilidad.ModificarVisibilidad modificarVisi;

        public ElegirVisibilidad(String formatoPasado)
        {
            formato = formatoPasado;
            InitializeComponent();
            label1.Text = formato;
            buttonGuardar.Text = formato;

            if (formato == "Eliminar Visibilidad")
            {
                string query = "SELECT D_DESCRIP FROM GDD_15.VISIBILIDADES WHERE F_BAJA IS NULL";
                DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
                comboBoxVisi.DataSource = dt.DefaultView;
                comboBoxVisi.ValueMember = "D_DESCRIP";
            } 
            else if (formato == "Modificar Visibilidad")
            {
                string query = "SELECT D_DESCRIP FROM GDD_15.VISIBILIDADES";
                DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
                comboBoxVisi.DataSource = dt.DefaultView;
                comboBoxVisi.ValueMember = "D_DESCRIP";
            }
        }

        private void ElegirVisibilidad_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (formato == "Eliminar Visibilidad")
            {
                if ((MessageBox.Show("¿Realmente desea dar de baja la Visibilidad " + comboBoxVisi.Text + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    //dar de baja visibilidad (to do)
                    //ver que no haya ninguna publicacion que la este usando, si es que hay tirar error
                    MessageBox.Show("Visibilidad " + comboBoxVisi.Text + " eliminada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else if (formato == "Modificar Visibilidad")
            {
                modificarVisi = new ABM_Visibilidad.ModificarVisibilidad(comboBoxVisi.Text, this);
                modificarVisi.Show();
            }
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

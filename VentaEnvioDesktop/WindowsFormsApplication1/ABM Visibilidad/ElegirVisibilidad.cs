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
                string query = "SELECT D_DESCRIP FROM GDD_15.VISIBILIDADES WHERE N_HABILITADO = 1";
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
                string query4 = "SELECT C_VISIBILIDAD FROM GDD_15.VISIBILIDADES WHERE D_DESCRIP = '" + comboBoxVisi.Text + "'";
                DataTable dt4 = (new ConexionSQL()).cargarTablaSQL(query4);
                string visiID = dt4.Rows[0][0].ToString();

                string query = "SELECT COUNT(N_ID_PUBLICACION) FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (E.N_ID_ESTADO = P.N_ID_ESTADO) WHERE C_VISIBILIDAD = '" + visiID + "' AND C_ESTADO IN ('Activa', 'Pausada')";
                DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
                string cant = dt.Rows[0][0].ToString();

                if (Convert.ToInt16(cant) != 0)
                {
                    MessageBox.Show("No se puede eliminar una visibilidad utilizada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if ((MessageBox.Show("¿Realmente desea dar de baja la Visibilidad " + comboBoxVisi.Text + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string agregarUsuario = "UPDATE GDD_15.VISIBILIDADES SET N_HABILITADO = 0 WHERE D_DESCRIP = '" + comboBoxVisi.Text + "'";
                    (new ConexionSQL()).ejecutarComandoSQL(agregarUsuario);
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
                modificarVisi.ShowDialog();
            }
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

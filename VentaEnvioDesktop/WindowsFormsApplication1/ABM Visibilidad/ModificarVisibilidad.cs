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
    public partial class ModificarVisibilidad : Form
    {
        String visibilidadPasada;
        ABM_Visibilidad.ElegirVisibilidad formPasado;

        public ModificarVisibilidad(String visibilidad, ABM_Visibilidad.ElegirVisibilidad form)
        {
            InitializeComponent();

            visibilidadPasada = visibilidad;  
            formPasado = form;

            txtNombreVisibilidad.Text = visibilidad;

            string query2 = "SELECT COUNT(*) FROM GDD_15.VISIBILIDADES WHERE D_DESCRIP = '" + visibilidadPasada + "' AND F_BAJA IS NULL";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string habilitado = dt2.Rows[0][0].ToString();
            if (habilitado == "1")
            {
                chkHabilitado.Checked = true;
            }
            else
            {
                chkHabilitado.Checked = false;
            }

            string query = "SELECT N_COMISION_PRECIO, N_COMISION_PORCENTAJE, N_COMISION_ENVIO FROM GDD_15.VISIBILIDADES WHERE D_DESCRIP = '" + visibilidadPasada + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string cPrecio = dt.Rows[0][0].ToString();
            txtCPrecio.Text = cPrecio;
            string cPorcentaje = dt.Rows[0][1].ToString();
            txtCPorcentaje.Text = cPorcentaje;
            string cEnvio = dt.Rows[0][2].ToString();
            txtCEnvio.Text = cEnvio;
        }

        private void ModificarVisibilidad_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("¿Realmente desea modificar la Visibilidad " + visibilidadPasada + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                modificarVisibilidad(visibilidadPasada);
                MessageBox.Show("Rol " + visibilidadPasada + " modificado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
                formPasado.Close();
            }
        }

        private void modificarVisibilidad(String visibilidad)
        {
            //hay que modificar la visibilidad (to do)
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

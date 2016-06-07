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

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class CrearPublicacion : Form
    {
        String formato;
        public CrearPublicacion(String formatoPasado, String nombreUsuarioPasado)
        {
            InitializeComponent();
            formato = formatoPasado;

            if (formatoPasado == "Subasta")
            {
                labelTitulo.Text = "Crear Publicación de Subasta";
                labelPrecio.Text = "Precio Inicial";
                txtStock.ReadOnly = true;
                txtStock.Text = "1";
            }

            string query = "SELECT concat(D_DESCRIP, ' $', N_COMISION_PRECIO) AS VISI FROM GDD_15.VISIBILIDADES";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            comboBoxVisi.DataSource = dt.DefaultView;
            comboBoxVisi.ValueMember = "VISI";

            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL("SELECT D_DESCRED FROM GDD_15.RUBROS");
            comboBoxRubro.DataSource = dt2.DefaultView;
            comboBoxRubro.ValueMember = "D_DESCRED";

        }

        private void CrearCompra_Load(object sender, EventArgs e)
        {

        }

        private void txtNombreVisibilidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //generar un borrador
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            //guardar la publicación
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {

        }
    }
}

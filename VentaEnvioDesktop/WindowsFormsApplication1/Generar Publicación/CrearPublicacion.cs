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

            string query = "SELECT concat(D_DESCRIP, ' $', N_COMISION_PRECIO) AS VISI FROM GDD_15.VISIBILIDADES WHERE N_HABILITADO = 1";
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
            //Generar Publicación

            if (!validaciones())
            {
                return;
            }
        }

        private bool validaciones()
        {
            if (txtDescrip.Text == "" || txtPrecio.Text == "" || txtStock.Text == "" || dateFechaVen.Value.ToString() == "")
            {
                MessageBox.Show("Debe completar todos los campos obligatorios", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtDescrip.Text.Length >= 100)
            {
                MessageBox.Show("La descripción debe tener menos de 100 caracteres", "Error Descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Int32 stock;

            try
            {
                stock = Convert.ToInt32(txtStock.Text);
            }
            catch
            {
                MessageBox.Show("El número de stock debe ser un entero menor a 2147483647", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (stock < 1)
            {
                MessageBox.Show("El número de documento debe ser mayor o igual a 1", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            float precio = (new Validaciones()).validacionStringAFloat(txtPrecio.Text, "Error Precio");

            if (precio == -1)
            {
                return false;
            }

            return true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Generar Borrador

            if (!validaciones())
            {
                return;
            }
        }
    }
}

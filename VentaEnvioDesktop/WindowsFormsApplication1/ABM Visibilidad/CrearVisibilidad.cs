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
    public partial class CrearVisibilidad : Form
    {
        float cPrecio, cPorcentaje, cEnvio;

        public CrearVisibilidad()
        {
            InitializeComponent();
            txtNombreVisibilidad.Text = "";
            txtCPrecio.Text = "";
            txtCPorcentaje.Text = "";
            txtCEnvio.Text = "";
        }

        private bool validaciones(){

            if(txtNombreVisibilidad.Text == "" || txtCPrecio.Text == "" || txtCPorcentaje.Text == "" || txtCEnvio.Text == ""){
                MessageBox.Show("Debe completar todos los campos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtNombreVisibilidad.Text.Length >= 50)
            {
                MessageBox.Show("El nombre de visibilidad debe tener menos de 50 caracteres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string comando = "SELECT * FROM  GDD_15.VISIBILIDADES WHERE D_DESCRIP = '" + txtNombreVisibilidad.Text + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][5].ToString() == "0")
                {
                    MessageBox.Show("Existe una visibilidad deshabilitada con ese nombre", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    MessageBox.Show("El nombre de visibilidad ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            cPrecio = (new Validaciones()).validacionStringAFloat(txtCPrecio.Text, "Error Precio");

            if (cPrecio == -1){
                return false;   
            }

            cPorcentaje = (new Validaciones()).validacionStringAFloat(txtCPorcentaje.Text, "Error Porcentaje");
            if (cPorcentaje == -1)
            {
                return false;
            }
            else if (cPorcentaje >= 1)
            {
                MessageBox.Show("Solo se admiten números entre 0 y 1", "Error Porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            cEnvio = (new Validaciones()).validacionStringAFloat(txtCEnvio.Text, "Error Envío");
            if (cEnvio == -1)
            {
                return false;
            }

            if ((txtNombreVisibilidad.Text).ToLower() == "todas")
            {
                MessageBox.Show("No se puede crear una visibilidad con ese nombre", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void txtNombreVisibilidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void CrearVisibilidad_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            if (validaciones())
            {
                string scPorcentaje = aStringSinComa(cPorcentaje);
                string scPrecio = aStringSinComa(cPrecio);
                string scEnvio = aStringSinComa(cEnvio);

                string agregarVisibilidad = "INSERT INTO GDD_15.VISIBILIDADES(D_DESCRIP,N_COMISION_PRECIO,N_COMISION_PORCENTAJE,N_COMISION_ENVIO) SELECT '" + txtNombreVisibilidad.Text + "', " + scPrecio + ", " + scPorcentaje + ", " + scEnvio;
                (new ConexionSQL()).ejecutarComandoSQL(agregarVisibilidad);

                MessageBox.Show("Visibilidad agregada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
        }

        private string aStringSinComa(float numero)
        {
            string stringNumero = numero.ToString().Replace(',', '.');
            return stringNumero;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

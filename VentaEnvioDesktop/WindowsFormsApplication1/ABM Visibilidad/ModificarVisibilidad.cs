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
        float cPrecio, cPorcentaje, cEnvio;
        Boolean estadoAnterior;

        public ModificarVisibilidad(String visibilidad, ABM_Visibilidad.ElegirVisibilidad form)
        {
            InitializeComponent();

            visibilidadPasada = visibilidad;  
            formPasado = form;

            txtNombreVisibilidad.Text = visibilidad;

            string query2 = "SELECT COUNT(*) FROM GDD_15.VISIBILIDADES WHERE D_DESCRIP = '" + visibilidadPasada + "' AND N_HABILITADO = 1";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string habilitado = dt2.Rows[0][0].ToString();
            if (habilitado == "1")
            {
               estadoAnterior = chkHabilitado.Checked = true;
            }
            else
            {
               estadoAnterior = chkHabilitado.Checked = false;
            }

            string query = "SELECT N_COMISION_PRECIO, N_COMISION_PORCENTAJE, N_COMISION_ENVIO FROM GDD_15.VISIBILIDADES WHERE D_DESCRIP = '" + visibilidadPasada + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string cPrecio = dt.Rows[0][0].ToString().Replace(',', '.');
            txtCPrecio.Text = cPrecio;
            string cPorcentaje = dt.Rows[0][1].ToString().Replace(',', '.');
            txtCPorcentaje.Text = cPorcentaje;
            string cEnvio = dt.Rows[0][2].ToString().Replace(',', '.');
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
            if (validaciones())
            {
                if ((MessageBox.Show("¿Realmente desea modificar la Visibilidad " + visibilidadPasada + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    modificarVisibilidad(visibilidadPasada);
                    MessageBox.Show("Rol " + visibilidadPasada + " modificado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    formPasado.Close();
                }
            }
        }

        private void modificarVisibilidad(String visibilidad)
        {
            string scPorcentaje = aStringSinComa(cPorcentaje);
            string scPrecio = aStringSinComa(cPrecio);
            string scEnvio = aStringSinComa(cEnvio);

            string agregarVisibilidad = "UPDATE GDD_15.VISIBILIDADES SET D_DESCRIP = '" + txtNombreVisibilidad.Text + "', N_COMISION_PRECIO = '" + scPrecio + "', N_COMISION_PORCENTAJE = '" + scPorcentaje + "', N_COMISION_ENVIO = '" + scEnvio + "' WHERE D_DESCRIP = '" + visibilidad + "'";
            (new ConexionSQL()).ejecutarComandoSQL(agregarVisibilidad);

            if (estadoAnterior == true && chkHabilitado.Checked == true)
            {

            }
            else if (estadoAnterior == true && chkHabilitado.Checked == false)
            {
                string comando3 = "UPDATE GDD_15.VISIBILIDADES SET N_HABILITADO = 0 WHERE D_DESCRIP = '" + visibilidad + "'";
                (new ConexionSQL()).ejecutarComandoSQL(comando3);
            }
            else if (estadoAnterior == false && chkHabilitado.Checked == true)
            {
                string comando4 = "UPDATE GDD_15.VISIBILIDADES SET N_HABILITADO = 1 WHERE D_DESCRIP = '" + visibilidad + "'";
                (new ConexionSQL()).ejecutarComandoSQL(comando4);
            }
            else
            {

            }
        }

        private string aStringSinComa(float numero)
        {
            string stringNumero = numero.ToString().Replace(',', '.');
            return stringNumero;
        }

        private bool validaciones(){

            if(txtNombreVisibilidad.Text == "" || txtCPrecio.Text == "" || txtCPorcentaje.Text == "" || txtCEnvio.Text == ""){
                MessageBox.Show("Debe completar todos los campos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtNombreVisibilidad.Text != visibilidadPasada)
            {
                string comando = "SELECT * FROM  GDD_15.VISIBILIDADES WHERE D_DESCRIP = '" + txtNombreVisibilidad.Text + "'";
                DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);
                if (dt.Rows.Count != 0)
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

            return true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

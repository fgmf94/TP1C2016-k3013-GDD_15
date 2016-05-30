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
        public CrearVisibilidad()
        {
            InitializeComponent();
        }

        private bool validaciones(){
            float a = 0;

            a = (new Validaciones()).validacionStringAFloat(txtCPrecio.Text, "Error Precio");

            if (a==-1){
                return false;   
            }

            a = (new Validaciones()).validacionStringAFloat(txtCPorcentaje.Text, "Error Porcentaje");
            if (a == -1)
            {
                return false;
            } else if (a > 100){
                MessageBox.Show("Solo se admiten números entre 0 y 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            a = (new Validaciones()).validacionStringAFloat(txtCEnvio.Text, "Error Envío");
            if (a == -1)
            {
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
            if (!validaciones())
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

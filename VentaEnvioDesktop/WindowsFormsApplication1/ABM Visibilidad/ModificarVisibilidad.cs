using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            txtNombreVisibilidad.Text = visibilidad;
            formPasado = form;

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

        }

    }
}

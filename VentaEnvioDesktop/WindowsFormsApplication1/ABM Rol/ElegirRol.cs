using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Rol
{
    public partial class ElegirRol : Form
    {
        String elegirFormato;

        public ElegirRol(String formato)
        {
            elegirFormato = formato;
            InitializeComponent();
            label1.Text = formato;
            buttonGuardar.Text = formato;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (elegirFormato == "Eliminar Rol")
            {
                MessageBox.Show("Eliminar Rol");
            } 
            else if (elegirFormato == "Modificar Rol")
            {
                MessageBox.Show("Modificar Rol");
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
    }
}

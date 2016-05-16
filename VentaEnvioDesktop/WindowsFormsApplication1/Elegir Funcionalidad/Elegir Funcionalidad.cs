using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Elegir_Funcionalidad
{
    public partial class EleccionFuncionalidad : Form
    {
        int funcionalidadNumero = -1;

        public EleccionFuncionalidad()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            funcionalidadNumero = funcionalidadCombo.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (funcionalidadNumero == -1){
                MessageBox.Show("Elija funcionalidad");
            } else {
                switch (funcionalidadNumero)
                {
                    case 0:
                        MessageBox.Show("Funcionalidad en construcción (ABM Rol)");
                        break;
                    default:
                        MessageBox.Show("Funcionalidad no implementada");
                        break;
                }
            }
        }
    }
}

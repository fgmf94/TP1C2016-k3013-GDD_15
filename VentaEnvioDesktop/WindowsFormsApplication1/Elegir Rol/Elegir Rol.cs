using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Elegir_Rol
{
    public partial class EleccionRol : Form
    {
        Elegir_Funcionalidad.EleccionFuncionalidad funcionalidades;

        public EleccionRol()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boton_Click(object sender, EventArgs e)
        {
            funcionalidades = new Elegir_Funcionalidad.EleccionFuncionalidad();
            funcionalidades.Show();
        }
    }
}

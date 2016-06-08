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
    public partial class ABMRol : Form
    {
        ABM_Rol.CrearRol crearRol;
        ABM_Rol.ElegirRol elegirRol;

        public ABMRol()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            crearRol = new ABM_Rol.CrearRol();
            crearRol.ShowDialog();
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            elegirRol = new ABM_Rol.ElegirRol("Modificar Rol");
            elegirRol.ShowDialog();
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            //Ver si hay roles para eliminar
            elegirRol = new ABM_Rol.ElegirRol("Eliminar Rol");
            elegirRol.ShowDialog();
        }
    }
}

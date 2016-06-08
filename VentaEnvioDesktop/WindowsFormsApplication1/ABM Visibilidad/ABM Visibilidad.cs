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
    public partial class ABMVisibilidad : Form
    {
        ABM_Visibilidad.CrearVisibilidad crearV;
        ABM_Visibilidad.ElegirVisibilidad elegirV;

        public ABMVisibilidad()
        {
            InitializeComponent();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            crearV = new ABM_Visibilidad.CrearVisibilidad();
            crearV.ShowDialog();
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            elegirV = new ABM_Visibilidad.ElegirVisibilidad("Modificar Visibilidad");
            elegirV.ShowDialog();
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            //ver si hay visibilidades para eliminar (to do)
            elegirV = new ABM_Visibilidad.ElegirVisibilidad("Eliminar Visibilidad");
            elegirV.ShowDialog();
        }

        private void ABMVisibilidad_Load(object sender, EventArgs e)
        {

        }
    }
}

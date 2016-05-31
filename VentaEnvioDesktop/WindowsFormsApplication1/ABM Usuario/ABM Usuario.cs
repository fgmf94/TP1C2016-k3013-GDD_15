using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class ABMUsuario : Form
    {
        ABM_Usuario.CrearUsuario crearUsuario;
        ABM_Usuario.ElegirUsuario elegirUsuario;

        public ABMUsuario()
        {
            InitializeComponent();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            crearUsuario = new ABM_Usuario.CrearUsuario();
            crearUsuario.Show();
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            elegirUsuario = new ABM_Usuario.ElegirUsuario("Eliminar Usuario");
            elegirUsuario.Show();
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            elegirUsuario = new ABM_Usuario.ElegirUsuario("Modificar Usuario");
            elegirUsuario.Show();
        }
    }
}

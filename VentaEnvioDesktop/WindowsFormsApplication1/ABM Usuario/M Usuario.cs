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
    public partial class Modificar_Usuario : Form
    {
        String usuario;
        String rol;

        public Modificar_Usuario(String rolPasado, String usuarioPasado)
        {
            InitializeComponent();
            labelUsuario.Text = "Modificar " + rolPasado;
            buttonModificar.Text = "Modificar " + rolPasado;
            usuario = usuarioPasado;
            rol = rolPasado;
        }

        private void Modificar_Usuario_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            ABM_Usuario.ElegirModificar elegirModif = new ABM_Usuario.ElegirModificar(usuario, this,rol);
            elegirModif.Show();
        }
    }
}

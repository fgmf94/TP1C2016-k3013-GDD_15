using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class ElegirTipo : Form
    {
        String nombreUsuario;
        public ElegirTipo(String nombreUsuarioPasado)
        {
            InitializeComponent();

            nombreUsuario = nombreUsuarioPasado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ComprarOfertar.ListadoPublicaciones listado = new ComprarOfertar.ListadoPublicaciones("Compra Inmediata",nombreUsuario);
            listado.Show();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            ComprarOfertar.ListadoPublicaciones listado = new ComprarOfertar.ListadoPublicaciones("Subasta",nombreUsuario);
            listado.Show();
        }
    }
}

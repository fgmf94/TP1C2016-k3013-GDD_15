using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class ElegirAccion : Form
    {
        String nombreUsuario;

        public ElegirAccion(String nombreUsuarioPasado)
        {
            InitializeComponent();
            nombreUsuario = nombreUsuarioPasado;
        }

        private void ElegirAccion_Load(object sender, EventArgs e)
        {

        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            Generar_Publicación.CrearPublicacion crearCompra = new Generar_Publicación.CrearPublicacion("Compra Inmediata",nombreUsuario);
            crearCompra.Show();
        }

        private void crearSubasta_Click(object sender, EventArgs e)
        {
            Generar_Publicación.CrearPublicacion crearCompra = new Generar_Publicación.CrearPublicacion("Subasta",nombreUsuario);
            crearCompra.Show();
        }

        private void buttonBorradores_Click(object sender, EventArgs e)
        {
            Generar_Publicación.MisBorradores borradores = new Generar_Publicación.MisBorradores(nombreUsuario);
            borradores.Show();
        }

        private void buttonPublicaciones_Click(object sender, EventArgs e)
        {
            Generar_Publicación.MisPublicaciones publis = new Generar_Publicación.MisPublicaciones(nombreUsuario);
            publis.Show();
        }
    }
}

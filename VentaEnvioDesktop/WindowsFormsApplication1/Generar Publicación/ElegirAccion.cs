using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MercadoEnvio.Utils;

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
            Generar_Publicación.CrearPublicacion crearCompra = new Generar_Publicación.CrearPublicacion("Compra Inmediata",nombreUsuario,0);
            crearCompra.ShowDialog();
        }

        private void crearSubasta_Click(object sender, EventArgs e)
        {
            Generar_Publicación.CrearPublicacion crearCompra = new Generar_Publicación.CrearPublicacion("Subasta",nombreUsuario,0);
            crearCompra.ShowDialog();
        }

        private void buttonBorradores_Click(object sender, EventArgs e)
        {
            string query = "SELECT N_ID_PUBLICACION FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) WHERE C_ESTADO IN ('Borrador') AND C_USUARIO_NOMBRE = '" + nombreUsuario + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No tienes borradores", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Generar_Publicación.MisBorradores borradores = new Generar_Publicación.MisBorradores(nombreUsuario);
                borradores.ShowDialog();
            }
        }

        private void buttonPublicaciones_Click(object sender, EventArgs e)
        {
            string query = "SELECT N_ID_PUBLICACION FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) WHERE C_ESTADO IN ('Activa', 'Pausada', 'Finalizada') AND C_USUARIO_NOMBRE = '" + nombreUsuario + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No tienes publicaciones", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Generar_Publicación.MisPublicaciones publis = new Generar_Publicación.MisPublicaciones(nombreUsuario);
                publis.ShowDialog();
            }
        }
    }
}

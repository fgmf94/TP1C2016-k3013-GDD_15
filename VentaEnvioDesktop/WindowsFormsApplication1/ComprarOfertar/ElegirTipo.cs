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
            string query2 = "SELECT COUNT(N_ID_PUBLICACION) FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.TIPOS T ON (P.N_ID_TIPO = T.N_ID_TIPO) JOIN GDD_15.VISIBILIDADES V ON (P.C_VISIBILIDAD = V.C_VISIBILIDAD) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE C_TIPO = 'Compra Inmediata' AND C_ESTADO IN ('Activa', 'Pausada') AND C_USUARIO_NOMBRE != '" + nombreUsuario + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string cantidadPublis = dt2.Rows[0][0].ToString();
            int cantPublis = Convert.ToInt16(cantidadPublis);

            if (cantPublis == 0)
            {
                MessageBox.Show("No hay publicaciones de compra para mostrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ComprarOfertar.ListadoPublicaciones listado = new ComprarOfertar.ListadoPublicaciones("Compra Inmediata", nombreUsuario);
                listado.ShowDialog();
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string query2 = "SELECT COUNT(N_ID_PUBLICACION) FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.TIPOS T ON (P.N_ID_TIPO = T.N_ID_TIPO) JOIN GDD_15.VISIBILIDADES V ON (P.C_VISIBILIDAD = V.C_VISIBILIDAD) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE C_TIPO = 'Subasta' AND C_ESTADO IN ('Activa', 'Pausada') AND C_USUARIO_NOMBRE != '" + nombreUsuario + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string cantidadPublis = dt2.Rows[0][0].ToString();
            int cantPublis = Convert.ToInt16(cantidadPublis);

            if (cantPublis == 0)
            {
                MessageBox.Show("No hay publicaciones de subasta para mostrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ComprarOfertar.ListadoPublicaciones listado = new ComprarOfertar.ListadoPublicaciones("Subasta", nombreUsuario);
                listado.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
        Int64 idCli;
        public ElegirTipo(String nombreUsuarioPasado)
        {
            InitializeComponent();

            nombreUsuario = nombreUsuarioPasado;

            string query2 = "SELECT N_ID_USUARIO FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + nombreUsuario + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string idCliente = dt2.Rows[0][0].ToString();
            idCli = Convert.ToInt64(idCliente);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query5 = "SELECT (SELECT COUNT(*) FROM GDD_15.OFERTAS WHERE N_ID_CLIENTE = '" + idCli + "' AND C_GANADOR = 'SI') + (SELECT COUNT(*) FROM GDD_15.COMPRAS WHERE N_ID_CLIENTE = '" + idCli + "') - (SELECT COUNT(*) FROM GDD_15.CALIFICACIONES WHERE N_ID_CLIENTE = '" + idCli + "')";
            DataTable dt5 = (new ConexionSQL()).cargarTablaSQL(query5);
            string comprasSinCalif = dt5.Rows[0][0].ToString();
            Int32 cantComprasSinCalif = Convert.ToInt32(comprasSinCalif);
            if (cantComprasSinCalif < 4)
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
            else
            {
                string query3 = "SELECT N_COMPRA_HABILITADA FROM GDD_15.CLIENTES WHERE N_ID_USUARIO = '" + idCli + "'";
                DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
                string compraHabilitada = dt5.Rows[0][0].ToString();

                if (compraHabilitada == "1")
                {
                    MessageBox.Show("Como tiene más de 3 publicaciones (" + cantComprasSinCalif + ") sin calificar no puede realizar compras u ofertas hasta que califique todas sus publicaciones", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string query7 = "UPDATE GDD_15.CLIENTES SET N_COMPRA_HABILITADA = '0' WHERE N_ID_USUARIO = '" + idCli + "'";
                    DataTable dt7 = (new ConexionSQL()).cargarTablaSQL(query7);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe calificar todas sus publicaciones para realizar una compra u oferta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string query5 = "SELECT (SELECT COUNT(*) FROM GDD_15.OFERTAS WHERE N_ID_CLIENTE = '" + idCli + "' AND C_GANADOR = 'SI') + (SELECT COUNT(*) FROM GDD_15.COMPRAS WHERE N_ID_CLIENTE = '" + idCli + "') - (SELECT COUNT(*) FROM GDD_15.CALIFICACIONES WHERE N_ID_CLIENTE = '" + idCli + "')";
            DataTable dt5 = (new ConexionSQL()).cargarTablaSQL(query5);
            string comprasSinCalif = dt5.Rows[0][0].ToString();
            Int32 cantComprasSinCalif = Convert.ToInt32(comprasSinCalif);
            if (cantComprasSinCalif < 4)
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
            else
            {
                string query3 = "SELECT N_COMPRA_HABILITADA FROM GDD_15.CLIENTES WHERE N_ID_USUARIO = '" + idCli + "'";
                DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
                string compraHabilitada = dt5.Rows[0][0].ToString();

                if (compraHabilitada == "1")
                {
                    MessageBox.Show("Como tiene más de 3 publicaciones (" + cantComprasSinCalif + ") sin calificar no puede realizar compras u ofertas hasta que califique todas sus publicaciones", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string query7 = "UPDATE GDD_15.CLIENTES SET N_COMPRA_HABILITADA = '0' WHERE N_ID_USUARIO = '" + idCli + "'";
                    DataTable dt7 = (new ConexionSQL()).cargarTablaSQL(query7);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe calificar todas sus publicaciones para realizar una compra u oferta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

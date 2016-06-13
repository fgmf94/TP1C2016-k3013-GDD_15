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

namespace WindowsFormsApplication1.Historial_Cliente
{
    public partial class Historial : Form
    {
        String nombreCliente;
        int numeroPagina;
        int cantTotalPags;
        Int64 idCli;

        public Historial(String nombreClientePasado)
        {
            InitializeComponent();
            nombreCliente = nombreClientePasado;

            string query2 = "SELECT N_ID_USUARIO FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + nombreCliente + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string idCliente = dt2.Rows[0][0].ToString();
            idCli = Convert.ToInt64(idCliente);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.RowTemplate.MinimumHeight = 33;
            filtrarPag(1);
        }

        private void filtrarPag(int pagina)
        {
            numeroPagina = pagina;
            labelNumPag.Text = Convert.ToString(pagina);

            string query2 = "SELECT (SELECT COUNT(*) CUENTA FROM GDD_15.CLIENTES CL JOIN GDD_15.COMPRAS CO ON (CL.N_ID_USUARIO = CO.N_ID_CLIENTE) WHERE CL.N_ID_USUARIO = '" + idCli + "') + (SELECT COUNT(*) CUENTA FROM GDD_15.CLIENTES CL JOIN GDD_15.OFERTAS O ON (CL.N_ID_USUARIO = O.N_ID_CLIENTE) WHERE CL.N_ID_USUARIO = '" + idCli + "')";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string cantidadPublis = dt2.Rows[0][0].ToString();
            int cantPublis = Convert.ToInt16(cantidadPublis);
            if ((cantPublis % 10) == 0)
            {
                cantTotalPags = (cantPublis / 10);
            }
            else
            {
                cantTotalPags = (cantPublis / 10) + 1;
            }
            if (pagina == cantTotalPags)
            {
                buttonSigPag.Enabled = false;
            }

            if (pagina == 1)
            {
                buttonPaginaAnt.Enabled = false;
                buttonPriPag.Enabled = false;

                if (cantTotalPags == 1)
                {
                    buttonSigPag.Enabled = false;
                }
                else
                {
                    buttonSigPag.Enabled = true;
                }
            }
            else
            {
                buttonPaginaAnt.Enabled = true;
                buttonPriPag.Enabled = true;
            }

            if (pagina == 1)
            {
                CompletadorDeTablas.hacerQuery("SELECT TOP 10 [Código Publicación], Tipo, Descripción, [Monto ($)], Cantidad, Envío, Ganador, [Fecha Operación]  FROM (SELECT CO.N_ID_PUBLICACION 'Código Publicación', 'Compra Inmediata' Tipo, P.D_DESCRED Descripción, N_CANTIDAD*N_PRECIO 'Monto ($)', N_CANTIDAD Cantidad, C_ENVIO Envío, 'No aplica' Ganador, F_ALTA 'Fecha Operación' FROM GDD_15.CLIENTES CL JOIN GDD_15.COMPRAS CO ON (CL.N_ID_USUARIO = CO.N_ID_CLIENTE) JOIN GDD_15.PUBLICACIONES P ON (CO.N_ID_PUBLICACION = P.N_ID_PUBLICACION) WHERE CL.N_ID_USUARIO = '" + idCli + "' UNION ALL SELECT O.N_ID_PUBLICACION 'Código Publicación', 'Subasta' Tipo, P.D_DESCRED Descripción, N_MONTO 'Monto ($)', '1' Cantidad, C_ENVIO Envío, C_GANADOR Ganador, F_ALTA 'Fecha Operación' FROM GDD_15.CLIENTES CL JOIN GDD_15.OFERTAS O ON (CL.N_ID_USUARIO = O.N_ID_CLIENTE) JOIN GDD_15.PUBLICACIONES P ON (O.N_ID_PUBLICACION = P.N_ID_PUBLICACION) WHERE CL.N_ID_USUARIO = '" + idCli + "') SQ ORDER BY [Fecha Operación]", ref dataGridView1);
            }
            else
            {
                CompletadorDeTablas.hacerQuery("SELECT TOP 10 [Código Publicación], Tipo, Descripción, [Monto ($)], Cantidad, Envío, Ganador, [Fecha Operación] FROM (SELECT TOP " + (cantPublis - (pagina - 1) * 10).ToString() + " [Código Publicación], Tipo, Descripción, [Monto ($)], Cantidad, Envío, Ganador, [Fecha Operación] FROM (SELECT CO.N_ID_PUBLICACION 'Código Publicación', 'Compra Inmediata' Tipo, P.D_DESCRED Descripción, N_CANTIDAD*N_PRECIO 'Monto ($)', N_CANTIDAD Cantidad, C_ENVIO Envío, 'No aplica' Ganador, F_ALTA 'Fecha Operación' FROM GDD_15.CLIENTES CL JOIN GDD_15.COMPRAS CO ON (CL.N_ID_USUARIO = CO.N_ID_CLIENTE) JOIN GDD_15.PUBLICACIONES P ON (CO.N_ID_PUBLICACION = P.N_ID_PUBLICACION) WHERE CL.N_ID_USUARIO = '" + idCli + "' UNION ALL SELECT O.N_ID_PUBLICACION 'Código Publicación', 'Subasta' Tipo, P.D_DESCRED Descripción, N_MONTO 'Monto ($)', '1' Cantidad, C_ENVIO Envío, C_GANADOR Ganador, F_ALTA 'Fecha Operación' FROM GDD_15.CLIENTES CL JOIN GDD_15.OFERTAS O ON (CL.N_ID_USUARIO = O.N_ID_CLIENTE) JOIN GDD_15.PUBLICACIONES P ON (O.N_ID_PUBLICACION = P.N_ID_PUBLICACION) WHERE CL.N_ID_USUARIO = '" + idCli + "' ) SQ ORDER BY [Fecha Operación] DESC) SQ2 ORDER BY [Fecha Operación]", ref dataGridView1);
            }

            dataGridView1.RowTemplate.MinimumHeight = 33;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonPaginaAnt_Click(object sender, EventArgs e)
        {
            filtrarPag(numeroPagina - 1);
        }

        private void buttonPriPag_Click(object sender, EventArgs e)
        {
            filtrarPag(1);
        }

        private void buttonSigPag_Click(object sender, EventArgs e)
        {
            filtrarPag(numeroPagina + 1);
        }
    }
}

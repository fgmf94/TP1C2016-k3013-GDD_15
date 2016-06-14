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

namespace WindowsFormsApplication1.Calificar
{
    public partial class ElegirRealizar : Form
    {
        Int64 idCli;
        public ElegirRealizar(Int64 idClientePasado)
        {
            InitializeComponent();
            idCli = idClientePasado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerCalificaciones verCalif = new VerCalificaciones(idCli);
            verCalif.ShowDialog();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT([Código Publicación]) FROM (SELECT CO.N_ID_PUBLICACION 'Código Publicación', N_ID_COMPRA 'Código Compra u Oferta', 'Compra Inmediata' Tipo, P.D_DESCRED Descripción, N_CANTIDAD*N_PRECIO 'Monto ($)', N_CANTIDAD Cantidad, C_ENVIO Envío, F_ALTA 'Fecha Operación' FROM GDD_15.CLIENTES CL JOIN GDD_15.COMPRAS CO ON (CL.N_ID_USUARIO = CO.N_ID_CLIENTE) JOIN GDD_15.PUBLICACIONES P ON (CO.N_ID_PUBLICACION = P.N_ID_PUBLICACION) WHERE CL.N_ID_USUARIO = '" + idCli + "' AND N_ID_COMPRA NOT IN (SELECT N_ID_COMPRA FROM GDD_15.CALIFICACIONES WHERE N_ID_CLIENTE = '" + idCli + "' AND N_ID_COMPRA IS NOT NULL) UNION ALL SELECT O.N_ID_PUBLICACION 'Código Publicación', N_ID_OFERTA 'Código Compra u Oferta', 'Subasta' Tipo, P.D_DESCRED Descripción, N_MONTO 'Monto ($)', '1' Cantidad, C_ENVIO Envíor, F_ALTA 'Fecha Operación' FROM GDD_15.CLIENTES CL JOIN GDD_15.OFERTAS O ON (CL.N_ID_USUARIO = O.N_ID_CLIENTE) JOIN GDD_15.PUBLICACIONES P ON (O.N_ID_PUBLICACION = P.N_ID_PUBLICACION) WHERE C_GANADOR = 'SI' AND CL.N_ID_USUARIO = '" + idCli + "' AND N_ID_OFERTA NOT IN (SELECT N_ID_OFERTA FROM GDD_15.CALIFICACIONES WHERE N_ID_CLIENTE = '" + idCli + "' AND N_ID_OFERTA IS NOT NULL)) SQ";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string cantidad = dt.Rows[0][0].ToString();
            if (cantidad == "0")
            {
                MessageBox.Show("No hay operaciones para calificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Calificar calif = new Calificar(idCli);
                calif.ShowDialog();
            }
        }
    }
}

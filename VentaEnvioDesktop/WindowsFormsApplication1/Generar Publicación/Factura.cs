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
    public partial class Factura : Form
    {
        public Factura(string idPubli)
        {
            InitializeComponent();

            txtCodPub.Text = idPubli;

            string query5 = "SELECT N_ID_FACTURA, F_ALTA FROM GDD_15.FACTURAS WHERE N_ID_PUBLICACION = '" + idPubli + "'";
            DataTable dt5 = (new ConexionSQL()).cargarTablaSQL(query5);
            string idFactura = dt5.Rows[0][0].ToString();
            string fechaAlta = dt5.Rows[0][1].ToString();

            dateFechaAlta.Text = fechaAlta;
            txtCodFact.Text = idFactura;

            string query = "SELECT N_MONTO FROM GDD_15.FACTURAS_ITEMS WHERE N_ID_FACTURA = '" + idFactura + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string monto = dt.Rows[0][0].ToString();

            txtMonto.Text = monto;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodPub_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

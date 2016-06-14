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

namespace WindowsFormsApplication1.Facturas
{
    public partial class Facturas : Form
    {
        Int64 idCli;
        public Facturas(Int64 idClientePasado)
        {
            InitializeComponent();
            idCli = idClientePasado;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.RowTemplate.MinimumHeight = 33;

            CompletadorDeTablas.hacerQuery("SELECT F.N_ID_FACTURA 'Código Factura', N_ID_ITEM 'Código Item', (CASE WHEN FI.N_ID_OFERTA IS NULL AND FI.N_ID_COMPRA IS NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por tipo de visibilidad' WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NULL THEN 'Comisión por venta'  WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por envío' END) 'Detalle', N_MONTO 'Monto Item ($)', F.F_ALTA 'Fecha Alta' FROM GDD_15.PUBLICACIONES P JOIN GDD_15.FACTURAS F ON (P.N_ID_PUBLICACION = F.N_ID_PUBLICACION) JOIN GDD_15.FACTURAS_ITEMS FI ON (F.N_ID_FACTURA = FI.N_ID_FACTURA) WHERE N_ID_USUARIO = '" + idCli + "' ORDER BY F.F_ALTA", ref dataGridView1);

        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkEnvio_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

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
        int numeroPagina;
        int cantTotalPags;
        string wheres;

        public Facturas(Int64 idClientePasado)
        {
            InitializeComponent();
            idCli = idClientePasado;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.RowTemplate.MinimumHeight = 33;

            inicializar();

            filtrarPagina(1);
        }

        private void inicializar()
        {
            dateFechaInicio.Enabled = false;
            dateFechaFin.Enabled = false;
            txtPrecioInicio.ReadOnly = true;
            txtPrecioFin.ReadOnly = true;

            dateFechaFin.Text = DateTime.Today.ToString();
            dateFechaInicio.Text = DateTime.Today.ToString();
            txtPrecioFin.Text = "";
            txtPrecioInicio.Text = "";

            chkCTipo.Checked = true;
            chkCVentas.Checked = true;
            chkCEnvio.Checked = true;
            chkFechas.Checked = false;
            chkImportes.Checked = false;

            filtrarPagina(1);
        }

        private void armarWheres()
        {
            wheres = "";

            
        }

        private void filtrarPagina(int pagina)
        {
            numeroPagina = pagina;
            labelNumPag.Text = Convert.ToString(pagina);

            armarWheres();

            if (pagina == 1)
            {
                CompletadorDeTablas.hacerQuery("SELECT TOP 10 F.N_ID_FACTURA 'Código Factura', N_ID_ITEM 'Código Item', (CASE WHEN FI.N_ID_OFERTA IS NULL AND FI.N_ID_COMPRA IS NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por tipo de visibilidad' WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NULL THEN 'Comisión por venta'  WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por envío' END) 'Detalle', N_MONTO 'Monto Item ($)', F.F_ALTA 'Fecha Alta' FROM GDD_15.PUBLICACIONES P JOIN GDD_15.FACTURAS F ON (P.N_ID_PUBLICACION = F.N_ID_PUBLICACION) JOIN GDD_15.FACTURAS_ITEMS FI ON (F.N_ID_FACTURA = FI.N_ID_FACTURA) WHERE N_ID_USUARIO = '" + idCli + "' ORDER BY F.F_ALTA", ref dataGridView1);
            }
            else
            {
                //CompletadorDeTablas.hacerQuery("SELECT TOP 10 [Código Publicación], Tipo, Descripción, [Monto ($)], Cantidad, Envío, Ganador, [Fecha Operación] FROM (SELECT TOP " + (cantPublis - (pagina - 1) * 10).ToString() + " [Código Publicación], Tipo, Descripción, [Monto ($)], Cantidad, Envío, Ganador, [Fecha Operación] FROM (SELECT CO.N_ID_PUBLICACION 'Código Publicación', 'Compra Inmediata' Tipo, P.D_DESCRED Descripción, N_CANTIDAD*N_PRECIO 'Monto ($)', N_CANTIDAD Cantidad, C_ENVIO Envío, 'No aplica' Ganador, F_ALTA 'Fecha Operación' FROM GDD_15.CLIENTES CL JOIN GDD_15.COMPRAS CO ON (CL.N_ID_USUARIO = CO.N_ID_CLIENTE) JOIN GDD_15.PUBLICACIONES P ON (CO.N_ID_PUBLICACION = P.N_ID_PUBLICACION) WHERE CL.N_ID_USUARIO = '" + idCli + "' UNION ALL SELECT O.N_ID_PUBLICACION 'Código Publicación', 'Subasta' Tipo, P.D_DESCRED Descripción, N_MONTO 'Monto ($)', '1' Cantidad, C_ENVIO Envío, C_GANADOR Ganador, F_ALTA 'Fecha Operación' FROM GDD_15.CLIENTES CL JOIN GDD_15.OFERTAS O ON (CL.N_ID_USUARIO = O.N_ID_CLIENTE) JOIN GDD_15.PUBLICACIONES P ON (O.N_ID_PUBLICACION = P.N_ID_PUBLICACION) WHERE CL.N_ID_USUARIO = '" + idCli + "' ) SQ ORDER BY [Fecha Operación] DESC) SQ2 ORDER BY [Fecha Operación]", ref dataGridView1);
            }
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            if (!validaciones())
            {
                return;
            }

            filtrarPagina(1);
        }

        private bool validaciones()
        {
            if (chkCEnvio.Checked == false && chkCTipo.Checked == false && chkCVentas.Checked == false)
            {
                MessageBox.Show("Debe elegir al menos una comisión", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (chkFechas.Checked == true)
            {
                DateTime ini = DateTime.Parse(dateFechaInicio.Text);
                DateTime fin = DateTime.Parse(dateFechaFin.Text);
                DateTime today = DateTime.Today;

                if (ini >= fin)
                {
                    MessageBox.Show("La fecha de inicio tiene que ser anterior a la de fin", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (ini > today)
                {
                    MessageBox.Show("La fecha de inicio tiene que ser anterior o igual a la de hoy", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (chkImportes.Checked == true)
            {

            }

            return true;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkEnvio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFechas.Checked == true)
            {
                dateFechaInicio.Enabled = true;
                dateFechaFin.Enabled = true;
            } 
            else if(chkFechas.Checked == false)
            {
                dateFechaInicio.Enabled = false;
                dateFechaFin.Enabled = false;
            }
        }

        private void chkImportes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkImportes.Checked == true)
            {
                txtPrecioInicio.ReadOnly = false;
                txtPrecioFin.ReadOnly = false;
            }
            else if (chkImportes.Checked == false)
            {
                txtPrecioInicio.ReadOnly = true;
                txtPrecioFin.ReadOnly = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inicializar();
        }

        private void buttonPaginaAnt_Click(object sender, EventArgs e)
        {

        }

        private void buttonPriPag_Click(object sender, EventArgs e)
        {
            filtrarPagina(1);
        }
    }
}

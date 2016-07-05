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
        }

        private void inicializar()
        {
            dateFechaInicio.Enabled = false;
            dateFechaFin.Enabled = false;
            txtPrecioInicio.ReadOnly = true;
            txtPrecioFin.ReadOnly = true;

            dateFechaFin.Text = DateTime.Parse(Program.nuevaFechaSistema()).ToString();
            dateFechaInicio.Text = DateTime.Parse(Program.nuevaFechaSistema()).ToString();
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

            wheres = wheres + "WHERE [Detalle] IN (";

            if (chkCTipo.Checked == true)
            {
                wheres = wheres + " 'Comisión por tipo de visibilidad',";
            }

            if (chkCVentas.Checked == true)
            {
                wheres = wheres + " 'Comisión por venta',";
            }

            if (chkCEnvio.Checked == true)
            {
                wheres = wheres + " 'Comisión por envío',";
            }

            wheres = wheres.Substring(0, wheres.Length - 1);
            wheres = wheres + ")";

            if (chkImportes.Checked == true)
            {
                wheres = wheres + " AND [Monto Item ($)] BETWEEN " + txtPrecioInicio.Text + " AND " + txtPrecioFin.Text;
            }

            if (chkFechas.Checked == true)
            {
                wheres = wheres + " AND [Fecha Alta] BETWEEN '" + DateTime.Parse(dateFechaInicio.Text) + "' AND '" + DateTime.Parse(dateFechaFin.Text) + "'";
            }
        }

        private void filtrarPagina(int pagina)
        {
            numeroPagina = pagina;
            labelNumPag.Text = Convert.ToString(pagina);

            armarWheres();

            string query2 = "SELECT COUNT([Código Factura]) FROM (SELECT F.N_ID_FACTURA 'Código Factura', N_ID_ITEM 'Código Item', CASE WHEN FI.N_ID_OFERTA IS NULL AND FI.N_ID_COMPRA IS NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por tipo de visibilidad' WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NULL THEN 'Comisión por venta'  WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por envío' END AS 'Detalle', N_MONTO 'Monto Item ($)', F.F_ALTA 'Fecha Alta' FROM GDD_15.PUBLICACIONES P JOIN GDD_15.FACTURAS F ON (P.N_ID_PUBLICACION = F.N_ID_PUBLICACION) JOIN GDD_15.FACTURAS_ITEMS FI ON (F.N_ID_FACTURA = FI.N_ID_FACTURA) WHERE N_ID_USUARIO = '" + idCli + "') SQ " + wheres;
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
            else if (pagina < cantTotalPags)
            {
                buttonSigPag.Enabled = true;
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

            if (cantPublis == 0)
            {
                buttonSigPag.Enabled = false;
            }

            if (pagina == 1)
            {
                CompletadorDeTablas.hacerQuery("SELECT TOP 10 [Código Factura], [Código Item], [Detalle], [Monto Item ($)], [Fecha Alta] FROM (SELECT F.N_ID_FACTURA 'Código Factura', N_ID_ITEM 'Código Item', CASE WHEN FI.N_ID_OFERTA IS NULL AND FI.N_ID_COMPRA IS NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por tipo de visibilidad' WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NULL THEN 'Comisión por venta'  WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por envío' END AS 'Detalle', N_MONTO 'Monto Item ($)', F.F_ALTA 'Fecha Alta' FROM GDD_15.PUBLICACIONES P JOIN GDD_15.FACTURAS F ON (P.N_ID_PUBLICACION = F.N_ID_PUBLICACION) JOIN GDD_15.FACTURAS_ITEMS FI ON (F.N_ID_FACTURA = FI.N_ID_FACTURA) WHERE N_ID_USUARIO = '" + idCli + "') SQ " + wheres + " ORDER BY [Fecha Alta]", ref dataGridView1);
            }
            else
            {
                CompletadorDeTablas.hacerQuery("SELECT TOP 10 [Código Factura], [Código Item], [Detalle], [Monto Item ($)], [Fecha Alta] FROM (SELECT TOP " + (cantPublis - (pagina - 1) * 10).ToString() + " [Código Factura], [Código Item], [Detalle], [Monto Item ($)], [Fecha Alta] FROM (SELECT F.N_ID_FACTURA 'Código Factura', N_ID_ITEM 'Código Item', CASE WHEN FI.N_ID_OFERTA IS NULL AND FI.N_ID_COMPRA IS NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por tipo de visibilidad' WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NULL THEN 'Comisión por venta'  WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por envío' END AS 'Detalle', N_MONTO 'Monto Item ($)', F.F_ALTA 'Fecha Alta' FROM GDD_15.PUBLICACIONES P JOIN GDD_15.FACTURAS F ON (P.N_ID_PUBLICACION = F.N_ID_PUBLICACION) JOIN GDD_15.FACTURAS_ITEMS FI ON (F.N_ID_FACTURA = FI.N_ID_FACTURA) WHERE N_ID_USUARIO = '" + idCli + "') SQ " + wheres + " ORDER BY [Fecha Alta] DESC) SQ2 ORDER BY [Fecha Alta]", ref dataGridView1);
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
                DateTime today = DateTime.Parse(Program.nuevaFechaSistema());

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
                int ini;

                try
                {
                    ini = Convert.ToInt32(txtPrecioInicio.Text);
                }
                catch
                {
                    MessageBox.Show("El precio de inicio debe ser un entero menor a 2147483647", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (ini < 0)
                {
                    MessageBox.Show("El precio de inicio debe ser mayor o igual a 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                int fin;

                try
                {
                    fin = Convert.ToInt32(txtPrecioFin.Text);
                }
                catch
                {
                    MessageBox.Show("El precio de fin debe ser un entero menor a 2147483647", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (fin < 0)
                {
                    MessageBox.Show("El precio de fin debe ser mayor o igual a 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (ini >= fin)
                {
                    MessageBox.Show("El precio de fin debe ser mayor al precio de inicio", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
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
                dateFechaFin.Text = DateTime.Parse(Program.nuevaFechaSistema()).ToString();
                dateFechaInicio.Text = DateTime.Parse(Program.nuevaFechaSistema()).ToString();
            } 
            else if(chkFechas.Checked == false)
            {
                dateFechaInicio.Enabled = false;
                dateFechaFin.Enabled = false;
                dateFechaFin.Text = DateTime.Parse(Program.nuevaFechaSistema()).ToString();
                dateFechaInicio.Text = DateTime.Parse(Program.nuevaFechaSistema()).ToString();
            }
        }

        private void chkImportes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkImportes.Checked == true)
            {
                txtPrecioInicio.ReadOnly = false;
                txtPrecioFin.ReadOnly = false;
                txtPrecioFin.Text = "";
                txtPrecioInicio.Text = "";
            }
            else if (chkImportes.Checked == false)
            {
                txtPrecioInicio.ReadOnly = true;
                txtPrecioFin.ReadOnly = true;
                txtPrecioFin.Text = "";
                txtPrecioInicio.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inicializar();
        }

        private void buttonPaginaAnt_Click(object sender, EventArgs e)
        {
            if (!validaciones())
            {
                return;
            }

            armarWheres();

            string query2 = "SELECT COUNT([Código Factura]) FROM (SELECT F.N_ID_FACTURA 'Código Factura', N_ID_ITEM 'Código Item', CASE WHEN FI.N_ID_OFERTA IS NULL AND FI.N_ID_COMPRA IS NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por tipo de visibilidad' WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NULL THEN 'Comisión por venta'  WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por envío' END AS 'Detalle', N_MONTO 'Monto Item ($)', F.F_ALTA 'Fecha Alta' FROM GDD_15.PUBLICACIONES P JOIN GDD_15.FACTURAS F ON (P.N_ID_PUBLICACION = F.N_ID_PUBLICACION) JOIN GDD_15.FACTURAS_ITEMS FI ON (F.N_ID_FACTURA = FI.N_ID_FACTURA) WHERE N_ID_USUARIO = '" + idCli + "') SQ " + wheres;
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

            if (cantTotalPags >= numeroPagina - 1)
            {
                filtrarPagina(numeroPagina - 1);
            }
            else
            {
                MessageBox.Show("No hay página anterior para esa búsqueda (Muestro primera página)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                filtrarPagina(1);
            }
        }

        private void buttonPriPag_Click(object sender, EventArgs e)
        {
            if (!validaciones())
            {
                return;
            }

            filtrarPagina(1);
        }

        private void buttonSigPag_Click(object sender, EventArgs e)
        {
            if (!validaciones())
            {
                return;
            }

            armarWheres();

            string query2 = "SELECT COUNT([Código Factura]) FROM (SELECT F.N_ID_FACTURA 'Código Factura', N_ID_ITEM 'Código Item', CASE WHEN FI.N_ID_OFERTA IS NULL AND FI.N_ID_COMPRA IS NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por tipo de visibilidad' WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NULL THEN 'Comisión por venta'  WHEN FI.N_ID_OFERTA IS NOT NULL OR FI.N_ID_COMPRA IS NOT NULL AND FI.C_VISIBILIDAD IS NOT NULL THEN 'Comisión por envío' END AS 'Detalle', N_MONTO 'Monto Item ($)', F.F_ALTA 'Fecha Alta' FROM GDD_15.PUBLICACIONES P JOIN GDD_15.FACTURAS F ON (P.N_ID_PUBLICACION = F.N_ID_PUBLICACION) JOIN GDD_15.FACTURAS_ITEMS FI ON (F.N_ID_FACTURA = FI.N_ID_FACTURA) WHERE N_ID_USUARIO = '" + idCli + "') SQ " + wheres;
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

            if (cantTotalPags > numeroPagina)
            {
                filtrarPagina(numeroPagina + 1);
            }
            else
            {
                MessageBox.Show("No hay siguiente página para esa búsqueda (Muestro primera página)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                filtrarPagina(1);
            }
        }
    }
}

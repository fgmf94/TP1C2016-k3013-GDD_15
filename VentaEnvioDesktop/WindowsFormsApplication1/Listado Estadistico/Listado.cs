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
using MercadoEnvio.Dominio;

namespace WindowsFormsApplication1.Listado_Estadistico
{
    public partial class Listado : Form
    {
        int listado;
        public Listado(int añoPasado, string trimPasado, int listadoPasado)
        {
            InitializeComponent();

            listado = listadoPasado;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.MinimumHeight = 33;

            DateTime hoy = DateTime.Parse(Program.nuevaFechaSistema());

            int añoHoy = hoy.Year;
            int i = 0;
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Año");

            while (i < 5)
            {
                DataRow row = dt.NewRow();
                row["Año"] = añoHoy - i;
                dt.Rows.Add(row);
                i++;
            }

            comboBoxAño.DataSource = dt.DefaultView;
            comboBoxAño.ValueMember = "Año";

            comboBoxAño.Text = añoPasado.ToString();
            comboBoxTri.Text = trimPasado;

            string listadoTexto = "";

            if(listadoPasado == 1)
            {
                listadoTexto = "Vendedores con mayor cantidad de productos no vendidos";

                DataTable dt2 = (new ConexionSQL()).cargarTablaSQL("SELECT D_DESCRIP FROM GDD_15.VISIBILIDADES");
                comboBoxRubro.DataSource = dt2.DefaultView;
                comboBoxRubro.ValueMember = "D_DESCRIP";

                labelRubro.Text = "Visibilidad";
            }
            else if(listadoPasado == 2)
            {
                listadoTexto = "Clientes con mayor cantidad de productos comprados";

                DataTable dt2 = (new ConexionSQL()).cargarTablaSQL("SELECT D_DESCRED FROM GDD_15.RUBROS");
                comboBoxRubro.DataSource = dt2.DefaultView;
                comboBoxRubro.ValueMember = "D_DESCRED";
            }
            else if(listadoPasado == 3)
            {
                listadoTexto = "Vendedores con mayor cantidad de facturas";
                comboBoxRubro.Hide();
                labelRubro.Hide();
            }
            else if(listadoPasado == 4)
            {
                listadoTexto = "Vendedores con mayor monto facturado";
                comboBoxRubro.Hide();
                labelRubro.Hide();
            }

            labelTitulo.Text = labelTitulo.Text + " " + listadoTexto;

            filtrar();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void chkListaRubros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void filtrar()
        {
            if (!validaciones())
            {
                return;
            }

            if (listado == 1)
            {
                CompletadorDeTablas.hacerQuery("SELECT * FROM GDD_15.DEV_VEN_MAYOR_PROD_NO_VEND(" + comboBoxTri.Text[0] + ", " + comboBoxAño.Text + ", '" + comboBoxRubro.Text + "')", ref dataGridView1);
            }
            else if (listado == 2)
            {
                CompletadorDeTablas.hacerQuery("SELECT * FROM GDD_15.DEV_CLI_MAYOR_PROD_COMPR(" + comboBoxTri.Text[0] + ", " + comboBoxAño.Text + ", '" + comboBoxRubro.Text + "')", ref dataGridView1);
            }
            else if (listado == 3)
            {
                CompletadorDeTablas.hacerQuery("SELECT * FROM GDD_15.DEV_VEN_MAYOR_FACT(" + comboBoxTri.Text[0] + ", " + comboBoxAño.Text + ")", ref dataGridView1);
            }
            else if (listado == 4)
            {
                CompletadorDeTablas.hacerQuery("SELECT * FROM GDD_15.DEV_VEN_MAYOR_MONTO_FACT(" + comboBoxTri.Text[0] + ", " + comboBoxAño.Text + ")", ref dataGridView1);
            }
        }

        private bool validaciones()
        {
            DateTime hoy = DateTime.Parse(Program.nuevaFechaSistema());

            Int16 añoAhora = Convert.ToInt16(hoy.Year);
            Int16 mesAhora = Convert.ToInt16(hoy.Month);

            if (añoAhora == Convert.ToInt16(comboBoxAño.Text))
            {
                if (Convert.ToInt16((comboBoxTri.Text[0]).ToString()) * 3 - 2 > mesAhora)
                {
                    MessageBox.Show("No se puede elegir un trimestre posterior al trimestre de hoy", "Error Descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }
    }
}

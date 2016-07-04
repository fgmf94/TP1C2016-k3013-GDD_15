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
        String wheres;
        int listado;
        public Listado(int añoPasado, string trimPasado, int listadoPasado)
        {
            InitializeComponent();

            listado = listadoPasado;

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
                comboBoxRubro.Hide();
                labelRubro.Hide();

                string comando = "SELECT * FROM GDD_15.VISIBILIDADES";
                DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(comando);

                chkListaVisibilidades.Items.Clear();
                for (int j = 0; j <= (dt3.Rows.Count - 1); j++)
                {
                    int idf = Convert.ToInt32(dt3.Rows[j][0]);
                    chkListaVisibilidades.Items.Insert(j, new Rubros(idf, dt3.Rows[j][1].ToString(), this));
                }
                for (int j = 0; j <= chkListaVisibilidades.Items.Count - 1; j++)
                {
                    chkListaVisibilidades.SetItemCheckState(j, CheckState.Checked);
                }
            }
            else if(listadoPasado == 2)
            {
                listadoTexto = "Clientes con mayor cantidad de productos comprados";
                chkListaVisibilidades.Hide();
                labelVisi.Hide();

                DataTable dt2 = (new ConexionSQL()).cargarTablaSQL("SELECT D_DESCRED FROM GDD_15.RUBROS");
                comboBoxRubro.DataSource = dt2.DefaultView;
                comboBoxRubro.ValueMember = "D_DESCRED";
            }
            else if(listadoPasado == 3)
            {
                listadoTexto = "Vendedores con mayor cantidad de facturas";
                comboBoxRubro.Hide();
                labelRubro.Hide();
                chkListaVisibilidades.Hide();
                labelVisi.Hide();
            }
            else if(listadoPasado == 4)
            {
                listadoTexto = "Vendedores con mayor monto facturado";
                comboBoxRubro.Hide();
                labelRubro.Hide();
                chkListaVisibilidades.Hide();
                labelVisi.Hide();
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

        }

        private void armarWheres()
        {

        }
    }
}

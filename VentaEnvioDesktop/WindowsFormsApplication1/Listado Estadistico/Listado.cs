using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Listado_Estadistico
{
    public partial class Listado : Form
    {
        public Listado(int añoPasado, string trimPasado, int listadoPasado)
        {
            InitializeComponent();

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
            }
            else if(listadoPasado == 2)
            {
                listadoTexto = "Clientes con mayor cantidad de productos comprados";
            }
            else if(listadoPasado == 3)
            {
                listadoTexto = "Vendedores con mayor cantidad de facturas";
            }
            else if(listadoPasado == 4)
            {
                listadoTexto = "Vendedores con mayor monto facturado";
            }

            labelTitulo.Text = labelTitulo.Text + " " + listadoTexto;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {

        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}

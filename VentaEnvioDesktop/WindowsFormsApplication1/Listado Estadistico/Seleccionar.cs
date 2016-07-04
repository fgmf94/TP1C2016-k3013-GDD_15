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

namespace WindowsFormsApplication1.Listado_Estadistico
{
    public partial class Seleccionar : Form
    {
        public Seleccionar()
        {
            InitializeComponent();

            DateTime hoy = DateTime.Parse(Program.nuevaFechaSistema());

            int año = hoy.Year;
            int i = 0;
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Año");

            while (i < 5)
            {
                DataRow row = dt.NewRow();
                row["Año"] = año - i;
                dt.Rows.Add(row);
                i++;
            }

            comboBoxAño.DataSource = dt.DefaultView;
            comboBoxAño.ValueMember = "Año";

            comboBoxTri.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mostrarListado(4);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            mostrarListado(1);
        }

        private void buttonListado2_Click(object sender, EventArgs e)
        {
            mostrarListado(2);
        }

        private void buttonListado3_Click(object sender, EventArgs e)
        {
            mostrarListado(3);
        }

        private void mostrarListado(int numero)
        {
            Listado_Estadistico.Listado list = new Listado_Estadistico.Listado(Convert.ToInt16(comboBoxAño.Text), comboBoxTri.Text, numero);
            list.ShowDialog();
        }
    }
}

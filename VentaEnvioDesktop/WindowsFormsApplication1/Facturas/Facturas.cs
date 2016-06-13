using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Facturas
{
    public partial class Facturas : Form
    {
        Int64 idCliente;
        public Facturas(Int64 idClientePasado)
        {
            InitializeComponent();
            idCliente = idClientePasado;
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

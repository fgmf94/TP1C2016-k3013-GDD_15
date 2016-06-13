using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Calificar
{
    public partial class Calificar : Form
    {
        Int64 idCli;
        public Calificar(Int64 idClientePasado)
        {
            InitializeComponent();
            idCli = idClientePasado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            CalificarOperacion calif = new CalificarOperacion();
            calif.ShowDialog();
        }
    }
}

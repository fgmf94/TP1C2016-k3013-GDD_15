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
    public partial class ElegirRealizar : Form
    {
        Int64 idCliente;
        public ElegirRealizar(Int64 idClientePasado)
        {
            InitializeComponent();
            idCliente = idClientePasado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerCalificaciones verCalif = new VerCalificaciones(idCliente);
            verCalif.ShowDialog();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Calificar calif = new Calificar(idCliente);
            calif.ShowDialog();
        }
    }
}

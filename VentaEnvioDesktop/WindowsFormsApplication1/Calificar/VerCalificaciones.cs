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

namespace WindowsFormsApplication1.Calificar
{
    public partial class VerCalificaciones : Form
    {
        Int64 idCli;
        public VerCalificaciones(Int64 idCliPasado)
        {
            InitializeComponent();
            idCli = idCliPasado;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;

            CompletadorDeTablas.hacerQuery("SELECT N_ID_COMPRA 'Código Compra u Oferta', C_CALIFICACION 'Estrellas', D_DESCRIP 'Detalle' FROM GDD_15.CALIFICACIONES WHERE N_ID_COMPRA IS NOT NULL AND N_ID_CLIENTE = '" + idCli + "' UNION ALL SELECT N_ID_OFERTA 'Código Compra u Oferta', C_CALIFICACION 'Estrellas', D_DESCRIP 'Detalle' FROM GDD_15.CALIFICACIONES WHERE N_ID_OFERTA IS NOT NULL AND N_ID_CLIENTE = '" + idCli + "'", ref dataGridView1);  
        }

        private void VerCalificaciones_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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

            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.MultiSelect = false;
            dataGridView3.ReadOnly = true;

            CompletadorDeTablas.hacerQuery("SELECT TOP 5 [Código Compra u Oferta], [Estrellas], [Detalle] FROM (SELECT N_ID_COMPRA 'Código Compra u Oferta', C_CALIFICACION 'Estrellas', D_DESCRIP 'Detalle' FROM GDD_15.CALIFICACIONES WHERE N_ID_COMPRA IS NOT NULL AND N_ID_CLIENTE = '" + idCli + "' UNION ALL SELECT N_ID_OFERTA 'Código Compra u Oferta', C_CALIFICACION 'Estrellas', D_DESCRIP 'Detalle' FROM GDD_15.CALIFICACIONES WHERE N_ID_OFERTA IS NOT NULL AND N_ID_CLIENTE = '" + idCli + "' ) SQ ORDER BY 1 DESC", ref dataGridView1);

            string query = "SELECT COUNT(C_CALIFICACION) FROM GDD_15.CALIFICACIONES WHERE N_ID_COMPRA IS NOT NULL AND N_ID_CLIENTE = '" + idCli + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string cantidad = dt.Rows[0][0].ToString();
            if (cantidad != "0")
            {
                CompletadorDeTablas.hacerQuery("SELECT C_CALIFICACION 'Estrellas', COUNT(C_CALIFICACION) 'Cantidad' FROM GDD_15.CALIFICACIONES WHERE N_ID_COMPRA IS NOT NULL AND N_ID_CLIENTE = '" + idCli + "' GROUP BY C_CALIFICACION", ref dataGridView2);
            }

            string query2 = "SELECT COUNT(C_CALIFICACION) FROM GDD_15.CALIFICACIONES WHERE N_ID_OFERTA IS NOT NULL AND N_ID_CLIENTE = '" + idCli + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string cantidad2 = dt2.Rows[0][0].ToString();
            if (cantidad2 != "0")
            {
                CompletadorDeTablas.hacerQuery("SELECT C_CALIFICACION 'Estrellas', COUNT(C_CALIFICACION) 'Cantidad' FROM GDD_15.CALIFICACIONES WHERE N_ID_OFERTA IS NOT NULL AND N_ID_CLIENTE = '" + idCli + "' GROUP BY C_CALIFICACION", ref dataGridView3);
            }
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

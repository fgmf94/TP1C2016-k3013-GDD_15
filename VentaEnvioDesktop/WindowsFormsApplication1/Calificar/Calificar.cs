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
    public partial class Calificar : Form
    {
        Int64 idCli;
        public Calificar(Int64 idClientePasado)
        {
            InitializeComponent();
            idCli = idClientePasado;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            inicializar();
        }

        private void inicializar()
        {
            CompletadorDeTablas.hacerQuery("SELECT [Código Publicación], [Código Compra u Oferta], Tipo, Descripción, [Monto ($)], Cantidad, Envío, [Fecha Operación] FROM (SELECT CO.N_ID_PUBLICACION 'Código Publicación', N_ID_COMPRA 'Código Compra u Oferta', 'Compra Inmediata' Tipo, P.D_DESCRED Descripción, N_CANTIDAD*N_PRECIO 'Monto ($)', N_CANTIDAD Cantidad, C_ENVIO Envío, F_ALTA 'Fecha Operación' FROM GDD_15.CLIENTES CL JOIN GDD_15.COMPRAS CO ON (CL.N_ID_USUARIO = CO.N_ID_CLIENTE) JOIN GDD_15.PUBLICACIONES P ON (CO.N_ID_PUBLICACION = P.N_ID_PUBLICACION) WHERE CL.N_ID_USUARIO = '" + idCli + "' UNION ALL SELECT O.N_ID_PUBLICACION 'Código Publicación', N_ID_OFERTA 'Código Compra u Oferta', 'Subasta' Tipo, P.D_DESCRED Descripción, N_MONTO 'Monto ($)', '1' Cantidad, C_ENVIO Envíor, F_ALTA 'Fecha Operación' FROM GDD_15.CLIENTES CL JOIN GDD_15.OFERTAS O ON (CL.N_ID_USUARIO = O.N_ID_CLIENTE) JOIN GDD_15.PUBLICACIONES P ON (O.N_ID_PUBLICACION = P.N_ID_PUBLICACION) WHERE C_GANADOR = 'SI' AND CL.N_ID_USUARIO = '" + idCli + "' ) SQ ORDER BY [Fecha Operación]", ref dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            string operacioId = row.Cells["Código Compra u Oferta"].Value.ToString();
            string tipo = row.Cells["Tipo"].Value.ToString();

            CalificarOperacion calif = new CalificarOperacion(idCli,Convert.ToInt64(operacioId),tipo,this);
            calif.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

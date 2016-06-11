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

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class MisPublicaciones : Form
    {
        public MisPublicaciones(String nombreUsuarioPasado)
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            CompletadorDeTablas.hacerQuery("SELECT N_ID_PUBLICACION 'Código Publicación', V.D_DESCRIP Visibilidad, C_ESTADO Estado, C_TIPO Tipo, P.D_DESCRED Descripción, N_STOCK Stock, N_PRECIO Precio, C_PERMITE_ENVIO Envío, P.F_INICIO 'Fecha Inicio', P.F_VENCIMIENTO 'Fecha Vencimiento' FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.TIPOS T ON (P.N_ID_TIPO = T.N_ID_TIPO) JOIN GDD_15.VISIBILIDADES V ON (P.C_VISIBILIDAD = V.C_VISIBILIDAD) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE C_ESTADO IN ('Activa', 'Pausada', 'Finalizada') AND C_USUARIO_NOMBRE = '" + nombreUsuarioPasado + "'", ref dataGridView1);
            
        }

        private void MisPublicaciones_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonActivar_Click(object sender, EventArgs e)
        {

        }
    }
}

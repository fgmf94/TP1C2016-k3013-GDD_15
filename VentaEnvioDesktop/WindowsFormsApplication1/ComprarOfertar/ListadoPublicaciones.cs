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

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class ListadoPublicaciones : Form
    {
        String formato;
        String nombreUsuario;
        public ListadoPublicaciones(String formatoPasado, String nombreUsuarioPasado)
        {
            InitializeComponent();
            formato = formatoPasado;
            nombreUsuario = nombreUsuarioPasado;

            string comando = "SELECT * FROM GDD_15.RUBROS";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);

            chkListaRubros.Items.Clear();
            for (int i = 0; i <= (dt.Rows.Count - 1); i++)
            {
                int idf = Convert.ToInt32(dt.Rows[i][0]);
                chkListaRubros.Items.Insert(i, new Rubros(idf, dt.Rows[i][2].ToString(), this));
            }

            if (formato == "Ofertar")
            {
                labelTitulo.Text = "Publicaciones para Ofertar";
            }

            inicializar();
        }

        private void inicializar()
        {
            for (int i = 0; i <= chkListaRubros.Items.Count - 1; i++)
            {
                chkListaRubros.SetItemCheckState(i, CheckState.Checked);
            }

            txtDescrip.Text = "";

            dataGridView1.RowTemplate.MinimumHeight = 34;

            CompletadorDeTablas.hacerQuery("SELECT TOP 10 N_ID_PUBLICACION Código, C_USUARIO_NOMBRE 'Nombre Usuario', P.D_DESCRED Descripción, R.D_DESCRED Rubro, N_PRECIO Precio, N_STOCK Stock, C_PERMITE_ENVIO 'Permite envio', F_VENCIMIENTO 'Fecha Vencimiento' FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.TIPOS T ON (P.N_ID_TIPO = T.N_ID_TIPO) JOIN GDD_15.VISIBILIDADES V ON (P.C_VISIBILIDAD = V.C_VISIBILIDAD) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE C_TIPO = '" + formato + "' AND C_ESTADO = 'Activa' AND C_USUARIO_NOMBRE != '" + nombreUsuario + "' ORDER BY V.N_COMISION_PRECIO DESC, C_PERMITE_ENVIO DESC, N_PRECIO ASC", ref dataGridView1);
        }

        private void ListadoPublicaciones_Load(object sender, EventArgs e)
        {

        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonElegirPub_Click(object sender, EventArgs e)
        {

        }

        private void buttonSeleccionarTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= chkListaRubros.Items.Count - 1; i++)
            {
                chkListaRubros.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void buttonReestablecer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= chkListaRubros.Items.Count - 1; i++)
            {
                chkListaRubros.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inicializar();
        }
    }
}

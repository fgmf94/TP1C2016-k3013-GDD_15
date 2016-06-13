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
        String nombreUsuario;
        public MisPublicaciones(String nombreUsuarioPasado)
        {
            InitializeComponent();

            nombreUsuario = nombreUsuarioPasado;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            inicializar();
            
        }

        private void inicializar()
        {
            CompletadorDeTablas.hacerQuery("SELECT N_ID_PUBLICACION 'Código', V.D_DESCRIP Visibilidad, C_ESTADO Estado, C_TIPO Tipo, P.D_DESCRED Descripción, N_STOCK Stock, N_PRECIO Precio, C_PERMITE_ENVIO Envío, P.F_INICIO 'Fecha Inicio', P.F_VENCIMIENTO 'Fecha Vencimiento' FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.TIPOS T ON (P.N_ID_TIPO = T.N_ID_TIPO) JOIN GDD_15.VISIBILIDADES V ON (P.C_VISIBILIDAD = V.C_VISIBILIDAD) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE C_ESTADO IN ('Activa', 'Pausada', 'Finalizada') AND C_USUARIO_NOMBRE = '" + nombreUsuario + "'", ref dataGridView1);
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
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            string estado = row.Cells["Estado"].Value.ToString();
            string idPubli = row.Cells["Código"].Value.ToString();
            if (estado == "Finalizada")
            {
                MessageBox.Show("No se puede activar una publicación Finalizada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (estado == "Pausada")
            {
                string query3 = "SELECT N_ID_ESTADO FROM GDD_15.ESTADOS WHERE C_ESTADO = 'Activa'";
                DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
                string estadoID = dt3.Rows[0][0].ToString();

                string comando = "UPDATE GDD_15.PUBLICACIONES SET N_ID_ESTADO = " + estadoID + " WHERE N_ID_PUBLICACION = " + idPubli;
                DataTable dt6 = (new ConexionSQL()).cargarTablaSQL(comando);
                inicializar();
            }
            else if (estado == "Activa")
            {
                MessageBox.Show("No se puede activar una publicación Activa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            string estado = row.Cells["Estado"].Value.ToString();
            string idPubli = row.Cells["Código"].Value.ToString();
            Int64 idPub = Convert.ToInt64(idPubli);
            if (estado == "Finalizada")
            {
                MessageBox.Show("No se puede finalizar un publicación Finalizada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (estado == "Pausada")
            {
                DataGridViewRow row1 = this.dataGridView1.SelectedRows[0];
                string tipo = row1.Cells["Tipo"].Value.ToString();
                if (tipo == "Subasta")
                {
                    MessageBox.Show("No se puede finalizar una subasta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string query3 = "SELECT N_ID_ESTADO FROM GDD_15.ESTADOS WHERE C_ESTADO = 'Finalizada'";
                    DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
                    string estadoID = dt3.Rows[0][0].ToString();

                    string comando = "UPDATE GDD_15.PUBLICACIONES SET N_ID_ESTADO = " + estadoID + " WHERE N_ID_PUBLICACION = " + idPubli;
                    DataTable dt6 = (new ConexionSQL()).cargarTablaSQL(comando);
                    inicializar();
                }
            }
            else if (estado == "Activa")
            {
                DataGridViewRow row1 = this.dataGridView1.SelectedRows[0];
                string tipo = row1.Cells["Tipo"].Value.ToString();
                if (tipo == "Subasta")
                {
                    MessageBox.Show("No se puede finalizar una subasta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string query3 = "SELECT N_ID_ESTADO FROM GDD_15.ESTADOS WHERE C_ESTADO = 'Finalizada'";
                    DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
                    string estadoID = dt3.Rows[0][0].ToString();

                    string comando = "UPDATE GDD_15.PUBLICACIONES SET N_ID_ESTADO = " + estadoID + " WHERE N_ID_PUBLICACION = " + idPubli;
                    DataTable dt6 = (new ConexionSQL()).cargarTablaSQL(comando);
                    inicializar();
                }
            }
        }

        private void buttonPausar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            string estado = row.Cells["Estado"].Value.ToString();
            string idPubli = row.Cells["Código"].Value.ToString();
            if (estado == "Finalizada")
            {
                MessageBox.Show("No se puede pausar un publicación Finalizada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (estado == "Pausada")
            {
                MessageBox.Show("No se puede pausar un publicación Pausada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (estado == "Activa")
            {
                string query3 = "SELECT N_ID_ESTADO FROM GDD_15.ESTADOS WHERE C_ESTADO = 'Pausada'";
                DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
                string estadoID = dt3.Rows[0][0].ToString();

                string comando = "UPDATE GDD_15.PUBLICACIONES SET N_ID_ESTADO = " + estadoID + " WHERE N_ID_PUBLICACION = " + idPubli;
                DataTable dt6 = (new ConexionSQL()).cargarTablaSQL(comando);
                inicializar();
            }
        }
    }
}

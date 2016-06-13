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
    public partial class MisBorradores : Form
    {
        String nombreUsuario;
        public MisBorradores(String nombreUsuarioPasado)
        {
            InitializeComponent();

            nombreUsuario = nombreUsuarioPasado;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            CompletadorDeTablas.hacerQuery("SELECT N_ID_PUBLICACION 'Código', V.D_DESCRIP Visibilidad, C_ESTADO Estado, C_TIPO Tipo, P.D_DESCRED Descripción, N_STOCK Stock, N_PRECIO Precio, C_PERMITE_ENVIO Envío, P.F_INICIO 'Fecha Inicio', P.F_VENCIMIENTO 'Fecha Vencimiento' FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.TIPOS T ON (P.N_ID_TIPO = T.N_ID_TIPO) JOIN GDD_15.VISIBILIDADES V ON (P.C_VISIBILIDAD = V.C_VISIBILIDAD) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE C_ESTADO IN ('Borrador') AND C_USUARIO_NOMBRE = '" + nombreUsuarioPasado + "'", ref dataGridView1);
            
        }

        private void MisBorradores_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                string value1 = row.Cells["Código"].Value.ToString();
                string tipo = row.Cells["Tipo"].Value.ToString();
                Int64 idPubli = Convert.ToInt64(value1);
                Generar_Publicación.CrearPublicacion crearPubli = new Generar_Publicación.CrearPublicacion(tipo, nombreUsuario, idPubli);
                crearPubli.Show();
            }
            else
            {
                MessageBox.Show("Por favor, elija una publicación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                string value1 = row.Cells["Código"].Value.ToString();
                Int64 idPubli = Convert.ToInt64(value1);
                if ((MessageBox.Show("¿Desea borrar el borrador?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string borrarBorrador = "DELETE FROM GDD_15.PUBLICACIONES WHERE N_ID_PUBLICACION = '" + idPubli + "'";
                    (new ConexionSQL()).ejecutarComandoSQL(borrarBorrador);
                    MessageBox.Show("Borrador eliminado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Por favor, elija una publicación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}

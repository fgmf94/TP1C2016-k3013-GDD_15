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

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class OfertarPubli : Form
    {
        String nombreUsuario;
        Int64 idPubli;
        Form form;
        float oferta;
        public OfertarPubli(Int64 idPubliPasado, String nombreUsuarioPasado, Form formPasado)
        {
            InitializeComponent();
            nombreUsuario = nombreUsuarioPasado;
            idPubli = idPubliPasado;
            form = formPasado;
            inicializar();
        }

        public void inicializar()
        {
            txtCodPub.Text = idPubli.ToString();
            String idPubliText = idPubli.ToString();

            string query2 = "SELECT C_USUARIO_NOMBRE, P.D_DESCRED, R.D_DESCRED Rubro, N_PRECIO, F_VENCIMIENTO, C_PERMITE_ENVIO FROM GDD_15.PUBLICACIONES P JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE N_ID_PUBLICACION = '" + idPubliText + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string nombreUsuarioPubli = dt2.Rows[0][0].ToString();
            txtNombreUsuario.Text = nombreUsuarioPubli;
            string descripPubli = dt2.Rows[0][1].ToString();
            txtDescrip.Text = descripPubli;
            string rubro = dt2.Rows[0][2].ToString();
            txtRubro.Text = rubro;
            string precio = dt2.Rows[0][3].ToString();
            txtPrecioInicial.Text = precio;
            string fechaVen = dt2.Rows[0][4].ToString();
            dateFechaVen.Text = fechaVen;
            string envio = dt2.Rows[0][5].ToString();
            if (envio == "SI")
            {

            }
            else if (envio == "NO")
            {
                chkEnvio.Enabled = false;
            }

            string  idClienteOfertaAnerior = "";

            string query = "SELECT MAX(N_MONTO) FROM GDD_15.PUBLICACIONES P JOIN GDD_15.OFERTAS O ON (P.N_ID_PUBLICACION = O.N_ID_PUBLICACION) WHERE P.N_ID_PUBLICACION = '" + idPubliText + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string ofertaAnterior = dt.Rows[0][0].ToString();

            string query3 = "SELECT N_ID_CLIENTE FROM GDD_15.PUBLICACIONES P JOIN GDD_15.OFERTAS O ON (P.N_ID_PUBLICACION = O.N_ID_PUBLICACION) WHERE P.N_ID_PUBLICACION = '" + idPubliText + "' AND N_MONTO = '" + ofertaAnterior + "'";
            DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
            if (dt3.Rows.Count != 0)
            {
                idClienteOfertaAnerior = dt3.Rows[0][0].ToString();
            }
            string query5 = "SELECT N_ID_USUARIO FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + nombreUsuario + "'";
            DataTable dt5 = (new ConexionSQL()).cargarTablaSQL(query5);
            string usuarioID = dt5.Rows[0][0].ToString();

            if (idClienteOfertaAnerior == usuarioID)
            {
                MessageBox.Show("La última oferta fue realizada por usted entonces no puede volver a ofertar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                buttonGuardar.Enabled = false;
                chkEnvio.Enabled = false;
                txtOferta.Enabled = false;
            }

            if (ofertaAnterior == "")
            {
                txtOfertaAnterior.Text = "0";
            }
            else
            {
                txtOfertaAnterior.Text = ofertaAnterior;
            }
            txtOferta.Text = "0";
        }

        private void OfertarPubli_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!validaciones())
            {
                return;
            }

            //Validar que no esta vencida

            if ((MessageBox.Show("¿Desea realizar la oferta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                ofertar();
                MessageBox.Show("Oferta realizada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                form.Close();
                this.Close();
            }
            
        }

        private void ofertar()
        {
            string query5 = "SELECT N_ID_USUARIO FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + nombreUsuario + "'";
            DataTable dt5 = (new ConexionSQL()).cargarTablaSQL(query5);
            string usuarioID = dt5.Rows[0][0].ToString();

            String envio;

            if (chkEnvio.Checked == true)
            {
                envio = "SI";
            }
            else
            {
                envio = "NO";
            }

            string agregarOferta = "INSERT INTO GDD_15.OFERTAS (N_ID_PUBLICACION, N_ID_CLIENTE, F_ALTA, N_MONTO, C_ENVIO) VALUES ('" + idPubli + "', '" + usuarioID + "', '" + DateTime.Now.ToString() + "', '" + txtOferta.Text + "', '" + envio + "') ";
            (new ConexionSQL()).ejecutarComandoSQL(agregarOferta);
        }

        private bool validaciones()
        {
            oferta = (new Validaciones()).validacionStringAFloat(txtOferta.Text, "Error Oferta");

            if (oferta == -1)
            {
                return false;
            }

            float ofertaAnterior = float.Parse(txtOfertaAnterior.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);

            if (oferta <= ofertaAnterior)
            {
                MessageBox.Show("La nueva oferta debe ser mayor a la anterior", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}

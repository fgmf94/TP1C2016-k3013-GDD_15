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
    public partial class ComprarPubli : Form
    {
        Int64 idPubli;
        String nombreUsuario;
        Form form;
        public ComprarPubli(Int64 idPubliPasado, String nombreUsuarioPasado, Form formPasado)
        {
            InitializeComponent();
            idPubli = idPubliPasado;
            inicializar();
            nombreUsuario = nombreUsuarioPasado;
            form = formPasado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (txtStockCant.Text == "0")
            {
                MessageBox.Show("La cantidad no puede ser 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Validación publi no vencida

            if ((MessageBox.Show("¿Desea realizar la comprar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                realizarCompra();
                MessageBox.Show("Compra realizada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                form.Close();
                this.Close();
            }
        }

        private void realizarCompra()
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

            string comando = "execute GDD_15.COMPRAR '" + idPubli + "', '" + usuarioID + "', '" + DateTime.Now.ToString() + "', '" + Convert.ToInt16(txtStockCant.Text) + "', '" + envio + "'";
            DataTable dt6 = (new ConexionSQL()).cargarTablaSQL(comando);
        }

        private void inicializar()
        {
            txtCodPub.Text = idPubli.ToString();
            String idPubliText = idPubli.ToString();

            string query2 = "SELECT C_USUARIO_NOMBRE, P.D_DESCRED, R.D_DESCRED Rubro, N_PRECIO, N_STOCK, C_PERMITE_ENVIO FROM GDD_15.PUBLICACIONES P JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE N_ID_PUBLICACION = '" + idPubliText + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string nombreUsuarioPubli = dt2.Rows[0][0].ToString();
            txtNombreUsuario.Text = nombreUsuarioPubli;
            string descripPubli = dt2.Rows[0][1].ToString();
            txtDescrip.Text = descripPubli;
            string rubro = dt2.Rows[0][2].ToString();
            txtRubro.Text = rubro;
            string precio = dt2.Rows[0][3].ToString();
            txtPrecio.Text = precio;
            string stock = dt2.Rows[0][4].ToString();
            txtStockDisp.Text = stock;
            string envio = dt2.Rows[0][5].ToString();
            if(envio == "SI")
            {

            } else if (envio == "NO")
            {
                chkEnvio.Enabled = false;
            }

            txtTotal.Text = "0";
            txtStockCant.Text = "1";
        }

        private void txtStockCant_TextChanged(object sender, EventArgs e)
        {
            if (txtStockCant.Text == "")
            {
                txtTotal.Text = "0";
                return;
            }

            int stockInt;

            try
            {
                stockInt = Convert.ToInt16(txtStockCant.Text);
            }
            catch
            {
                MessageBox.Show("El número de stock debe ser un entero menor a 32767", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockCant.Text = "1";
                return;
            }

            if (stockInt > Convert.ToInt16(txtStockDisp.Text))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock disponible", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockCant.Text = "1";
                return;
            }

            float precioFloat = float.Parse(txtPrecio.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            txtTotal.Text = (precioFloat * stockInt).ToString();
        }
    }
}

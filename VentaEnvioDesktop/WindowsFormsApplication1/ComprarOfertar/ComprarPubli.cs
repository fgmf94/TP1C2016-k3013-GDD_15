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
        string idCli;
        public ComprarPubli(Int64 idPubliPasado, String nombreUsuarioPasado, Form formPasado)
        {
            InitializeComponent();
            idPubli = idPubliPasado;
            inicializar();
            nombreUsuario = nombreUsuarioPasado;
            form = formPasado;

            calcularReputacion();
        }

        private void calcularReputacion()
        {
            string query5 = "SELECT N_ID_USUARIO FROM GDD_15.PUBLICACIONES WHERE N_ID_PUBLICACION = '" + idPubli + "'";
            DataTable dt5 = (new ConexionSQL()).cargarTablaSQL(query5);
            string usuarioID = dt5.Rows[0][0].ToString();

            string query = "SELECT COUNT(*), SUM(C_CALIFICACION) FROM GDD_15.PUBLICACIONES P JOIN GDD_15.OFERTAS O ON (O.N_ID_PUBLICACION = P.N_ID_PUBLICACION) JOIN GDD_15.CALIFICACIONES C ON (C.N_ID_OFERTA = O.N_ID_OFERTA) WHERE P.N_ID_USUARIO = '" + usuarioID + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            Int64 cantOfertasCalif = Convert.ToInt64(dt.Rows[0][0].ToString());
            Int64 estrellasOfertas;
            if (cantOfertasCalif != 0)
            {
                estrellasOfertas = Convert.ToInt64(dt.Rows[0][1].ToString());
            }
            else
            {
                estrellasOfertas = 0;
            }

            string query2 = "SELECT COUNT(*), SUM(C_CALIFICACION) FROM GDD_15.PUBLICACIONES P JOIN GDD_15.COMPRAS CO ON (CO.N_ID_PUBLICACION = P.N_ID_PUBLICACION) JOIN GDD_15.CALIFICACIONES CA ON (CA.N_ID_COMPRA = CO.N_ID_COMPRA) WHERE P.N_ID_USUARIO = '" + usuarioID + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            Int64 cantComprasCalif = Convert.ToInt64(dt2.Rows[0][0].ToString());
            Int64 estrellasCompras;
            if(cantComprasCalif != 0)
            {
                estrellasCompras = Convert.ToInt64(dt2.Rows[0][1].ToString());
            } 
            else
            {
                estrellasCompras = 0;
            }

            if (cantComprasCalif + cantOfertasCalif == 0)
            {
                txtReputacion.Text = "No tiene calificaciones";
                labelSobre100.Hide();
                return;
            }

            float promedio = (estrellasOfertas + estrellasCompras) / (cantComprasCalif + cantOfertasCalif);

            float factor = factorDeAjuste(cantComprasCalif + cantOfertasCalif);

            float reputacion = (promedio - 1) * 25 * factor;

            if (reputacion > 100)
            {
                reputacion = 100;
            }

            txtReputacion.Text = reputacion.ToString();
        }

        private float factorDeAjuste(Int64 cantidadCalif)
        {
            Int64 i = 0;
            float factor = 0.5F;

            while (i < cantidadCalif - 1)
            {
                factor = factor + ((float)1 / (float)Convert.ToInt64(Math.Pow(2, i + 2)));
                i++;
            }

            return factor + 0.1F;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (txtStockCant.Text == "")
            {
                MessageBox.Show("Complete el campo cantidad", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                string query5 = "SELECT (SELECT COUNT(*) FROM GDD_15.OFERTAS WHERE N_ID_CLIENTE = '" + idCli + "' AND C_GANADOR = 'SI') + (SELECT COUNT(*) FROM GDD_15.COMPRAS WHERE N_ID_CLIENTE = '" + idCli + "') - (SELECT COUNT(*) FROM GDD_15.CALIFICACIONES WHERE N_ID_CLIENTE = '" + idCli + "')";
                DataTable dt5 = (new ConexionSQL()).cargarTablaSQL(query5);
                string comprasSinCalif = dt5.Rows[0][0].ToString();
                Int32 cantComprasSinCalif = Convert.ToInt32(comprasSinCalif);
                if (cantComprasSinCalif < 4)
                {

                }
                else
                {
                    MessageBox.Show("Como tiene más de 3 publicaciones (" + cantComprasSinCalif + ") sin calificar no puede realizar compras u ofertas hasta que califique todas sus publicaciones", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string query7 = "UPDATE GDD_15.CLIENTES SET N_COMPRA_HABILITADA = '0' WHERE N_ID_USUARIO = '" + idCli + "'";
                    DataTable dt7 = (new ConexionSQL()).cargarTablaSQL(query7);
                }

                form.Close();
                this.Close();
            }
        }

        private void realizarCompra()
        {
            string query5 = "SELECT N_ID_USUARIO FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + nombreUsuario + "'";
            DataTable dt5 = (new ConexionSQL()).cargarTablaSQL(query5);
            string usuarioID = dt5.Rows[0][0].ToString();

            idCli = usuarioID;

            String envio;

            if (chkEnvio.Checked == true)
            {
                envio = "SI";
            }
            else
            {
                envio = "NO";
            }

            string comando = "execute GDD_15.COMPRAR '" + idPubli + "', '" + usuarioID + "', '" + DateTime.Parse(Program.nuevaFechaSistema()).ToString() + "', '" + Convert.ToInt32(txtStockCant.Text) + "', '" + envio + "'";
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

            Int32 stockInt;

            try
            {
                stockInt = Convert.ToInt32(txtStockCant.Text);
            }
            catch
            {
                MessageBox.Show("El número de stock debe ser un entero menor a 2147483647", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockCant.Text = "1";
                return;
            }

            if (stockInt > Convert.ToInt32(txtStockDisp.Text))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock disponible", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockCant.Text = "1";
                return;
            }

            float precioFloat = float.Parse(txtPrecio.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            txtTotal.Text = (precioFloat * stockInt).ToString();
        }

        private void txtReputacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class CrearPublicacion : Form
    {
        String tipo;
        String nombreUsuario;
        Int64 numeroPub;
        Int64 idPublicacion;
        Form form;
        public CrearPublicacion(String formatoPasado, String nombreUsuarioPasado, Int64 numero, Form formPasado)
        {
            InitializeComponent();
            tipo = formatoPasado;
            idPublicacion = numero;
            form = formPasado;

            if (formatoPasado == "Subasta")
            {
                labelTitulo.Text = "Crear Publicación de Subasta";
                labelPrecio.Text = "Precio Inicial";
                txtStock.ReadOnly = true;
                txtStock.Text = "1";
            }

            DateTime diaDeHoy = DateTime.Parse(Program.nuevaFechaSistema());
            dateFechaVen.Text = diaDeHoy.ToString();

            string query = "SELECT concat(D_DESCRIP, ' $', N_COMISION_PRECIO) AS VISI FROM GDD_15.VISIBILIDADES WHERE N_HABILITADO = 1";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            comboBoxVisi.DataSource = dt.DefaultView;
            comboBoxVisi.ValueMember = "VISI";

            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL("SELECT D_DESCRED FROM GDD_15.RUBROS");
            comboBoxRubro.DataSource = dt2.DefaultView;
            comboBoxRubro.ValueMember = "D_DESCRED";

            if (idPublicacion == 0)
            {
                string query3 = "SELECT TOP 1 N_ID_PUBLICACION FROM GDD_15.PUBLICACIONES ORDER BY N_ID_PUBLICACION DESC ";
                DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
                if (dt3.Rows.Count == 0)
                {
                    txtCodPub.Text = "1";
                    numeroPub = 1;
                }
                else
                {
                    string idText = dt3.Rows[0][0].ToString();
                    Int64 idPub = Convert.ToInt64(idText);
                    numeroPub = idPub + 1;
                    txtCodPub.Text = numeroPub.ToString();
                }
            }
            else
            {
                txtCodPub.Text = idPublicacion.ToString();
                string query3 = "SELECT concat(V.D_DESCRIP, ' $', N_COMISION_PRECIO), P.D_DESCRED, N_STOCK, N_PRECIO, R.D_DESCRED, P.F_VENCIMIENTO, C_PERMITE_ENVIO FROM GDD_15.PUBLICACIONES P JOIN GDD_15.VISIBILIDADES V ON (P.C_VISIBILIDAD = V.C_VISIBILIDAD) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE N_ID_PUBLICACION = '" + idPublicacion + "'";
                DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
                string visibilidad = dt3.Rows[0][0].ToString();
                comboBoxVisi.Text = visibilidad;
                string descripcion = dt3.Rows[0][1].ToString();
                txtDescrip.Text = descripcion;
                string stock = dt3.Rows[0][2].ToString();
                txtStock.Text = stock;
                string precio = dt3.Rows[0][3].ToString();
                txtPrecio.Text = precio;
                string rubro = dt3.Rows[0][4].ToString();
                comboBoxRubro.Text = rubro;
                string fechaVen = dt3.Rows[0][5].ToString();
                dateFechaVen.Text = fechaVen;
                string envio = dt3.Rows[0][6].ToString();
                if (envio == "SI")
                {
                    chkEnvio.Checked = true;
                }
                else
                {
                    chkEnvio.Checked = false;
                }
                button1.Text = "Modificar borrador";
            }

            nombreUsuario = nombreUsuarioPasado;
        }

        private void CrearCompra_Load(object sender, EventArgs e)
        {

        }

        private void txtNombreVisibilidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            //Generar Publicación

            if (!validaciones())
            {
                return;
            }

            if (idPublicacion == 0)
            {
                if ((MessageBox.Show("¿Desea generar la publicación?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    crearPublicacion("Activa");
                    MessageBox.Show("Publicación " + numeroPub + " generada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
            }
            else
            {
                if ((MessageBox.Show("¿Desea generar la publicación?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    modifPublicacion("Activa");
                    MessageBox.Show("Publicación " + idPublicacion + " generada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    form.Close();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Generar Borrador

            if (!validaciones())
            {
                return;
            }

            if (idPublicacion == 0)
            {
                if ((MessageBox.Show("¿Desea generar el borrador?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    crearPublicacion("Borrador");
                    MessageBox.Show("Borrador " + numeroPub + " generado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
            }
            else
            {
                if ((MessageBox.Show("¿Desea modificar el borrador?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    modifPublicacion("Borrador");
                    MessageBox.Show("Borrador " + idPublicacion + " modificado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    form.Close();
                }
            }
        }

        public void modifPublicacion(String estado)
        {
            string query3 = "SELECT N_ID_ESTADO FROM GDD_15.ESTADOS WHERE C_ESTADO = '" + estado + "'";
            DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
            string estadoID = dt3.Rows[0][0].ToString();

            string query = "SELECT N_ID_TIPO FROM GDD_15.TIPOS WHERE C_TIPO = '" + tipo + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string tipoID = dt.Rows[0][0].ToString();

            string query2 = "SELECT N_ID_RUBRO FROM GDD_15.RUBROS WHERE D_DESCRED = '" + comboBoxRubro.Text + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string rubroID = dt2.Rows[0][0].ToString();

            int index = comboBoxVisi.Text.IndexOf("$");
            String visibilidad = comboBoxVisi.Text.Substring(0, index);

            string query4 = "SELECT C_VISIBILIDAD FROM GDD_15.VISIBILIDADES WHERE D_DESCRIP = '" + visibilidad + "'";
            DataTable dt4 = (new ConexionSQL()).cargarTablaSQL(query4);
            string visiID = dt4.Rows[0][0].ToString();

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

            string comando = "execute GDD_15.BORRADOR_A_ACTIVA '" + usuarioID + "', '" + rubroID + "', '" + visiID + "', '" + estadoID + "', '" + tipoID + "', '" + txtDescrip.Text + "', '" + txtStock.Text + "', '" + DateTime.Now.ToString() + "', '" + DateTime.Parse(dateFechaVen.Text).ToString() + "', '" + txtPrecio.Text + "', '" + envio + "', '" + idPublicacion + "'";
            DataTable dt6 = (new ConexionSQL()).cargarTablaSQL(comando);
        }

        public void crearPublicacion(String estado)
        {
            string query3 = "SELECT N_ID_ESTADO FROM GDD_15.ESTADOS WHERE C_ESTADO = '" + estado + "'";
            DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
            string estadoID = dt3.Rows[0][0].ToString();

            string query = "SELECT N_ID_TIPO FROM GDD_15.TIPOS WHERE C_TIPO = '" + tipo + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string tipoID = dt.Rows[0][0].ToString();

            string query2 = "SELECT N_ID_RUBRO FROM GDD_15.RUBROS WHERE D_DESCRED = '" + comboBoxRubro.Text + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string rubroID = dt2.Rows[0][0].ToString();

            int index = comboBoxVisi.Text.IndexOf("$");
            String visibilidad = comboBoxVisi.Text.Substring(0, index);

            string query4 = "SELECT C_VISIBILIDAD FROM GDD_15.VISIBILIDADES WHERE D_DESCRIP = '" + visibilidad + "'";
            DataTable dt4 = (new ConexionSQL()).cargarTablaSQL(query4);
            string visiID = dt4.Rows[0][0].ToString();

            string query5 = "SELECT N_ID_USUARIO FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + nombreUsuario + "'";
            DataTable dt5 = (new ConexionSQL()).cargarTablaSQL(query5);
            string usuarioID = dt5.Rows[0][0].ToString();

            String envio;

            if (chkEnvio.Checked == true)
            {
                envio = "SI";
            } else 
            {
                envio = "NO";
            }

            //string agregarPublicacion = "INSERT INTO GDD_15.PUBLICACIONES(N_ID_USUARIO, N_ID_RUBRO, C_VISIBILIDAD, N_ID_ESTADO, N_ID_TIPO, D_DESCRED, N_STOCK, F_INICIO, F_VENCIMIENTO, N_PRECIO, C_PERMITE_ENVIO) VALUES ('" + usuarioID + "', '" + rubroID + "', '" + visiID + "', '" + estadoID + "', '" + tipoID + "', '" + txtDescrip.Text + "', '" + txtStock.Text + "', '" + DateTime.Now.ToString() + "', '" + DateTime.Parse(dateFechaVen.Text).ToString() + "', '" + txtPrecio.Text + "', '" + envio + "')";
            //(new ConexionSQL()).ejecutarComandoSQL(agregarPublicacion);

            string comando = "execute GDD_15.AGREGARPUBLICACION '" + usuarioID + "', '" + rubroID + "', '" + visiID + "', '" + estadoID + "', '" + tipoID + "', '" + txtDescrip.Text + "', '" + txtStock.Text + "', '" + DateTime.Parse(Program.nuevaFechaSistema()).ToString() + "', '" + DateTime.Parse(dateFechaVen.Text).ToString() + "', '" + txtPrecio.Text + "', '" + envio + "'";
            DataTable dt6 = (new ConexionSQL()).cargarTablaSQL(comando);
        }

        private bool validaciones()
        {
            if (txtDescrip.Text == "" || txtPrecio.Text == "" || txtStock.Text == "" || dateFechaVen.Value.ToString() == "")
            {
                MessageBox.Show("Debe completar todos los campos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtDescrip.Text.Length >= 100)
            {
                MessageBox.Show("La descripción debe tener menos de 100 caracteres", "Error Descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Int32 stock;

            try
            {
                stock = Convert.ToInt32(txtStock.Text);
            }
            catch
            {
                MessageBox.Show("El número de stock debe ser un entero menor a 2147483647", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (stock < 1)
            {
                MessageBox.Show("El número de documento debe ser mayor o igual a 1", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            float precio = (new Validaciones()).validacionStringAFloat(txtPrecio.Text, "Error Precio");

            if (precio == -1)
            {
                return false;
            }

            DateTime diaDeHoy = DateTime.Parse(Program.nuevaFechaSistema());

            if (diaDeHoy > DateTime.Parse(dateFechaVen.Text))
            {
                MessageBox.Show("La fecha de vencimiento tiene que ser posterior al día de hoy", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxVisi.Text == "Gratis $0" && chkEnvio.Checked == true)
            {
                MessageBox.Show("La visibilidad Gratis no puede tener envío", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void comboBoxVisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVisi.Text == "Gratis $0")
            {
                chkEnvio.Checked = false;
                chkEnvio.Enabled = false;
            }
            else
            {
                chkEnvio.Enabled = true;
            }
        }
    }
}

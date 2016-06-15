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

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class ModificarDatosCliente : Form
    {
        Form form1;
        Form form2;
        Usuario usuario;
        public ModificarDatosCliente(String usuarioPasado, Form formPasada1, Form formPasada2)
        {
            InitializeComponent();
            form1 = formPasada1;
            form2 = formPasada2;

            DateTime diaDeHoy = DateTime.Parse(Program.nuevaFechaSistema());
            dateFechaNac.Text = diaDeHoy.ToString();

            usuario = new Usuario();
            usuario.username = usuarioPasado;

            string query = "SELECT N_ID_USUARIO FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + usuarioPasado + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string idUsuario = dt.Rows[0][0].ToString();
            string query2 = "SELECT *  FROM GDD_15.CLIENTES WHERE N_ID_USUARIO = '" + idUsuario + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string idDireccion = dt2.Rows[0][1].ToString();
            string tipoDoc = dt2.Rows[0][2].ToString();
            comboBoxTipoDoc.Text = tipoDoc;
            string numeroDoc = dt2.Rows[0][3].ToString();
            txtNumDoc.Text = numeroDoc;
            usuario.cliTipoDocumento = tipoDoc;
            usuario.cliNumeroDocumento = numeroDoc;
            string apellido = dt2.Rows[0][4].ToString();
            txtApellido.Text = apellido;
            string nombre = dt2.Rows[0][5].ToString();
            txtNombre.Text = nombre;
            string fechaNac = dt2.Rows[0][6].ToString();
            dateFechaNac.Text = fechaNac;
            string telefono = dt2.Rows[0][7].ToString();
            txtTel.Text = telefono;
            string correo = dt2.Rows[0][8].ToString();
            txtMail.Text = correo;
            string query3 = "SELECT *  FROM GDD_15.DIRECCIONES WHERE N_ID_DIRECCION = '" + idDireccion + "'";
            DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
            string calle = dt3.Rows[0][1].ToString();
            txtCalle.Text = calle;
            string numero = dt3.Rows[0][2].ToString();
            txtNumeroCalle.Text = numero;
            string piso = dt3.Rows[0][3].ToString();
            txtPiso.Text = piso;
            string depto = dt3.Rows[0][4].ToString();
            txtDepto.Text = depto;
            string postal = dt3.Rows[0][5].ToString();
            txtCodPost.Text = postal;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!validacionesCliente())
            {
                return;
            }

            if ((MessageBox.Show("¿Realmente desea modificar el usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                modificarUsuario();
                MessageBox.Show("Usuario modificado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                form1.Close();
                form2.Close();
                this.Close();
            }
        }
            

        private void modificarUsuario()
        {
            usuario.cliNombre = txtNombre.Text;
            usuario.cliApellido = txtApellido.Text;
            usuario.cliTipoDocumento = comboBoxTipoDoc.Text;
            usuario.cliNumeroDocumento = txtNumDoc.Text;
            usuario.mail = txtMail.Text;
            usuario.telefono = Convert.ToInt64(txtTel.Text);
            usuario.calle = txtCalle.Text;
            usuario.numeroCalle = Convert.ToInt64(txtNumeroCalle.Text);
            usuario.piso = txtPiso.Text;
            usuario.depto = txtDepto.Text;
            usuario.codigoPostal = txtCodPost.Text;
            usuario.cliFechaNac = DateTime.Parse(dateFechaNac.Text).ToString();

            string query = "SELECT N_ID_USUARIO FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + usuario.username + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string usuarioID = dt.Rows[0][0].ToString(); 

            string query2 = "SELECT N_ID_DIRECCION FROM GDD_15.CLIENTES WHERE N_ID_USUARIO = '" + usuarioID + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string direccionID = dt2.Rows[0][0].ToString();
            
            string modifDireccion = "UPDATE GDD_15.DIRECCIONES SET C_CALLE = '" + usuario.calle + "', N_NUMERO = '" + usuario.numeroCalle + "', C_PISO ='" + usuario.piso + "', C_DEPTO = '" + usuario.depto + "', C_POSTAL = '" + usuario.codigoPostal + "' WHERE N_ID_DIRECCION = '" + direccionID + "'";
            (new ConexionSQL()).ejecutarComandoSQL(modifDireccion);

            string modifCliente = "UPDATE GDD_15.CLIENTES SET N_ID_USUARIO = '" + usuarioID + "', N_ID_DIRECCION = '" + direccionID + "', C_TIPO_DOCUMENTO = '" + usuario.cliTipoDocumento + "', N_DOCUMENTO = '" + usuario.cliNumeroDocumento + "', D_APELLIDOS = '" + usuario.cliApellido + "', D_NOMBRES = '" + usuario.cliNombre + "', F_NACIMIENTO = '" + usuario.cliFechaNac + "', N_TELEFONO = '" + usuario.telefono + "', C_CORREO = '" + usuario.mail + "' WHERE N_ID_USUARIO = '" + usuarioID + "'";
            (new ConexionSQL()).ejecutarComandoSQL(modifCliente);
        }

        private bool validacionesCliente()
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtCalle.Text == "" || comboBoxTipoDoc.Text == "" || txtNumDoc.Text == "" || txtMail.Text == "" || txtTel.Text == "" || txtCalle.Text == "" || txtNumeroCalle.Text == "" || txtCodPost.Text == "" || dateFechaNac.Value.ToString() == "")
            {
                MessageBox.Show("Debe completar todos los campos obligatorios", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPiso.Text == "" ^ txtDepto.Text == "")
            {
                MessageBox.Show("Debe completar el campo Piso y Departamento si hay alguno completado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPiso.Text == "" && txtDepto.Text == "")
            {
                usuario.piso = "NULL";
                usuario.depto = "NULL";
            }

            if (txtNombre.TextLength > 100)
            {
                MessageBox.Show("El nombre no debe superar los 100 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPiso.TextLength > 50)
            {
                MessageBox.Show("El piso no debe superar los 50 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtDepto.TextLength > 50)
            {
                MessageBox.Show("El departamento no debe superar los 50 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtNombre.TextLength > 100)
            {
                MessageBox.Show("El nombre no debe superar los 100 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtApellido.TextLength > 100)
            {
                MessageBox.Show("El apellido no debe superar los 100 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int numDoc;

            try
            {
                numDoc = Convert.ToInt32(txtNumDoc.Text);
            }
            catch
            {
                MessageBox.Show("El número de documento debe ser un entero menor a 2147483647", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numDoc < 1)
            {
                MessageBox.Show("El número de documento debe ser mayor o igual a 1", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtNumDoc.TextLength > 100)
            {
                MessageBox.Show("El número de documento no debe superar los 100 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtMail.TextLength > 50)
            {
                MessageBox.Show("El mail no debe superar los 50 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!(txtMail.Text.Contains("@")))
            {
                MessageBox.Show("El mail debe contener el carácter @", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Int64 numTel;
            try
            {
                numTel = Convert.ToInt64(txtTel.Text);
            }
            catch
            {
                MessageBox.Show("El número de téléfono debe ser un entero menor a 9223372036854775807", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numDoc < 1)
            {
                MessageBox.Show("El número de teléfono debe ser mayor o igual a 1", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtCalle.TextLength > 100)
            {
                MessageBox.Show("La calle no debe superar los 100 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Int64 numCalle;
            try
            {
                numCalle = Convert.ToInt64(txtNumeroCalle.Text);
            }
            catch
            {
                MessageBox.Show("El número de calle debe ser un entero menor a 9223372036854775807", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numCalle < 1)
            {
                MessageBox.Show("El número de calle debe ser mayor o igual a 1", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtCodPost.TextLength > 50)
            {
                MessageBox.Show("El código postal no debe superar los 50 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime diaDeHoy = DateTime.Now;

            if (diaDeHoy < DateTime.Parse(dateFechaNac.Text))
            {
                MessageBox.Show("La fecha de nacimiento tiene que ser anterior al día de hoy", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!(comboBoxTipoDoc.Text == usuario.cliTipoDocumento && txtNumDoc.Text == usuario.cliNumeroDocumento))
            {
                string query2 = "SELECT COUNT(*) FROM GDD_15.CLIENTES WHERE C_TIPO_DOCUMENTO = '" + comboBoxTipoDoc.Text + "' AND N_DOCUMENTO = '" + txtNumDoc.Text + "'";
                DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
                string cantidad = dt2.Rows[0][0].ToString();
                if (cantidad != "0")
                {
                    MessageBox.Show("Ya existe ese tipo y número de documento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }
    }
}

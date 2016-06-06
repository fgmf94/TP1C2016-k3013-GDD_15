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
    public partial class CrearCliente : Form
    {
        ABM_Usuario.CrearUsuario form;
        Usuario usuario;

        public CrearCliente(Usuario usuarioPasado, ABM_Usuario.CrearUsuario formPasada)
        {
            InitializeComponent();
            form = formPasada;
            usuario = usuarioPasado;
        }

        private void CrearCliente_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("¿Realmente desea cancelar la creación del Usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                form.Close();
                this.Close();
            }
            
        }

        private void buttonAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!validacionesCliente())
            {
                return;
            }

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

            string agregarUsuario = "INSERT INTO GDD_15.USUARIOS(C_USUARIO_NOMBRE,C_PASSWORD,N_PUBLICACION_GRATIS) VALUES ('" + usuario.username + "',(SELECT SUBSTRING(master.dbo.fn_varbintohexstr(HASHBYTES('SHA2_256','" + usuario.password + "')),3,250)),'SI')";
            (new ConexionSQL()).ejecutarComandoSQL(agregarUsuario);

            string asignarRol = "INSERT INTO GDD_15.ROLES_USUARIOS(N_ID_USUARIO, N_ID_ROL) SELECT tablaUsuarios.N_ID_USUARIO, tablaRoles.N_ID_ROL FROM GDD_15.USUARIOS tablaUsuarios, GDD_15.ROLES tablaRoles WHERE tablaRoles.C_ROL = 'Cliente' AND tablaUsuarios.C_USUARIO_NOMBRE = '" + usuario.username + "'";
            (new ConexionSQL()).ejecutarComandoSQL(asignarRol);

            string agregarDireccion = "INSERT INTO GDD_15.DIRECCIONES(C_CALLE, N_NUMERO, C_PISO, C_DEPTO, C_POSTAL) VALUES ('" + usuario.calle + "', '" + usuario.numeroCalle + "', '" + usuario.piso + "', '" + usuario.depto + "', '" + usuario.codigoPostal + "')";
            (new ConexionSQL()).ejecutarComandoSQL(agregarDireccion);

            string query2 = "SELECT N_ID_DIRECCION FROM GDD_15.DIRECCIONES WHERE C_CALLE = '" + usuario.calle + "' AND N_NUMERO = '" + usuario.numeroCalle + "' AND C_PISO = '" + usuario.piso + "' AND C_DEPTO = '" + usuario.depto + "' AND C_POSTAL = '" + usuario.codigoPostal + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string direccionID = dt2.Rows[0][0].ToString();

            string query = "SELECT N_ID_USUARIO FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + usuario.username + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string usuarioID = dt.Rows[0][0].ToString();

            string agregarCliente = "INSERT INTO GDD_15.CLIENTES(N_ID_USUARIO, N_ID_DIRECCION, C_TIPO_DOCUMENTO, N_DOCUMENTO, D_APELLIDOS, D_NOMBRES, F_NACIMIENTO, N_TELEFONO, C_CORREO) VALUES ('" + usuarioID + "', '" + direccionID + "', '" + usuario.cliTipoDocumento + "', '" + usuario.cliNumeroDocumento + "', '" + usuario.cliApellido + "', '" + usuario.cliNombre + "', '" + usuario.cliFechaNac + "', '" + usuario.telefono + "', '" + usuario.mail + "')";
            (new ConexionSQL()).ejecutarComandoSQL(agregarCliente);

            MessageBox.Show("Cliente agregado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
            form.Close();
            this.Close();
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

            if (txtPiso.Text == "" && txtDepto.Text == ""){
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
                MessageBox.Show("El número de documento debe ser un entero menor a 1000000000", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (txtMail.TextLength > 50){
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
                MessageBox.Show("El número de téléfono debe ser un entero menor a 100000000000000", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("El número de calle debe ser un entero menor a 100000000000000", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string query2 = "SELECT COUNT(*) FROM GDD_15.CLIENTES WHERE C_TIPO_DOCUMENTO = '" + comboBoxTipoDoc.Text + "' AND N_DOCUMENTO = '" + txtNumDoc.Text + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string cantidad = dt2.Rows[0][0].ToString();
            if (cantidad != "0")
            {
                MessageBox.Show("Ya existe ese tipo y número de documento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
                 
            return true;
        }

        private void txtNumDoc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

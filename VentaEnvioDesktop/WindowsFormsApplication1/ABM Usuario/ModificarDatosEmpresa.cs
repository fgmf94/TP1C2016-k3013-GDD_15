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
    public partial class ModificarDatosEmpresa : Form
    {
        Form form1;
        Form form2;
        Usuario usuario;
        
        public ModificarDatosEmpresa(String usuarioPasado, Form formPasado1, Form formPasado2)
        {
            InitializeComponent();
            form1 = formPasado1;
            form2 = formPasado2;
            usuario = new Usuario();

            usuario.username = usuarioPasado;

            string query = "SELECT N_ID_USUARIO FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + usuarioPasado + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string idUsuario = dt.Rows[0][0].ToString();
            string query2 = "SELECT *  FROM GDD_15.EMPRESAS WHERE N_ID_USUARIO = '" + idUsuario + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string idDireccion = dt2.Rows[0][2].ToString();
            string idRubro = dt2.Rows[0][1].ToString();
            string razonSoc = dt2.Rows[0][3].ToString();
            txtRazonSocial.Text = razonSoc;
            string ciudad = dt2.Rows[0][4].ToString();
            txtCiudad.Text = ciudad;
            string cuit = dt2.Rows[0][5].ToString();
            txtCuit.Text = cuit;
            usuario.empCuit = cuit;
            usuario.empRazonSocial = razonSoc;
            string nombreContacto = dt2.Rows[0][6].ToString();
            txtNombreContacto.Text = nombreContacto;
            string telefono = dt2.Rows[0][7].ToString();
            txtTel.Text = telefono;
            string correo = dt2.Rows[0][8].ToString();
            txtMail.Text = correo;
            string fecCre = dt2.Rows[0][9].ToString();
            dateFechaNac.Text = fecCre;
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

        private void ModificarDatosEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!validacionesEmpresa())
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
            usuario.empRazonSocial = txtRazonSocial.Text;
            usuario.empNombreContacto = txtNombreContacto.Text;
            usuario.empRubroPrincipal = comboBoxRubro.Text;
            usuario.empCuit = txtCuit.Text;
            usuario.empCiudad = txtCiudad.Text;
            usuario.mail = txtMail.Text;
            usuario.telefono = Convert.ToInt64(txtTel.Text);
            usuario.calle = txtCalle.Text;
            usuario.numeroCalle = Convert.ToInt64(txtNumeroCalle.Text);
            usuario.piso = txtPiso.Text;
            usuario.depto = txtDepto.Text;
            usuario.codigoPostal = txtCodPost.Text;
            usuario.empFechaCreacion = DateTime.Parse(dateFechaNac.Text).ToString();

            string query = "SELECT N_ID_USUARIO FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + usuario.username + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);
            string usuarioID = dt.Rows[0][0].ToString();

            string query2 = "SELECT N_ID_DIRECCION FROM GDD_15.EMPRESAS WHERE N_ID_USUARIO = '" + usuarioID + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string direccionID = dt2.Rows[0][0].ToString();

            string modifDireccion = "UPDATE GDD_15.DIRECCIONES SET C_CALLE = '" + usuario.calle + "', N_NUMERO = '" + usuario.numeroCalle + "', C_PISO ='" + usuario.piso + "', C_DEPTO = '" + usuario.depto + "', C_POSTAL = '" + usuario.codigoPostal + "' WHERE N_ID_DIRECCION = '" + direccionID + "'";
            (new ConexionSQL()).ejecutarComandoSQL(modifDireccion);

            string modifCliente = "UPDATE GDD_15.EMPRESAS SET N_ID_USUARIO = '" + usuarioID + "', N_ID_DIRECCION = '" + direccionID + "', C_RAZON_SOCIAL = '" + usuario.empRazonSocial + "', C_CIUDAD = '" + usuario.empCiudad + "', N_CUIT = '" + usuario.empCuit + "', D_NOMBRE_CONTACTO = '" + usuario.empNombreContacto + "', F_CREACION = '" + usuario.empFechaCreacion + "', N_TELEFONO = '" + usuario.telefono + "', C_CORREO = '" + usuario.mail + "' WHERE N_ID_USUARIO = '" + usuarioID + "'";
            (new ConexionSQL()).ejecutarComandoSQL(modifCliente);
        }

        private bool validacionesEmpresa()
        {
            if (txtRazonSocial.Text == "" || txtNombreContacto.Text == "" || txtCalle.Text == "" || txtCuit.Text == "" || txtMail.Text == "" || txtTel.Text == "" || txtCalle.Text == "" || txtNumeroCalle.Text == "" || txtCodPost.Text == "" || dateFechaNac.Value.ToString() == "" || txtCiudad.Text == "")
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
                usuario.piso = "-1";
                usuario.depto = "-1";
            }

            if (txtRazonSocial.TextLength > 100)
            {
                MessageBox.Show("La razón social no debe superar los 100 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtNombreContacto.TextLength > 100)
            {
                MessageBox.Show("El nombre de contacto no debe superar los 100 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (txtCuit.TextLength > 50)
            {
                MessageBox.Show("El CUIT no debe superar los 50 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!validacionCuit())
            {
                MessageBox.Show("El CUIT debe ser de tipo XX-XXXXXXXX-XX", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("El número de téléfono debe ser un entero menor a 100000000000000", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtCiudad.TextLength > 100)
            {
                MessageBox.Show("La ciudad no debe superar los 100 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (txtRazonSocial.Text != usuario.empRazonSocial)
            {
                string query2 = "SELECT COUNT(*) FROM GDD_15.EMPRESAS WHERE C_RAZON_SOCIAL = '" + txtRazonSocial.Text + "'";
                DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
                string cantidad = dt2.Rows[0][0].ToString();
                if (cantidad != "0")
                {
                    MessageBox.Show("Ya existe esa razón social", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (txtCuit.Text != usuario.empCuit)
            {
                string query3 = "SELECT COUNT(*) FROM GDD_15.EMPRESAS WHERE N_CUIT = '" + txtCuit.Text + "'";
                DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
                string cantidad2 = dt3.Rows[0][0].ToString();
                if (cantidad2 != "0")
                {
                    MessageBox.Show("Ya existe ese número de CUIT", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (comboBoxRubro.Text == "")
            {
                usuario.empRubroPrincipal = "-1";
            }

            return true;
        }

        public bool validacionCuit()
        {
            if (txtCuit.Text.Length == 14)
            {
                if (txtCuit.Text[2] != '-' || txtCuit.Text[11] != '-')
                {
                    return false;
                }

                StringBuilder sb = new StringBuilder(txtCuit.Text);
                sb[2] = '0';
                sb[11] = '0';
                string nuevoCuit = sb.ToString();

                Int64 cuil;

                try
                {
                    cuil = Convert.ToInt64(nuevoCuit);
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}

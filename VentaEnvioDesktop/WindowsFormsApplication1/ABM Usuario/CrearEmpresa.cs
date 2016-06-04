﻿using System;
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
    public partial class CrearEmpresa : Form
    {
        ABM_Usuario.CrearUsuario form;
        Usuario usuario;
        public CrearEmpresa(Usuario usuarioPasado, ABM_Usuario.CrearUsuario formPasada)
        {
            InitializeComponent();
            form = formPasada;
            usuario = usuarioPasado;
        }

        private void CrearEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
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

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            if (!validacionesEmpresa())
            {
                return;
            }

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

            //Inserto los datos en la BD (to do)

            MessageBox.Show("Empresa agregada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
            form.Close();
            this.Close();
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

            //Se podrían hacer más validaciones del CUIT
            
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

            string query2 = "SELECT COUNT(*) FROM GDD_15.EMPRESAS WHERE C_RAZON_SOCIAL = '" + txtRazonSocial.Text + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string cantidad = dt2.Rows[0][0].ToString();
            if (cantidad != "0")
            {
                MessageBox.Show("Ya existe esa razón social", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string query3 = "SELECT COUNT(*) FROM GDD_15.EMPRESAS WHERE N_CUIT = '" + txtCuit.Text + "'";
            DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
            string cantidad2 = dt3.Rows[0][0].ToString();
            if (cantidad2 != "0")
            {
                MessageBox.Show("Ya existe ese número de CUIT", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxRubro.Text == "")
            {
                usuario.empRubroPrincipal = "-1";
            }

            return true;
        }
    }
}

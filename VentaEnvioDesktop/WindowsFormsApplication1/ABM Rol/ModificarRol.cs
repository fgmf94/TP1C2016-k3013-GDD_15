﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MercadoEnvio.Dominio;
using MercadoEnvio.Utils;

namespace WindowsFormsApplication1.ABM_Rol
{
    public partial class ModificarRol : Form
    {
        String rolPasado;
        ABM_Rol.ElegirRol form;

        public ModificarRol(String rol, ABM_Rol.ElegirRol formElegirRol)
        {
            InitializeComponent();
            rolPasado = rol;
            form = formElegirRol;

            string comando = "SELECT * FROM GDD_15.FUNCIONALIDADES";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);

            chkListaFuncionalidades.Items.Clear();
            for (int i = 0; i <= (dt.Rows.Count - 1); i++)
            {
                int idf = Convert.ToInt32(dt.Rows[i][0]);
                chkListaFuncionalidades.Items.Insert(i, new Funcionalidades(idf, dt.Rows[i][1].ToString(), this));
            }

            //cargo el nombre y si esta habilitado el rol
            txtNombreRol.Text = rolPasado;
            string query2 = "SELECT COUNT(*) FROM GDD_15.ROLES WHERE C_ROL = '" + rolPasado + "' AND F_BAJA IS NULL";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string habilitado = dt2.Rows[0][0].ToString();
            if(habilitado == "1"){
                chkHabilitado.Checked = true;
            }else{
            chkHabilitado.Checked = false;
            }

            //cargo las funcionalidades del rol
            string qfuncion = "SELECT F.D_DESCRED FROM GDD_15.FUNCIONALIDADES_ROLES FR JOIN GDD_15.ROLES R ON (R.N_ID_ROL = FR.N_ID_ROL) JOIN GDD_15.FUNCIONALIDADES F ON (F.N_ID_FUNCIONALIDAD = FR.N_ID_FUNCIONALIDAD) WHERE R.C_ROL = '" + rolPasado + "' AND FR.F_BAJA IS NULL";
            DataTable dtfunciones = (new ConexionSQL()).cargarTablaSQL(qfuncion);

            List<string> servicios = new List<string>();

            //--cargo mi lista
            for (int i = 0; i <= (dtfunciones.Rows.Count - 1); i++)
            {
                servicios.Add(dtfunciones.Rows[i][0].ToString());
            }

            //--Comparo con loscheckElements
            for (int i = 0; i <= (chkListaFuncionalidades.Items.Count - 1); i++)
            {
                if (servicios.Contains(chkListaFuncionalidades.Items[i].ToString()))
                {
                    chkListaFuncionalidades.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    chkListaFuncionalidades.SetItemCheckState(i, CheckState.Unchecked);
                }

            }
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void chkListaFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSeleccionarTodo_Click(object sender, EventArgs e)
        {

        }

        private void btSeleccionarTodo_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i <= chkListaFuncionalidades.Items.Count - 1; i++)
            {
                chkListaFuncionalidades.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkListaFuncionalidades_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void txtNombreRol_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            if (txtNombreRol.Text.Equals(string.Empty))
            {
                MessageBox.Show("Falta agregar nombre", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (chkListaFuncionalidades.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Falta elegir funcionalidades", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            };

            if (txtNombreRol.Text != rolPasado)
            {
                if (validacionNombreExistente())
                {
                    return;
                }
            }

            if ((MessageBox.Show("¿Realmente desea modificar el rol " + rolPasado + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                  modificarRol(rolPasado);
                  MessageBox.Show("Rol " + rolPasado + " modificado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                  this.Close();
                  form.Close();
            }
        }

        private bool validacionNombreExistente()
        {
            string comando = "SELECT * FROM  GDD_15.ROLES WHERE C_ROL = '" + txtNombreRol.Text + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);
            if (dt.Rows.Count != 0)
            {
                MessageBox.Show("El nombre de rol ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void modificarRol(String rol)
        {
            // (to do)
        }
    }
}
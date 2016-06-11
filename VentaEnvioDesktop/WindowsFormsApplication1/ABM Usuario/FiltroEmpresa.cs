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

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class FiltroEmpresa : Form
    {
        String formato;
        String wheres;
        public FiltroEmpresa(String formatoPasado)
        {
            InitializeComponent();
            formato = formatoPasado;
            inicializar();
            wheres = "";
        }

        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            inicializar();
        }

        private void inicializar()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            txtCuit.Text = "";
            txtEmail.Text = "";
            txtRazonSoc.Text = "";
            CompletadorDeTablas.hacerQuery("SELECT C_USUARIO_NOMBRE Username, C_RAZON_SOCIAL 'Razón Social', N_CUIT CUIT, C_CORREO Mail FROM GDD_15.USUARIOS U JOIN GDD_15.EMPRESAS E ON (U.N_ID_USUARIO = E.N_ID_USUARIO)", ref dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                string value1 = row.Cells["Username"].Value.ToString();
                ABM_Usuario.ElegirUsuario form = new ABM_Usuario.ElegirUsuario(formato, value1);
                this.Close();
                form.Show();
            }
            else
            {
                MessageBox.Show("Por favor, elija una fila", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            if (txtRazonSoc.Text == "" && txtCuit.Text == "" && txtEmail.Text == "")
            {
                MessageBox.Show("Debe ingresar al menos algún filtro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                wheres = "";
                if (txtCuit.Text != "")
                {
                    if (!validacionCuit())
                    {
                        MessageBox.Show("El CUIT debe ser de tipo XX-XXXXXXXX-XX", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                armarWheres();
                CompletadorDeTablas.hacerQuery("SELECT C_USUARIO_NOMBRE Username, C_RAZON_SOCIAL 'Razón Social', N_CUIT CUIT, C_CORREO Mail FROM GDD_15.USUARIOS U JOIN GDD_15.EMPRESAS E ON (U.N_ID_USUARIO = E.N_ID_USUARIO) WHERE " + wheres, ref dataGridView1);
            }
        }

        public bool validacionCuit()
        {
            if(txtCuit.Text.Length == 14)
            {
                if(txtCuit.Text[2] != '-' || txtCuit.Text[11] != '-')
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

        public void armarWheres()
        {
            if (txtRazonSoc.Text != "")
            {
                wheres = wheres + "C_RAZON_SOCIAL LIKE '%" + txtRazonSoc.Text + "%' AND ";
            }
            if (txtEmail.Text != "")
            {
                wheres = wheres + "C_CORREO LIKE '%" + txtEmail.Text + "%' AND ";
            }
            if (txtCuit.Text != "")
            {
                wheres = wheres + "N_CUIT = '" + txtCuit.Text + "' AND ";
            }

            wheres = wheres.Substring(0, wheres.Length - 5);
        }
    }
}

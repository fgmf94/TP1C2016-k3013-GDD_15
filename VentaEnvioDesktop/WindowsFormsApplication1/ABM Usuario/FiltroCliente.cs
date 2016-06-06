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
    public partial class FiltroCliente : Form
    {
        String wheres;
        String formato;
        public FiltroCliente(String formatoPasado)
        {
            InitializeComponent();
            inicializar();
            wheres = "";
            formato = formatoPasado;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            if(txtApellido.Text == "" && txtNumDoc.Text == "" && txtEmail.Text == "" && txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar al menos algún filtro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else 
            {
                wheres = "";
                if(txtNumDoc.Text != ""){
                    if(!validacionNumDoc()){
                        return;
                    }
                }
                armarWheres();
                CompletadorDeTablas.hacerQuery("SELECT C_USUARIO_NOMBRE Username, D_NOMBRES Nombres, D_APELLIDOS Apellidos, N_DOCUMENTO DNI, C_CORREO Mail FROM GDD_15.USUARIOS U JOIN GDD_15.CLIENTES C ON (U.N_ID_USUARIO = C.N_ID_USUARIO) WHERE " + wheres, ref dataGridView1);
            }
        }

        public bool validacionNumDoc()
        {
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
            return true;
        }


        public void armarWheres()
        {
            if(txtNombre.Text != "")
            {
                wheres = wheres + "D_NOMBRES LIKE '%" + txtNombre.Text + "%' AND ";
            }
            if (txtApellido.Text != "")
            {
                wheres = wheres + "D_APELLIDOS LIKE '%" + txtApellido.Text + "%' AND ";
            }
            if (txtEmail.Text != "")
            {
                wheres = wheres + "C_CORREO LIKE '%" + txtEmail.Text + "%' AND ";
            }
            if (txtNumDoc.Text != "")
            {
                wheres = wheres + "N_DOCUMENTO = '" + txtNumDoc.Text + "' AND ";
            }

            wheres = wheres.Substring(0, wheres.Length - 5);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            inicializar();
        }

        private void inicializar()
        {
            CompletadorDeTablas.hacerQuery("SELECT C_USUARIO_NOMBRE Username, D_NOMBRES Nombres, D_APELLIDOS Apellidos, N_DOCUMENTO DNI, C_CORREO Mail FROM GDD_15.USUARIOS U JOIN GDD_15.CLIENTES C ON (U.N_ID_USUARIO = C.N_ID_USUARIO)", ref dataGridView1);
            txtApellido.Text = "";
            txtNumDoc.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                string value1 = row.Cells["Username"].Value.ToString();
                ABM_Usuario.ElegirUsuario form = new ABM_Usuario.ElegirUsuario(formato,value1);
                this.Close();
                form.Show();
            } else 
            {
                MessageBox.Show("Por favor, elija una fila", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}

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

namespace WindowsFormsApplication1.ABM_Rol
{
    public partial class CrearRol : Form
    {
        string nombreRol;

        public CrearRol()
        {
            InitializeComponent();
            txtNombreRol.Text = "";

            string comando = "SELECT * FROM GDD_15.FUNCIONALIDADES";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);

            chkListaFuncionalidades.Items.Clear();
            for (int i = 0; i <= (dt.Rows.Count - 1); i++)
            {
                int idf = Convert.ToInt32(dt.Rows[i][0]);
                chkListaFuncionalidades.Items.Insert(i, new Funcionalidades(idf, dt.Rows[i][1].ToString(), this));
            }

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
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

            if (txtNombreRol.Text.Length >= 100)
            {
                MessageBox.Show("El nombre de rol debe tener menos de 100 caracteres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtNombreRol.Text.All(Char.IsLetter))
            {
                MessageBox.Show("Sólo se admiten letras en el nombre del rol", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (validacionNombreExistente())
            {
                return;
            }

            agregarRol();

            MessageBox.Show("Rol agregado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
            this.Close();

        }

        private void agregarRol()
        {
            string agregarRol = "INSERT INTO GDD_15.ROLES(C_ROL) VALUES('" + nombreRol + "')";
            (new ConexionSQL()).ejecutarComandoSQL(agregarRol);

            DataTable tblfunc = new DataTable("func");
            tblfunc.Columns.Add("Id", typeof(int));

            string comando = "INSERT INTO GDD_15.FUNCIONALIDADES_ROLES(N_ID_ROL, N_ID_FUNCIONALIDAD) SELECT tablaRol.N_ID_ROL,tablaFuncionalidad.N_ID_FUNCIONALIDAD FROM GDD_15.ROLES  tablaRol, GDD_15.FUNCIONALIDADES tablaFuncionalidad WHERE tablaRol.C_ROL = '" + nombreRol + "' AND tablaFuncionalidad.D_DESCRED IN (";

            foreach (Funcionalidades elemento in chkListaFuncionalidades.CheckedItems)
            {
                comando = comando + " '" + elemento.Descripcion + "',";
            }
            comando = comando.Substring(0, comando.Length - 1);
            comando = comando + ")";

            (new ConexionSQL()).ejecutarComandoSQL(comando);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chkListaFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btSeleccionarTodo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= chkListaFuncionalidades.Items.Count - 1; i++)
            {
                chkListaFuncionalidades.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void txtNombreRol_TextChanged(object sender, EventArgs e)
        {
            nombreRol = txtNombreRol.Text.ToString();
        }

        private bool validacionNombreExistente()
        {
            string comando = "SELECT * FROM  GDD_15.ROLES WHERE C_ROL = '" + txtNombreRol.Text + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][2].ToString() == "0")
                {
                    MessageBox.Show("Existe un rol deshabilitado con ese nombre", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
                else
                {
                    MessageBox.Show("El nombre de rol ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

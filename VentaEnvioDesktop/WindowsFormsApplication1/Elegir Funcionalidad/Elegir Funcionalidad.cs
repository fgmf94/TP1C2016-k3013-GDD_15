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

namespace WindowsFormsApplication1.Elegir_Funcionalidad
{
    public partial class EleccionFuncionalidad : Form
    {
        string funcionalidad;

        public EleccionFuncionalidad(String rol)
        {
            InitializeComponent();

            DataTable dt = (new ConexionSQL()).cargarTablaSQL("SELECT F.D_DESCRED FROM GDD_15.FUNCIONALIDADES_ROLES FR JOIN GDD_15.ROLES R ON (R.N_ID_ROL = FR.N_ID_ROL) JOIN GDD_15.FUNCIONALIDADES F ON (F.N_ID_FUNCIONALIDAD = FR.N_ID_FUNCIONALIDAD) WHERE R.C_ROL = '" + rol + "' AND R.F_BAJA IS NULL AND FR.F_BAJA IS NULL"); 
            comboBoxFuncionalidad.DataSource = dt.DefaultView;
            comboBoxFuncionalidad.ValueMember = "D_DESCRED";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funcionalidad = comboBoxFuncionalidad.Text;
            MessageBox.Show(funcionalidad);
            /*if (funcionalidadNumero == -1){
                MessageBox.Show("Elija funcionalidad");
            } else {
                switch (funcionalidadNumero)
                {
                    case 0:
                        MessageBox.Show("Funcionalidad en construcción (ABM Rol)");
                        break;
                    default:
                        MessageBox.Show("Funcionalidad no implementada");
                        break;
                }
            }*/
        }
    }
}

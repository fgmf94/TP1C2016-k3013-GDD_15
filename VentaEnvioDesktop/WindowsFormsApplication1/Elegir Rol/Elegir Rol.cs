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

namespace WindowsFormsApplication1.Elegir_Rol
{
    public partial class EleccionRol : Form
    {
        Elegir_Funcionalidad.EleccionFuncionalidad funcionalidades;

        public EleccionRol(String username)
        {
            InitializeComponent();

            DataTable dt = (new ConexionSQL()).cargarTablaSQL("SELECT R.C_ROL FROM GDD_15.ROLES_USUARIOS RU JOIN GDD_15.USUARIOS U ON (U.N_ID_USUARIO = RU.N_ID_USUARIO) JOIN GDD_15.ROLES R ON (R.N_ID_ROL = RU.N_ID_ROL) WHERE U.C_USUARIO_NOMBRE = '" + username + "' AND R.F_BAJA IS NULL AND RU.F_BAJA IS NULL "); 
            comboBoxRoles.DataSource = dt.DefaultView;
            comboBoxRoles.ValueMember = "C_ROL";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boton_Click(object sender, EventArgs e)
        {
            funcionalidades = new Elegir_Funcionalidad.EleccionFuncionalidad();
            funcionalidades.Show();
        }
    }
}

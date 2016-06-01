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
        string nombreUsuario;
        string rol;
        ABM_Rol.ABMRol abmRol;
        ABM_Visibilidad.ABMVisibilidad abmVis;
        ABM_Usuario.ABMUsuario abmUsuario;
        ABM_Usuario.Modificar_Usuario mUsuario;

        public EleccionFuncionalidad(String rolPasado, String username)
        {
            InitializeComponent();
            rol = rolPasado;
            nombreUsuario = username;
            DataTable dt = (new ConexionSQL()).cargarTablaSQL("SELECT F.D_DESCRED FROM GDD_15.FUNCIONALIDADES_ROLES FR JOIN GDD_15.ROLES R ON (R.N_ID_ROL = FR.N_ID_ROL) JOIN GDD_15.FUNCIONALIDADES F ON (F.N_ID_FUNCIONALIDAD = FR.N_ID_FUNCIONALIDAD) WHERE R.C_ROL = '" + rolPasado + "' AND R.F_BAJA IS NULL AND FR.F_BAJA IS NULL"); 
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
            switch (funcionalidad)
            {
                case "ABM de Rol":
                    abmRol = new ABM_Rol.ABMRol();
                    abmRol.Show();
                    break;
                case "ABM de Usuarios":
                    if (rol == "Administrativo")
                    {
                        abmUsuario = new ABM_Usuario.ABMUsuario();
                        abmUsuario.Show();
                    }
                    else
                    {
                        mUsuario = new ABM_Usuario.Modificar_Usuario(rol, nombreUsuario);
                        mUsuario.Show();
                    }
                    break;
                case "ABM de Rubro":
                    MessageBox.Show("Funcionalidad no requerida");
                    break;
                case "ABM de visibilidad de publicación":
                    abmVis = new ABM_Visibilidad.ABMVisibilidad();
                    abmVis.Show();
                    break;
                case "Generar Publicación":
                    MessageBox.Show("Generar publicación");
                    break;
                case "Comprar/Ofertar":
                    MessageBox.Show("Comprar/Ofertar");
                    break;
                case "Historial":
                    MessageBox.Show("Historial");
                    break;
                case "Calificar al Vendedor":
                    MessageBox.Show("Calificar al Vendedor");
                    break;
                case "Consulta de facturas":
                    MessageBox.Show("Consulta de facturas");
                    break;
                case "Listado Estadístico":
                    MessageBox.Show("Listado Estadístico");
                    break;
                default:
                    MessageBox.Show("Elija una funcionalidad de las indicadas",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    break;
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

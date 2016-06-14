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
            DataTable dt = (new ConexionSQL()).cargarTablaSQL("SELECT F.D_DESCRED FROM GDD_15.FUNCIONALIDADES_ROLES FR JOIN GDD_15.ROLES R ON (R.N_ID_ROL = FR.N_ID_ROL) JOIN GDD_15.FUNCIONALIDADES F ON (F.N_ID_FUNCIONALIDAD = FR.N_ID_FUNCIONALIDAD) WHERE R.C_ROL = '" + rolPasado + "' AND R.N_HABILITADO = 1"); 
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
            string query2 = "SELECT N_ID_USUARIO FROM GDD_15.USUARIOS WHERE C_USUARIO_NOMBRE = '" + nombreUsuario + "'";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string idCliente = dt2.Rows[0][0].ToString();
            Int64 idCli = Convert.ToInt64(idCliente);

            switch (funcionalidad)
            {
                case "ABM de Rol":
                    abmRol = new ABM_Rol.ABMRol();
                    abmRol.ShowDialog();
                    break;
                case "ABM de Usuarios":
                    if (rol == "Administrativo")
                    {
                        abmUsuario = new ABM_Usuario.ABMUsuario();
                        abmUsuario.ShowDialog();
                    }
                    else if (rol == "Empresa" || rol == "Cliente")
                    {
                        mUsuario = new ABM_Usuario.Modificar_Usuario(rol, nombreUsuario);
                        mUsuario.ShowDialog();
                    } else {
                        MessageBox.Show("No se puede modificar un usuario del rol: " + rol);
                    }
                    break;
                case "ABM de Rubro":
                    MessageBox.Show("Funcionalidad no requerida");
                    break;
                case "ABM de visibilidad de publicación":
                    abmVis = new ABM_Visibilidad.ABMVisibilidad();
                    abmVis.ShowDialog();
                    break;
                case "Generar Publicación":
                    Generar_Publicación.ElegirAccion elegirAccion = new Generar_Publicación.ElegirAccion(nombreUsuario);
                    elegirAccion.ShowDialog();
                    break;
                case "Comprar/Ofertar":
                    ComprarOfertar.ElegirTipo elegirTipo = new ComprarOfertar.ElegirTipo(nombreUsuario);
                    elegirTipo.ShowDialog();
                    break;
                case "Historial":
                    
                    string query3 = "SELECT (SELECT COUNT(*) CUENTA FROM GDD_15.CLIENTES CL JOIN GDD_15.COMPRAS CO ON (CL.N_ID_USUARIO = CO.N_ID_CLIENTE) WHERE CL.N_ID_USUARIO = '" + idCli + "') + (SELECT COUNT(*) CUENTA FROM GDD_15.CLIENTES CL JOIN GDD_15.OFERTAS O ON (CL.N_ID_USUARIO = O.N_ID_CLIENTE) WHERE CL.N_ID_USUARIO = '" + idCli + "')";
                    DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(query3);
                    string cantidadOperaciones = dt3.Rows[0][0].ToString();
                    if (cantidadOperaciones != "0")
                    {
                        Historial_Cliente.Historial historial = new Historial_Cliente.Historial(nombreUsuario);
                        historial.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No hay operaciones en el historial", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Calificar al Vendedor":
                    Calificar.ElegirRealizar realizar = new Calificar.ElegirRealizar(idCli);
                    realizar.ShowDialog();
                    break;
                case "Consulta de facturas":
                    Facturas.Facturas facturas = new Facturas.Facturas(idCli);
                    facturas.ShowDialog();
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

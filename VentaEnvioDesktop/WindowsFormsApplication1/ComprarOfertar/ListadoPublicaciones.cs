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

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class ListadoPublicaciones : Form
    {
        String formato;
        String nombreUsuario;
        int numeroPagina;
        int cantTotalPags;
        String wheres;
        public ListadoPublicaciones(String formatoPasado, String nombreUsuarioPasado)
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            formato = formatoPasado;
            nombreUsuario = nombreUsuarioPasado;

            string comando = "SELECT * FROM GDD_15.RUBROS";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);

            chkListaRubros.Items.Clear();
            for (int i = 0; i <= (dt.Rows.Count - 1); i++)
            {
                int idf = Convert.ToInt32(dt.Rows[i][0]);
                chkListaRubros.Items.Insert(i, new Rubros(idf, dt.Rows[i][2].ToString(), this));
            }

            if (formato == "Subasta")
            {
                labelTitulo.Text = "Publicaciones para Ofertar";
            }

            inicializar();
        }

        private void inicializar()
        {
            dataGridView1.RowTemplate.MinimumHeight = 33;
            txtDescrip.Text = "";
            
            for (int i = 0; i <= chkListaRubros.Items.Count - 1; i++)
            {
                chkListaRubros.SetItemCheckState(i, CheckState.Checked);
            }

            filtrarPag(1);
           
        }

        private void armarWhere()
        {
            wheres = wheres + "(";
            foreach (Rubros elemento in chkListaRubros.CheckedItems)
            {
                wheres = wheres + " '" + elemento.Descripcion + "',";
            }
            wheres = wheres.Substring(0, wheres.Length - 1);
            wheres = wheres + ")";

            if (txtDescrip.Text != "")
            {
                wheres = wheres + " AND P.D_DESCRED LIKE '%" + txtDescrip.Text + "%'";
            }
            else if (formato == "Subasta")
            {

            }
        }

        private void ListadoPublicaciones_Load(object sender, EventArgs e)
        {

        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonElegirPub_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                string estado = row.Cells["Estado"].Value.ToString();
                if (estado != "Pausada")
                {
                    DataGridViewRow row2 = this.dataGridView1.SelectedRows[0];
                    string value1 = row2.Cells["Código"].Value.ToString();
                    Int64 idPubli = Convert.ToInt64(value1);
                    if (formato == "Subasta")
                    {
                        ComprarOfertar.OfertarPubli ofertar = new ComprarOfertar.OfertarPubli(idPubli, nombreUsuario, this);
                        ofertar.ShowDialog();
                    }
                    else if (formato == "Compra Inmediata")
                    {
                        ComprarOfertar.ComprarPubli comprar = new ComprarOfertar.ComprarPubli(idPubli, nombreUsuario, this);
                        comprar.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No se pueden realizar operaciones sobre una publicación pausada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Por favor, elija una publicación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void buttonSeleccionarTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= chkListaRubros.Items.Count - 1; i++)
            {
                chkListaRubros.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void buttonReestablecer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= chkListaRubros.Items.Count - 1; i++)
            {
                chkListaRubros.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inicializar();
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            filtrarPag(1);
        }

        private void filtrarPag(int pagina)
        {
            numeroPagina = pagina;
            labelNumPag.Text = Convert.ToString(pagina);
            if (chkListaRubros.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Se debe elegir al menos un rubro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            };

            wheres = "";
            armarWhere();

            string query2 = "SELECT COUNT(N_ID_PUBLICACION) FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.TIPOS T ON (P.N_ID_TIPO = T.N_ID_TIPO) JOIN GDD_15.VISIBILIDADES V ON (P.C_VISIBILIDAD = V.C_VISIBILIDAD) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE C_TIPO = '" + formato + "' AND C_ESTADO IN ('Activa', 'Pausada') AND C_USUARIO_NOMBRE != '" + nombreUsuario + "' AND R.D_DESCRED IN " + wheres;
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string cantidadPublis = dt2.Rows[0][0].ToString();
            int cantPublis = Convert.ToInt16(cantidadPublis);
            if((cantPublis % 10) == 0)
            {
                cantTotalPags = (cantPublis / 10);
            } else 
            {
                cantTotalPags = (cantPublis / 10) + 1;
            }

            if (pagina == cantTotalPags)
            {
                buttonSigPag.Enabled = false;
            }

            if (pagina == 1)
            {
                buttonPaginaAnt.Enabled = false;
                buttonPriPag.Enabled = false;

                if (cantTotalPags == 1)
                {
                    buttonSigPag.Enabled = false;
                }
                else
                {
                    buttonSigPag.Enabled = true;
                }
            }
            else
            {
                buttonPaginaAnt.Enabled = true;
                buttonPriPag.Enabled = true;
            }

            string campos = "";
            string campos2 = "";
            string campos3 = "";

            if (formato == "Compra Inmediata")
            {
                campos = "N_ID_PUBLICACION Código, C_USUARIO_NOMBRE 'Nombre Usuario', P.D_DESCRED Descripción, R.D_DESCRED Rubro, N_PRECIO 'Precio ($)', N_STOCK Stock, C_PERMITE_ENVIO 'Permite envio', F_VENCIMIENTO 'Fecha Vencimiento', C_ESTADO 'Estado'";
                campos2 = "N_ID_PUBLICACION Código, C_USUARIO_NOMBRE, P.D_DESCRED Descripción, R.D_DESCRED Rubro, N_PRECIO, N_STOCK Stock, C_PERMITE_ENVIO, F_VENCIMIENTO, N_COMISION_PRECIO, C_ESTADO";
                campos3 = "Código, C_USUARIO_NOMBRE 'Nombre Usuario', Descripción, Rubro, N_PRECIO 'Precio ($)', Stock, C_PERMITE_ENVIO 'Permite envio', F_VENCIMIENTO 'Fecha Vencimiento', C_ESTADO 'Estado'";
            }
            else if (formato == "Subasta")
            {
                campos = "N_ID_PUBLICACION Código, C_USUARIO_NOMBRE 'Nombre Usuario', P.D_DESCRED Descripción, R.D_DESCRED Rubro, N_PRECIO 'Precio Inicio ($)', C_PERMITE_ENVIO 'Permite envio', F_INICIO 'Fecha Inicio', F_VENCIMIENTO 'Fecha Vencimiento', C_ESTADO 'Estado'";
                campos2 = "N_ID_PUBLICACION Código, C_USUARIO_NOMBRE, P.D_DESCRED Descripción, R.D_DESCRED Rubro, N_PRECIO, C_PERMITE_ENVIO, F_INICIO, F_VENCIMIENTO, N_COMISION_PRECIO, C_ESTADO";
                campos3 = "Código, C_USUARIO_NOMBRE 'Nombre Usuario', Descripción, Rubro, N_PRECIO 'Precio Inicio ($)', C_PERMITE_ENVIO 'Permite envio',  F_INICIO 'Fecha Inicio', F_VENCIMIENTO 'Fecha Vencimiento', C_ESTADO 'Estado'";
            }

            if (pagina == 1)
            {
                CompletadorDeTablas.hacerQuery("SELECT TOP 10 " + campos + " FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.TIPOS T ON (P.N_ID_TIPO = T.N_ID_TIPO) JOIN GDD_15.VISIBILIDADES V ON (P.C_VISIBILIDAD = V.C_VISIBILIDAD) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE C_TIPO = '" + formato + "' AND C_ESTADO IN ('Activa', 'Pausada') AND C_USUARIO_NOMBRE != '" + nombreUsuario + "' AND R.D_DESCRED IN " + wheres + " ORDER BY V.N_COMISION_PRECIO DESC, C_PERMITE_ENVIO DESC, N_PRECIO ASC", ref dataGridView1);
            }
            else
            {
                CompletadorDeTablas.hacerQuery("SELECT TOP 10 " + campos3 + " FROM (SELECT TOP " + (cantPublis - (pagina - 1) * 10).ToString() + " " + campos2 + " FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.TIPOS T ON (P.N_ID_TIPO = T.N_ID_TIPO) JOIN GDD_15.VISIBILIDADES V ON (P.C_VISIBILIDAD = V.C_VISIBILIDAD) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE C_TIPO = '" + formato + "' AND C_ESTADO IN ('Activa', 'Pausada') AND C_USUARIO_NOMBRE != '" + nombreUsuario + "' AND R.D_DESCRED IN " + wheres + " ORDER BY N_COMISION_PRECIO ASC, C_PERMITE_ENVIO ASC, N_PRECIO DESC) SQ ORDER BY N_COMISION_PRECIO DESC, C_PERMITE_ENVIO DESC, N_PRECIO ASC", ref dataGridView1);
            }

            dataGridView1.RowTemplate.MinimumHeight = 33;
        }

        private void buttonPaginaAnt_Click(object sender, EventArgs e)
        {
            if (chkListaRubros.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Se debe elegir al menos un rubro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            };

            wheres = "";
            armarWhere();

            string query2 = "SELECT COUNT(N_ID_PUBLICACION) FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.TIPOS T ON (P.N_ID_TIPO = T.N_ID_TIPO) JOIN GDD_15.VISIBILIDADES V ON (P.C_VISIBILIDAD = V.C_VISIBILIDAD) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE C_TIPO = '" + formato + "' AND C_ESTADO IN ('Activa', 'Pausada') AND C_USUARIO_NOMBRE != '" + nombreUsuario + "' AND R.D_DESCRED IN " + wheres;
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string cantidadPublis = dt2.Rows[0][0].ToString();
            int cantPublis = Convert.ToInt16(cantidadPublis);
            if ((cantPublis % 10) == 0)
            {
                cantTotalPags = (cantPublis / 10);
            }
            else
            {
                cantTotalPags = (cantPublis / 10) + 1;
            }

            if (cantTotalPags >= numeroPagina - 1)
            {
                filtrarPag(numeroPagina - 1);
            }
            else 
            {
                MessageBox.Show("No hay página anterior para esa búsqueda (Muestro primera página)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                filtrarPag(1);
            }
        }

        private void buttonPriPag_Click(object sender, EventArgs e)
        {
            if (chkListaRubros.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Se debe elegir al menos un rubro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            };

            filtrarPag(1);
        }

        private void buttonSigPag_Click(object sender, EventArgs e)
        {
            if (chkListaRubros.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Se debe elegir al menos un rubro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            };

            wheres = "";
            armarWhere();

            string query2 = "SELECT COUNT(N_ID_PUBLICACION) FROM GDD_15.PUBLICACIONES P JOIN GDD_15.ESTADOS E ON (P.N_ID_ESTADO = E.N_ID_ESTADO) JOIN GDD_15.TIPOS T ON (P.N_ID_TIPO = T.N_ID_TIPO) JOIN GDD_15.VISIBILIDADES V ON (P.C_VISIBILIDAD = V.C_VISIBILIDAD) JOIN GDD_15.USUARIOS U ON (P.N_ID_USUARIO = U.N_ID_USUARIO) JOIN GDD_15.RUBROS R ON (P.N_ID_RUBRO = R.N_ID_RUBRO) WHERE C_TIPO = '" + formato + "' AND C_ESTADO IN ('Activa', 'Pausada') AND C_USUARIO_NOMBRE != '" + nombreUsuario + "' AND R.D_DESCRED IN " + wheres;
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(query2);
            string cantidadPublis = dt2.Rows[0][0].ToString();
            int cantPublis = Convert.ToInt16(cantidadPublis);
            if ((cantPublis % 10) == 0)
            {
                cantTotalPags = (cantPublis / 10);
            }
            else
            {
                cantTotalPags = (cantPublis / 10) + 1;
            }

            if (cantTotalPags > numeroPagina)
            {
                filtrarPag(numeroPagina + 1);
            }
            else
            {
                MessageBox.Show("No hay siguiente página para esa búsqueda (Muestro primera página)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                filtrarPag(1);
            }
        }
    }
}

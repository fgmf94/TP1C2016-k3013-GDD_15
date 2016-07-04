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

namespace WindowsFormsApplication1.Calificar
{
    public partial class CalificarOperacion : Form
    {
        Int64 idCli;
        Int64 idOpe;
        String tipo;
        Form listadoSinCalif;
        public CalificarOperacion(Int64 idCliPasado, Int64 idOperacionPasado, String tipoPasado, Form formPasado)
        {
            InitializeComponent();
            idCli = idCliPasado;
            idOpe = idOperacionPasado;
            tipo = tipoPasado;
            listadoSinCalif = formPasado;

            comboBoxDetalle.SelectedIndex = 0;
            comboBoxEstrellas.SelectedIndex = 0;

            txtCodOpe.Text = idOpe.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDetalle.Text == "Texto libre")
            {
                txtTextoLibre.ReadOnly = false;
            }
            else
            {
                txtTextoLibre.ReadOnly = true;
                txtTextoLibre.Text = "";
                comboBoxEstrellas.SelectedIndex = comboBoxDetalle.SelectedIndex - 1;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!validaciones())
            {
                return;
            }

            if ((MessageBox.Show("¿Realmente desea calificar la Operación?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                calificarOperacion();
                string query5 = "SELECT (SELECT COUNT(*) FROM GDD_15.OFERTAS WHERE N_ID_CLIENTE = '" + idCli + "' AND C_GANADOR = 'SI') + (SELECT COUNT(*) FROM GDD_15.COMPRAS WHERE N_ID_CLIENTE = '" + idCli + "') - (SELECT COUNT(*) FROM GDD_15.CALIFICACIONES WHERE N_ID_CLIENTE = '" + idCli + "')";
                DataTable dt5 = (new ConexionSQL()).cargarTablaSQL(query5);
                string comprasSinCalif = dt5.Rows[0][0].ToString();
                Int32 cantComprasSinCalif = Convert.ToInt32(comprasSinCalif);
                string query6 = "SELECT N_COMPRA_HABILITADA FROM GDD_15.CLIENTES WHERE N_ID_USUARIO = '" + idCli + "'";
                DataTable dt6 = (new ConexionSQL()).cargarTablaSQL(query6);
                string compraHabilitada = dt6.Rows[0][0].ToString();
                MessageBox.Show("Operación calificada");
                if (cantComprasSinCalif == 0 && compraHabilitada == "0")
                {
                    string query7 = "UPDATE GDD_15.CLIENTES SET N_COMPRA_HABILITADA = '1' WHERE N_ID_USUARIO = '" + idCli + "'";
                    DataTable dt7 = (new ConexionSQL()).cargarTablaSQL(query7);
                    MessageBox.Show("Ahora puede volver a realizar compras u ofertas");
                }
                this.Close();
                listadoSinCalif.Close();
            }
        }

        private void calificarOperacion()
        {
            string agregarCalif = "";
            string detalle;

            if (comboBoxDetalle.SelectedIndex == 0)
            {
                detalle = txtTextoLibre.Text;
            }
            else
            {
                detalle = comboBoxDetalle.Text;
            }

            if (tipo == "Compra Inmediata")
            {
                agregarCalif = "INSERT INTO GDD_15.CALIFICACIONES(N_ID_COMPRA, N_ID_CLIENTE, C_CALIFICACION, D_DESCRIP) VALUES ('" + idOpe + "', '" + idCli + "', '" + (comboBoxEstrellas.SelectedIndex + 1) + "', '" + detalle + "')";
            }
            else if (tipo == "Subasta")
            {
                agregarCalif = "INSERT INTO GDD_15.CALIFICACIONES(N_ID_OFERTA, N_ID_CLIENTE, C_CALIFICACION, D_DESCRIP) VALUES ('" + idOpe + "', '" + idCli + "', '" + (comboBoxEstrellas.SelectedIndex + 1) + "', '" + detalle + "')";
            }

            (new ConexionSQL()).ejecutarComandoSQL(agregarCalif);
        }

        private bool validaciones()
        {
            if (txtTextoLibre.TextLength > 250)
            {
                MessageBox.Show("El detalle no debe superar los 250 caractéres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxDetalle.SelectedIndex == 0)
            {
                if (txtTextoLibre.Text == "")
                {
                    MessageBox.Show("Por favor, escribir detalle de calificación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void comboBoxEstrellas_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDetalle.SelectedIndex = comboBoxEstrellas.SelectedIndex + 1;
        }
    }
}

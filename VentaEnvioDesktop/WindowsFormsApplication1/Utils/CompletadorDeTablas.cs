using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace MercadoEnvio.Utils
{
    public static class CompletadorDeTablas
    {
        public static void hacerQuery(string query, ref DataGridView dataGrid)
        {
            ConexionSQL conn = new ConexionSQL();
            DataTable dt = conn.cargarTablaSQL(query);

            try
            {
                if (dataGrid.DataSource != null) dataGrid.Columns.Remove("seleccionar");
            }
            catch
            {
                //El unico caso donde va a tirar error es si no lo encuentra, entonces
                //es lo mismo que no haga nada
            }

            dataGrid.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados en la consulta", "Falló la busqueda", MessageBoxButtons.OK);
                dataGrid.DataSource = null;

            }
            else
            {
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            dataGrid.AllowUserToAddRows = false;
        }

    }
}

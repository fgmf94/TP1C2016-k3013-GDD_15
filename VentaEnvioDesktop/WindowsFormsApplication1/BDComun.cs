using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MercadoEnvio
{
    public class BDComun
    {
        public static SqlConnection obtenerConexion()
        {
            SqlConnection conect = new SqlConnection("Data source=.\\SQLSERVER2012; Initial Catalog=GD1C2016;User Id=gd; Password=gd2016");
            conect.Open();
            return conect;
        }

        public static DataTable select()
        {
            ConexionSQL conn = new ConexionSQL();
            return conn.cargarTablaSQL("select distinct Aeronave_Fabricante, Tipo_Servicio FROM gd_esquema.Maestra");
        }
    }
}

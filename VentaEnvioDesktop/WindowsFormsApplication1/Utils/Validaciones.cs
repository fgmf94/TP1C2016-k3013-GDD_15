using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace MercadoEnvio.Utils
{
    class Validaciones
    {
        public float validacionStringAFloat(String numero, String textoError)
        {
            float resultado;

            try
            {
                resultado = float.Parse(numero.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                if (resultado < 0)
                {
                    MessageBox.Show("Sólo se admiten números positivos", textoError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }

                if (resultado > 1000000)
                {
                    MessageBox.Show("Sólo se admiten números menores a 1000000", textoError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }

            }

            catch
            {
                MessageBox.Show("Sólo se admiten números", textoError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

            return resultado;
        }
    }
}

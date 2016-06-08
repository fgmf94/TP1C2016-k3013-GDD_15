using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.Dominio
{
    public class Rubros
    {
        int id;
        Form FormAsociado;

        public Rubros(int identifyer, string descripcion, Form elFormCaracteristico)
        {
            this.id = identifyer;
            this.Descripcion = descripcion;
            FormAsociado = elFormCaracteristico;
        }

        public string Descripcion { get; set; }

        public Form getFormAsociado()
        {
            return FormAsociado;
        }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}

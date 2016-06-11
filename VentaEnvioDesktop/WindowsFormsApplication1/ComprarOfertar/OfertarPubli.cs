using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class OfertarPubli : Form
    {
        String nombreUsuario;
        Int64 idPubli;
        Form form;
        public OfertarPubli(Int64 idPubliPasado, String nombreUsuarioPasado, Form formPasado)
        {
            InitializeComponent();
            nombreUsuario = nombreUsuarioPasado;
            idPubli = idPubliPasado;
            form = formPasado;
        }

        private void OfertarPubli_Load(object sender, EventArgs e)
        {

        }
    }
}

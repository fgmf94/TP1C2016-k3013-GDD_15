using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEnvio;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Inicio());

        }

        public static String ip()
        {
            return ConfigurationManager.AppSettings["ip"];
        }

        public static String puerto()
        {
            return ConfigurationManager.AppSettings["puerto"];
        }


        public static String nuevaFechaSistema()
        {
            return ConfigurationManager.AppSettings["FechaGlobal"];
        }
    }
}

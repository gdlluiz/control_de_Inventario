using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//Importo CapaPresentacio para que se comunique con la misma
using CapaPresentacion;

namespace SistemaVentas
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // indico que  corra el formularioFrmCategoria
            Application.Run(new frmLogin());
        }
    }
}

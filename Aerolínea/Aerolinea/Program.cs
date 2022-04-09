using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aerolinea
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        
        static void Main()
        {
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new pantallaLogin_Form());

            if (pantallaLogin_Form.login_verificado == true)
            {
                PantallaPrincipal_Form pantallaPrincipal = new PantallaPrincipal_Form();
                Application.Run(pantallaPrincipal);
           }
        }
    }
}

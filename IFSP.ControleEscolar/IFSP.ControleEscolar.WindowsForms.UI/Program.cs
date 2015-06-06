using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFSP.ControleEscolar.WindowsForms.UI
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

            FormPrincipal formPrincipal = new FormPrincipal();
            FormLogin formLogin = new FormLogin(formPrincipal);

            formLogin.ShowDialog();

            if (formLogin.Logado == true)
            {
                Application.Run(formPrincipal);
            }
        }
    }
}

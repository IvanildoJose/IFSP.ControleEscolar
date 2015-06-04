using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ControleEscolar.ClassLibrary.Core.Models
{
    public class Login
    {
        public String LoginNome { get; set; }
        public String Nome { get; set; }
        public String Senha { get; set; }
        public String Poderes { get; set; }

        public Login()
        {
            this.LoginNome = "Default";
            this.Nome = "Default";
            this.Senha = "Default";
            this.Poderes = "Default";
        }

        public void ValidarLogin(String Nome, String Senha)
        {
            // TODO Logica de validação...
        }
    }
}

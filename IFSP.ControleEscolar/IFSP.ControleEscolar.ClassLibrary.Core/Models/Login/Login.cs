using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ControleEscolar.ClassLibrary.Core.Models.Login
{
    public class Login
    {
        public String Nome { get; set; }
        public String NomeCompleto { get; set; }
        public String Senha { get; set; }

        public void ValidarLogin(String Nome, String Senha)
        {
            // TODO Logica de validação...
        }
    }
}

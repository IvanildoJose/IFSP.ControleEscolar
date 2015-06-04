using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ControleEscolar.ClassLibrary.Core.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Matricula { get; set; }
        public Login FuncionarioLogin { get; set; }

        public Funcionario()
        {
            this.FuncionarioLogin = new Login();
        }
    }
}

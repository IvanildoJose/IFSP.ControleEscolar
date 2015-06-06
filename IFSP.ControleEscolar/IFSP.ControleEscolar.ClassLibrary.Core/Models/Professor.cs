using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ControleEscolar.ClassLibrary.Core.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Pronturario { get; set; }
        public String Endereco { get; set; }
        public String CPF { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }

        public Login ProfessorLogin { get; set; }

        public Professor()
        {
            this.ProfessorLogin = new Login();
        }
    }
}

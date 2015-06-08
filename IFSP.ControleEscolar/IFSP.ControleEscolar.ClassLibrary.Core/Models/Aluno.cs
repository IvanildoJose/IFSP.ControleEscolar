using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ControleEscolar.ClassLibrary.Core.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Prontuario { get; set; }
        public String Endereco { get; set; }
        public String CPF { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }
        public String Curso { get; set; }

        public override string ToString()
        {
            return String.Format(
                "\nID Aluno: {0} \nProntuário: {1} \nNome: {2} \nEndereço{3} \nCPF: {4} \nTelefone: {5}\nEmail: {6}",
                this.Id,
                this.Prontuario,
                this.Nome,
                this.Endereco,
                this.CPF,
                this.Telefone,
                this.Email
                );
        }
    }
}

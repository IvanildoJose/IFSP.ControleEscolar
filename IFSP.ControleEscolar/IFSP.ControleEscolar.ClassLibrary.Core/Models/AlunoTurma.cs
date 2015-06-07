using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ControleEscolar.ClassLibrary.Core.Models
{
    public class AlunoTurma
    {
        public Aluno AlunoAtrib { get; set; }
        public Turma TurmaAtrib { get; set; }

        public AlunoTurma()
        {
            this.AlunoAtrib = new Aluno();
            this.TurmaAtrib = new Turma();
        }
    }
}

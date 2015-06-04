using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ControleEscolar.ClassLibrary.Core.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Duracao { get; set; }
        public String Periodo { get; set; }
    }
}

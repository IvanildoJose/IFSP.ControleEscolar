using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ControleEscolar.ClassLibrary.Core.Utils
{
    // Interface para Manipulação de arquivos
    public interface IManipuladorArquivo<T> where T: class
    {
        void DefinirLocalArquivo(String caminho);
        List<T> ObterTodos();
        void SalvarLista( List<T> lista);
    }
}

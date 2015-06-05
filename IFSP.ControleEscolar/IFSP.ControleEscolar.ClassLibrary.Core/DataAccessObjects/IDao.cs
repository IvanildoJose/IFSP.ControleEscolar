using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ControleEscolar.ClassLibrary.Core.DataAccessObjects
{
    public interface IDao <T> where T : class
    {
        void Inserir(T obj);
        void Alterar(T obj);
        void Deletar(T obj);
        T BuscarPorId(int id);
        List<T> BuscarTodos();
    }
}

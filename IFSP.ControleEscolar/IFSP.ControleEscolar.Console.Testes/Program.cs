using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
using IFSP.ControleEscolar.ClassLibrary.Core.Utils;
using IFSP.ControleEscolar.ClassLibrary.Core.Models;

namespace IFSP.ControleEscolar.Console.Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            ManipuladorArquivoTXT txt = new ManipuladorArquivoTXT("c:\\dados\\Alunos.txt");
            ManipuladorArquivoXML xml = new ManipuladorArquivoXML("c:\\dados\\Alunos.xml");

            List<Aluno> alunos;

            try
            {
                alunos = txt.ObterTodos();

                xml.SalvarLista(alunos);
            }
            catch (Exception erro)
            {
                System.Console.WriteLine(erro.Message);
            }

            System.Console.ReadKey();
        }
    }
}

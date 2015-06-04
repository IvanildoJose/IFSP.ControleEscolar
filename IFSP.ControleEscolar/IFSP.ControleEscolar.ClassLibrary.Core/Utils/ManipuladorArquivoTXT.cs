using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Importando modelos.
using IFSP.ControleEscolar.ClassLibrary.Core.Models;

namespace IFSP.ControleEscolar.ClassLibrary.Core.Utils
{
    public class ManipuladorArquivoTXT : IManipuladorArquivo<Aluno>
    {
        public String Caminho { get; private set; }

        public ManipuladorArquivoTXT(String caminho)
        {
            this.DefinirLocalArquivo(caminho);
        }

        public void DefinirLocalArquivo(String caminho)
        {
            this.Caminho = caminho;
        }

        public List<Aluno> ObterTodos()
        {
            List<Aluno> alunos = new List<Aluno>();

            try
            {
                using (Stream arquivo = File.Open(this.Caminho, FileMode.Open))
                using (StreamReader leitor = new StreamReader(arquivo))
                {
                    String cabecalhoDosCampos = leitor.ReadLine();
                    String linha = "";
                    while ((linha = leitor.ReadLine()) != null)
                    {
                        String[] registros = linha.Split(';');

                        Aluno aluno = new Aluno();
                        aluno.Id = Convert.ToInt32(registros[0]);
                        aluno.Prontuario = registros[1];
                        aluno.Nome = registros[2];
                        aluno.Endereco = registros[3];
                        aluno.CPF = registros[4];
                        aluno.Telefone = registros[5];
                        // aluno.IdCurso = Convert.ToInt32(registros[6]);

                        alunos.Add(aluno);
                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception(
                    "Erro na Classe [" + this + "]:\n" + erro.Message);
            }
            finally
            {

            }

            return alunos;
        }

        public void SalvarLista(List<Aluno> lista)
        {
            throw new NotImplementedException();
        }
    }
}

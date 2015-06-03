using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Importando modelos.
using IFSP.ControleEscolar.ClassLibrary.Core.Models;
using System.Xml;

namespace IFSP.ControleEscolar.ClassLibrary.Core.Utils
{
    public class ManipuladorArquivoXML : IManipuladorArquivo<Aluno>
    {
        public String Caminho { get; private set; }

        public ManipuladorArquivoXML(String caminho)
        {
            this.DefinirLocalArquivo(caminho);
        }

        public void DefinirLocalArquivo(String caminho)
        {
            this.Caminho = caminho;
        }

        public List<Aluno> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void SalvarLista(List<Aluno> alunos)
        {
            try
            {
                // Abrindo (ou criando) o documento XML para escrita 
                XmlTextWriter escritor = new XmlTextWriter(this.Caminho, System.Text.Encoding.UTF8);

                // Comando de formatacao do documento (indentacao) 
                escritor.Formatting = Formatting.Indented;

                // Iniciando o documento
                escritor.WriteStartDocument();

                // Escrevendo o elemento raiz do documento 
                escritor.WriteStartElement("alunos");

                foreach (Aluno aluno in alunos)
                {
                    // Id;Prontuario;Nome;Endereco;CPF;Telefone;ID Curso
                    // Iniciando o elemento aluno 
                    escritor.WriteStartElement("aluno");

                    escritor.WriteElementString("id", aluno.Id.ToString());
                    escritor.WriteElementString("prontuario", aluno.Prontuario);
                    escritor.WriteElementString("nome", aluno.Nome);
                    escritor.WriteElementString("endereco", aluno.Endereco);
                    escritor.WriteElementString("cpf", aluno.CPF);
                    escritor.WriteElementString("telefone", aluno.Telefone);
                    escritor.WriteElementString("idcurso", aluno.IdCurso.ToString());

                    // Fechando o elemento 
                    escritor.WriteEndElement();
                }
                // Fechando o elemento raiz 
                escritor.WriteEndElement();
                // Fechando o documento 
                escritor.WriteEndDocument();
                escritor.Close();
            }
            catch (Exception erro)
            {
                throw new Exception(
                    "Erro na Classe [" + this + "]:\n" + erro.Message);
            }
            finally
            {

            }
        }
    }
}

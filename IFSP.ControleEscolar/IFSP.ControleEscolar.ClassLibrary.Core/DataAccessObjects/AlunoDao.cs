using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Modelos
using IFSP.ControleEscolar.ClassLibrary.Core.Models;

// Drive Mysql Server
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace IFSP.ControleEscolar.ClassLibrary.Core.DataAccessObjects
{
    public class AlunoDao : IDao<Aluno>
    {
        public void Inserir(Aluno obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "INSERT INTO tbl_aluno " +
                "(alu_nome, alu_prontuario, alu_endereco, alu_cpf, alu_telefone, alu_email, curso) " +
                "VALUES (@alu_nome, @alu_prontuario, @alu_endereco, @alu_cpf, @alu_telefone, @alu_email, @curso)";

            comando.Parameters.AddWithValue("@alu_nome", obj.Nome);
            comando.Parameters.AddWithValue("@alu_prontuario", obj.Prontuario);
            comando.Parameters.AddWithValue("@alu_endereco", obj.Endereco);
            comando.Parameters.AddWithValue("@alu_cpf", obj.CPF);
            comando.Parameters.AddWithValue("@alu_telefone", obj.Telefone);
            comando.Parameters.AddWithValue("@alu_email", obj.Email);
            comando.Parameters.AddWithValue("@curso", obj.Curso);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Alterar(Aluno obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "UPDATE tbl_Aluno " +
                "SET " +
                "alu_nome=@alu_nome, "+
                "alu_prontuario=@alu_prontuario,"+
                "alu_endereco=@alu_endereco,"+
                "alu_cpf=@alu_cpf,"+
                "alu_telefone=@alu_telefone," +
                "alu_email=@alu_email," +
                "curso=@curso " +
                "WHERE alu_id=@alu_id";

            comando.Parameters.AddWithValue("@alu_id", obj.Id);
            comando.Parameters.AddWithValue("@alu_nome", obj.Nome);
            comando.Parameters.AddWithValue("@alu_prontuario", obj.Prontuario);
            comando.Parameters.AddWithValue("@alu_endereco", obj.Endereco);
            comando.Parameters.AddWithValue("@alu_cpf", obj.CPF);
            comando.Parameters.AddWithValue("@alu_telefone", obj.Telefone);
            comando.Parameters.AddWithValue("@alu_email", obj.Email);
            comando.Parameters.AddWithValue("@curso", obj.Curso);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Deletar(Aluno obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "DELETE FROM tbl_Aluno WHERE alu_id=@alu_id";

            comando.Parameters.AddWithValue("@alu_id", obj.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public Aluno BuscarPorId(int id)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "SELECT alu_id, alu_nome, alu_prontuario, alu_endereco, alu_cpf, alu_telefone, alu_email, curso FROM tbl_aluno WHERE alu_id=@alu_id";

            comando.Parameters.AddWithValue("@alu_id", id);

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            Aluno temp = new Aluno();

            if (dr.HasRows)
            {
                dr.Read();
                temp.Id = Convert.ToInt32(dr["alu_id"]);
                temp.Nome = Convert.ToString(dr["alu_nome"]);
                temp.Prontuario = Convert.ToString(dr["alu_prontuario"]);
                temp.Endereco = Convert.ToString(dr["alu_endereco"]);
                temp.CPF = Convert.ToString(dr["alu_cpf"]);
                temp.Telefone = Convert.ToString(dr["alu_telefone"]);
                temp.Email = Convert.ToString(dr["alu_email"]);
                temp.Curso = Convert.ToString(dr["curso"]);
            }
            else
            {
                temp = null;
            }

            return temp;
        }

        public List<Aluno> BuscarTodos()
        {
            List<Aluno> lista = new List<Aluno>();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT alu_id, alu_nome, alu_prontuario, alu_endereco, alu_cpf, alu_telefone, alu_email, curso FROM tbl_aluno";

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Aluno temp = new Aluno();
                    temp.Id = Convert.ToInt32(dr["alu_id"]);
                    temp.Nome = Convert.ToString(dr["alu_nome"]);
                    temp.Prontuario = Convert.ToString(dr["alu_prontuario"]);
                    temp.Endereco = Convert.ToString(dr["alu_endereco"]);
                    temp.CPF = Convert.ToString(dr["alu_cpf"]);
                    temp.Telefone = Convert.ToString(dr["alu_telefone"]);
                    temp.Email = Convert.ToString(dr["alu_email"]);
                    temp.Curso = Convert.ToString(dr["curso"]);

                    lista.Add(temp);
                }

            }
            else
            {
                lista = null;
            }

            return lista;
        }
    }
}

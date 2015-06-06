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
    public class ProfessorDao : IDao<Professor>
    {
        public void Inserir(Professor obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "INSERT INTO tbl_professor(pro_nome, pro_prontuario, pro_endereco, pro_cpf, pro_telefone, pro_email, tbl_login_log_login) " +
                "VALUES (@pro_nome, @pro_prontuario, @pro_endereco, @pro_cpf, @pro_telefone, @pro_email, @tbl_login_log_login)";

            comando.Parameters.AddWithValue("@pro_nome", obj.Nome);
            comando.Parameters.AddWithValue("@pro_prontuario", obj.Pronturario);
            comando.Parameters.AddWithValue("@pro_endereco", obj.Endereco);
            comando.Parameters.AddWithValue("@pro_cpf", obj.CPF);
            comando.Parameters.AddWithValue("@pro_telefone", obj.Telefone);
            comando.Parameters.AddWithValue("@pro_email", obj.Email);
            comando.Parameters.AddWithValue("@tbl_login_log_login", obj.ProfessorLogin.LoginNome);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Alterar(Professor obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;

            comando.CommandText =
                "UPDATE tbl_professor " +
                "SET  " +
                "pro_nome=@pro_nome, " +
                "pro_prontuario=@pro_prontuario, " +
                "pro_endereco=@pro_endereco, " +
                "pro_cpf=@pro_cpf, " +
                "pro_telefone=@pro_telefone, " +
                "pro_email=@pro_email, " +
                "tbl_login_log_login=@tbl_login_log_login " +
                "WHERE pro_id=@pro_id";

            comando.Parameters.AddWithValue("@pro_id", obj.Id);
            comando.Parameters.AddWithValue("@pro_nome", obj.Nome);
            comando.Parameters.AddWithValue("@pro_prontuario", obj.Pronturario);
            comando.Parameters.AddWithValue("@pro_endereco", obj.Endereco);
            comando.Parameters.AddWithValue("@pro_cpf", obj.CPF);
            comando.Parameters.AddWithValue("@pro_telefone", obj.Telefone);
            comando.Parameters.AddWithValue("@pro_email", obj.Email);
            comando.Parameters.AddWithValue("@tbl_login_log_login", obj.ProfessorLogin.LoginNome);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Deletar(Professor obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "DELETE FROM tbl_professor WHERE pro_id=@pro_id";

            comando.Parameters.AddWithValue("@pro_id", obj.Id);

            MysqlConexao.ComandoCRUD(comando);
            new LoginDao().Deletar(obj.ProfessorLogin);
        }

        public Professor BuscarPorId(int id)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "SELECT pro_id, pro_nome, pro_prontuario, pro_endereco, " +
                "pro_cpf, pro_telefone, pro_email, tbl_login_log_login FROM tbl_professor"+
                " WHERE pro_id=@pro_id";

            comando.Parameters.AddWithValue("@pro_id", id);

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            Professor temp = new Professor();

            if (dr.HasRows)
            {
                dr.Read();
                temp.Id = Convert.ToInt32(dr["pro_id"]);
                temp.Nome = Convert.ToString(dr["pro_nome"]);
                temp.Pronturario = Convert.ToString(dr["pro_prontuario"]);
                temp.Endereco = Convert.ToString(dr["pro_endereco"]);
                temp.CPF = Convert.ToString(dr["pro_cpf"]);
                temp.Telefone = Convert.ToString(dr["pro_telefone"]);
                temp.Email = Convert.ToString(dr["pro_email"]);
                temp.ProfessorLogin = new LoginDao().BuscarPorId(
                    Convert.ToString(dr["tbl_login_log_login"]));
            }
            else
            {
                temp = null;
            }

            return temp;
        }

        public List<Professor> BuscarTodos()
        {
            List<Professor> lista = new List<Professor>();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "SELECT pro_id, pro_nome, pro_prontuario, pro_endereco, " +
                 "pro_cpf, pro_telefone, pro_email, tbl_login_log_login FROM tbl_professor";

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Professor temp = new Professor();
                    temp.Id = Convert.ToInt32(dr["pro_id"]);
                    temp.Nome = Convert.ToString(dr["pro_nome"]);
                    temp.Pronturario = Convert.ToString(dr["pro_prontuario"]);
                    temp.Endereco = Convert.ToString(dr["pro_endereco"]);
                    temp.CPF = Convert.ToString(dr["pro_cpf"]);
                    temp.Telefone = Convert.ToString(dr["pro_telefone"]);
                    temp.Email = Convert.ToString(dr["pro_email"]);
                    temp.ProfessorLogin = new LoginDao().BuscarPorId(
                        Convert.ToString(dr["tbl_login_log_login"]));

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

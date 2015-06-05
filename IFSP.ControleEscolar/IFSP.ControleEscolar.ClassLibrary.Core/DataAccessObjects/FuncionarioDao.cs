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
    public class FuncionarioDao : IDao<Funcionario>
    {
        public void Inserir(Funcionario obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "INSERT INTO tbl_funcionario(fun_nome, fun_matricula, tbl_login_log_login)" +
                "VALUES (@fun_nome, @fun_matricula, @tbl_login_log_login)";

            comando.Parameters.AddWithValue("@fun_nome", obj.Nome);
            comando.Parameters.AddWithValue("@fun_matricula", obj.Matricula);
            comando.Parameters.AddWithValue("@tbl_login_log_login", obj.FuncionarioLogin.LoginNome);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Alterar(Funcionario obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;

            comando.CommandText =
                "UPDATE tbl_funcionario " +
                "SET " +
                "fun_nome=@fun_nome, " +
                "fun_matricula=@fun_matricula, " +
                "tbl_login_log_login=@tbl_login_log_login " +
                "WHERE fun_id=@fun_id";

            comando.Parameters.AddWithValue("@fun_id", obj.Id);
            comando.Parameters.AddWithValue("@fun_nome", obj.Nome);
            comando.Parameters.AddWithValue("@fun_matricula", obj.Matricula);
            comando.Parameters.AddWithValue("@tbl_login_log_login", obj.FuncionarioLogin.LoginNome);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Deletar(Funcionario obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "DELETE FROM tbl_funcionario WHERE fun_id=@fun_id";

            comando.Parameters.AddWithValue("@fun_id", obj.Id);

            MysqlConexao.ComandoCRUD(comando);
            new LoginDao().Deletar(obj.FuncionarioLogin);
        }

        public Funcionario BuscarPorId(int id)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "SELECT fun_id, fun_nome, fun_matricula, tbl_login_log_login " +
                "FROM tbl_funcionario WHERE fun_id=@fun_id";

            comando.Parameters.AddWithValue("@fun_id", id);

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            Funcionario temp = new Funcionario();

            if (dr.HasRows)
            {
                dr.Read();
                temp.Id = Convert.ToInt32(dr["fun_id"]);
                temp.Nome = Convert.ToString(dr["fun_nome"]);
                temp.Matricula = Convert.ToString(dr["fun_matricula"]);
                temp.FuncionarioLogin = new LoginDao().BuscarPorId(
                    Convert.ToString(dr["tbl_login_log_login"]));
            }
            else
            {
                temp = null;
            }

            return temp;
        }

        public List<Funcionario> BuscarTodos()
        {
            List<Funcionario> lista = new List<Funcionario>();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "SELECT fun_id, fun_nome, fun_matricula, tbl_login_log_login " +
                "FROM tbl_funcionario";

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Funcionario temp = new Funcionario();
                    temp.Id = Convert.ToInt32(dr["fun_id"]);
                    temp.Nome = Convert.ToString(dr["fun_nome"]);
                    temp.Matricula = Convert.ToString(dr["fun_matricula"]);
                    temp.FuncionarioLogin = new LoginDao().BuscarPorId(
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

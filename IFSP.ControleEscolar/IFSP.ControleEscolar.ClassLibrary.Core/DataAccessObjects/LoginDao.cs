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
    public class LoginDao : IDao<Login>
    {
        public void Inserir(Login obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = 
                "INSERT INTO tbl_login(log_login, log_nome, log_senha, log_poderes)" +
                "VALUES (@log_login, @log_nome, @log_senha, @log_poderes)";

            comando.Parameters.AddWithValue("log_login", obj.LoginNome);
            comando.Parameters.AddWithValue("log_nome", obj.Nome);
            comando.Parameters.AddWithValue("log_senha", obj.Senha);
            comando.Parameters.AddWithValue("log_poderes", obj.Poderes);

            MysqlConexao.ComandoCRUD(comando);
        }
        
        public void Alterar(Login obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "UPDATE tbl_login SET log_nome=@log_nome, log_senha=@log_senha, log_poderes=@log_poderes WHERE log_login=@log_login";

            comando.Parameters.AddWithValue("@log_login", obj.LoginNome);
            comando.Parameters.AddWithValue("@log_nome", obj.Nome);
            comando.Parameters.AddWithValue("@log_senha", obj.Senha);
            comando.Parameters.AddWithValue("@log_poderes", obj.Poderes);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Deletar(Login obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "DELETE FROM tbl_login WHERE log_login=@log_login";

            comando.Parameters.AddWithValue("@log_login", obj.LoginNome);
            
            MysqlConexao.ComandoCRUD(comando);
        }

        public Login BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Login BuscarPorId(String login)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "SELECT * FROM tbl_login WHERE log_login=@log_login";

            comando.Parameters.AddWithValue("@log_login", login);

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            Login temp = new Login();

            if (dr.HasRows)
            {
                dr.Read();
                temp.LoginNome = Convert.ToString(dr["log_login"]);
                temp.Nome = Convert.ToString(dr["log_nome"]);
                temp.Senha = Convert.ToString(dr["log_senha"]);
                temp.Poderes = Convert.ToString(dr["log_poderes"]);
            }
            else
            {
                temp = null;
            }

            return temp;
        }

        public Login BuscarLogin(String login, String senha)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "SELECT * FROM tbl_login WHERE log_login=@log_login AND log_senha=@log_senha";

            comando.Parameters.AddWithValue("@log_login", login);
            comando.Parameters.AddWithValue("@log_senha", senha);

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            Login temp = new Login();

            if (dr.HasRows)
            {
                dr.Read();
                temp.LoginNome = Convert.ToString(dr["log_login"]);
                temp.Nome = Convert.ToString(dr["log_nome"]);
                temp.Senha = Convert.ToString(dr["log_senha"]);
                temp.Poderes = Convert.ToString(dr["log_poderes"]);
            }
            else
            {
                temp = null;
            }

            return temp;
        }

        public List<Login> BuscarTodos()
        {
            List<Login> lista = new List<Login>();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM tbl_login";

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Login temp = new Login();
                    temp.LoginNome = Convert.ToString(dr["log_login"]);
                    temp.Nome = Convert.ToString(dr["log_nome"]);
                    temp.Senha = Convert.ToString(dr["log_senha"]);
                    temp.Poderes = Convert.ToString(dr["log_poderes"]);

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

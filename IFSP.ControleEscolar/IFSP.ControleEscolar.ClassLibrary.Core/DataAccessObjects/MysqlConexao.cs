using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Drive Mysql Server
using MySql.Data.MySqlClient;

namespace IFSP.ControleEscolar.ClassLibrary.Core.DataAccessObjects
{
    public class MysqlConexao
    {
        private MysqlConexao() { }

        public static MySqlConnection Conectar()
        {
            String servidor = "127.0.0.1";
            String usuario = "root";
            String senha = ""; // Altere para sua senha
            String banco = "banco_escolar";

            String stringDeConexao = String.Format(
                "server={0};uid={1};pwd={2};database={3};",
                servidor, usuario, senha, banco);

            MySqlConnection conexao = new MySqlConnection(stringDeConexao);
            conexao.Open();

            return conexao;
        }

        public static void ComandoCRUD(MySqlCommand camandoSql)
        {
            MySqlConnection objConexao = Conectar();
            camandoSql.Connection = objConexao;
            camandoSql.ExecuteNonQuery();
            objConexao.Close();
        }

        public static MySqlDataReader Selecionar(MySqlCommand comandoSql)
        {
            MySqlConnection objConexao = Conectar();
            comandoSql.Connection = objConexao;
            MySqlDataReader dr = comandoSql.ExecuteReader(
                System.Data.CommandBehavior.CloseConnection);
            
            return dr;
        }
    }
}

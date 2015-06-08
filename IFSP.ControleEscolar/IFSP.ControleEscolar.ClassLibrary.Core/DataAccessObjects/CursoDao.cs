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
    public class CursoDao : IDao<Curso>
    {
        public void Inserir(Curso obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "INSERT INTO tbl_curso(cur_nome, cur_duracao, cur_periodo) " +
                "VALUES (@cur_nome, @cur_duracao, @cur_periodo)";

            comando.Parameters.AddWithValue("@cur_nome", obj.Nome);
            comando.Parameters.AddWithValue("@cur_duracao", obj.Duracao);
            comando.Parameters.AddWithValue("@cur_periodo", obj.Periodo);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Alterar(Curso obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "UPDATE tbl_curso " +
                "SET " +
                "cur_nome=@cur_nome, cur_duracao=@cur_duracao, cur_periodo=@cur_periodo " +
                "WHERE cur_id=@cur_id";

            comando.Parameters.AddWithValue("@cur_id", obj.Id);
            comando.Parameters.AddWithValue("@cur_nome", obj.Nome);
            comando.Parameters.AddWithValue("@cur_duracao", obj.Duracao);
            comando.Parameters.AddWithValue("@cur_periodo", obj.Periodo);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Deletar(Curso obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "DELETE FROM tbl_curso WHERE cur_id=@cur_id";

            comando.Parameters.AddWithValue("@cur_id", obj.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public Curso BuscarPorId(int id)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "SELECT cur_id, cur_nome, cur_duracao, cur_periodo FROM tbl_curso WHERE cur_id=@cur_id";

            comando.Parameters.AddWithValue("@cur_id", id);

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            Curso temp = new Curso();

            if (dr.HasRows)
            {
                dr.Read();
                temp.Id = Convert.ToInt32(dr["cur_id"]);
                temp.Nome = Convert.ToString(dr["cur_nome"]);
                temp.Duracao = Convert.ToString(dr["cur_duracao"]);
                temp.Periodo = Convert.ToString(dr["cur_periodo"]);
            }
            else
            {
                temp = null;
            }

            return temp;
        }

        public List<Curso> BuscarTodos()
        {
            List<Curso> lista = new List<Curso>();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT cur_id, cur_nome, cur_duracao, cur_periodo FROM tbl_curso";

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Curso temp = new Curso();
                    temp.Id = Convert.ToInt32(dr["cur_id"]);
                    temp.Nome = Convert.ToString(dr["cur_nome"]);
                    temp.Duracao = Convert.ToString(dr["cur_duracao"]);
                    temp.Periodo = Convert.ToString(dr["cur_periodo"]);

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

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
    public class DisciplinaDao : IDao<Disciplina>
    {
        public void Inserir(Disciplina obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "INSERT INTO tbl_disciplina(dis_sigla, dis_nome) VALUES (@dis_sigla, @dis_nome)";

            comando.Parameters.AddWithValue("@dis_sigla", obj.Sigla);
            comando.Parameters.AddWithValue("@dis_nome", obj.Nome);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Alterar(Disciplina obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "UPDATE tbl_disciplina SET dis_sigla=@dis_sigla, dis_nome=@dis_nome WHERE dis_id=@dis_id";

            comando.Parameters.AddWithValue("@dis_id", obj.Id);
            comando.Parameters.AddWithValue("@dis_sigla", obj.Sigla);
            comando.Parameters.AddWithValue("@dis_nome", obj.Nome);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Deletar(Disciplina obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "DELETE FROM tbl_disciplina WHERE dis_id=@dis_id";

            comando.Parameters.AddWithValue("@dis_id", obj.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public Disciplina BuscarPorId(int id)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "SELECT dis_id, dis_sigla, dis_nome FROM tbl_disciplina WHERE dis_id=@dis_id";

            comando.Parameters.AddWithValue("@dis_id", id);

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            Disciplina temp = new Disciplina();

            if (dr.HasRows)
            {
                dr.Read();
                temp.Id = Convert.ToInt32(dr["dis_id"]);
                temp.Sigla = Convert.ToString(dr["dis_sigla"]);
                temp.Nome = Convert.ToString(dr["dis_nome"]);
            }
            else
            {
                temp = null;
            }

            return temp;
        }

        public List<Disciplina> BuscarTodos()
        {
            List<Disciplina> lista = new List<Disciplina>();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT dis_id, dis_sigla, dis_nome FROM tbl_disciplina";

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Disciplina temp = new Disciplina();
                    temp.Id = Convert.ToInt32(dr["dis_id"]);
                    temp.Sigla = Convert.ToString(dr["dis_sigla"]);
                    temp.Nome = Convert.ToString(dr["dis_nome"]);

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

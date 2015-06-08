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
    public class TurmaDao : IDao<Turma>
    {
        public void Inserir(Turma obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "INSERT INTO tbl_turma(tur_numero) VALUES (@tur_numero)";

            comando.Parameters.AddWithValue("@tur_numero", obj.Numero);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Alterar(Turma obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "UPDATE tbl_turma SET tur_numero=@tur_numero WHERE tur_id=@tur_id";

            comando.Parameters.AddWithValue("@tur_numero", obj.Numero);
            comando.Parameters.AddWithValue("@tur_id", obj.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Deletar(Turma obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "DELETE FROM tbl_turma WHERE tur_id=@tur_id";

            comando.Parameters.AddWithValue("@tur_id", obj.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public Turma BuscarPorId(int id)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "SELECT tur_id, tur_numero FROM tbl_turma WHERE tur_id=@tur_id";

            comando.Parameters.AddWithValue("@tur_id", id);

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            Turma temp = new Turma();

            if (dr.HasRows)
            {
                dr.Read();
                temp.Id = Convert.ToInt32(dr["tur_id"]);
                temp.Numero = Convert.ToString(dr["tur_numero"]);
            }
            else
            {
                temp = null;
            }

            return temp;
        }

        public List<Turma> BuscarTodos()
        {
            List<Turma> lista = new List<Turma>();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT tur_id, tur_numero FROM tbl_turma";

            MySqlDataReader dr = MysqlConexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Turma temp = new Turma();
                    temp.Id = Convert.ToInt32(dr["tur_id"]);
                    temp.Numero = Convert.ToString(dr["tur_numero"]);

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

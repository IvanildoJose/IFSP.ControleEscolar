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
    public class TurmaDisciplinaDao : IDao<TurmaDisciplina>
    {
        public void Inserir(TurmaDisciplina obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "INSERT INTO tbl_turma_has_tbl_disciplina(tbl_turma_tur_id, tbl_disciplina_dis_id) "+
                "VALUES (@tbl_turma_tur_id, @tbl_disciplina_dis_id)";

            comando.Parameters.AddWithValue("@tbl_turma_tur_id", obj.TurmaAtrib.Id);
            comando.Parameters.AddWithValue("@tbl_disciplina_dis_id", obj.DisciplinaAtrib.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Alterar(TurmaDisciplina obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "UPDATE tbl_turma_has_tbl_disciplina " +
                "SET tbl_turma_tur_id=@tbl_turma_tur_id, tbl_disciplina_dis_id=@tbl_disciplina_dis_id  " +
                "WHERE  " +
                "tbl_turma_tur_id=@tbl_turma_tur_id AND tbl_disciplina_dis_id=@tbl_disciplina_dis_id  " +
                
            comando.Parameters.AddWithValue("@tbl_turma_tur_id", obj.TurmaAtrib.Id);
            comando.Parameters.AddWithValue("@tbl_disciplina_dis_id", obj.DisciplinaAtrib.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Deletar(TurmaDisciplina obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "DELETE FROM tbl_turma_has_tbl_disciplina " +
                "WHERE  " +
                "tbl_turma_tur_id=@tbl_turma_tur_id AND tbl_disciplina_dis_id=@tbl_disciplina_dis_id  " +

            comando.Parameters.AddWithValue("@tbl_turma_tur_id", obj.TurmaAtrib.Id);
            comando.Parameters.AddWithValue("@tbl_disciplina_dis_id", obj.DisciplinaAtrib.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public TurmaDisciplina BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<TurmaDisciplina> BuscarTodos()
        {
            throw new NotImplementedException();
        }
    }
}

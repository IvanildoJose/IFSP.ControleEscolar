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
    public class CursoDisciplinaDao : IDao<CursoDisciplina>
    {
        public void Inserir(CursoDisciplina obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "INSERT INTO tbl_curso_has_tbl_disciplina(tbl_curso_cur_id, tbl_disciplina_dis_id) " +
                "VALUES (@tbl_curso_cur_id, @tbl_disciplina_dis_id)";

            comando.Parameters.AddWithValue("@tbl_curso_cur_id", obj.CursoAtrib.Id);
            comando.Parameters.AddWithValue("@tbl_disciplina_dis_id", obj.DisciplinaAtrib.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Alterar(CursoDisciplina obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "UPDATE tbl_curso_has_tbl_disciplina " +
                "SET tbl_curso_cur_id=@tbl_curso_cur_id, tbl_disciplina_dis_id=@tbl_disciplina_dis_id  " +
                "WHERE  " +
                "tbl_curso_cur_id=@tbl_curso_cur_id  " +
                "AND  " +
                "tbl_disciplina_dis_id=@tbl_disciplina_dis_id ";

            comando.Parameters.AddWithValue("@tbl_curso_cur_id", obj.CursoAtrib.Id);
            comando.Parameters.AddWithValue("@tbl_disciplina_dis_id", obj.DisciplinaAtrib.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Deletar(CursoDisciplina obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "DELETE FROM tbl_curso_has_tbl_disciplina " +
                "WHERE " +
                "WHERE  " +
                "tbl_curso_cur_id=@tbl_curso_cur_id  " +
                "AND  " +
                "tbl_disciplina_dis_id=@tbl_disciplina_dis_id ";

            comando.Parameters.AddWithValue("@tbl_curso_cur_id", obj.CursoAtrib.Id);
            comando.Parameters.AddWithValue("@tbl_disciplina_dis_id", obj.DisciplinaAtrib.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public CursoDisciplina BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<CursoDisciplina> BuscarTodos()
        {
            throw new NotImplementedException();
        }
    }
}

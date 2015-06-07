using IFSP.ControleEscolar.ClassLibrary.Core.Models;
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
    public class DisciplinaProfessorDao : IDao<DisciplinaProfessor>
    {
        public void Inserir(DisciplinaProfessor obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "INSERT INTO tbl_disciplina_has_tbl_professor(tbl_disciplina_dis_id, tbl_professor_pro_id) " +
                "VALUES (@tbl_disciplina_dis_id, @tbl_professor_pro_id)";

            comando.Parameters.AddWithValue("@tbl_disciplina_dis_id", obj.DisciplinaAtrib.Id);
            comando.Parameters.AddWithValue("@tbl_professor_pro_id", obj.ProfessorAtrib.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Alterar(DisciplinaProfessor obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "UPDATE tbl_disciplina_has_tbl_professor " +
                "SET " +
                "tbl_disciplina_dis_id=@tbl_disciplina_dis_id, tbl_professor_pro_id=@tbl_professor_pro_id " +
                "WHERE " +
                "tbl_disciplina_dis_id=@tbl_disciplina_dis_id " +
                "AND " +
                "tbl_professor_pro_id=@tbl_professor_pro_id";

            comando.Parameters.AddWithValue("@tbl_disciplina_dis_id", obj.DisciplinaAtrib.Id);
            comando.Parameters.AddWithValue("@tbl_professor_pro_id", obj.ProfessorAtrib.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Deletar(DisciplinaProfessor obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "DELETE FROM tbl_disciplina_has_tbl_professor " +
                "WHERE " +
                "tbl_disciplina_dis_id=@tbl_disciplina_dis_id " +
                "AND " +
                "tbl_professor_pro_id=@tbl_professor_pro_id";

            comando.Parameters.AddWithValue("@tbl_disciplina_dis_id", obj.DisciplinaAtrib.Id);
            comando.Parameters.AddWithValue("@tbl_professor_pro_id", obj.ProfessorAtrib.Id);

            MysqlConexao.ComandoCRUD(comando);
            
        }

        public DisciplinaProfessor BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<DisciplinaProfessor> BuscarTodos()
        {
            throw new NotImplementedException();
        }
    }
}

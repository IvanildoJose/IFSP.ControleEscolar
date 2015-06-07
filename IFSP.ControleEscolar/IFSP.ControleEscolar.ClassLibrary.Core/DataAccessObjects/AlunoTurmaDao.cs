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
    public class AlunoTurmaDao : IDao<AlunoTurma>
    {
        public void Inserir(AlunoTurma obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "INSERT INTO tbl_aluno_has_tbl_turma(tbl_aluno_alu_id, tbl_turma_tur_id) "+
                "VALUES (@tbl_aluno_alu_id, @tbl_turma_tur_id)";

            comando.Parameters.AddWithValue("@tbl_aluno_alu_id", obj.AlunoAtrib.Id);
            comando.Parameters.AddWithValue("@tbl_turma_tur_id", obj.TurmaAtrib.Id);
            MysqlConexao.ComandoCRUD(comando);
        }

        public void Alterar(AlunoTurma obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "UPDATE tbl_aluno_has_tbl_turma SET tbl_aluno_alu_id=@tbl_aluno_alu_id, tbl_turma_tur_id=@tbl_turma_tur_id WHERE tbl_aluno_alu_id=@tbl_aluno_alu_id AND tbl_turma_tur_id=@tbl_turma_tur_id";

            comando.Parameters.AddWithValue("@tbl_aluno_alu_id", obj.AlunoAtrib.Id);
            comando.Parameters.AddWithValue("@tbl_turma_tur_id", obj.TurmaAtrib.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public void Deletar(AlunoTurma obj)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText =
                "DELETE FROM tbl_aluno_has_tbl_turma WHERE tbl_aluno_alu_id=@tbl_aluno_alu_id AND tbl_turma_tur_id=@tbl_turma_tur_id";

            comando.Parameters.AddWithValue("@tbl_aluno_alu_id", obj.AlunoAtrib.Id);
            comando.Parameters.AddWithValue("@tbl_turma_tur_id", obj.TurmaAtrib.Id);

            MysqlConexao.ComandoCRUD(comando);
        }

        public AlunoTurma BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<AlunoTurma> BuscarTodos()
        {
            throw new NotImplementedException();
        }
    }
}

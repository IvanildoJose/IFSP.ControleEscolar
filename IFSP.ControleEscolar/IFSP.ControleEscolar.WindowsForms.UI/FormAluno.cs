using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
using IFSP.ControleEscolar.ClassLibrary.Core.Models;
using IFSP.ControleEscolar.ClassLibrary.Core.DataAccessObjects;

namespace IFSP.ControleEscolar.WindowsForms.UI
{
    public partial class FormAluno : Form
    {
        private CursoDao cursoDao;
        private AlunoDao aluno;

        public FormAluno()
        {
            InitializeComponent();
        }

        private void FormAluno_Load(object sender, EventArgs e)
        {
            this.CarregarComboxCursos();
        }

        private void CarregarComboxCursos()
        {
            //this.cmbCursos.DataSource = cursoDao.BuscarTodos();

        }
    }
}

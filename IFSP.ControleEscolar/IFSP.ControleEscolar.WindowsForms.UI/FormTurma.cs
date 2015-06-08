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
    public partial class FormTurma : Form
    {
        private TurmaDao turmaDao;

        public FormTurma()
        {
            InitializeComponent();

            this.turmaDao = new TurmaDao();
        }

        private void FormTurma_Load(object sender, EventArgs e)
        {
            this.CarregarGrid();
            this.LimparCampos();

        }

        private void LimparCampos()
        {
            foreach (var item in gpbDados.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Clear();
                }
                else if (item is ComboBox)
                {
                    (item as ComboBox).Text = "";
                }
            }

            this.lblNumeroTurma.Focus();
        }

        private void CarregarGrid()
        {
            try
            {
                this.dgvDados.DataSource = this.turmaDao.BuscarTodos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro: " + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Turma t = new Turma();

            try
            {
                // t.Id = Convert.ToInt32(tbxIdTurma.Text);
                t.Numero = tbxNumTurma.Text;

                this.turmaDao.Inserir(t);
                MessageBox.Show("Cadastrado!");
                this.LimparCampos();
                this.CarregarGrid();
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro: \n" + erro.Message,
                    "Erro!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Turma t = new Turma();

            try
            {
                t.Id = Convert.ToInt32(tbxIdTurma.Text);
                t.Numero = tbxNumTurma.Text;

                this.turmaDao.Alterar(t);
                MessageBox.Show("Alterado!");
                this.LimparCampos();
                this.CarregarGrid();
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro: \n" + erro.Message,
                    "Erro!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Turma t = new Turma();

            try
            {
                t.Id = Convert.ToInt32(tbxIdTurma.Text);
                t.Numero = tbxNumTurma.Text;

                this.turmaDao.Deletar(t);
                MessageBox.Show("Deletado!");
                this.LimparCampos();
                this.CarregarGrid();
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro: \n" + erro.Message,
                    "Erro!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Turma p = this.turmaDao.BuscarPorId(
                    Convert.ToInt32(dgvDados.SelectedCells[0].Value));

                this.tbxIdTurma.Text = p.Id.ToString();
                this.tbxNumTurma.Text = p.Numero;
                
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro: " + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

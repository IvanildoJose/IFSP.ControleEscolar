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
    public partial class FormCurso : Form
    {
        private CursoDao cursoDao;

        public FormCurso()
        {
            InitializeComponent();
            this.cursoDao = new CursoDao();
        }

        private void FormCurso_Load(object sender, EventArgs e)
        {
            this.CarregarGrid();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Curso c = new Curso();
            c.Nome = txtNome.Text;
            c.Duracao = txtDuracao.Text;
            c.Periodo = txtPeriodo.Text;
            
            try
            {
                this.cursoDao.Inserir(c);
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

        private void CarregarGrid()
        {
            try
            {
                this.dgvDados.DataSource = this.cursoDao.BuscarTodos();
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

        private void LimparCampos()
        {
            foreach (var item in gpbDados.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).Text = "";
                }
            }
            txtNome.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Curso c = new Curso();
            c.Id = Convert.ToInt32(txtId.Text);
            c.Nome = txtNome.Text;
            c.Duracao = txtDuracao.Text;
            c.Periodo = txtPeriodo.Text;

            try
            {
                this.cursoDao.Alterar(c);
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
            Curso c = new Curso();
            c.Id = Convert.ToInt32(txtId.Text);
            c.Nome = txtNome.Text;
            c.Duracao = txtDuracao.Text;
            c.Periodo = txtPeriodo.Text;

            try
            {
                this.cursoDao.Deletar(c);
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

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Curso c = this.cursoDao.BuscarPorId(
                    Convert.ToInt32(dgvDados.SelectedCells[0].Value));

                txtId.Text = c.Id.ToString();
                txtNome.Text = c.Nome;
                txtDuracao.Text = c.Duracao;
                txtPeriodo.Text = c.Periodo;
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

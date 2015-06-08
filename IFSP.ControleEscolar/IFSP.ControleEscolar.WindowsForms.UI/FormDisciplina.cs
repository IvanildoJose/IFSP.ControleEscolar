using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IFSP.ControleEscolar.ClassLibrary.Core.Models;
using IFSP.ControleEscolar.ClassLibrary.Core.DataAccessObjects;

namespace IFSP.ControleEscolar.WindowsForms.UI
{
    public partial class FormDisciplina : Form
    {
        private DisciplinaDao disciplinaDao;

        public FormDisciplina()
        {
            InitializeComponent();

            this.disciplinaDao = new DisciplinaDao();
        }

        private void FormDisciplina_Load(object sender, EventArgs e)
        {
            this.CarregarGrid();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Disciplina d = new Disciplina();

            d.Sigla = txtSigla.Text;
            d.Nome = txtNomeDisc.Text;

            try
            {
                this.disciplinaDao.Inserir(d);
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
                this.dgvDados.DataSource = this.disciplinaDao.BuscarTodos();
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
            txtSigla.Focus();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Disciplina d = new Disciplina();
            d.Id = Convert.ToInt32(txtId.Text);
            d.Sigla = txtSigla.Text;
            d.Nome = txtNomeDisc.Text;

            try
            {
                this.disciplinaDao.Alterar(d);
                MessageBox.Show("Alterar!");
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
            Disciplina d = new Disciplina();
            d.Id = Convert.ToInt32(txtId.Text);
            d.Sigla = txtSigla.Text;
            d.Nome = txtNomeDisc.Text;

            try
            {
                this.disciplinaDao.Deletar(d);
                MessageBox.Show("Excluido!");
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
                Disciplina d = this.disciplinaDao.BuscarPorId(
                    Convert.ToInt32(dgvDados.SelectedCells[0].Value));

                txtId.Text = d.Id.ToString();
                txtSigla.Text = d.Sigla;
                txtNomeDisc.Text = d.Nome;
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

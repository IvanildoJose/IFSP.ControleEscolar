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
    public partial class FormFuncionarios : Form
    {
        private FuncionarioDao funcionarioDao;

        public FormFuncionarios()
        {
            InitializeComponent();

            this.funcionarioDao = new FuncionarioDao();
        }

        private void FormFuncionarios_Load(object sender, EventArgs e)
        {
            this.CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                this.dgvDados.DataSource = this.funcionarioDao.BuscarTodos();
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

        private void btnAtribuirLogin_Click(object sender, EventArgs e)
        {
            FormGerenciarLogin formGerenciarLogin = new FormGerenciarLogin(true);
            formGerenciarLogin.ShowDialog();

            lblLogin.Text = (formGerenciarLogin.GetLoginChamada()).LoginNome;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Funcionario f = new Funcionario();
            f.Nome = txtNome.Text;
            f.Matricula = txtMatricula.Text;
            f.FuncionarioLogin = new LoginDao().BuscarPorId(lblLogin.Text);

            try
            {
                this.funcionarioDao.Inserir(f);
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

        private void LimparCampos()
        {
            this.txtId.Clear();
            this.txtMatricula.Clear();
            this.txtNome.Clear();
            this.lblLogin.Text = "...";
            this.txtNome.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Funcionario f = this.funcionarioDao.BuscarPorId(
                    Convert.ToInt32(dgvDados.SelectedCells[0].Value));

                txtId.Text = f.Id.ToString();
                txtNome.Text = f.Nome;
                txtMatricula.Text = f.Matricula;
                lblLogin.Text = f.FuncionarioLogin.LoginNome;
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Funcionario f = new Funcionario();

            try
            {
                f.Id = Convert.ToInt32(txtId.Text);
                f.Nome = txtNome.Text;
                f.Matricula = txtMatricula.Text;
                f.FuncionarioLogin = new LoginDao().BuscarPorId(lblLogin.Text);

                this.funcionarioDao.Deletar(f);
                MessageBox.Show("Excluido!");
                this.LimparCampos();
                this.CarregarGrid();
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Funcionario f = new Funcionario();

            try
            {
                f.Id = Convert.ToInt32(txtId.Text);
                f.Nome = txtNome.Text;
                f.Matricula = txtMatricula.Text;
                f.FuncionarioLogin = new LoginDao().BuscarPorId(lblLogin.Text);

                this.funcionarioDao.Alterar(f);
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
    }
}

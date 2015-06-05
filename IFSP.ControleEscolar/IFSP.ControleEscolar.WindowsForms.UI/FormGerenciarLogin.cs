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
    public partial class FormGerenciarLogin : Form
    {
        private LoginDao loginDao;

        public FormGerenciarLogin()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            this.loginDao = new LoginDao();
            login.LoginNome = txtLogin.Text;
            login.Nome = txtNome.Text;
            login.Senha = txtSenha.Text;
            login.Poderes = cmdPoderes.Text;

            try
            {
                this.loginDao.Inserir(login);
                MessageBox.Show("Cadastrado!");
                this.LimparCampos();
                this.PopularGridView();
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
            this.txtLogin.Focus();

            foreach (var item in this.gpbLogins.Controls)
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

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            this.loginDao = new LoginDao();
            login.LoginNome = txtLogin.Text;
            login.Nome = txtNome.Text;
            login.Senha = txtSenha.Text;
            login.Poderes = cmdPoderes.Text;

            try
            {
                this.loginDao.Alterar(login);
                MessageBox.Show("Alterado!");
                this.LimparCampos();
                this.PopularGridView();
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
            Login login = new Login();

            this.loginDao = new LoginDao();
            login.LoginNome = txtLogin.Text;
            login.Nome = txtNome.Text;
            login.Senha = txtSenha.Text;
            login.Poderes = cmdPoderes.Text;

            try
            {
                this.loginDao.Deletar(login);
                MessageBox.Show("Excluido!");
                this.LimparCampos();
                this.PopularGridView();
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

        public void PopularGridView()
        {
            try
            {
                this.loginDao = new LoginDao();
                this.dgvLogin.DataSource = this.loginDao.BuscarTodos();
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

        private void FormGerenciarLogin_Load(object sender, EventArgs e)
        {
            this.PopularGridView();
        }

        private void dgvLogin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Login l = this.loginDao.BuscarPorId(dgvLogin.SelectedCells[0].Value.ToString());
                txtLogin.Text = l.LoginNome;
                txtNome.Text = l.Nome;
                txtSenha.Text = l.Senha;
                cmdPoderes.Text = l.Poderes;
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

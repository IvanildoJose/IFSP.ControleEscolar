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
        private bool chamada;

        public FormGerenciarLogin()
        {
            InitializeComponent();
            this.chamada = false;
        }

        public FormGerenciarLogin(bool chamada)
        {
            InitializeComponent();

            this.chamada = true;
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
            if (this.chamada == true)
            {
                this.linkOK.Visible = true;
            }
            else
            {
                this.linkOK.Visible = false;
            }

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

        public Login GetLoginChamada()
        {
            Login login = null;

            if (this.chamada == true)
            {
                try
                {
                    login = this.loginDao.BuscarPorId(dgvLogin.SelectedCells[0].Value.ToString());
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

            return login;
        }

        private void ckbVisualizarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbVisualizarSenha.Checked)
            {
                this.txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtSenha.UseSystemPasswordChar = true;
            }
        }

        private void linkOK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!(txtLogin.Text.Equals("") || txtLogin.Text == String.Empty))
            {
                this.Close();
                return;
            }
            this.txtLogin.Focus();
        }
    }
}

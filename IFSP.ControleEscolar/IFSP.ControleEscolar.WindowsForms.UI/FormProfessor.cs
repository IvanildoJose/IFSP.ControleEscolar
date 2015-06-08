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
    public partial class FormProfessor : Form
    {
        private ProfessorDao professorDao;

        public FormProfessor()
        {
            InitializeComponent();

            this.professorDao = new ProfessorDao();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        private void btnAtribuirLogin_Click(object sender, EventArgs e)
        {
            FormGerenciarLogin formGerenciarLogin = new FormGerenciarLogin(true);
            formGerenciarLogin.ShowDialog();

            lblLogin.Text = (formGerenciarLogin.GetLoginChamada()).LoginNome;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Professor p = new Professor();
            
            try
            {
                p.Nome = txtNome.Text;
                p.Pronturario = txtProntuario.Text;
                p.Endereco = txtEnd.Text;
                p.CPF = txtCpf.Text;
                p.Telefone = txtTel.Text;
                p.Email = txtEmail.Text;

                p.ProfessorLogin = new LoginDao().BuscarPorId(lblLogin.Text);


                this.professorDao.Inserir(p);
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
                this.dgvDados.DataSource = this.professorDao.BuscarTodos();
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
            this.txtId.Clear();
            this.txtNome.Clear();
            this.txtProntuario.Clear();
            this.txtEnd.Clear();
            this.txtCpf.Clear();
            this.txtTel.Clear();
            this.txtEmail.Clear();
            this.lblLogin.Text = "";
            this.lblLogin.Text = "...";
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Professor p = new Professor();
            
            try
            {
                p.ProfessorLogin = new LoginDao().BuscarPorId(lblLogin.Text);
                p.Id = Convert.ToInt32(txtId.Text);

                p.Nome = txtNome.Text;
                p.Pronturario = txtProntuario.Text;
                p.Endereco = txtEnd.Text;
                p.CPF = txtCpf.Text;
                p.Telefone = txtTel.Text;
                p.Email = txtEmail.Text;

                this.professorDao.Alterar(p);
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
            Professor p = new Professor();

            try
            {
                p.ProfessorLogin = new LoginDao().BuscarPorId(lblLogin.Text);
                p.Id = Convert.ToInt32(txtId.Text);

                p.Nome = txtNome.Text;
                p.Pronturario = txtProntuario.Text;
                p.Endereco = txtEnd.Text;
                p.CPF = txtCpf.Text;
                p.Telefone = txtTel.Text;
                p.Email = txtEmail.Text;

                this.professorDao.Deletar(p);
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

        private void FormProfessor_Load(object sender, EventArgs e)
        {
            this.CarregarGrid();
            this.LimparCampos();
        }

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Professor p = this.professorDao.BuscarPorId(
                    Convert.ToInt32(dgvDados.SelectedCells[0].Value));

                this.txtId.Text = p.Id.ToString();
                this.txtNome.Text = p.Nome;
                this.txtProntuario.Text = p.Pronturario;
                this.txtEnd.Text = p.Endereco;
                this.txtCpf.Text = p.CPF;
                this.txtTel.Text = p.Telefone;
                this.txtEmail.Text = p.Email;
                this.lblLogin.Text = p.ProfessorLogin.LoginNome;
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

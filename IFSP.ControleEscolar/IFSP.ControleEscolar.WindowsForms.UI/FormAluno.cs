﻿using System;
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
        private AlunoDao alunoDao;

        public FormAluno()
        {
            InitializeComponent();

            this.alunoDao = new AlunoDao();
            this.cursoDao = new CursoDao();
        }

        private void FormAluno_Load(object sender, EventArgs e)
        {
            this.CarregarComboxCursos();
            this.CarregarGrid();

            this.LimparCampos();
        }

        private void CarregarComboxCursos()
        {
            cmbCursos.DataSource = cursoDao.BuscarTodos();
            cmbCursos.ValueMember = "Id";
            cmbCursos.DisplayMember = "Nome";
        }

        private void CarregarGrid()
        {
            try
            {
                this.dgvDados.DataSource = this.alunoDao.BuscarTodos();
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        private void LimparCampos()
        {
            foreach (var item in gpbDados.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).Text = "" ;
                }
            }
            this.txtNome.Focus();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Aluno a = new Aluno();

            try
            {
                a.Nome = txtNome.Text;
                a.Prontuario = txtProntuario.Text;
                a.Endereco = txtEnd.Text;
                a.CPF = txtCPF.Text;
                a.Telefone = txtTel.Text;
                a.Email = txtEmail.Text;
                a.Curso = cmbCursos.Text;

                this.alunoDao.Inserir(a);
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
            Aluno a = new Aluno();
           
            try
            {
                a.Id = Convert.ToInt32(txtId.Text);
                a.Nome = txtNome.Text;
                a.Prontuario = txtProntuario.Text;
                a.Endereco = txtEnd.Text;
                a.CPF = txtCPF.Text;
                a.Telefone = txtTel.Text;
                a.Email = txtEmail.Text;
                a.Curso = cmbCursos.Text;

                this.alunoDao.Alterar(a);
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
            Aluno a = new Aluno();

            try
            {
                a.Nome = txtNome.Text;
                a.Prontuario = txtProntuario.Text;
                a.Endereco = txtEnd.Text;
                a.CPF = txtCPF.Text;
                a.Telefone = txtTel.Text;
                a.Email = txtEmail.Text;
                a.Curso = cmbCursos.Text;

                a.Id = Convert.ToInt32(txtId.Text);

                this.alunoDao.Deletar(a);
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
                Aluno a = this.alunoDao.BuscarPorId(
                    Convert.ToInt32(dgvDados.SelectedCells[0].Value));

                this.txtId.Text = a.Id.ToString();
                this.txtNome.Text = a.Nome;
                this.txtProntuario.Text = a.Prontuario;
                this.txtEnd.Text = a.Endereco;
                this.txtCPF.Text = a.CPF;
                this.txtTel.Text = a.Telefone;
                this.txtEmail.Text = a.Email;
                this.cmbCursos.Text = a.Curso;
                
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

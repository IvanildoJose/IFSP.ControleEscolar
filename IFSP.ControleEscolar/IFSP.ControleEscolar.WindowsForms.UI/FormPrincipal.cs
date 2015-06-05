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

namespace IFSP.ControleEscolar.WindowsForms.UI
{
    public partial class FormPrincipal : Form
    {
        public DateTime HorarioDoLogin { get; set; }
        public Login usuarioLogado;

        public FormPrincipal()
        {
            InitializeComponent();

            this.HorarioDoLogin = new DateTime();
            this.usuarioLogado = new Login();
            // this.Hide();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // this.Hide();
            FormLogin frmLogin = new FormLogin(this);
            frmLogin.ShowDialog();

            this.tslNomeUsuarioLogado.Text = this.usuarioLogado.Nome;
            this.HorarioDoLogin = DateTime.Now;
            this.tslHorarioEntradaSistema.Text += HorarioDoLogin.ToString();

            this.stpBarradeStatus.Visible = true;
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Sistema de Controle Escolar\n" +
                "\n-----------------------------------" +
                "\n\nDesenvolvedores: " +
                "\n\nAline Oshiro" +
                "\nHenrique Fernandes" +
                "\nIvanilvo Junior" +
                "\n-----------------------------------\n" +
                "\n\nA5LP1 - Copy Right and Left 2015 - " + DateTime.Now.Year,
                "Sobre o Sistema de Controle Escolar"
                );
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sair = MessageBox.Show(
                "Deseja realmente ir embora do sistema?",
                "Confirmação...",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (sair == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new FormGerenciarLogin().ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new FormFuncionarios().ShowDialog();
        }
    }

}

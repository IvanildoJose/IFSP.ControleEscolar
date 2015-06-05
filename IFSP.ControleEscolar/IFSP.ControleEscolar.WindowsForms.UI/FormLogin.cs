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
    public partial class FormLogin : Form
    {
        private Form form;

        public FormLogin(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            LoginDao loginDao = new LoginDao();
            Login login;

            try
            {
                login = loginDao.BuscarLogin(txtLogin.Text, txtSenha.Text);
                if (login == null)
                {
                    MessageBox.Show("Acesso negado!", "Negado");
                    return;
                }
                
                this.Close();
                ((FormPrincipal)form).usuarioLogado = login;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: \n", "Erro..." + erro.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.txtLogin.Focus();
        }
    }
}

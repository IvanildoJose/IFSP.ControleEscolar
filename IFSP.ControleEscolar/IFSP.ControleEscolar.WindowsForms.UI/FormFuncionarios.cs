using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFSP.ControleEscolar.WindowsForms.UI
{
    public partial class FormFuncionarios : Form
    {
        public FormFuncionarios()
        {
            InitializeComponent();
        }

        private void FormFuncionarios_Load(object sender, EventArgs e)
        {

        }

        private void btnAtribuirLogin_Click(object sender, EventArgs e)
        {
            FormGerenciarLogin formGerenciarLogin = new FormGerenciarLogin(true);
            formGerenciarLogin.ShowDialog();

            lblLogin.Text = (formGerenciarLogin.GetLoginChamada()).LoginNome;
        }
    }
}

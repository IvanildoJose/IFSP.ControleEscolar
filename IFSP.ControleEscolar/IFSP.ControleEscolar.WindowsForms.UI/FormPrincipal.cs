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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {            
            FormLogin frmLogin = new FormLogin();
            frmLogin.ShowDialog();
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
    }
}

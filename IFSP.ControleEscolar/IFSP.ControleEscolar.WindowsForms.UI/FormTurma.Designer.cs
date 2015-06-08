namespace IFSP.ControleEscolar.WindowsForms.UI
{
    partial class FormTurma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.cbxTurmaCurso = new System.Windows.Forms.ComboBox();
            this.cbxTurmaDisc = new System.Windows.Forms.ComboBox();
            this.tbxNumTurma = new System.Windows.Forms.TextBox();
            this.tbxIdTurma = new System.Windows.Forms.TextBox();
            this.lblTurmaCurso = new System.Windows.Forms.Label();
            this.lblTurmaDisc = new System.Windows.Forms.Label();
            this.lblNumeroTurma = new System.Windows.Forms.Label();
            this.lblIDTurma = new System.Windows.Forms.Label();
            this.gpbDados = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.gpbDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(7, 226);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(448, 173);
            this.dgvDados.TabIndex = 25;
            this.dgvDados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellClick);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(7, 197);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 24;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(178, 197);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 23;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(263, 197);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 22;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(94, 197);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 21;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // cbxTurmaCurso
            // 
            this.cbxTurmaCurso.FormattingEnabled = true;
            this.cbxTurmaCurso.Location = new System.Drawing.Point(114, 142);
            this.cbxTurmaCurso.Name = "cbxTurmaCurso";
            this.cbxTurmaCurso.Size = new System.Drawing.Size(318, 21);
            this.cbxTurmaCurso.TabIndex = 20;
            // 
            // cbxTurmaDisc
            // 
            this.cbxTurmaDisc.FormattingEnabled = true;
            this.cbxTurmaDisc.Location = new System.Drawing.Point(114, 106);
            this.cbxTurmaDisc.Name = "cbxTurmaDisc";
            this.cbxTurmaDisc.Size = new System.Drawing.Size(318, 21);
            this.cbxTurmaDisc.TabIndex = 19;
            // 
            // tbxNumTurma
            // 
            this.tbxNumTurma.Location = new System.Drawing.Point(114, 69);
            this.tbxNumTurma.Name = "tbxNumTurma";
            this.tbxNumTurma.Size = new System.Drawing.Size(176, 20);
            this.tbxNumTurma.TabIndex = 18;
            // 
            // tbxIdTurma
            // 
            this.tbxIdTurma.Enabled = false;
            this.tbxIdTurma.Location = new System.Drawing.Point(114, 31);
            this.tbxIdTurma.Name = "tbxIdTurma";
            this.tbxIdTurma.Size = new System.Drawing.Size(84, 20);
            this.tbxIdTurma.TabIndex = 17;
            // 
            // lblTurmaCurso
            // 
            this.lblTurmaCurso.AutoSize = true;
            this.lblTurmaCurso.Location = new System.Drawing.Point(17, 150);
            this.lblTurmaCurso.Name = "lblTurmaCurso";
            this.lblTurmaCurso.Size = new System.Drawing.Size(37, 13);
            this.lblTurmaCurso.TabIndex = 16;
            this.lblTurmaCurso.Text = "Curso:";
            // 
            // lblTurmaDisc
            // 
            this.lblTurmaDisc.AutoSize = true;
            this.lblTurmaDisc.Location = new System.Drawing.Point(17, 114);
            this.lblTurmaDisc.Name = "lblTurmaDisc";
            this.lblTurmaDisc.Size = new System.Drawing.Size(58, 13);
            this.lblTurmaDisc.TabIndex = 15;
            this.lblTurmaDisc.Text = "Disciplina: ";
            // 
            // lblNumeroTurma
            // 
            this.lblNumeroTurma.AutoSize = true;
            this.lblNumeroTurma.Location = new System.Drawing.Point(17, 76);
            this.lblNumeroTurma.Name = "lblNumeroTurma";
            this.lblNumeroTurma.Size = new System.Drawing.Size(95, 13);
            this.lblNumeroTurma.TabIndex = 14;
            this.lblNumeroTurma.Text = "Número da Turma:";
            // 
            // lblIDTurma
            // 
            this.lblIDTurma.AutoSize = true;
            this.lblIDTurma.Location = new System.Drawing.Point(17, 34);
            this.lblIDTurma.Name = "lblIDTurma";
            this.lblIDTurma.Size = new System.Drawing.Size(21, 13);
            this.lblIDTurma.TabIndex = 13;
            this.lblIDTurma.Text = "ID:";
            // 
            // gpbDados
            // 
            this.gpbDados.Controls.Add(this.lblIDTurma);
            this.gpbDados.Controls.Add(this.lblNumeroTurma);
            this.gpbDados.Controls.Add(this.lblTurmaDisc);
            this.gpbDados.Controls.Add(this.lblTurmaCurso);
            this.gpbDados.Controls.Add(this.tbxIdTurma);
            this.gpbDados.Controls.Add(this.tbxNumTurma);
            this.gpbDados.Controls.Add(this.cbxTurmaCurso);
            this.gpbDados.Controls.Add(this.cbxTurmaDisc);
            this.gpbDados.Location = new System.Drawing.Point(7, 0);
            this.gpbDados.Name = "gpbDados";
            this.gpbDados.Size = new System.Drawing.Size(448, 191);
            this.gpbDados.TabIndex = 26;
            this.gpbDados.TabStop = false;
            this.gpbDados.Text = "Dados";
            // 
            // FormTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 410);
            this.Controls.Add(this.gpbDados);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnAtualizar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormTurma";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turmas";
            this.Load += new System.EventHandler(this.FormTurma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.gpbDados.ResumeLayout(false);
            this.gpbDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.ComboBox cbxTurmaCurso;
        private System.Windows.Forms.ComboBox cbxTurmaDisc;
        private System.Windows.Forms.TextBox tbxNumTurma;
        private System.Windows.Forms.TextBox tbxIdTurma;
        private System.Windows.Forms.Label lblTurmaCurso;
        private System.Windows.Forms.Label lblTurmaDisc;
        private System.Windows.Forms.Label lblNumeroTurma;
        private System.Windows.Forms.Label lblIDTurma;
        private System.Windows.Forms.GroupBox gpbDados;
    }
}
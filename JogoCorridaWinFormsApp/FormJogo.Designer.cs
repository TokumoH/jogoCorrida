namespace JogoCorridaWinFormsApp
{
    partial class FormJogo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            picCarroCorrida = new PictureBox();
            timerJogo = new System.Windows.Forms.Timer(components);
            labelPontuacao = new Label();
            ((System.ComponentModel.ISupportInitialize)picCarroCorrida).BeginInit();
            SuspendLayout();
            // 
            // picCarroCorrida
            // 
            picCarroCorrida.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picCarroCorrida.BackColor = Color.Transparent;
            picCarroCorrida.BackgroundImage = Properties.Resources.carroPNG;
            picCarroCorrida.BackgroundImageLayout = ImageLayout.Stretch;
            picCarroCorrida.Cursor = Cursors.No;
            picCarroCorrida.Location = new Point(359, 369);
            picCarroCorrida.Margin = new Padding(3, 4, 3, 4);
            picCarroCorrida.Name = "picCarroCorrida";
            picCarroCorrida.Size = new Size(92, 71);
            picCarroCorrida.TabIndex = 1;
            picCarroCorrida.TabStop = false;
            // 
            // timerJogo
            // 
            timerJogo.Interval = 200;
            timerJogo.Tick += timerJogo_Tick;
            // 
            // labelPontuacao
            // 
            labelPontuacao.AutoSize = true;
            labelPontuacao.Location = new Point(22, 521);
            labelPontuacao.Name = "labelPontuacao";
            labelPontuacao.Size = new Size(78, 20);
            labelPontuacao.TabIndex = 2;
            labelPontuacao.Text = "Pontuação";
            // 
            // FormJogo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Gemini_Generated_Image_2qpyvz2qpyvz2qpy;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 500);
            Controls.Add(labelPontuacao);
            Controls.Add(picCarroCorrida);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormJogo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JogoCorrida";
            KeyDown += FormJogo_KeyDown;
            ((System.ComponentModel.ISupportInitialize)picCarroCorrida).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox picCarroCorrida;
        private System.Windows.Forms.Timer timerJogo;
        private Label labelPontuacao;
    }
}

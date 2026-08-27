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
            pictureBoxEspantalho = new PictureBox();
            pictureBoxHowl = new PictureBox();
            pictureBoxKiki = new PictureBox();
            labelTimer = new Label();
            labelPontos = new Label();
            ((System.ComponentModel.ISupportInitialize)picCarroCorrida).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEspantalho).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHowl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxKiki).BeginInit();
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
            // pictureBoxEspantalho
            // 
            pictureBoxEspantalho.BackColor = Color.Transparent;
            pictureBoxEspantalho.BackgroundImage = Properties.Resources.espantalho;
            pictureBoxEspantalho.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxEspantalho.Location = new Point(745, 152);
            pictureBoxEspantalho.Name = "pictureBoxEspantalho";
            pictureBoxEspantalho.Size = new Size(53, 64);
            pictureBoxEspantalho.TabIndex = 2;
            pictureBoxEspantalho.TabStop = false;
            // 
            // pictureBoxHowl
            // 
            pictureBoxHowl.BackColor = Color.Transparent;
            pictureBoxHowl.BackgroundImage = Properties.Resources.howl;
            pictureBoxHowl.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxHowl.Location = new Point(34, 29);
            pictureBoxHowl.Name = "pictureBoxHowl";
            pictureBoxHowl.Size = new Size(61, 54);
            pictureBoxHowl.TabIndex = 3;
            pictureBoxHowl.TabStop = false;
            // 
            // pictureBoxKiki
            // 
            pictureBoxKiki.BackColor = Color.Transparent;
            pictureBoxKiki.BackgroundImage = Properties.Resources.kiki;
            pictureBoxKiki.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxKiki.Location = new Point(680, 29);
            pictureBoxKiki.Name = "pictureBoxKiki";
            pictureBoxKiki.Size = new Size(63, 54);
            pictureBoxKiki.TabIndex = 4;
            pictureBoxKiki.TabStop = false;
            // 
            // labelTimer
            // 
            labelTimer.AutoSize = true;
            labelTimer.Location = new Point(101, 29);
            labelTimer.Name = "labelTimer";
            labelTimer.Size = new Size(50, 20);
            labelTimer.TabIndex = 5;
            labelTimer.Text = "label1";
            // 
            // labelPontos
            // 
            labelPontos.AutoSize = true;
            labelPontos.Location = new Point(101, 63);
            labelPontos.Name = "labelPontos";
            labelPontos.Size = new Size(50, 20);
            labelPontos.TabIndex = 6;
            labelPontos.Text = "label2";
            // 
            // FormJogo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Gemini_Generated_Image_2qpyvz2qpyvz2qpy;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 500);
            Controls.Add(labelPontos);
            Controls.Add(labelTimer);
            Controls.Add(pictureBoxKiki);
            Controls.Add(pictureBoxHowl);
            Controls.Add(pictureBoxEspantalho);
            Controls.Add(picCarroCorrida);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormJogo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JogoCorrida";
            KeyDown += FormJogo_KeyDown;
            ((System.ComponentModel.ISupportInitialize)picCarroCorrida).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEspantalho).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHowl).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxKiki).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox picCarroCorrida;
        private System.Windows.Forms.Timer timerJogo;
        private PictureBox pictureBoxEspantalho;
        private PictureBox pictureBoxHowl;
        private PictureBox pictureBoxKiki;
        private Label labelTimer;
        private Label labelPontos;
    }
}

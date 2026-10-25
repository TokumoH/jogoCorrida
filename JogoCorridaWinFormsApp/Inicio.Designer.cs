namespace JogoCorridaWinFormsApp
{
    partial class Inicio
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
            groupBoxSelect = new GroupBox();
            buttonQuit = new Button();
            buttonHard = new Button();
            buttonMedium = new Button();
            buttonEasy = new Button();
            groupBoxSelect.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxSelect
            // 
            groupBoxSelect.BackColor = Color.Transparent;
            groupBoxSelect.Controls.Add(buttonQuit);
            groupBoxSelect.Controls.Add(buttonHard);
            groupBoxSelect.Controls.Add(buttonMedium);
            groupBoxSelect.Controls.Add(buttonEasy);
            groupBoxSelect.Font = new Font("Segoe UI", 20F);
            groupBoxSelect.ForeColor = Color.White;
            groupBoxSelect.Location = new Point(60, 257);
            groupBoxSelect.Name = "groupBoxSelect";
            groupBoxSelect.Size = new Size(648, 148);
            groupBoxSelect.TabIndex = 0;
            groupBoxSelect.TabStop = false;
            groupBoxSelect.Text = "Selecione o nível";
            groupBoxSelect.Enter += groupBoxSelect_Enter;
            // 
            // buttonQuit
            // 
            buttonQuit.BackColor = Color.DimGray;
            buttonQuit.Location = new Point(478, 60);
            buttonQuit.Name = "buttonQuit";
            buttonQuit.Size = new Size(140, 60);
            buttonQuit.TabIndex = 4;
            buttonQuit.Text = "Sair";
            buttonQuit.UseVisualStyleBackColor = false;
            buttonQuit.Click += buttonQuit_Click;
            // 
            // buttonHard
            // 
            buttonHard.BackColor = Color.Red;
            buttonHard.Location = new Point(323, 60);
            buttonHard.Name = "buttonHard";
            buttonHard.Size = new Size(140, 60);
            buttonHard.TabIndex = 3;
            buttonHard.Text = "Difícil";
            buttonHard.UseVisualStyleBackColor = false;
            buttonHard.Click += buttonHard_Click;
            // 
            // buttonMedium
            // 
            buttonMedium.BackColor = Color.Yellow;
            buttonMedium.Location = new Point(163, 60);
            buttonMedium.Name = "buttonMedium";
            buttonMedium.Size = new Size(140, 60);
            buttonMedium.TabIndex = 2;
            buttonMedium.Text = "Médio";
            buttonMedium.UseVisualStyleBackColor = false;
            buttonMedium.Click += buttonMedium_Click;
            // 
            // buttonEasy
            // 
            buttonEasy.BackColor = Color.Lime;
            buttonEasy.Location = new Point(6, 60);
            buttonEasy.Name = "buttonEasy";
            buttonEasy.Size = new Size(140, 60);
            buttonEasy.TabIndex = 1;
            buttonEasy.Text = "Fácil";
            buttonEasy.UseVisualStyleBackColor = false;
            buttonEasy.Click += buttonEasy_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Camarão_Kart__Corrida_ao_Entardecer;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(782, 453);
            Controls.Add(groupBoxSelect);
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio";
            Load += Inicio_Load;
            groupBoxSelect.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxSelect;
        private Button buttonEasy;
        private Button buttonHard;
        private Button buttonMedium;
        private Button buttonQuit;
    }
}
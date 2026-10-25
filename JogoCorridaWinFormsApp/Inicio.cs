using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JogoCorridaWinFormsApp
{
    public partial class Inicio : Form
    {
        String dificuldade = "";
        bool jogoIniciado = false;
        public Inicio()
        {
            InitializeComponent(); ;

        }

        private void buttonHard_Click(object sender, EventArgs e)
        {
            dificuldade = "hard";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonEasy_Click(object sender, EventArgs e)
        {
            dificuldade = "easy";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonMedium_Click(object sender, EventArgs e)
        {
            dificuldade = "medium";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            dificuldade = "quit";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public String getDificuldade()
        {
            return dificuldade;
        }
        private void groupBoxSelect_Enter(object sender, EventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}

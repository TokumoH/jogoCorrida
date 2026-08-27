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
        public Inicio()
        {
            InitializeComponent();
        }

        private void buttonHard_Click(object sender, EventArgs e)
        {
            var jogo = new FormJogo("Dificil");
            jogo.ShowDialog();
        }

        private void buttonEasy_Click(object sender, EventArgs e)
        {
            var jogo = new FormJogo("Facil");
            jogo.ShowDialog();
        }

        private void buttonMedium_Click(object sender, EventArgs e)
        {
            var jogo = new FormJogo("Medio");
            jogo.ShowDialog();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

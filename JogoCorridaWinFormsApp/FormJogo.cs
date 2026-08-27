using jogoCorrida;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JogoCorridaWinFormsApp
{
    public partial class FormJogo : Form
    {
        Jogo jogo;
        DateTime tempoUltimaMovimentaca = DateTime.Now;
        DateTime comeco = DateTime.Now;
        List<PictureBox> pictureBoxesOb = [];
        List<PictureBox> pictureBoxesP = [];
        List<PictureBox> pictureBoxesC = [];

        public FormJogo()
        {
            InitializeComponent();
            jogo = new Jogo
            {
                Faixa1Inicio = 200,
                Faixa1Fim = 300,
                Faixa2Inicio = 305,
                Faixa2Fim = 405,
                Faixa3Inicio = 410,
                Faixa3Fim = 510

            };
            jogo.Pontuacao = 0;
            jogo.YMaximo = 500;
            jogo.IniciaJogo();
            jogo.Carro.PosicaoX = jogo.PosicionaObjeto(1);
            jogo.Carro.Altura = 200;
            jogo.Carro.Largura = 180;
            jogo.Velocidade = 1;
            jogo.Vidas = 2;

            GerarObstaculo();
            GerarPontos();
          
            timerJogo.Enabled = true;
        }
        public void GerarObstaculo()
        {
            foreach (var ob in jogo.Obstaculos)
            {
                var picOb = new PictureBox();
                picOb.BackColor = Color.Transparent;
                picOb.BackgroundImage = Properties.Resources.obstaculo;
                picOb.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBoxesOb.Add(picOb);
                this.Controls.Add(picOb);
            }
        }
        public void GerarPontos()
        {
            foreach (var pt in jogo.Pontos)
            {
                var picPt = new PictureBox();
                picPt.BackColor = Color.Transparent;
                picPt.BackgroundImage = Properties.Resources.images_removebg_preview;
                picPt.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBoxesP.Add(picPt);
                this.Controls.Add(picPt);
            }
        }
       
        private void FormJogo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && jogo.Posicao > 1)
            {
                jogo.Carro.PosicaoX = jogo.PosicionaObjeto(--jogo.Posicao);
            }
            else if (e.KeyCode == Keys.Right && jogo.Posicao < 3)
            {
                jogo.Carro.PosicaoX = jogo.PosicionaObjeto(++jogo.Posicao);
            }
        }

        private void timerJogo_Tick(object sender, EventArgs e)
        {
            picCarroCorrida.Location = new Point(jogo.Carro.PosicaoX, jogo.Carro.PosicaoY);
            var i = 0;
            var j = 0;

            foreach (var ob in jogo.Obstaculos)
            {
                if (ob.Largura >= 10)
                {
                    pictureBoxesOb[i].Location = new Point(ob.PosicaoX, ob.PosicaoY);
                    pictureBoxesOb[i].Size = new Size(ob.Altura, ob.Largura);
                }
                i++;
            }
            foreach (var p in jogo.Pontos)
            {
                if (p.Largura >= 10)
                {
                    pictureBoxesP[j].Location = new Point(p.PosicaoX, p.PosicaoY);
                    pictureBoxesP[j].Size = new Size(p.Altura, p.Largura);
                }
                j++;
            }

            if ((DateTime.Now - tempoUltimaMovimentaca).Milliseconds >= jogo.Velocidade)
            {
                tempoUltimaMovimentaca = DateTime.Now;
                jogo.MovimentarObstaculos(jogo.Obstaculos);
                jogo.MovimentarObstaculos(jogo.Pontos);
                atualizarInterface();
            }
            if (jogo.ChecarColisao())
            {
                //GameOver();
                //TocarSom();
                --jogo.Vidas;
                if (jogo.Vidas == 0)
                {
                    Application.Exit();
                }
            }
            jogo.ChecarPontuacao();
            Application.DoEvents();
        }
        private void atualizarInterface()
        {
            int tempoAtual = 0;
            tempoAtual += (DateTime.Now - comeco).Seconds;
            labelPontos.Text = $"Pontos: {jogo.Pontuacao}";
            labelTimer.Text = $"Tempo de Jogo: {tempoAtual}";
        }
    }
}

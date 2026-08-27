using jogoCorrida;
using System.Media;
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

        public FormJogo(String nivel)
        {
            DoubleBuffered = true;
            
            InitializeComponent();
            TocarSomCorrida();
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
            jogo.Velocidade = ChecarVelocidade(nivel);
            jogo.Vidas = ChecarVidas(nivel);

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
                picOb.BackgroundImage = null;
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
                picPt.BackgroundImage = null;
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

        private async void timerJogo_Tick(object sender, EventArgs e)
        {
            picCarroCorrida.Location = new Point(jogo.Carro.PosicaoX, jogo.Carro.PosicaoY);
            var i = 0;
            var j = 0;

            foreach (var ob in jogo.Obstaculos)
            {
                if (ob.Largura >= 10)
                {
                    pictureBoxesOb[i].BackgroundImage = Properties.Resources.obstaculo;
                }
                else
                {
                    pictureBoxesOb[i].BackgroundImage = null;
                }
                pictureBoxesOb[i].Location = new Point(ob.PosicaoX, ob.PosicaoY);
                pictureBoxesOb[i].Size = new Size(ob.Altura, ob.Largura);

                i++;
            }
            foreach (var p in jogo.Pontos)
            {
                pictureBoxesP[j].Location = new Point(p.PosicaoX, p.PosicaoY);
                pictureBoxesP[j].Size = new Size(p.Altura, p.Largura);
                if (p.Largura >= 10)
                {
                    pictureBoxesP[j].BackgroundImage = Properties.Resources.moeda;
                }
                else
                {
                    pictureBoxesP[j].BackgroundImage = null;
                }
                j++;
            }

            if ((DateTime.Now - tempoUltimaMovimentaca).Milliseconds >= jogo.Velocidade)
            {
                tempoUltimaMovimentaca = DateTime.Now;
                jogo.VerificarFimPercurso();
                jogo.MovimentarObstaculos(jogo.Obstaculos);
                await Task.Delay(5000);
                jogo.MovimentarObstaculos(jogo.Pontos);
                AtualizarInterface();
            }
            if (jogo.ChecarColisao())
            {
                //GameOver();
                //TocarSom();
                TocarSomBatida();
                await Task.Delay(1000);

                --jogo.Vidas;
                
                if (jogo.Vidas == 0)
                {
                    Application.Restart();
                }
                else
                {
                    TocarSomCorrida();
                }
            }
            jogo.ChecarPontuacao();
            Application.DoEvents();
        }
        private int ChecarVelocidade(String vel)
        {
            int newVel = 0;
            if(vel == "Facil")
            {
                newVel = 200;
            }
            else if(vel == "Medio")
            {
                newVel = 100;
            }
            else if (vel == "Dificil")
            {
                newVel = 50;
            }
            return newVel;
        }
        private int ChecarVidas(String vel)
        {
            int newVida = 5;
            if (vel == "Facil")
            {
                newVida = 5;
            }
            else if (vel == "Medio")
            {
                newVida = 2;
            }
            else if (vel == "Dificil")
            {
                newVida = 1;
            }
            return newVida;
        }
        
        private void GameOver()
        {
            var picOver = new PictureBox();
            picOver.Size = new Size(800, 500);
            picOver.Location = new Point(0, 0);
            //cOver.BackgroundImage = Properties.Resources.
        }
        private void AtualizarInterface()
        {
            int tempoAtual = 0;
            tempoAtual += (DateTime.Now - comeco).TotalMinutes;
            int pontos = jogo.PontuacaoTempo(tempoAtual);
            labelPontos.Text = $"Moedas Coletadas: {jogo.Pontuacao}";
            labelTimer.Text = $"Tempo de Jogo: {tempoAtual}";
            labelVidas.Text = $"Vidas Restantes: {jogo.Vidas}";
            labelPontosTempo.Text = $"Pontuação por Tempo: {pontos}";
            labelPontosObstaculos.Text = $"Pontos por Obstaculos: {jogo.PontosObstaculos}";
        }
        private void TocarSomBatida()
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = "C:\\Users\\hidek\\source\\repos\\jogoCorrida\\JogoCorridaWinFormsApp\\Resources\\crashSOund.wav";
            sp.Play();
        }
        private void TocarSomCorrida()
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = "C:\\Users\\hidek\\source\\repos\\jogoCorrida\\JogoCorridaWinFormsApp\\Resources\\tekuMusic.wav";
            sp.PlayLooping();
        }
    }
}

using jogoCorrida;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JogoCorridaWinFormsApp
{
    public partial class FormJogo : Form
    {
        Jogo jogo;
        Inicio inicio = new Inicio();
        DateTime tempoUltimaMovimentaca = DateTime.Now;
        DateTime comeco = DateTime.Now;
        DateTime flagContagem = DateTime.Now;
        List<PictureBox> pictureBoxesOb = [];
        List<PictureBox> pictureBoxesP = [];
        List<PictureBox> pictureBoxesC = [];
        bool flagTempo = true;

        public FormJogo(String nivel)
        {
            DoubleBuffered = true;
            jogo = new Jogo
            {
                Faixa1Inicio = 200,
                Faixa1Fim = 300,
                Faixa2Inicio = 305,
                Faixa2Fim = 405,
                Faixa3Inicio = 410,
                Faixa3Fim = 510

            };
            InitializeComponent();
            TocarSomCorrida();

            jogo.Pontuacao = 0;
            jogo.YMaximo = 500;
            jogo.IniciaJogo();
            jogo.Carro.PosicaoX = jogo.PosicionaObjeto(1);
            jogo.Carro.Altura = 200;
            jogo.Carro.Largura = 180;

            ChecarNivel(nivel);
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
                if (i > 0)
                {

                }
                if (ob.Largura >= 10)
                {
                    int qual = ob.Identificacao;
                    if (qual == 1)
                    {
                        pictureBoxesOb[i].BackgroundImage = Properties.Resources.obstaculo;
                    }
                    else if (qual == 2)
                    {
                        pictureBoxesOb[i].BackgroundImage = Properties.Resources.cone;
                    }
                    else
                    {
                        pictureBoxesOb[i].BackgroundImage = Properties.Resources.cacto;
                    }
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
                if ((flagContagem - tempoUltimaMovimentaca).Milliseconds >= 3000)
                {
                    flagTempo = true;
                    flagContagem = DateTime.Now;
                }
                jogo.MovimentarObstaculos(jogo.Obstaculos, flagTempo);
                jogo.MovimentarObstaculos(jogo.Pontos, flagTempo);
                AtualizarInterface();
                if (jogo.PontosTempo >= 100 && jogo.FaseAtual == "Fase 1")
                {
                    await
                    TrocaFaseVisual();
                    TrocaFaseDificuldade();
                    jogo.FaseAtual = "Fase 2";
                }
                flagTempo = false;
            }
            if (jogo.ChecarColisao())
            {
                //GameOver();
                //TocarSom();
                EfeitoBatida();
                await Task.Delay(2000);


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
        private async void EfeitoBatida()
        {
            TocarSomBatida();
            timerJogo.Stop();
            picCarroCorrida.BackgroundImage = null;
            pictureBoxCarroBatido.Location = new Point(jogo.Carro.PosicaoX, jogo.Carro.PosicaoY);
            pictureBoxCarroBatido.Size = new Size(92, 71);
            pictureBoxCarroBatido.BackgroundImage = Properties.Resources.carroBatido;
            await Task.Delay(2000);
            pictureBoxCarroBatido.Location = new Point(0, 0);
            pictureBoxCarroBatido.Size = new Size(0, 0);
            pictureBoxCarroBatido.BackgroundImage = null;
            picCarroCorrida.BackgroundImage = Properties.Resources.carroPNG;
            timerJogo.Start();

        }
        private void ChecarNivel(String vel)
        {
            if (vel == "easy")
            {
                jogo.Vidas = 5;
                jogo.Velocidade = 200;
                jogo.numeroSorte = 150;
            }
            else if (vel == "medium")
            {
                jogo.Vidas = 2;
                jogo.Velocidade = 100;
                jogo.numeroSorte = 100;
            }
            else if (vel == "hard")
            {
                jogo.Vidas = 1;
                jogo.Velocidade = 50;
                jogo.numeroSorte = 80;
            }
            else
            {
                jogo.Velocidade = 100;
                jogo.Vidas = 2;
                jogo.numeroSorte = 100;
            }
        }
        private void AtualizarInterface()
        {
            double tempoAtual = 0;
            tempoAtual += (DateTime.Now - comeco).TotalMinutes;
            int pontos = jogo.PontuacaoTempo(tempoAtual);
            tempoAtual = CalcularMinutos(tempoAtual);
            labelPontos.Text = $"Moedas Coletadas: {jogo.Pontuacao}";
            labelTimer.Text = $"Tempo de Jogo: {Math.Round(tempoAtual, 2)}";
            labelVidas.Text = $"Vidas Restantes: {jogo.Vidas}";
            labelPontosTempo.Text = $"Pontuação por Tempo: {pontos}";
            labelPontosObstaculos.Text = $"Pontos por Obstaculos: {jogo.PontosObstaculos}";
        }
        private double CalcularMinutos(double tempo)
        {
            double segundos = 0;
            segundos = tempo * 60;
            return segundos;

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
        private void TrocaFaseDificuldade()
        {
            jogo.Velocidade -= 20;

        }
        private async Task TrocaFaseVisual()
        {
            timerJogo.Stop();
            labelHeadingFase.Font = new Font("Palatino Linotype", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHeadingFase.Location = new Point(209, 152);
            labelHeadingFase.Name = "labelHeadingFase";
            labelHeadingFase.Size = new Size(398, 162);
            labelHeadingFase.TabIndex = 11;
            labelHeadingFase.Text = "Fase 2";
            labelHeadingFase.TextAlign = ContentAlignment.MiddleCenter;
            await Task.Delay(1000);
            BackgroundImage = Properties.Resources.pistaNoiteKamarao;
            await Task.Delay(1000);
            labelHeadingFase.Font = new Font("Palatino Linotype", 1F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHeadingFase.Location = new Point(0, 0);
            labelHeadingFase.Name = "labelHeadingFase";
            labelHeadingFase.Size = new Size(0, 0);
            labelHeadingFase.TabIndex = 0;
            labelHeadingFase.Text = null;
            labelHeadingFase.TextAlign = ContentAlignment.MiddleCenter;
            await Task.Delay(1000);
            timerJogo.Start();
        }

        private void FormJogo_Load(object sender, EventArgs e)
        {

        }
    }
}

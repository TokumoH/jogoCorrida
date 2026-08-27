using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace jogoCorrida
{
    public class Jogo
    {
        public Elemento Carro { get; set; }
        public List<Elemento> Obstaculos { get; set; }
        public List<Elemento> Pontos { get; set; }
        public int Velocidade { get; set; }
        public int Pontuacao { get; set; }
        public int MelhorPontuacao { get; set; }
        public int ColisoesPermitidas{ get; set; }
        public int Faixa1Inicio { get; set; }
        public int Faixa1Fim { get; set; }
        public int Faixa2Inicio { get; set; }
        public int Faixa2Fim { get; set; }
        public int Faixa3Inicio { get; set; }
        public int Faixa3Fim { get; set; }
        public int YMaximo { get; set; } = 50;
        public int Posicao { get; set;  }
        public int X_inicial { get; set; } = 400;
        public int Y_inicial { get; set; } = 210;
        public int Vidas { get; set; }
        public int PontosTempo { get; set; } = 0;
        public int PontosObstaculos { get; set; } = 0;
        public void IniciaJogo()
        {
            Carro = new Elemento();
            Carro.Tipo = TipoElemento.Carro;
            Carro.PosicaoX = PosicionaObjeto(1);
            Carro.PosicaoY = YMaximo - 10;

            Carro.PosicaoY = YMaximo - 120;

            Obstaculos = FabricaObstaculos(3);
            Pontos = FabricaObstaculos(2);

        }
        public List<Elemento> FabricaObstaculos(int qtd)
        {
            var tamanho_inicial = 2;
            var rnd = new Random();
            var obstaculos = new List<Elemento>();

            for (int i = 0; i < qtd; i++)
            { 
                var ob = new Elemento();
                var faixa = rnd.Next(1, 4);
                ob.Faixa = faixa;
                ob.PosicaoX = X_inicial;
                ob.PosicaoY = Y_inicial;
                ob.Altura = tamanho_inicial;
                ob.Largura = tamanho_inicial;
                obstaculos.Add(ob);

            }
            return obstaculos;
        }
        public int PosicionaObjeto(int faixa)
        {
            if(faixa == 1)
            {
                return Faixa1Inicio + ((Faixa1Fim - Faixa1Inicio) / 2);
            }
            else if(faixa == 2) 
            {
                return Faixa2Inicio + ((Faixa2Fim - Faixa2Inicio) / 2);
            }
            else 
            {
                return Faixa3Inicio + ((Faixa3Fim - Faixa3Inicio) / 2);
            }

        }

        public void Acelerar(int incremento)
        {
            Velocidade += incremento;
        }

        public int ChecarFaixaElemento(Elemento elemento)
        {
            if(elemento.PosicaoX >= Faixa1Inicio && elemento.PosicaoX <= Faixa1Fim)
            {
                return 1;
            }
            else if (elemento.PosicaoX >= Faixa2Inicio && elemento.PosicaoX <= Faixa2Fim)
            {
                return 2;
            }

            else if (elemento.PosicaoX >= Faixa3Inicio && elemento.PosicaoX <= Faixa3Fim)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        public bool ChecarPontuacao()
        {
            foreach (var p in Pontos)
            {
                if (ChecarFaixaElemento(Carro) == p.Faixa)
                {
                    if (Carro.PosicaoY - p.PosicaoY <= 80)
                    {
                        Pontuacao++;
                        p.PosicaoY = Y_inicial;
                        p.PosicaoX = X_inicial;
                        p.Largura = 2;
                        p.Altura = 2;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ChecarColisao()
        {
            foreach(var ob in Obstaculos)
            {
                if(ChecarFaixaElemento(Carro) == ob.Faixa)
                {
                    if(Carro.PosicaoY - ob.PosicaoY <= 90)

                    {
                        ob.PosicaoY = Y_inicial;
                        ob.PosicaoX = X_inicial;
                        ob.Largura = 2;
                        ob.Altura = 2;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool VerificaFimJogo()
        {
            return true;
        }
        public async void VerificarFimPercurso()
        {
            foreach (var ob in Obstaculos)
            {
                if (Carro.PosicaoY - ob.PosicaoY <= 80)
                {
                    
                    ob.Altura = 2;
                    ob.Largura = 2;
                    ob.PosicaoY = Y_inicial;
                    ob.PosicaoX = X_inicial;
                    PontosObstaculos += 10;
                    await Task.Delay(4000);
                }
            }
            foreach (var p in Pontos)
            {
                if (Carro.PosicaoY - p.PosicaoY <= 80)
                {
                    p.Altura = 2;
                    p.Largura = 2;
                    p.PosicaoY = Y_inicial;
                    p.PosicaoX = X_inicial;
                    await Task.Delay(4000);
                }
            }
        }
        public int PontuacaoTempo(int tempoAtual)
        {
            PontosTempo = (tempoAtual * 10);
            return PontosTempo;
        }
        public async void MovimentarObstaculos(List<Elemento> Props)
        {
            foreach (var ob in Props)
            {
                
                var rnd = new Random();
                var del = rnd.Next(7000, 9000);
                await Task.Delay(del);
                
                ob.Largura += 2;
                ob.Altura += 2;
                if (ob.Faixa == 1)
                {
                    ob.PosicaoX -= 3;
                    ob.PosicaoY += 2;
                }
                else if (ob.Faixa == 2)
                {
                    ob.PosicaoX -= 1;
                    ob.PosicaoY += 2;
                }
                else if (ob.Faixa == 3)
                {
                    ob.PosicaoX += 1;
                    ob.PosicaoY += 2;
                }
            }
            
        }
    }
}

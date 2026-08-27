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
            var tamanho_inicial = 10;
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
                    if (Carro.PosicaoY - p.PosicaoY <= 50)
                    {
                        Pontuacao++;
                        p.PosicaoY = 210;
                        p.PosicaoX = 405;
                        p.Largura = 10;
                        p.Altura = 10;
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
                    if(Carro.PosicaoY - ob.PosicaoY <= 50)

                    {
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

        public async void MovimentarObstaculos(List<Elemento> Props)
        {
            foreach (var ob in Props)
            {
                await Task.Delay(1200);
                ob.Largura += 10;
                ob.Altura += 10;
                if (ob.Faixa == 1)
                {
                    ob.PosicaoX -= 15;
                    ob.PosicaoY += 10;
                }
                else if (ob.Faixa == 2)
                {
                    ob.PosicaoX -= 5;
                    ob.PosicaoY += 10;
                }
                else if (ob.Faixa == 3)
                {
                    ob.PosicaoX += 5;
                    ob.PosicaoY += 10;
                }
                if(Carro.PosicaoY - ob.PosicaoY <= 40)
                { 
                    ob.Altura = 10;
                    ob.Largura = 10;
                    ob.PosicaoY = Y_inicial;
                    ob.PosicaoX = X_inicial;
                }
            }
            
        }
    }
}

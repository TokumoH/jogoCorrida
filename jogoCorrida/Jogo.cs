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
        public int numeroSorte { get; set; } = 100;
        public int FlagTimer { get; set; } = 0;
        public String FaseAtual { get; set; } = "Fase 1";
        public void IniciaJogo() 
        {
            Carro = new Elemento();
            Carro.Tipo = TipoElemento.Carro;
            Carro.PosicaoX = PosicionaObjeto(1);
            Carro.PosicaoY = YMaximo - 10;

            Carro.PosicaoY = YMaximo - 120;

            Obstaculos = FabricaObstaculos(5);
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
                var tipo = rnd.Next(1, 4);
                var sorte = rnd.Next(1, numeroSorte);
                ob.Sorte = sorte;
                ob.Flag = 0;
                ob.Identificacao = tipo;
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
                    if(Carro.PosicaoY - ob.PosicaoY <= 85)

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
        public bool VerificaFaixa(int val)
        {
            foreach (var ob in Obstaculos)
            {
                if(ob.Flag == 1)
                {
                    if(ob.Faixa == val)
                    {
                        return true;

                    }
                }
            }
            foreach (var p in Pontos)
            {
                if (p.Flag == 1)
                {
                    if (p.Faixa == val)
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
        public async void VerificarFimPercurso()
        {
            var rnd = new Random();
            var faixaNova = 0;
            foreach (var ob in Obstaculos)
            {
                if (Carro.PosicaoY - ob.PosicaoY <= 70)
                {

                    faixaNova = rnd.Next(1, 4);
                    ob.Altura = 2;
                    ob.Largura = 2;
                    ob.Faixa = faixaNova;
                    ob.PosicaoY = Y_inicial;
                    ob.PosicaoX = X_inicial;
                    PontosObstaculos += 10;
                    ob.Flag = 0;
                    
                }
            }
            foreach (var p in Pontos)
            {
                if (Carro.PosicaoY - p.PosicaoY <= 70)
                {
                    faixaNova = rnd.Next(1, 4);
                    if (VerificaFaixa(faixaNova))
                    {
                        var faixaAux = 0;
                        do
                        {
                            faixaAux = rnd.Next(1, 4);
                        } while (!VerificaFaixa(faixaAux));
                        faixaNova = faixaAux;
                    }
                    p.Faixa = faixaNova;
                    p.Altura = 2;
                    p.Largura = 2;
                    p.PosicaoY = Y_inicial;
                    p.PosicaoX = X_inicial;
                    p.Flag = 0;
                    
                }
            }
        }
        public int PontuacaoTempo(double tempoAtual)
        {
            PontosTempo = (int)(tempoAtual*60) * 10;
            return PontosTempo;
        }
        public void MovimentarObstaculos(List<Elemento> Props, bool tempo)
        {
            var i = 0;
            var rnd = new Random();
            var crescimento = 1;
            var sorteio = rnd.Next(1, numeroSorte);
            var index = 0;
            foreach (var ob in Props)
            {
                if(ob.Altura >= 200)
                {
                    crescimento = 5;
                }
                index = ob.Faixa - 1;
                bool faixaOcupada = false;

                if (tempo)
                {
                    faixaOcupada = false;
                }
                else
                {
                    faixaOcupada = VerificaFaixa(ob.Faixa);
                }

                VerificarFimPercurso();
                if((i == 0 || (ob.Sorte == sorteio && !faixaOcupada) || ob.Flag == 1))
                {
                    ob.Flag = 1;
                    ob.Largura += 2 * crescimento;
                    ob.Altura += 2 * crescimento;
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
                crescimento = 1;
                i++;
                
            }
            
        }
    }
}

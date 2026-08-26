using jogoCorrida;
using System.Data;
using System.Security.Cryptography.X509Certificates;
class Program
{
    static void Main()
    {
        Jogo jogo = new Jogo
        {
            Faixa1Inicio = 2,
            Faixa1Fim = 11,
            Faixa2Inicio = 13,
            Faixa2Fim = 22,
            Faixa3Inicio = 24,
            Faixa3Fim = 33,
            Pontuacao = 0
        };

        jogo.IniciaJogo();
        jogo.Carro.PosicaoX = jogo.PosicionaObjeto(2);
        jogo.Carro.PosicaoY = 10;
        jogo.YMaximo = 11;
        jogo.Velocidade = 200;
        var tempoUltimaMovimentacao = DateTime.Now;
        var pontuacao = jogo.Pontuacao; 

        int posicao = 2;
        TelaIncial();
        for (; ; )
        {
            

            DesenhaCenario(pontuacao);
            DesenharElemento(jogo.Carro.PosicaoY, jogo.Carro.PosicaoX, '0');
            /*
            DesenhaCenario();
            DesenharElemento(2, 6, 'X');
            DesenharElemento(4, 17, 'X');
            DesenharElemento(10, posicao == "Left" ? 6 : 17 , '0');
           */
            
           
            foreach (var ob in jogo.Obstaculos)
            {
                if (ob.PosicaoY >= 0)
                {
                    DesenharElemento(ob.PosicaoY, ob.PosicaoX, 'X');
                }
            }

            foreach (var p in jogo.Pontos)
            {
                if (p.PosicaoY >= 0)
                {
                    DesenharElemento(p.PosicaoY, p.PosicaoX, '$');
                }
            }

            if ((DateTime.Now - tempoUltimaMovimentacao).Milliseconds >= jogo.Velocidade){
                tempoUltimaMovimentacao = DateTime.Now;
                jogo.MovimentarObstaculos();
            }
            
            if (Console.KeyAvailable)
            {
                Console.Beep();
                var tecla = Console.ReadKey();
                Console.WriteLine(tecla.ToString());
                if (tecla.Key == ConsoleKey.LeftArrow && posicao > 1)
                {
                    posicao -= 1;
                    jogo.Carro.PosicaoX = jogo.PosicionaObjeto(posicao);
                }
                else if (tecla.Key == ConsoleKey.RightArrow && posicao < 4)
                {
                    posicao += 1;
                    jogo.Carro.PosicaoX = jogo.PosicionaObjeto(posicao);
                }
            }
            jogo.ChecarPontuacao();
            pontuacao = jogo.Pontuacao;
            if (jogo.ChecarColisao())
            {
                GameOver();
                Console.Beep();
                break;
            }

            Thread.Sleep(100);

        }
    }
    public static void DesenharElemento(int linha, int coluna, char simbolo)
    {
        var xOriginal = Console.CursorLeft;
        var yOriginal = Console.CursorTop;
        Console.SetCursorPosition(coluna, linha);
        Console.Write(simbolo.ToString());
        Console.SetCursorPosition(xOriginal, yOriginal);
    }

    public static void GameOver()
    {
        Console.Clear();
        Console.Write("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n" +
            "███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀\r\n" +
            "██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼\r\n" +
            "██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀\r\n" +
            "██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼\r\n" +
            "███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄\r\n" +
            "┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n" +
            "███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼\r\n" +
            "██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼\r\n" +
            "██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼\r\n" +
            "██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼\r\n" +
            "███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄\r\n" +
            "┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n" +
            "┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼\r\n" +
            "┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼\r\n" +
            "┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼\r\n" +
            "┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼\r\n" +
            "┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼\r\n" +
            "┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼\r\n" +
            "┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼\r\n" +
            "┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n" +
            "┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼\r\n" +
            "┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼\r\n" +
            "┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼\r\n" +
            "┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\n");
    }
    public static void DesenhaCenario(int pont)
    {
        Console.Clear();
        Console.WriteLine(
            "+----------+----------+----------+\n" +
            "|          |          |          |\n" +
            "|          |          |          |\n" +
            "|          |          |          |\n" +
            "|          |          |          |\n" +
            "|          |          |          |\n" +
            "|          |          |          |\n" +
            "|          |          |          |\n" +
            "|          |          |          |\n" +
            "|          |          |          |\n" +
            "|          |          |          |\n" +
            "+----------+----------+----------+\n");
        Console.Write("Pontuação: " + pont + "\n");
 
    }
    public static void TelaIncial()
    {
        var iniciar = true;
        Console.WriteLine("Fórmula Leclerc 16");
        Console.WriteLine(
            "       .-----------,-.-------. \r\n" +
            "       |:_L_e_c_l//(_)\\e_r_c|:\r\n" +
            "    ___||=======// ,--.\\===.|  ___\r\n" +
            "  .'.\"\"'\\\\____.'/ | (__)\\__|\\.'.\"\"'.\r\n" +
            "  | |\"\"\"||._       '---'__   `-|\"\"\"|\r\n" +
            "  | |\"\"\"||. '-.___  ` -'--'     `-.| ___\r\n" +
            "  | |\"\"\"|| '-.'.\"\"'.----._     .---:'.\"\"'.\r\n" +
            "  `.'_\".'|   | |\"\"\"|_____ `. /\\ \\___||_\"\"|\r\n" +
            "          '-.| |\"\"_/_____\\  \\ \\\\ \\_____\\_|\r\n" +
            "             | |\"|____    ', '.__/   ____|\r\n" +
            "             `.'__.'  `'---'-'---'-'.'__.'"
            );
        Console.Write("Pressione qualquer tecla para iniciar o jogo...");  
        while (iniciar)
        {
            
            if (Console.KeyAvailable)
            {
                iniciar = false;
            }
        }
    }

    
}

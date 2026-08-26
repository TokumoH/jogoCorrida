using System.ComponentModel;

namespace jogoCorrida
{
    public class Elemento
    {
        //ATRIBUTO DA CLASSE
        public TipoElemento Tipo { get; set; }
        public int PosicaoX;
        public int PosicaoY;
        public int Altura { get; set; }
        public int Faixa { get; set; }
        public int Largura { get; set; }

        public void Movimentar(int x, int y)
        {
            PosicaoX = x;
            PosicaoY = y;
        }
    }
}

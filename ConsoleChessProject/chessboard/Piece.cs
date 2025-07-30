using ConsoleChessProject.chessboard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChessProject.chessboard
{
    class Piece
    {
        public Position Position { get; set; }
        public Cor Cor { get; protected set; }
        public int Moviments { get; set; }
        public Chessboard Chessboard { get; set; }

        public Piece(Cor cor, Chessboard chessboard)
        {
            Position = null;
            Cor = cor;
            Chessboard = chessboard;
            Moviments = 0;
        }

        public void addMoviments() 
        {
            Moviments++;
        }
    }
}

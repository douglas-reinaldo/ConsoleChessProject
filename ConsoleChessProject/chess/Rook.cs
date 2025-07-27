using ConsoleChessProject.chessboard;
using ConsoleChessProject.chessboard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChessProject.chess
{
    class Rook : Piece
    {
        public Rook(Cor cor, Chessboard chessboard) : base(cor, chessboard)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}

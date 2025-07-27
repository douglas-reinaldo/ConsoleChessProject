using ConsoleChessProject.chessboard;
using ConsoleChessProject.chessboard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChessProject.chess
{
    class King : Piece
    {
        public King(Cor cor, Chessboard chessboard) : base(cor, chessboard)
        {
        }

        public override string ToString()
        {
            return "K";
        }
    }
}

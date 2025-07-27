using System;
using ConsoleChessProject.chessboard;

namespace ConsoleChessProject.chess
{
    class ChessboardPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessboardPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }


        public Position toPosition() 
        {
            return new Position(8 - Line, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}

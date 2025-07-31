using ConsoleChessProject.chessboard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChessProject.chessboard
{
    abstract class Piece
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

        public void subtractMoviments() 
        {
            Moviments--;
        }

        public abstract bool[,] possibleMovements();

        public bool canMoveTo(Position position) 
        {
            return possibleMovements()[position.line, position.column];
        }

        public bool existPossibleMoviments() 
        {
            bool[,] mat = possibleMovements();
            for (int i = 0; i < Chessboard.Lines; i++) 
            {
                for (int j = 0; j < Chessboard.Columns; j++) 
                {
                    if (mat[i, j]) 
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

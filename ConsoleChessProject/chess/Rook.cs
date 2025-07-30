using ConsoleChessProject.chessboard;
using ConsoleChessProject.chessboard.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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


        private bool canMove(Position position)
        {
            Piece p = Chessboard.piece(position);
            return p == null || p.Cor != Cor;
        }


        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[Chessboard.Lines, Chessboard.Columns];

            Position position = new Position(0, 0);


            // cima
            position.setValues(Position.line - 1, Position.column);
            while (Chessboard.validPosition(position) && canMove(position)) 
            {
                mat[position.line, position.column] = true;
                if (Chessboard.piece(position) != null && Chessboard.piece(position).Cor != Cor) 
                {
                    break;
                }

                position.line = position.line - 1;

            }

            // abaixo
            position.setValues(Position.line + 1, Position.column);
            while (Chessboard.validPosition(position) && canMove(position))
            {
                mat[position.line, position.column] = true;
                if (Chessboard.piece(position) != null && Chessboard.piece(position).Cor != Cor)
                {
                    break;
                }

                position.line = position.line + 1;

            }


            // direita
            position.setValues(Position.line, Position.column + 1);
            while (Chessboard.validPosition(position) && canMove(position))
            {
                mat[position.line, position.column] = true;
                if (Chessboard.piece(position) != null && Chessboard.piece(position).Cor != Cor)
                {
                    break;
                }

                position.column = position.column + 1;

            }

            // esquerda
            position.setValues(Position.line, Position.column - 1);
            while (Chessboard.validPosition(position) && canMove(position))
            {
                mat[position.line, position.column] = true;
                if (Chessboard.piece(position) != null && Chessboard.piece(position).Cor != Cor)
                {
                    break;
                }

                position.column = position.column - 1;

            }
            return mat;
        }



    }
}

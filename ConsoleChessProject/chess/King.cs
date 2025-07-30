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

        private bool canMove(Position position) 
        {
            Piece p = Chessboard.piece(position);
            return p == null || p.Cor != Cor; 
        }


        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[Chessboard.Lines, Chessboard.Columns];

            Position position = new Position(0, 0);

            // acima
            position.setValues(Position.line - 1, Position.column);
            if (Chessboard.validPosition(position) && canMove(position)) 
            {
                mat[position.line, position.column] = true;
            }

            // ne
            position.setValues(Position.line - 1, Position.column + 1);
            if (Chessboard.validPosition(position) && canMove(position))
            {
                mat[position.line, position.column] = true;
            }

            // direita
            position.setValues(Position.line, Position.column + 1);
            if (Chessboard.validPosition(position) && canMove(position))
            {
                mat[position.line, position.column] = true;
            }

            // se
            position.setValues(Position.line + 1, Position.column + 1);
            if (Chessboard.validPosition(position) && canMove(position))
            {
                mat[position.line, position.column] = true;
            }

            // abaixo
            position.setValues(Position.line + 1, Position.column);
            if (Chessboard.validPosition(position) && canMove(position))
            {
                mat[position.line, position.column] = true;
            }

            // so
            position.setValues(Position.line + 1, Position.column - 1);
            if (Chessboard.validPosition(position) && canMove(position))
            {
                mat[position.line, position.column] = true;
            }

            // esquerda
            position.setValues(Position.line, Position.column - 1);
            if (Chessboard.validPosition(position) && canMove(position))
            {
                mat[position.line, position.column] = true;
            }

            // no
            position.setValues(Position.line - 1, Position.column - 1);
            if (Chessboard.validPosition(position) && canMove(position))
            {
                mat[position.line, position.column] = true;
            }

            return mat;
        }


        public override string ToString()
        {
            return "K";
        }
    }
}

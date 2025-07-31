using ConsoleChessProject.chessboard;
using ConsoleChessProject.chessboard.Enums;
using ConsoleChessProject.chess;

namespace xadrez
{
    class Bishop : Piece
    {
        public Bishop(Cor color, Chessboard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        private bool canMove(Position pos)
        {
            Piece p = Chessboard.piece(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[Chessboard.Lines, Chessboard.Columns];

            Position pos = new Position(0, 0);

            // Northwest
            pos.setValues(Position.line - 1, Position.column - 1);
            while (Chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (Chessboard.piece(pos) != null && Chessboard.piece(pos).Cor != Cor)
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column - 1);
            }

            // Northeast
            pos.setValues(Position.line - 1, Position.column + 1);
            while (Chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (Chessboard.piece(pos) != null && Chessboard.piece(pos).Cor != Cor)
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column + 1);
            }

            // Southeast
            pos.setValues(Position.line + 1, Position.column + 1);
            while (Chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (Chessboard.piece(pos) != null && Chessboard.piece(pos).Cor != Cor)
                {
                    break;
                }
                pos.setValues(pos.line + 1, pos.column + 1);
            }

            // Southwest
            pos.setValues(Position.line + 1, Position.column - 1);
            while (Chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (Chessboard.piece(pos) != null && Chessboard.piece(pos).Cor != Cor)
                {
                    break;
                }
                pos.setValues(pos.line + 1, pos.column - 1);
            }

            return mat;
        }
    }
}

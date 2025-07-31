using ConsoleChessProject.chessboard;
using ConsoleChessProject.chessboard.Enums;
using ConsoleChessProject.chess;

namespace xadrez
{
    class Knight : Piece
    {
        public Knight(Cor color, Chessboard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "N";
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

            pos.setValues(Position.line - 1, Position.column - 2);
            if (Chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(Position.line - 2, Position.column - 1);
            if (Chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(Position.line - 2, Position.column + 1);
            if (Chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(Position.line - 1, Position.column + 2);
            if (Chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(Position.line + 1, Position.column + 2);
            if (Chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(Position.line + 2, Position.column + 1);
            if (Chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(Position.line + 2, Position.column - 1);
            if (Chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(Position.line + 1, Position.column - 2);
            if (Chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            return mat;
        }
    }
}

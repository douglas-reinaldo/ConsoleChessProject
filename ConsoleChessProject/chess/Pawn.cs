using ConsoleChessProject.chessboard;
using ConsoleChessProject.chessboard.Enums;
using ConsoleChessProject.chess;


namespace xadrez
{

    class Pawn : Piece
    {

        public Pawn(Cor cor, Chessboard tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existsEnemy(Position pos)
        {
            Piece p = Chessboard.piece(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Free(Position pos)
        {
            return Chessboard.piece(pos) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[Chessboard.Lines, Chessboard.Columns];

            Position pos = new Position(0, 0);

            if (Cor == Cor.Branca)
            {
                pos.setValues(Position.line - 1, Position.column);
                if (Chessboard.validPosition(pos) && Free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(Position.line - 2, Position.column);
                Position p2 = new Position(Position.line - 1, Position.column);
                if (Chessboard.validPosition(p2) && Free(p2) && Chessboard.validPosition(pos) && Free(pos) && Moviments == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(Position.line - 1, Position.column);
                if (Chessboard.validPosition(pos) && existsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(Position.line - 1, Position.column);
                if (Chessboard.validPosition(pos) && existsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }
            else
            {
                pos.setValues(Position.line + 1, Position.column);
                if (Chessboard.validPosition(pos) && Free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(Position.line + 2, Position.column);
                Position p2 = new Position(Position.line + 1, Position.column);
                if (Chessboard.validPosition(p2) && Free(p2) && Chessboard.validPosition(pos) && Free(pos) && Moviments == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(Position.line + 1, Position.column);
                if (Chessboard.validPosition(pos) && existsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(Position.line + 1, Position.column);
                if (Chessboard.validPosition(pos) && existsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }

            return mat;
        }
    }
}
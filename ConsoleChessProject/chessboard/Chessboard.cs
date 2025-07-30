using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChessProject.chessboard
{
    class Chessboard
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces { get; set; }

        public Chessboard(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines, Columns];
        }



        public Piece piece(int line, int column) 
        {
            return Pieces[line, column];
        }


        public Piece piece(Position position) 
        {
            return Pieces[position.line, position.column];
        }
        



        public bool pieceExists(Position position) 
        {
            validatePosition(position);
            return piece(position) != null;
        }



        public void inputPiece(Piece piece, Position position) 
        {
            if (pieceExists(position))
            {
                throw new ChessboardException("There is already exists a piece in this position");
            }
            Pieces[position.line, position.column] = piece;
            piece.Position = position;
        }



        public bool validPosition(Position position) 
        {
            if (position.line < 0 || position.line >= Lines || position.column < 0 || position.column >= Columns) 
            {
                return false;
            }
            return true;
        }


        public Piece removePiece(Position pos) 
        {
            if (piece(pos) == null) 
            {
                return null;
            }

            Piece ps = piece(pos);
            ps.Position = null;
            Pieces[pos.line, pos.column] = null;
            return ps;
        }


        public void validatePosition(Position position) 
        {
            if (!validPosition(position)) 
            {
                throw new ChessboardException("Invalid Position!");
            }
        }
    }
}

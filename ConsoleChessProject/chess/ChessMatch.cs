using System;
using ConsoleChessProject.chessboard.Enums;
using ConsoleChessProject.chessboard;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;

namespace ConsoleChessProject.chess
{
    class ChessMatch
    {
        public Chessboard cb { get; private set; }
        private int turno;
        private Cor currentPlayer;
        public bool finished { get; private set; }



        public ChessMatch()
        {
            cb = new Chessboard(8, 8);
            turno = 1;
            currentPlayer = Cor.Branca;
            finished = false;
            setUpPieces();
        }

        public void executeMoviment(Position source, Position target) 
        {
            Piece p = cb.removePiece(source);
            p.addMoviments();
            Piece capturedPiece = cb.removePiece(target);
            cb.inputPiece(p, target);

        }

        public void setUpPieces() 
        {
            cb.inputPiece(new Rook(Cor.Branca, cb), new ChessboardPosition('c', 1).toPosition());
            cb.inputPiece(new Rook(Cor.Branca, cb), new ChessboardPosition('c', 2).toPosition());
            cb.inputPiece(new Rook(Cor.Branca, cb), new ChessboardPosition('d', 2).toPosition());
            cb.inputPiece(new Rook(Cor.Branca, cb), new ChessboardPosition('d', 3).toPosition());
            cb.inputPiece(new Rook(Cor.Branca, cb), new ChessboardPosition('e', 1).toPosition());
            cb.inputPiece(new King(Cor.Branca, cb), new ChessboardPosition('d', 1).toPosition());


            cb.inputPiece(new Rook(Cor.Preta, cb), new ChessboardPosition('c', 7).toPosition());
            cb.inputPiece(new Rook(Cor.Preta, cb), new ChessboardPosition('c', 8).toPosition());
            cb.inputPiece(new Rook(Cor.Preta, cb), new ChessboardPosition('d', 7).toPosition());
            cb.inputPiece(new Rook(Cor.Preta, cb), new ChessboardPosition('e', 7).toPosition());
            cb.inputPiece(new Rook(Cor.Preta, cb), new ChessboardPosition('e', 8).toPosition());
            cb.inputPiece(new King(Cor.Preta, cb), new ChessboardPosition('d', 8).toPosition());



        }

    }
}

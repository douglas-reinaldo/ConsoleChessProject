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
        public int turno { get; private set; }
        public Cor currentPlayer { get; private set; }
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


        public void makePlay(Position source, Position target) 
        {
            executeMoviment(source, target);
            turno++;
            changePlayer();
        }

        public void changePlayer() 
        {
            if (currentPlayer == Cor.Branca) 
            {
                currentPlayer = Cor.Preta;
            }
            else 
            {
                currentPlayer = Cor.Branca;
            }
        }

        public void validateOriginPosition(Position position) 
        {
            if (cb.piece(position) == null) 
            {
                throw new ChessboardException("There is no piece in the chosen origin position");
            }
            if (currentPlayer != cb.piece(position).Cor) 
            {
                throw new ChessboardException("The chosen origin piece is not yours");
            }
            if (!cb.piece(position).existPossibleMoviments()) 
            {
                throw new ChessboardException("There is no possible movements for chosen origin piece");
            }
        }

        public void validateTargetPosition(Position origin, Position target) 
        {
            if (!cb.piece(origin).canMoveTo(target)) 
            {
                throw new ChessboardException("Invalid target position!");
            }
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

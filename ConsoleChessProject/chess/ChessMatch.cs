using System;
using ConsoleChessProject.chessboard.Enums;
using ConsoleChessProject.chessboard;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleChessProject.chess
{
    class ChessMatch
    {
        public Chessboard cb { get; private set; }
        public int turno { get; private set; }
        public Cor currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> catchedPieces;
        public bool check { get; private set; }


        public ChessMatch()
        {
            cb = new Chessboard(8, 8);
            turno = 1;
            currentPlayer = Cor.Branca;
            finished = false;
            check = false;
            pieces = new HashSet<Piece>();
            catchedPieces = new HashSet<Piece>();
            setUpPieces();
        }

        public Piece executeMoviment(Position source, Position target) 
        {
            Piece p = cb.removePiece(source);
            p.addMoviments();
            Piece capturedPiece = cb.removePiece(target);
            cb.inputPiece(p, target);
            if (capturedPiece != null) 
            {
                catchedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMovement(Position source, Position target, Piece capturedPiece) 
        {
            Piece p = cb.removePiece(target);
            p.subtractMoviments();

            if (capturedPiece != null) 
            {
                cb.inputPiece(capturedPiece, target);
                catchedPieces.Remove(capturedPiece);
            }
            cb.inputPiece(p, source);
        }

        public void makePlay(Position source, Position target) 
        {
            Piece capturedPiece = executeMoviment(source, target);
            if (isInCheck(currentPlayer)) 
            {
                undoMovement(source, target, capturedPiece);
                throw new ChessboardException("You can't put yourself in check.");
            }

            if (isInCheck(rival(currentPlayer))) 
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (checkMateTest(rival(currentPlayer))) 
            {
                finished = true;
            }

            else
            {
                turno++;
                changePlayer();
            }
                
        }


        public bool checkMateTest(Cor cor) 
        {
            if (!isInCheck(cor)) 
            {
                return false;
            }

            foreach (Piece x in piecesInGame(cor)) 
            {
                bool[,] mat = x.possibleMovements();
                for (int i = 0; i < cb.Lines; i++)
                {
                    for (int j = 0; j < cb.Columns; j++) 
                    {
                        if (mat[i,j]) 
                        {
                            Position source = x.Position;
                            Position target = new Position(i, j);
                            Piece capturedPiece = executeMoviment(source, target);
                            bool chessTest = isInCheck(cor);
                            undoMovement(source, target, capturedPiece);
                            if (!chessTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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


        public HashSet<Piece> capturedPieces(Cor cor) 
        {
            return catchedPieces.Where(n => n.Cor == cor).ToHashSet();
        }


        public HashSet<Piece> piecesInGame(Cor cor) 
        {
            HashSet<Piece> tempPieces = pieces.Where(n => n.Cor == cor).ToHashSet();
            tempPieces.ExceptWith(capturedPieces(cor));
            return tempPieces;
        }



        private Cor rival(Cor cor) 
        {
            if (cor == Cor.Branca) 
            {
                return Cor.Preta;
            }
            else 
            {
                return Cor.Branca;
            }
        }

        public bool isInCheck(Cor cor) 
        {
            Piece r = king(cor);
            foreach (Piece piece in piecesInGame(rival(cor)))
            {
                bool[,] mat = piece.possibleMovements();
                if (mat[r.Position.line, r.Position.column]) 
                {
                    return true;
                }
            }
            return false;
        }

        private Piece king(Cor cor) 
        {
            foreach (Piece piece in piecesInGame(cor)) 
            {
                if (piece is King) 
                {
                    return piece;
                }
            }
            return null;
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


        public void insertNewPiece(char column, int line, Piece piece) 
        {
            cb.inputPiece(piece, new ChessboardPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        public void setUpPieces() 
        {
            insertNewPiece('c', 1, new Rook(Cor.Branca, cb));
            insertNewPiece('c', 2, new Rook(Cor.Branca, cb));
            insertNewPiece('d', 2, new Rook(Cor.Branca, cb));
            insertNewPiece('d', 3, new Rook(Cor.Branca, cb));
            insertNewPiece('e', 1, new Rook(Cor.Branca, cb));
            insertNewPiece('d', 1, new King(Cor.Branca, cb));

            insertNewPiece('c', 7, new Rook(Cor.Preta, cb));
            insertNewPiece('c', 8, new Rook(Cor.Preta, cb));
            insertNewPiece('d', 7, new Rook(Cor.Preta, cb));
            insertNewPiece('e', 7, new Rook(Cor.Preta, cb));
            insertNewPiece('e', 8, new Rook(Cor.Preta, cb));
            insertNewPiece('d', 8, new King(Cor.Preta, cb));


        }

    }
}

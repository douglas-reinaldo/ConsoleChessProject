using System;
using System.Collections.Generic;
using System.Security.Permissions;
using ConsoleChessProject.chess;
using ConsoleChessProject.chessboard;
using ConsoleChessProject.chessboard.Enums;

namespace ConsoleChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                Chessboard cb = new Chessboard(8, 8);

                cb.inputPiece(new Rook(Cor.Preta, cb), new Position(0, 0));
                cb.inputPiece(new Rook(Cor.Preta, cb), new Position(1, 3));
                cb.inputPiece(new King(Cor.Preta, cb), new Position(0, 2));

                cb.inputPiece(new King(Cor.Branca, cb), new Position(3, 5));
                Screen.printChessboard(cb);
            }

            catch (ChessboardException e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

using System;
using ConsoleChessProject.chess;
using ConsoleChessProject.chessboard;
using ConsoleChessProject.chessboard.Enums;
using System.Collections.Generic;

namespace ConsoleChessProject
{
    class Screen
    {
        public static void printChessMatch(ChessMatch chessMatch)
        {
            printChessboard(chessMatch.cb);

            Console.WriteLine();
            printCapturedPieces(chessMatch);
            Console.WriteLine("Turno: " + chessMatch.turno);
            Console.WriteLine("Waiting play: " + chessMatch.currentPlayer);
            if (chessMatch.check) 
            {
                Console.WriteLine("CHECK!");
            }
        }

        public static void printCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            printSet(chessMatch.capturedPieces(Cor.Branca));
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            printSet(chessMatch.capturedPieces(Cor.Preta));
            Console.ForegroundColor = aux;
        }

        public static void printSet(HashSet<Piece> pieces) 
        {
            Console.Write("[");
            foreach (var item in pieces)
            {
                Console.Write(item + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }


        public static void printChessboard(Chessboard chessboard)
        {
            for (int i = 0; i < chessboard.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {

                    PrintPiece(chessboard.piece(i, j));

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printChessboard(Chessboard chessboard, bool[,] possiblePositions)
        {
            ConsoleColor originBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;


            for (int i = 0; i < chessboard.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = changedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originBackground;
                    }
                    PrintPiece(chessboard.piece(i, j));
                    Console.BackgroundColor = originBackground;


                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originBackground;
        }



        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Cor == chessboard.Enums.Cor.Branca)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor cc = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = cc;
                }
                Console.Write(" ");
            }
        }

        public static ChessboardPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessboardPosition(column, line);
        }
    }


}

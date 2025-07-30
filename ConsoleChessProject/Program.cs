using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
                ChessMatch cm = new ChessMatch();

                while (!cm.finished) 
                {
                    Console.Clear();
                    Screen.printChessboard(cm.cb);

                    Console.WriteLine();
                    Console.Write("Source: ");
                    Position source = Screen.readChessPosition().toPosition();
                    bool[,] possiblePositions = cm.cb.piece(source).possibleMovements();

                    Console.Clear();
                    Screen.printChessboard(cm.cb, possiblePositions);


                    Console.WriteLine();
                    Console.Write("Target: ");
                    Position target = Screen.readChessPosition().toPosition();

                    cm.executeMoviment(source, target);
                }
            }

            catch (ChessboardException e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

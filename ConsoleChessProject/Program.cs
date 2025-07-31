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

                    try
                    {
                        Console.Clear();
                        Screen.printChessMatch(cm);

                        Console.WriteLine();
                        Console.Write("Source: ");
                        Position source = Screen.readChessPosition().toPosition();
                        cm.validateOriginPosition(source);
                        bool[,] possiblePositions = cm.cb.piece(source).possibleMovements();
                      

                        Console.Clear();
                        Screen.printChessboard(cm.cb, possiblePositions);


                        Console.WriteLine();
                        Console.Write("Target: ");
                        Position target = Screen.readChessPosition().toPosition();
                        cm.validateTargetPosition(source, target);

                        cm.makePlay(source, target);
                    }
                    catch (ChessboardException e) 
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }

            catch (ChessboardException e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

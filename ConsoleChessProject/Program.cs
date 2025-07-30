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

                    Console.Write("Source: ");
                    Position source = Screen.readChessPosition().toPosition();

                    Console.WriteLine("Target: ");
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

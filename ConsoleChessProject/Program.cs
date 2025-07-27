using System;
using System.Collections.Generic;
using System.Security.Permissions;
using ConsoleChessProject.chessboard;

namespace ConsoleChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var chessboard = new Chessboard(8, 8);
            Screen.printChessboard(chessboard);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChessProject.chessboard
{
    class ChessboardException : Exception
    {
        public ChessboardException(string Message) : base(Message) 
        { }
    }
}

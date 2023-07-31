using Chess;
using console_chess;
using console_chess.Exceptions;
using Table;

namespace console_chess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition pos = new ChessPosition('d', 6);

            Console.WriteLine(pos.toPosition());
        }
    }
}

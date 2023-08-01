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
            ChessMatch match = new ChessMatch();
            Screen.PrintTable(match.Tab);
        }
    }
}

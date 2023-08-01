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
            GameTable tab = new GameTable(8, 8);

            tab.PlaceThePiece(new Position(0, 2), new Rook(tab, Color.Black));
            tab.PlaceThePiece(new Position(3, 5), new Knight(tab, Color.Black));
            tab.PlaceThePiece(new Position(4, 4), new Queen(tab, Color.White));

            Screen.PrintTable(tab);
        }
    }
}

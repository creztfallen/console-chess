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
            try
            {
            ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintTable(match.Tab);

                    Console.Write("\nOrigin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    match.MovePiece(origin, destination);
                }

            } 
            catch (Exception ex)
            {

            }
        }
    }
}

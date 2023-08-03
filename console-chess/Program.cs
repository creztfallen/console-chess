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

          try
          {
            Console.Clear();
            Screen.PrintMatch(match);

            Console.WriteLine();
            Console.Write("Origem: ");
            Position origem = Screen.ReadChessPosition().ToPosition();
            match.ValidateOriginPosition(origem);

            bool[,] posicoesPossiveis = match.Tab.PiecePosition(origem).PossibleMoves();

            Console.Clear();
            Screen.PrintTable(match.Tab, posicoesPossiveis);

            Console.WriteLine();
            Console.Write("Destino: ");
            Position destino = Screen.ReadChessPosition().ToPosition();
            match.ValidateDestinationPosition(origem, destino);

            match.MakeThePlay(origem, destino);
          }
          catch (TableException e)
          {
            Console.WriteLine(e.Message);
            Console.ReadLine();
          }
        }
        Console.Clear();
        Screen.PrintMatch(match);
      }
      catch (TableException e)
      {
        Console.WriteLine(e.Message);
      }

      Console.ReadLine();
    }
  }
}

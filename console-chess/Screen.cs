using Chess;
using Table;

namespace console_chess
{
  class Screen
  {
    public static void PrintMatch(ChessMatch match)
    {
      PrintTable(match.Tab);
      Console.WriteLine();
      PrintCapturedPieces(match);
      Console.WriteLine();
      Console.WriteLine("Turn: " + match.Turn);
      if (!match.Finished)
      {
        Console.WriteLine("Waiting for play: " + match.CurrentPlayer);
        if (match.Check)
        {
          Console.WriteLine("CHECK!");
        }
      }
      else
      {
        Console.WriteLine("CHECK MATE!");
        Console.WriteLine("Winner: " + match.CurrentPlayer);
      }
    }

    public static void PrintCapturedPieces(ChessMatch match)
    {
      Console.WriteLine("Captured pieces:");
      Console.Write("White: ");
      PrintGroup(match.CapturedPieces(Color.White));
      Console.WriteLine();
      Console.Write("Black: ");
      ConsoleColor aux = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Yellow;
      PrintGroup(match.CapturedPieces(Color.Black));
      Console.ForegroundColor = aux;
      Console.WriteLine();
    }

    public static void PrintGroup(HashSet<Piece> group)
    {
      Console.Write("[");
      foreach (Piece x in group)
      {
        Console.Write(x + " ");
      }
      Console.Write("]");
    }

    public static void PrintTable(GameTable tab)
    {
      for (int i = 0; i < tab.Rows; i++)
      {
        Console.Write(8 - i + " ");
        for (int j = 0; j < tab.Columns; j++)
        {
          if (tab.PiecePosition(i, j) == null)
          {
            Console.Write("- ");
          }
          else
          {
            AddPiece(tab.PiecePosition(i, j));
          }

        }
        Console.WriteLine();
      }
      Console.WriteLine("  A B C D E F G H");
    }

    public static void PrintTable(GameTable tab, bool[,] possiblePositions)
    {
      ConsoleColor originalBackground = Console.BackgroundColor;
      ConsoleColor alteredBackGround = ConsoleColor.DarkGray;

      for (int i = 0; i < tab.Rows; i++)
      {
        Console.Write(8 - i + " ");
        for (int j = 0; j < tab.Columns; j++)
        {
          if (possiblePositions[i, j])
          {
            Console.BackgroundColor = alteredBackGround;
          }
          else
          {
            Console.BackgroundColor = originalBackground;
          }
          AddPiece(tab.PiecePosition(i, j));
          Console.BackgroundColor = originalBackground;
        }
        Console.WriteLine();
      }
      Console.WriteLine("  A B C D E F G H");
      Console.BackgroundColor = originalBackground;
    }

    public static ChessPosition ReadChessPosition()
    {
      string s = Console.ReadLine();
      char column = s[0];
      int row = int.Parse(s[1] + "");
      return new ChessPosition(column, row);
    }

    public static void AddPiece(Piece piece)
    {
      if (piece == null)
      {
        Console.Write("- ");
      }
      else
      {
        if (piece.Color == Color.White)
        {
          Console.Write(piece);
        }
        else
        {
          ConsoleColor aux = Console.ForegroundColor;
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write(piece);
          Console.ForegroundColor = aux;
        }
        Console.Write(" ");
      }

    }
  }
}

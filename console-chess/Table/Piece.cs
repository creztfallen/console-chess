
using Table;

namespace Table
{
  abstract class Piece
  {
    public GameTable Tab { get; protected set; }
    public Color Color { get; protected set; }
    public Position? Position { get; set; }
    public int MovesQuantity { get; protected set; }

    public Piece(GameTable tab, Color color)
    {
      Tab = tab;
      Color = color;
      Position = null;
      MovesQuantity = 0;
    }

    public void IncrementMovesQuantity()
    {
      MovesQuantity++;
    }

    public void DecrementMovesQuantity()
    {
      MovesQuantity--;
    }

    public bool PossibleMOvesExist()
    {
      bool[,] mat = PossibleMoves();
      for (int i = 0; i < Tab.Rows; i++)
      {
        for (int j = 0; j < Tab.Columns; j++)
        {
          if (mat[i, j])
          {
            return true;
          }
        }
      }
      return false;
    }

    public bool PossibleMove(Position pos)
    {
      return PossibleMoves()[pos.Row, pos.Column];
    }

    public abstract bool[,] PossibleMoves();
  }
}

using Table;

namespace Chess
{
  class Queen : Piece
  {
    public Queen(GameTable Tab, Color color) : base(Tab, color)
    {
    }

    public override string ToString()
    {
      return "Q";
    }

    private bool podeMover(Position pos)
    {
      Piece p = Tab.PiecePosition(pos);
      return p == null || p.Color != Color;
    }

    public override bool[,] PossibleMoves()
    {
      bool[,] mat = new bool[Tab.Rows, Tab.Columns];

      Position pos = new Position(0, 0);

      // esquerda
      pos.DefineValues(Position.Row, Position.Column - 1);
      while (Tab.ValidPosition(pos) && podeMover(pos))
      {
        mat[pos.Row, pos.Column] = true;
        if (Tab.PiecePosition(pos) != null && Tab.PiecePosition(pos).Color != Color)
        {
          break;
        }
        pos.DefineValues(pos.Row, pos.Column - 1);
      }

      // direita
      pos.DefineValues(Position.Row, Position.Column + 1);
      while (Tab.ValidPosition(pos) && podeMover(pos))
      {
        mat[pos.Row, pos.Column] = true;
        if (Tab.PiecePosition(pos) != null && Tab.PiecePosition(pos).Color != Color)
        {
          break;
        }
        pos.DefineValues(pos.Row, pos.Column + 1);
      }

      // acima
      pos.DefineValues(Position.Row - 1, Position.Column);
      while (Tab.ValidPosition(pos) && podeMover(pos))
      {
        mat[pos.Row, pos.Column] = true;
        if (Tab.PiecePosition(pos) != null && Tab.PiecePosition(pos).Color != Color)
        {
          break;
        }
        pos.DefineValues(pos.Row - 1, pos.Column);
      }

      // abaixo
      pos.DefineValues(Position.Row + 1, Position.Column);
      while (Tab.ValidPosition(pos) && podeMover(pos))
      {
        mat[pos.Row, pos.Column] = true;
        if (Tab.PiecePosition(pos) != null && Tab.PiecePosition(pos).Color != Color)
        {
          break;
        }
        pos.DefineValues(pos.Row + 1, pos.Column);
      }

      // NO
      pos.DefineValues(Position.Row - 1, Position.Column - 1);
      while (Tab.ValidPosition(pos) && podeMover(pos))
      {
        mat[pos.Row, pos.Column] = true;
        if (Tab.PiecePosition(pos) != null && Tab.PiecePosition(pos).Color != Color)
        {
          break;
        }
        pos.DefineValues(pos.Row - 1, pos.Column - 1);
      }

      // NE
      pos.DefineValues(Position.Row - 1, Position.Column + 1);
      while (Tab.ValidPosition(pos) && podeMover(pos))
      {
        mat[pos.Row, pos.Column] = true;
        if (Tab.PiecePosition(pos) != null && Tab.PiecePosition(pos).Color != Color)
        {
          break;
        }
        pos.DefineValues(pos.Row - 1, pos.Column + 1);
      }

      // SE
      pos.DefineValues(Position.Row + 1, Position.Column + 1);
      while (Tab.ValidPosition(pos) && podeMover(pos))
      {
        mat[pos.Row, pos.Column] = true;
        if (Tab.PiecePosition(pos) != null && Tab.PiecePosition(pos).Color != Color)
        {
          break;
        }
        pos.DefineValues(pos.Row + 1, pos.Column + 1);
      }

      // SO
      pos.DefineValues(Position.Row + 1, Position.Column - 1);
      while (Tab.ValidPosition(pos) && podeMover(pos))
      {
        mat[pos.Row, pos.Column] = true;
        if (Tab.PiecePosition(pos) != null && Tab.PiecePosition(pos).Color != Color)
        {
          break;
        }
        pos.DefineValues(pos.Row + 1, pos.Column - 1);
      }

      return mat;
    }
  }
}

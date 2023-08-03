using Table;

namespace Chess
{
  class Bishop : Piece
  {
    public Bishop(GameTable tab, Color Color) : base(tab, Color)
    {
    }

    public override string ToString()
    {
      return "B";
    }

    private bool CanMove(Position pos)
    {
      Piece p = Tab.PiecePosition(pos);
      return p == null || p.Color != Color;
    }

    public override bool[,] PossibleMoves()
    {
      bool[,] mat = new bool[Tab.Rows, Tab.Columns];

      Position pos = new Position(0, 0);

      // NO
      pos.DefineValues(Position.Row - 1, Position.Column - 1);
      while (Tab.ValidPosition(pos) && CanMove(pos))
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
      while (Tab.ValidPosition(pos) && CanMove(pos))
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
      while (Tab.ValidPosition(pos) && CanMove(pos))
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
      while (Tab.ValidPosition(pos) && CanMove(pos))
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

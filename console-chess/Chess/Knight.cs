using Table;

namespace Chess
{
  class Knight : Piece
  {
    public Knight(GameTable tab, Color Color) : base(tab, Color)
    {
    }

    public override string ToString()
    {
      return "X";
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

      pos.DefineValues(Position.Row - 1, Position.Column - 2);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }
      pos.DefineValues(Position.Row - 2, Position.Column - 1);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }
      pos.DefineValues(Position.Row - 2, Position.Column + 1);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }
      pos.DefineValues(Position.Row - 1, Position.Column + 2);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }
      pos.DefineValues(Position.Row + 1, Position.Column + 2);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }
      pos.DefineValues(Position.Row + 2, Position.Column + 1);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }
      pos.DefineValues(Position.Row + 2, Position.Column - 1);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }
      pos.DefineValues(Position.Row + 1, Position.Column - 2);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }

      return mat;
    }
  }
}

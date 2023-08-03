using System.Runtime.ConstrainedExecution;
using Table;

namespace Chess
{
  class King : Piece
  {
    private ChessMatch Match;
    public King(GameTable Tab, Color color, ChessMatch match) : base(Tab, color)
    {
      Match = match;
    }
    public override string ToString()
    {
      return "K";
    }

    private bool CanMove(Position pos)
    {
      Piece p = Tab.PiecePosition(pos);
      return p == null || p.Color != Color;
    }
    private bool TestChessCastling(Position pos)
    {
      Piece p = Tab.PiecePosition(pos);
      return p != null && p is Rook && p.Color == Color && p.MovesQuantity == 0;
    }

    public override bool[,] PossibleMoves()
    {
      bool[,] mat = new bool[Tab.Rows, Tab.Columns];

      Position pos = new Position(0, 0);

      //up
      pos.DefineValues(pos.Row - 1, pos.Column);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }

      //ne
      pos.DefineValues(pos.Row - 1, pos.Column + 1);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }

      //right
      pos.DefineValues(pos.Row, pos.Column + 1);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }

      //se
      pos.DefineValues(pos.Row + 1, pos.Column + 1);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }

      //down
      pos.DefineValues(pos.Row + 1, pos.Column);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }

      //sw
      pos.DefineValues(pos.Row + 1, pos.Column - 1);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }

      //left
      pos.DefineValues(pos.Row, pos.Column - 1);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }

      //nw
      pos.DefineValues(pos.Row - 1, pos.Column - 1);
      if (Tab.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Row, pos.Column] = true;
      }

      if (MovesQuantity == 0 && !Match.Check)
      {
        // #jogadaespecial roque pequeno
        Position posT1 = new Position(Position.Row, Position.Column + 3);
        if (TestChessCastling(posT1))
        {
          Position p1 = new Position(Position.Row, Position.Column + 1);
          Position p2 = new Position(Position.Row, Position.Column + 2);
          if (Tab.PiecePosition(p1) == null && Tab.PiecePosition(p2) == null)
          {
            mat[Position.Row, Position.Column + 2] = true;
          }
        }
        // #jogadaespecial roque grande
        Position posT2 = new Position(Position.Row, Position.Column - 4);
        if (TestChessCastling(posT2))
        {
          Position p1 = new Position(Position.Row, Position.Column - 1);
          Position p2 = new Position(Position.Row, Position.Column - 2);
          Position p3 = new Position(Position.Row, Position.Column - 3);
          if (Tab.PiecePosition(p1) == null && Tab.PiecePosition(p2) == null && Tab.PiecePosition(p3) == null)
          {
            mat[Position.Row, Position.Column - 2] = true;
          }
        }
      }

      return mat;
    }
  }
}

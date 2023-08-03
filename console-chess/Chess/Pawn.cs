using Table;

namespace Chess
{
  class Pawn : Piece
  {
    private ChessMatch Match;

    public Pawn(GameTable Tab, Color color, ChessMatch match) : base(Tab, color)
    {
      Match = match;
    }

    public override string ToString()
    {
      return "P";
    }

    private bool existeInimigo(Position pos)
    {
      Piece p = Tab.PiecePosition(pos);
      return p != null && p.Color != Color;
    }

    private bool livre(Position pos)
    {
      return Tab.PiecePosition(pos) == null;
    }

    public override bool[,] PossibleMoves()
    {
      bool[,] mat = new bool[Tab.Rows, Tab.Columns];

      Position pos = new Position(0, 0);

      if (Color == Color.White)
      {
        pos.DefineValues(Position.Row - 1, Position.Column);
        if (Tab.ValidPosition(pos) && livre(pos))
        {
          mat[pos.Row, pos.Column] = true;
        }
        pos.DefineValues(Position.Row - 2, Position.Column);
        Position p2 = new Position(Position.Row - 1, Position.Column);
        if (Tab.ValidPosition(p2) && livre(p2) && Tab.ValidPosition(pos) && livre(pos) && MovesQuantity == 0)
        {
          mat[pos.Row, pos.Column] = true;
        }
        pos.DefineValues(Position.Row - 1, Position.Column - 1);
        if (Tab.ValidPosition(pos) && existeInimigo(pos))
        {
          mat[pos.Row, pos.Column] = true;
        }
        pos.DefineValues(Position.Row - 1, Position.Column + 1);
        if (Tab.ValidPosition(pos) && existeInimigo(pos))
        {
          mat[pos.Row, pos.Column] = true;
        }

        // #jogadaespecial en passant
        if (Position.Row == 3)
        {
          Position esquerda = new Position(Position.Row, Position.Column - 1);
          if (Tab.ValidPosition(esquerda) && existeInimigo(esquerda) && Tab.PiecePosition(esquerda) == Match.VulnerableEnpassant)
          {
            mat[esquerda.Row - 1, esquerda.Column] = true;
          }
          Position direita = new Position(Position.Row, Position.Column + 1);
          if (Tab.ValidPosition(direita) && existeInimigo(direita) && Tab.PiecePosition(direita) == Match.VulnerableEnpassant)
          {
            mat[direita.Row - 1, direita.Column] = true;
          }
        }
      }
      else
      {
        pos.DefineValues(Position.Row + 1, Position.Column);
        if (Tab.ValidPosition(pos) && livre(pos))
        {
          mat[pos.Row, pos.Column] = true;
        }
        pos.DefineValues(Position.Row + 2, Position.Column);
        Position p2 = new Position(Position.Row + 1, Position.Column);
        if (Tab.ValidPosition(p2) && livre(p2) && Tab.ValidPosition(pos) && livre(pos) && MovesQuantity == 0)
        {
          mat[pos.Row, pos.Column] = true;
        }
        pos.DefineValues(Position.Row + 1, Position.Column - 1);
        if (Tab.ValidPosition(pos) && existeInimigo(pos))
        {
          mat[pos.Row, pos.Column] = true;
        }
        pos.DefineValues(Position.Row + 1, Position.Column + 1);
        if (Tab.ValidPosition(pos) && existeInimigo(pos))
        {
          mat[pos.Row, pos.Column] = true;
        }

        // #jogadaespecial en passant
        if (Position.Row == 4)
        {
          Position esquerda = new Position(Position.Row, Position.Column - 1);
          if (Tab.ValidPosition(esquerda) && existeInimigo(esquerda) && Tab.PiecePosition(esquerda) == Match.VulnerableEnpassant)
          {
            mat[esquerda.Row + 1, esquerda.Column] = true;
          }
          Position direita = new Position(Position.Row, Position.Column + 1);
          if (Tab.ValidPosition(direita) && existeInimigo(direita) && Tab.PiecePosition(direita) == Match.VulnerableEnpassant)
          {
            mat[direita.Row + 1, direita.Column] = true;
          }
        }
      }

      return mat;
    }
  }
}

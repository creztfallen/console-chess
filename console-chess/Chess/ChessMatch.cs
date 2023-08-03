using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table;
using console_chess.Exceptions;

namespace Chess
{
  class ChessMatch
  {
    public GameTable Tab { get; private set; }
    public int Turn { get; private set; }
    public Color CurrentPlayer { get; private set; }
    private HashSet<Piece> Pieces;
    private HashSet<Piece> Captured;
    public bool Check { get; private set; }
    public bool Finished { get; private set; }
    public Piece VulnerableEnpassant { get; private set; }

    public ChessMatch()
    {
      Tab = new GameTable(8, 8);
      Turn = 1;
      CurrentPlayer = Color.White;
      Finished = false;
      Check = false;
      VulnerableEnpassant = null;
      Pieces = new HashSet<Piece>();
      Captured = new HashSet<Piece>();
      ArrangePieces();
    }

    public Piece Move(Position origin, Position destination)
    {
      Piece p = Tab.RemoveThePiece(origin);
      p.IncrementMovesQuantity();
      Piece capturedPiece = Tab.RemoveThePiece(destination);
      Tab.PlaceThePiece(destination, p);
      if (capturedPiece != null)
      {
        Captured.Add(capturedPiece);
      }

      // #jogadaespecial roque pequeno
      if (p is King && destination.Column == origin.Column + 2)
      {
        Position originT = new Position(origin.Row, origin.Column + 3);
        Position destinationT = new Position(origin.Row, origin.Column + 1);
        Piece T = Tab.RemoveThePiece(originT);
        T.IncrementMovesQuantity();
        Tab.PlaceThePiece(destinationT, T);
      }

      // #jogadaespecial roque grande
      if (p is King && destination.Column == origin.Column - 2)
      {
        Position originT = new Position(origin.Row, origin.Column - 4);
        Position destinationT = new Position(origin.Row, origin.Column - 1);
        Piece T = Tab.RemoveThePiece(originT);
        T.IncrementMovesQuantity();
        Tab.PlaceThePiece(destinationT, T);
      }

      // #jogadaespecial en passant
      if (p is Pawn)
      {
        if (origin.Column != destination.Column && capturedPiece == null)
        {
          Position posP;
          if (p.Color == Color.White)
          {
            posP = new Position(destination.Row + 1, destination.Column);
          }
          else
          {
            posP = new Position(destination.Row - 1, destination.Column);
          }
          capturedPiece = Tab.RemoveThePiece(posP);
          Captured.Add(capturedPiece);
        }
      }

      return capturedPiece;
    }

    public void UndoMove(Position origin, Position destination, Piece capturedPiece)
    {
      Piece p = Tab.RemoveThePiece(destination);
      p.DecrementMovesQuantity();
      if (capturedPiece != null)
      {
        Tab.PlaceThePiece(destination, capturedPiece);
        Captured.Remove(capturedPiece);
      }
      Tab.PlaceThePiece(origin, p);

      // #jogadaespecial roque pequeno
      if (p is King && destination.Column == origin.Column + 2)
      {
        Position originT = new Position(origin.Row, origin.Column + 3);
        Position destinoT = new Position(origin.Row, origin.Column + 1);
        Piece T = Tab.RemoveThePiece(destinoT);
        T.DecrementMovesQuantity();
        Tab.PlaceThePiece(originT, T);
      }

      // #jogadaespecial roque grande
      if (p is King && destination.Column == origin.Column - 2)
      {
        Position originT = new Position(origin.Row, origin.Column - 4);
        Position destinoT = new Position(origin.Row, origin.Column - 1);
        Piece T = Tab.RemoveThePiece(destinoT);
        T.DecrementMovesQuantity();
        Tab.PlaceThePiece(originT, T);
      }

      // #jogadaespecial en passant
      if (p is Pawn)
      {
        if (origin.Column != destination.Column && capturedPiece == VulnerableEnpassant)
        {
          Piece pawn = Tab.RemoveThePiece(destination);
          Position posP;
          if (p.Color == Color.White)
          {
            posP = new Position(3, destination.Column);
          }
          else
          {
            posP = new Position(4, destination.Column);
          }
          Tab.PlaceThePiece(posP, pawn);
        }
      }
    }

    public void ValidateOriginPosition(Position pos)
    {
      if (Tab.PiecePosition(pos) == null)
      {
        throw new TableException("There are no pieces at the chosen origin position!");
      }
      if (CurrentPlayer != Tab.PiecePosition(pos).Color)
      {
        throw new TableException("The piece at the chosen origin position is not yours!");
      }
      if (!Tab.PiecePosition(pos).PossibleMOvesExist())
      {
        throw new TableException("There are no possible moves for the piece at the chosen origin position.");
      }
    }

    public void ValidateDestinationPosition(Position origin, Position destination)
    {
      if (!Tab.PiecePosition(origin).PossibleMove(destination))
      {
        throw new TableException("Invalid destination position!");
      }
    }

    public void MakeThePlay(Position origin, Position destination)
    {
      Piece capturedPiece = Move(origin, destination);

      if (IsInCheck(CurrentPlayer))
      {
        UndoMove(origin, destination, capturedPiece);
        throw new TableException("You can not put yourself into check!");
      }

      Piece p = Tab.PiecePosition(destination);

      // #jogadaespecial promocao
      if (p is Pawn)
      {
        if ((p.Color == Color.White && destination.Row == 0) || (p.Color == Color.Black && destination.Row == 7))
        {
          p = Tab.RemoveThePiece(destination);
          Pieces.Remove(p);
          Piece queen = new Queen(Tab, p.Color);
          Tab.PlaceThePiece(destination, queen);
          Pieces.Add(queen);
        }
      }

      if (IsInCheck(Opponent(CurrentPlayer)))
      {
        Check = true;
      }
      else
      {
        Check = false;
      }

      if (TestCheckMate(Opponent(CurrentPlayer)))
      {
        Finished = true;
      }
      else
      {
        Turn++;
        ChangePlayer();
      }

      // #jogadaespecial en passant
      if (p is Pawn && (destination.Row == origin.Row - 2 || destination.Row == origin.Row + 2))
      {
        VulnerableEnpassant = p;
      }
      else
      {
        VulnerableEnpassant = null;
      }

    }

    private void ChangePlayer()
    {
      if (CurrentPlayer == Color.White)
      {
        CurrentPlayer = Color.Black;
      }
      else
      {
        CurrentPlayer = Color.White;
      }
    }


    public HashSet<Piece> CapturedPieces(Color color)
    {
      HashSet<Piece> aux = new HashSet<Piece>();
      foreach (Piece x in Captured)
      {
        if (x.Color == color)
        {
          aux.Add(x);
        }
      }
      return aux;
    }


    public HashSet<Piece> PiecesInGame(Color color)
    {
      HashSet<Piece> aux = new HashSet<Piece>();
      foreach (Piece x in Pieces)
      {
        if (x.Color == color)
        {
          aux.Add(x);
        }
      }
      aux.ExceptWith(CapturedPieces(color));
      return aux;
    }

    private Color Opponent(Color color)
    {
      if (color == Color.White)
      {
        return Color.Black;
      }
      else
      {
        return Color.White;
      }
    }

    private Piece King(Color color)
    {
      foreach (Piece x in PiecesInGame(color))
      {
        if (x is King)
        {
          return x;
        }
      }
      return null;
    }

    public bool IsInCheck(Color Color)
    {
      Piece K = King(Color);
      if (K == null)
      {
        throw new TableException("The is no " + Color + " king on the table!");
      }
      foreach (Piece x in PiecesInGame(Opponent(Color)))
      {
        bool[,] mat = x.PossibleMoves();
        if (mat[K.Position.Row, K.Position.Column])
        {
          return true;
        }
      }
      return false;
    }

    public bool TestCheckMate(Color Color)
    {
      if (!IsInCheck(Color))
      {
        return false;
      }
      foreach (Piece x in PiecesInGame(Color))
      {
        bool[,] mat = x.PossibleMoves();
        for (int i = 0; i < Tab.Rows; i++)
        {
          for (int j = 0; j < Tab.Rows; j++)
          {
            if (mat[i, j])
            {
              Position origin = x.Position;
              Position destination = new Position(i, j);
              Piece capturedPiece = Move(origin, destination);
              bool testeXeque = IsInCheck(Color);
              UndoMove(origin, destination, capturedPiece);
              if (!testeXeque)
              {
                return false;
              }
            }
          }
        }
      }
      return true;
    }

    public void PlaceNewPiece(char column, int row, Piece piece)
    {
      Tab.PlaceThePiece(new ChessPosition(column, row).ToPosition(), piece);
      Pieces.Add(piece);
    }


    private void ArrangePieces()
    {
      PlaceNewPiece('a', 1, new Rook(Tab, Color.White));
      PlaceNewPiece('b', 1, new Knight(Tab, Color.White));
      PlaceNewPiece('c', 1, new Bishop(Tab, Color.White));
      PlaceNewPiece('d', 1, new Queen(Tab, Color.White));
      PlaceNewPiece('e', 1, new King(Tab, Color.White, this));
      PlaceNewPiece('f', 1, new Bishop(Tab, Color.White));
      PlaceNewPiece('g', 1, new Knight(Tab, Color.White));
      PlaceNewPiece('h', 1, new Rook(Tab, Color.White));
      PlaceNewPiece('a', 2, new Pawn(Tab, Color.White, this));
      PlaceNewPiece('b', 2, new Pawn(Tab, Color.White, this));
      PlaceNewPiece('c', 2, new Pawn(Tab, Color.White, this));
      PlaceNewPiece('d', 2, new Pawn(Tab, Color.White, this));
      PlaceNewPiece('e', 2, new Pawn(Tab, Color.White, this));
      PlaceNewPiece('f', 2, new Pawn(Tab, Color.White, this));
      PlaceNewPiece('g', 2, new Pawn(Tab, Color.White, this));
      PlaceNewPiece('h', 2, new Pawn(Tab, Color.White, this));

      PlaceNewPiece('a', 8, new Rook(Tab, Color.Black));
      PlaceNewPiece('b', 8, new Knight(Tab, Color.Black));
      PlaceNewPiece('c', 8, new Bishop(Tab, Color.Black));
      PlaceNewPiece('d', 8, new Queen(Tab, Color.Black));
      PlaceNewPiece('e', 8, new King(Tab, Color.Black, this));
      PlaceNewPiece('f', 8, new Bishop(Tab, Color.Black));
      PlaceNewPiece('g', 8, new Knight(Tab, Color.Black));
      PlaceNewPiece('h', 8, new Rook(Tab, Color.Black));
      PlaceNewPiece('a', 7, new Pawn(Tab, Color.Black, this));
      PlaceNewPiece('b', 7, new Pawn(Tab, Color.Black, this));
      PlaceNewPiece('c', 7, new Pawn(Tab, Color.Black, this));
      PlaceNewPiece('d', 7, new Pawn(Tab, Color.Black, this));
      PlaceNewPiece('e', 7, new Pawn(Tab, Color.Black, this));
      PlaceNewPiece('f', 7, new Pawn(Tab, Color.Black, this));
      PlaceNewPiece('g', 7, new Pawn(Tab, Color.Black, this));
      PlaceNewPiece('h', 7, new Pawn(Tab, Color.Black, this));
    }
  }
}

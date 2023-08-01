using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table;

namespace Chess
{
     class ChessMatch
    {
        public GameTable Tab { get; private set; }
        private int Turn;
        private Color CurrentPlayer;

        public ChessMatch() 
        {
            Tab = new GameTable(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            ArrangePieces();
        }

        public void MovePiece(Position origin, Position destination) 
        {
            Piece p = Tab.RemoveThePiece(origin);
            p.IncrementMovesQuantity();
            Piece capturedPiece = Tab.RemoveThePiece(destination);
            Tab.PlaceThePiece(destination, p);
        }

        private void ArrangePieces()
        {

            Tab.PlaceThePiece(new ChessPosition('c', 2).ToPosition(), new Rook(Tab, Color.Black));
            Tab.PlaceThePiece(new ChessPosition('d', 5).ToPosition(), new Knight(Tab, Color.Black));
            Tab.PlaceThePiece(new ChessPosition('a', 4).ToPosition(), new Queen(Tab, Color.White));
        }
    }
}

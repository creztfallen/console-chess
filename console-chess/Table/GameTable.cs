using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    class GameTable
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public GameTable(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }

        public Piece PiecePosition(int line, int column)
        {
            return Pieces[line, column];
        }

        public void PlaceThePiece(Position pos, Piece piece)
        {
            Pieces[pos.Row, pos.Column] = piece;
            piece.Position = pos;
        }
    }
}

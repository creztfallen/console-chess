using console_chess.Exceptions;

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

        public Piece PiecePosition(int row, int column)
        {
            return Pieces[row, column];
        }

        public Piece PiecePosition(Position pos)
        {
            return Pieces[pos.Row, pos.Column];
        }

        public bool PieceExists(Position pos)
        {
            ValidatePosition(pos);
            return PiecePosition(pos) != null;
        }

        public void PlaceThePiece(Position pos, Piece piece)
        {
            if (PieceExists(pos))
            {
                throw new TableException("A piece already exists in this position.");
            }
            Pieces[pos.Row, pos.Column] = piece;
            piece.Position = pos;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Row < 0 || pos.Column < 0 || pos.Row >= Rows || pos.Column > Columns) {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos)) {
                throw new TableException("invalid position");
            }
        }
    }
}

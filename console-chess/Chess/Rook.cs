using Table;

namespace Chess
{
    class Rook : Piece
    {
        public Rook(GameTable tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "R";
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

            //up
            pos.DefineValues(pos.Row - 1, pos.Column);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.PiecePosition(pos) != null && Tab.PiecePosition(pos).Color != Color) break;
                pos.Row = pos.Row - 1;
            }

            //down
            pos.DefineValues(pos.Row + 1, pos.Column);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.PiecePosition(pos) != null && Tab.PiecePosition(pos).Color != Color) break;
                pos.Row = pos.Row + 1;
            }

            //right
            pos.DefineValues(pos.Row, pos.Column + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.PiecePosition(pos) != null && Tab.PiecePosition(pos).Color != Color) break;
                pos.Column = pos.Column + 1;
            }

            //left
            pos.DefineValues(pos.Row, pos.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.PiecePosition(pos) != null && Tab.PiecePosition(pos).Color != Color) break;
                pos.Column = pos.Column - 1;
            }

            return mat;
        }
    }
}

using Table;

namespace Chess
{
    class King : Piece
    {
        public King(GameTable tab, Color color ) : base(tab, color)
        {
            
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
            pos.DefineValues(pos.Row + 1, pos.Column -1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //left
            pos.DefineValues(pos.Row , pos.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //nw
            pos.DefineValues(pos.Row - 1, pos.Column -1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }
    }
}

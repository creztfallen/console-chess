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
    }
}

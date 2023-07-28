using Table;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(GameTable tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "Q";
        }
    }
}

using Table;

namespace Chess
{
    class Knight : Piece
    {
        public Knight(GameTable tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "Kn";
        }
    }
}

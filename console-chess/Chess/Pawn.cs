using Table;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(GameTable tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "P";
        }
    }
}

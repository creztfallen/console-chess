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
    }
}

using Table;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(GameTable tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "B";
        }
    }
}

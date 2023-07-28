
using Table;

namespace Table
{
    internal class Piece
    {
        public Position? Position { get; set; }
        public Color Color { get; protected set; }
        public int MovesQuantity { get; protected set; }
        public GameTable Tab { get; protected set; }

        public Piece(Position position, Color color, GameTable tab)
        {
            Position = position;
            Color = color;
            Tab = tab;
            MovesQuantity = 0;
        }

    }
}

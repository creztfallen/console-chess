
using Table;

namespace Table
{
    abstract class Piece
    {
        public GameTable Tab { get; protected set; }
        public Color Color { get; protected set; }
        public Position? Position { get; set; }
        public int MovesQuantity { get; protected set; }

        public Piece(GameTable tab, Color color)
        {
            Tab = tab;
            Color = color;
            Position = null;
            MovesQuantity = 0;
        }

        public void IncrementMovesQuantity()
        {
            MovesQuantity++;
        }

        public abstract bool[,] PossibleMoves();
    }
}

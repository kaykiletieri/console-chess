namespace console_chess.Board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public int MovementQuantity { get; set; }
        public Board Board { get; set; }

        public Piece( Color color, Board board)
        {
            this.Position = null;
            this.Color = color;
            this.Board = board;
            this.MovementQuantity = 0;
        }

        public void IncrementMovementQuantity()
        {
            this.MovementQuantity++;
        }
    }
}

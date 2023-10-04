namespace console_chess.Board
{
    public class Piece
    {
        public required Position Position { get; set; }
        public required Color Color { get; set; }
        public required int MovementQuantity { get; set; }
        public required Board Board { get; set; }

        public Piece(Position position, Color color, Board board)
        {
            this.Position = position;
            this.Color = color;
            this.Board = board;
            this.MovementQuantity = 0;
        }
    }
}

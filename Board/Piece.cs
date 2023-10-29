namespace console_chess.Board
{
    public abstract class Piece
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

        public void DecrementMovementQuantity()
        {
            this.MovementQuantity--;
        }

        public abstract bool[,] PossibleMovements();

        public bool ExistPossibleMovements()
        {
            bool[,] matrix = PossibleMovements();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        public bool PossibleMovement(Position position)
        {
            return PossibleMovements()[position.Row, position.Column];
        }
    }
}

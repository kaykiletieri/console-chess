namespace console_chess.Board
{
    public class Board
    {
        public required int Rows { get; set; }
        public required int Columns { get; set; }
        private Piece[,] Pieces { get; set; }

        public Board(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.Pieces = new Piece[rows, columns];
        }
    }
}

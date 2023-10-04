namespace console_chess.Board
{
    public class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces { get; set; }

        public Board(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.Pieces = new Piece[rows, columns];
        }

        public Piece Piece(int row, int column)
        {
            return this.Pieces[row, column];
        }
    }
}

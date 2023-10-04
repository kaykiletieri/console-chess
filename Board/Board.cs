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

        public Piece Piece(Position position)
        {
            return this.Pieces[position.Row, position.Column];
        }

        public bool PieceExists(Position position)
        {
            this.ValidatePosition(position);
            return this.Piece(position) != null;
        }

        public void InsertPiece(Piece piece, Position position)
        {
            if(this.PieceExists(position))
            {
                throw new BoardException("There is already a piece in this position!");
            }

            this.Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Row < 0 || position.Row >= this.Rows || position.Column < 0 || position.Column >= this.Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!this.ValidPosition(position))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}

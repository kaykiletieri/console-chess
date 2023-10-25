using console_chess.Board;

namespace console_chess.Chess
{
    public class Rook : Piece
    {
        public Rook(Color color, Board.Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != this.Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] bools = new bool[Board.Rows, Board.Columns];

            Position position = new(0, 0);

            // Above
            position.SetValues(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                bools[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row--;
            }

            // Right
            position.SetValues(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                bools[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Column++;
            }

            // Below
            position.SetValues(Position.Row + 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                bools[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row++;
            }

            // Left
            position.SetValues(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                bools[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Column--;
            }
            return bools;
        }
    }
}

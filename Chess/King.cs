using console_chess.Board;

namespace console_chess.Chess
{
    public class King : Piece
    {
        public King(Color color, Board.Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "K";
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
            if (Board.ValidPosition(position) && CanMove(position))
            {
                bools[position.Row, position.Column] = true;
            }

            // Northeast
            position.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                bools[position.Row, position.Column] = true;
            }

            // Right
            position.SetValues(Position.Row, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                bools[position.Row, position.Column] = true;
            }

            // Southeast
            position.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                bools[position.Row, position.Column] = true;
            }

            // Below
            position.SetValues(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                bools[position.Row, position.Column] = true;
            }

            // Southwest
            position.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                bools[position.Row, position.Column] = true;
            }

            // Left
            position.SetValues(Position.Row, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                bools[position.Row, position.Column] = true;
            }
            
            // Northwest
            position.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                bools[position.Row, position.Column] = true;
            }

            return bools;
        }
    }
}

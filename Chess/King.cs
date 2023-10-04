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
    }
}

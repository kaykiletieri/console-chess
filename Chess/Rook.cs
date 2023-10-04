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
    }
}

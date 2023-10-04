using console_chess.Board;

namespace console_chess.Chess
{
    public class Pawn : Piece
    {
        public Pawn(Color color, Board.Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "P";
        }
    }
}

using console_chess.Board;

namespace console_chess.Chess
{
    public class Horse : Piece
    {
        public Horse(Color color, Board.Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "H";
        }
    }
}

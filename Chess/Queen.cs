using console_chess.Board;

namespace console_chess.Chess
{
    public class Queen : Piece
    {
        public Queen(Color color, Board.Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        public override bool[,] PossibleMovements()
        {
            throw new NotImplementedException();
        }
    }
}

using console_chess.Board;

namespace console_chess.Chess
{
    public class Bishop : Piece
    {
        public Bishop(Color color, Board.Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] PossibleMovements()
        {
            throw new NotImplementedException();
        }
    }
}

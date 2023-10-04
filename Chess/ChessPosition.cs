using console_chess.Board;

namespace console_chess.Chess
{
    public class ChessPosition
    {
        public char Column { get; set; }
        public int Row { get; set; }

        public ChessPosition(char column, int row)
        {
            Column = column;
            Row = row;
        }

        public override string ToString()
        {
            return "" + Column + Row;
        }

        public Position ToPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }
    }
}

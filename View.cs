namespace console_chess
{
    public class View
    {
        public static void PrintBoard(Board.Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                System.Console.Write($"{8 - row} ");
                for (int column = 0; column < board.Columns; column++)
                {
                    if (board.Piece(row, column) == null)
                    {
                        System.Console.Write("- ");
                    }
                    else
                    {
                        System.Console.Write($"{board.Piece(row, column)} ");
                    }
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h");
        }
    }
}

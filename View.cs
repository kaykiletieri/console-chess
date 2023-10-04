using console_chess.Board;

namespace console_chess
{
    public class View
    {
        public static void PrintBoard(Board.Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                Console.Write($"{8 - row} ");
                for (int column = 0; column < board.Columns; column++)
                {
                    if (board.Piece(row, column) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.Piece(row, column));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}

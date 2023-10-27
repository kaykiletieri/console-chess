using console_chess.Board;
using console_chess.Chess;

namespace console_chess
{
    public class View
    {
        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine($"Turn: {match.Turn}");
            if (!match.Finished)
            {
                Console.WriteLine($"Waiting player: {match.CurrentPlayer}");
                if (match.InCheck)
                {
                    Console.WriteLine("CHECK!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine($"Winner: {match.CurrentPlayer}");
            }
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            PrintSet(match.CapturedPiecesByColor(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.CapturedPiecesByColor(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece piece in set)
            {
                Console.Write($"{piece} ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board.Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                Console.Write($"{8 - row} ");
                for (int column = 0; column < board.Columns; column++)
                {
                    PrintPiece(board.Piece(row, column));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board.Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            for (int row = 0; row < board.Rows; row++)
            {
                Console.Write($"{8 - row} ");
                for (int column = 0; column < board.Columns; column++)
                {
                    if (possiblePositions[row, column])
                    {
                        Console.BackgroundColor = alteredBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.Piece(row, column));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            string input = Console.ReadLine();
            char column = input[0];
            int row = int.Parse(input[1].ToString());
            return new ChessPosition(column, row);
        }
    }
}

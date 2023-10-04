using console_chess;
using console_chess.Board;
using console_chess.Chess;

try
{
    ChessMatch match = new();
    View.PrintBoard(match.Board);
}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}
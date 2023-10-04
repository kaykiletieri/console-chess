using console_chess;
using console_chess.Board;
using console_chess.Chess;

try
{
    ChessMatch match = new();

    while(!match.Finished)
    {
        Console.Clear();
        View.PrintBoard(match.Board);

        Console.WriteLine();
        Console.Write("Origin: ");
        Position origin = View.ReadChessPosition().ToPosition();
        match.Board.ValidatePosition(origin);
        Console.Write("Destination: ");
        Position destination = View.ReadChessPosition().ToPosition();
        match.Board.ValidatePosition(destination);

        match.ExecuteMovement(origin, destination);
    }
    View.PrintBoard(match.Board);
}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}
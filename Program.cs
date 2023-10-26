using console_chess;
using console_chess.Board;
using console_chess.Chess;

try
{
    ChessMatch match = new();

    while(!match.Finished)
    {
        try
        {
            Console.Clear();
            View.PrintMatch(match);

            Console.WriteLine();
            Console.Write("Origin: ");
            Position origin = View.ReadChessPosition().ToPosition();
            match.ValidateOriginPosition(origin);

            bool[,] possiblePositions = match.Board.Piece(origin).PossibleMovements();

            Console.Clear();
            View.PrintBoard(match.Board, possiblePositions);

            Console.WriteLine();
            Console.Write("Destination: ");
            Position destination = View.ReadChessPosition().ToPosition();
            match.ValidateDestinationPosition(origin, destination);

            match.MakePlay(origin, destination);
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
    View.PrintBoard(match.Board);
}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}
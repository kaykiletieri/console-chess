using console_chess;
using console_chess.Board;
using console_chess.Chess;
try
{
    Board board = new(8, 8);

    board.InsertPiece(new Rook(Color.Black, board), new Position(0, 0));
    board.InsertPiece(new Rook(Color.Black, board), new Position(1, 3));
    board.InsertPiece(new King(Color.Black, board), new Position(0, 7));
    board.InsertPiece(new King(Color.White, board), new Position(0, 2));

    View.PrintBoard(board);
    Console.ReadLine();
}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}
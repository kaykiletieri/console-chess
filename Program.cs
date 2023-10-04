using console_chess;
using console_chess.Board;
using console_chess.Chess;

Board board = new(8, 8);

board.InsertPiece(new Rook(Color.Black, board), new Position(0, 0));
board.InsertPiece(new Rook(Color.Black, board), new Position(1, 3));
board.InsertPiece(new King(Color.Black, board), new Position(2, 4));

View.PrintBoard(board);
Console.ReadLine();
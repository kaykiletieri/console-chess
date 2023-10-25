using console_chess.Board;
using System.Drawing;
using Color = console_chess.Board.Color;

namespace console_chess.Chess
{
    public class ChessMatch
    {
        public Board.Board Board { get; private set; }
        public int Turn { get; private set; }
        public Board.Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        
        public ChessMatch()
        {
            this.Board = new Board.Board(8, 8);
            this.Turn = 1;
            this.CurrentPlayer = console_chess.Board.Color.White;
            this.Finished = false;
            InsertPieces();
        }

        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece piece = this.Board.RemovePiece(origin);
            piece.IncrementMovementQuantity();
            Piece capturedPiece = this.Board.RemovePiece(destination);
            this.Board.InsertPiece(piece, destination);
        }

        public void MakePlay(Position origin, Position destination)
        {
            ExecuteMovement(origin, destination);
            this.Turn++;
            ChangePlayer();
        }

        private void ChangePlayer()
        {
            if (this.CurrentPlayer == Color.White)
            {
                this.CurrentPlayer = Color.Black;
            }
            else
            {
                this.CurrentPlayer = Color.White;
            }
        }

        public void ValidateOriginPosition(Position position)
        {
            if (this.Board.Piece(position) == null)
            {
                throw new BoardException("There is no piece in the chosen origin position!");
            }
            if (this.CurrentPlayer != this.Board.Piece(position).Color)
            {
                throw new BoardException("The chosen piece is not yours!");
            }
            if (!this.Board.Piece(position).ExistPossibleMovements())
            {
                throw new BoardException("There are no possible movements for the chosen piece!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!this.Board.Piece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Invalid destination position!");
            }
        }

        public void InsertPieces()
        {
            Board.InsertPiece(new Rook(Color.White, this.Board), new ChessPosition('a', 1).ToPosition());
            Board.InsertPiece(new Horse(Color.White, this.Board), new ChessPosition('b', 1).ToPosition());
            Board.InsertPiece(new Bishop(Color.White, this.Board), new ChessPosition('c', 1).ToPosition());
            Board.InsertPiece(new Queen(Color.White, this.Board), new ChessPosition('d', 1).ToPosition());
            Board.InsertPiece(new King(Color.White, this.Board), new ChessPosition('e', 1).ToPosition());
            Board.InsertPiece(new Bishop(Color.White, this.Board), new ChessPosition('f', 1).ToPosition());
            Board.InsertPiece(new Horse(Color.White, this.Board), new ChessPosition('g', 1).ToPosition());
            Board.InsertPiece(new Rook(Color.White, this.Board), new ChessPosition('h', 1).ToPosition());
            Board.InsertPiece(new Pawn(Color.White, this.Board), new ChessPosition('a', 2).ToPosition());
            Board.InsertPiece(new Pawn(Color.White, this.Board), new ChessPosition('b', 2).ToPosition());
            Board.InsertPiece(new Pawn(Color.White, this.Board), new ChessPosition('c', 2).ToPosition());
            Board.InsertPiece(new Pawn(Color.White, this.Board), new ChessPosition('d', 2).ToPosition());
            Board.InsertPiece(new Pawn(Color.White, this.Board), new ChessPosition('e', 2).ToPosition());
            Board.InsertPiece(new Pawn(Color.White, this.Board), new ChessPosition('f', 2).ToPosition());
            Board.InsertPiece(new Pawn(Color.White, this.Board), new ChessPosition('g', 2).ToPosition());
            Board.InsertPiece(new Pawn(Color.White, this.Board), new ChessPosition('h', 2).ToPosition());
            
            Board.InsertPiece(new Rook(Color.Black, this.Board), new ChessPosition('a', 8).ToPosition());
            Board.InsertPiece(new Horse(Color.Black, this.Board), new ChessPosition('b', 8).ToPosition());
            Board.InsertPiece(new Bishop(Color.Black, this.Board), new ChessPosition('c', 8).ToPosition());
            Board.InsertPiece(new Queen(Color.Black, this.Board), new ChessPosition('d', 8).ToPosition());
            Board.InsertPiece(new King(Color.Black, this.Board), new ChessPosition('e', 8).ToPosition());
            Board.InsertPiece(new Bishop(Color.Black, this.Board), new ChessPosition('f', 8).ToPosition());
            Board.InsertPiece(new Horse(Color.Black, this.Board), new ChessPosition('g', 8).ToPosition());
            Board.InsertPiece(new Rook(Color.Black, this.Board), new ChessPosition('h', 8).ToPosition());
            Board.InsertPiece(new Pawn(Color.Black, this.Board), new ChessPosition('a', 7).ToPosition());
            Board.InsertPiece(new Pawn(Color.Black, this.Board), new ChessPosition('b', 7).ToPosition());
            Board.InsertPiece(new Pawn(Color.Black, this.Board), new ChessPosition('c', 7).ToPosition());
            Board.InsertPiece(new Pawn(Color.Black, this.Board), new ChessPosition('d', 7).ToPosition());
            Board.InsertPiece(new Pawn(Color.Black, this.Board), new ChessPosition('e', 7).ToPosition());
            Board.InsertPiece(new Pawn(Color.Black, this.Board), new ChessPosition('f', 7).ToPosition());
            Board.InsertPiece(new Pawn(Color.Black, this.Board), new ChessPosition('g', 7).ToPosition());
            Board.InsertPiece(new Pawn(Color.Black, this.Board), new ChessPosition('h', 7).ToPosition());
        }
    }
}

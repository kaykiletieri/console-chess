using System.Collections.Generic;
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
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;
        public bool InCheck { get; private set; }

        public ChessMatch()
        {
            this.Board = new Board.Board(8, 8);
            this.Turn = 1;
            this.CurrentPlayer = console_chess.Board.Color.White;
            this.Finished = false;
            this.Pieces = new HashSet<Piece>();
            this.CapturedPieces = new HashSet<Piece>();
            this.InCheck = false;
            this.Finished = false;
            InsertPieces();
        }

        public Piece ExecuteMovement(Position origin, Position destination)
        {
            Piece piece = this.Board.RemovePiece(origin);
            piece.IncrementMovementQuantity();
            Piece capturedPiece = this.Board.RemovePiece(destination);
            this.Board.InsertPiece(piece, destination);
            if (capturedPiece != null)
            {
                this.CapturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = this.Board.RemovePiece(destination);
            piece.DecrementMovementQuantity();
            if (capturedPiece != null)
            {
                this.Board.InsertPiece(capturedPiece, destination);
                this.CapturedPieces.Remove(capturedPiece);
            }
            this.Board.InsertPiece(piece, origin);
        }

        public void MakePlay(Position origin, Position destination)
        {
            ExecuteMovement(origin, destination);
            Piece capturedPiece = ExecuteMovement(origin, destination);
            if (IsInCheck(this.CurrentPlayer))
            {
                UndoMovement(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }
            if (IsInCheck(Opponent(this.CurrentPlayer)))
            {
                this.InCheck = true;
            }
            else
            {
                this.InCheck = false;
            }

            if(TestCheckMate(this.CurrentPlayer))
            {
                Finished = true;
            }
            else
            {
                this.Turn++;
                ChangePlayer();
            }
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

        public HashSet<Piece> CapturedPiecesByColor(Color color)
        {
            HashSet<Piece> capturedPiecesByColor = new HashSet<Piece>();
            foreach (Piece piece in this.CapturedPieces)
            {
                if (piece.Color == color)
                {
                    capturedPiecesByColor.Add(piece);
                }
            }
            return capturedPiecesByColor;
        }

        public HashSet<Piece> PiecesInGameByColor(Color color)
        {
            HashSet<Piece> piecesInGameByColor = new HashSet<Piece>();
            foreach (Piece piece in this.Pieces)
            {
                if (piece.Color == color)
                {
                    piecesInGameByColor.Add(piece);
                }
            }
            piecesInGameByColor.ExceptWith(CapturedPiecesByColor(color));
            return piecesInGameByColor;
        }

        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece piece in PiecesInGameByColor(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece king = King(color);
            if (king == null)
            {
                throw new BoardException($"There is no {color} king on the board!");
            }
            foreach (Piece piece in PiecesInGameByColor(Opponent(color)))
            {
                bool[,] possibleMovements = piece.PossibleMovements();
                if (possibleMovements[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestCheckMate(Color color)
        { 
            if (!IsInCheck(color))
            {  
                return false; 
            }

            foreach (Piece piece in PiecesInGameByColor(color))
            {
                bool[,] matriz = piece.PossibleMovements();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (matriz[i, j])
                        {
                            Position origin = piece.Position;
                            Position destiny = new(i, j);
                            Piece capturedPiece = ExecuteMovement(origin, destiny);
                            bool testCheck = IsInCheck(color);
                            UndoMovement(origin, destiny, capturedPiece);

                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void InsertNewPiece(char column, int row, Piece piece)
        {
            Board.InsertPiece(piece, new ChessPosition(column, row).ToPosition());
            this.Pieces.Add(piece);
        }

        public void InsertPieces()
        {
            InsertNewPiece('a', 1, new Rook(Color.White, this.Board));
            InsertNewPiece('b', 1, new Horse(Color.White, this.Board));
            InsertNewPiece('c', 1, new Bishop(Color.White, this.Board));
            InsertNewPiece('d', 1, new Queen(Color.White, this.Board));
            InsertNewPiece('e', 1, new King(Color.White, this.Board));
            InsertNewPiece('f', 1, new Bishop(Color.White, this.Board));
            InsertNewPiece('g', 1, new Horse(Color.White, this.Board));
            InsertNewPiece('h', 1, new Rook(Color.White, this.Board));
            InsertNewPiece('a', 2, new Pawn(Color.White, this.Board));
            InsertNewPiece('b', 2, new Pawn(Color.White, this.Board));
            InsertNewPiece('c', 2, new Pawn(Color.White, this.Board));
            InsertNewPiece('d', 2, new Pawn(Color.White, this.Board));
            InsertNewPiece('e', 2, new Pawn(Color.White, this.Board));
            InsertNewPiece('f', 2, new Pawn(Color.White, this.Board));
            InsertNewPiece('g', 2, new Pawn(Color.White, this.Board));
            InsertNewPiece('h', 2, new Pawn(Color.White, this.Board));

            InsertNewPiece('a', 8, new Rook(Color.Black, this.Board));
            InsertNewPiece('b', 8, new Horse(Color.Black, this.Board));
            InsertNewPiece('c', 8, new Bishop(Color.Black, this.Board));
            InsertNewPiece('d', 8, new Queen(Color.Black, this.Board));
            InsertNewPiece('e', 8, new King(Color.Black, this.Board));
            InsertNewPiece('f', 8, new Bishop(Color.Black, this.Board));
            InsertNewPiece('g', 8, new Horse(Color.Black, this.Board));
            InsertNewPiece('h', 8, new Rook(Color.Black, this.Board));
            InsertNewPiece('a', 7, new Pawn(Color.Black, this.Board));
            InsertNewPiece('b', 7, new Pawn(Color.Black, this.Board));
            InsertNewPiece('c', 7, new Pawn(Color.Black, this.Board));
            InsertNewPiece('d', 7, new Pawn(Color.Black, this.Board));
            InsertNewPiece('e', 7, new Pawn(Color.Black, this.Board));
            InsertNewPiece('f', 7, new Pawn(Color.Black, this.Board));
            InsertNewPiece('g', 7, new Pawn(Color.Black, this.Board));
            InsertNewPiece('h', 7, new Pawn(Color.Black, this.Board));
        }
    }
}

using Chess;
using ChessBoard;

namespace Chess
{
    //This class will implement the mecanics of the game.
    class ChessGame
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; protected set; }
        public bool Finished { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            PlacePieces();
        }

        public void ExecuteAMove(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementAmountMoves();

            Piece capturedPiece = Board.RemovePiece(destination);

            Board.PlacePiece(piece, destination);
        }

        public void MakeAMove(Position origin, Position destination)
        {
            ExecuteAMove(origin, destination);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position position)
        {
            if(Board.GetPiece(position) == null)
            {
                throw new BoardException("There is no piece in this position. Try again!");
            }
            if(ActualPlayer != Board.GetPiece(position).Color)
            {
                throw new BoardException("You are trying to move a piece with the wrong color. Try again!");
            }
            if(!Board.GetPiece(position).ThereIsPossibleMoves())
            {
                throw new BoardException("Sorry, but this piece can't move. Try again!");
            }
        }


        public void ValidadeDestinyPosition(Position origin, Position destiny)
        {
            if(!Board.GetPiece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("This destiny position is not valid. Thay again!");
            }
        }

        private void ChangePlayer()
        {
            ActualPlayer = ActualPlayer == Color.White ? Color.Black : Color.White;
        }

        public void PlacePieces()
        {
            //White pieces
            // Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('a', 2).ToPosition());
            // Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('b', 2).ToPosition());
            // Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('c', 2).ToPosition());
            // Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('d', 2).ToPosition());
            // Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('e', 2).ToPosition());
            // Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('f', 2).ToPosition());
            // Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('g', 2).ToPosition());
            // Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('h', 2).ToPosition());
            Board.PlacePiece(new Tower(Color.White, Board), new ChessPosition('a', 1).ToPosition());
            Board.PlacePiece(new Tower(Color.White, Board), new ChessPosition('h', 1).ToPosition());
            Board.PlacePiece(new King(Color.White, Board), new ChessPosition('d', 1).ToPosition());

            //Black pieces
            // Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('a', 7).ToPosition());
            // Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('b', 7).ToPosition());
            // Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('c', 7).ToPosition());
            // Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('d', 7).ToPosition());
            // Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('e', 7).ToPosition());
            // Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('f', 7).ToPosition());
            // Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('g', 7).ToPosition());
            Board.PlacePiece(new King(Color.Black, Board), new ChessPosition('h', 7).ToPosition());

            Board.PlacePiece(new Tower(Color.Black, Board), new ChessPosition('h', 8).ToPosition());

        }

    }
}
using System.Drawing;
using static Chess___netanel.ChessUtilities;

namespace Chess___netanel
{
    partial class Admin
    {
        //not meant for castling, promotion and en passant. also not meant for UI moves.
        public void undoMove()
        {

        }

        private void coordinateMoveAndRemovalOfPiecesInAllPlatforms(int curXIndex, int curYIndex, int finXIndex, int finYIndex)
        {
            ChessPiece currentPiece = board[curXIndex, curYIndex];
            ChessPiece finalPiece = board[finXIndex, finYIndex];

            //REMOVE PIECES
            if (finalPiece != null)
                removePieceOnAllPlatforms(finXIndex, finYIndex, finalPiece.Color);

            //MOVE PIECES
            movePiecesOnAllPlatforms(curXIndex, curYIndex, finXIndex, finYIndex, currentPiece);
        }

        private void movePiecesOnAllPlatforms(int curXIndex, int curYIndex, int finXIndex, int finYIndex, ChessPiece piece)
        {
            //update UI model
            UIForm.MovePiece(curXIndex, curYIndex, finXIndex, finYIndex);

            //update list
            collectionsOfPiecesOnBoard[(int)piece.Color][new Point(finXIndex, finYIndex)] = piece;
            collectionsOfPiecesOnBoard[(int)piece.Color].Remove(new Point(curXIndex, curYIndex));

            //update real board model
            board[finXIndex, finYIndex] = board[curXIndex, curYIndex];
            board[curXIndex, curYIndex] = null;         
        }

        private void removePieceOnAllPlatforms(int XIndex, int YIndex, Colors color)
        {
            UIForm.RemovePiece(XIndex, YIndex);
            collectionsOfPiecesOnBoard[(int)color].Remove(new Point(XIndex, YIndex));
            board[XIndex, YIndex] = null;
        }
    }
}

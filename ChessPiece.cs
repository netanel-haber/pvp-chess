using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess___netanel
{
    public abstract class ChessPiece
    {
        public Colors Color { get; set; }
        public PieceType Type { get; set; }
    }


    interface IFirstMoveOverPieces
    {
        void SetFirstMoveOver();
    }


    class Pawn : ChessPiece, IFirstMoveOverPieces
    {
        public bool IsFirstMoveOver { get; private set; } = false;
        public void SetFirstMoveOver()
        {
            IsFirstMoveOver = true;
        }

        public Pawn(Colors col)
        {
            Type = PieceType.Pawn;
            Color = col;
        }

    }

    class Rook : ChessPiece, IFirstMoveOverPieces
    {
        public bool IsFirstMoveOver { get; private set; } = false;
        public RookTag WhichSide { get; set; }

        public Rook(Colors col,RookTag whichSide)
        {
            Type = PieceType.Rook;
            Color = col;
            WhichSide = whichSide;
        }


        public void SetFirstMoveOver()
        {
            IsFirstMoveOver = true;
        }
    }


    class King : ChessPiece, IFirstMoveOverPieces
    {
        public bool IsFirstMoveOver { get; private set; } = false;
        public int HomeTurfFile { get; }

        public King(Colors col)
        {
            Type = PieceType.King;
            Color = col;
            HomeTurfFile = col == Colors.White ? 7 : 0;
        }

        public void SetFirstMoveOver()
        {
            IsFirstMoveOver = true;
        }
    }

    class Bishop : ChessPiece
    {
        public bool isDarkColor { get; set; }

        public Bishop(Colors col)
        {
            Type = PieceType.Bishop;
            Color = col;
        }

    }

    class Queen:ChessPiece
    {

        public Queen(Colors col)
        {
            Color = col;
            Type = PieceType.Queen;
        }
    }

    class Knight : ChessPiece
    {
        public Knight(Colors col)
        {
            Type = PieceType.Knight;
            Color = col;
        }
    }

    enum RookTag { QueenSideRook, KingSideRook, PromotedPawn }
}

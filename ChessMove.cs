using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess___netanel
{
    class ChessMove
    {
        public ChessPiece MovingPiece { get; set; }

        public ChessPiece RemovedPiece { get; set; }
  
        public Point RankAndFileFinal { get; set; }

        public Point RankAndFileCurrent { get; set; }

        public bool IsEat { get; set; }

        public bool IsCheck { get; set; }

        public bool IsDoubleCheck { get; set; }

        public bool IsEndGameInfo { get; set; }
        public string EndGameInfo { get; set; }

        public string PromotedTo { get; set; } = "_";

        public ChessMoveTag Tag { get; set; }

        public override string ToString()
        {
            if (IsEndGameInfo)
                return EndGameInfo;

            if (Tag == ChessMoveTag.KingSideCastle)
                return "0-0";
            if (Tag == ChessMoveTag.QueenSideCastle)
                return "0-0-0";

            string result = "";
            switch (MovingPiece.Type)
            {
                case PieceType.Pawn:
                    result = "";
                    break;
                case PieceType.Knight:
                    result = "N";
                    break;
                default:
                    result = Enum.GetName(typeof(PieceType), MovingPiece.Type)[0] + "";
                    break;
            }

            Point current = RankAndFileCurrent;
            result += ChessUtilities.ConvertIndicesToRankAndFile(current.X, current.Y);

            if (IsEat)
                result += "x";
            else
                result += "->";

            Point final = RankAndFileFinal;
            result += ChessUtilities.ConvertIndicesToRankAndFile(final.X, final.Y);

            if (Tag == ChessMoveTag.EnPassant)
                result += "e.p.";

            if (IsCheck)
                result += "+";

            if (IsDoubleCheck)
                result += "+";

            switch (PromotedTo)
            {
                case "K":
                    result += "N";
                    break;
                default:
                    if(PromotedTo!="_")
                    result += PromotedTo;
                    break;
            }
            return result;

        }


    }

    enum ChessMoveTag { DoublePawnMove = 1, PawnPromotion, EnPassant, KingSideCastle, QueenSideCastle }
}

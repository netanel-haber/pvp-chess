using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess___netanel
{
    static class ChessUtilities
    {
        //return rank and file of square for topleftcorner location
        public static string ConvertLocationToRankAndFile(Point Location)
        {
            string rank = Enum.GetName(typeof(Rank), (Location.X - 21) / 75);
            string file = (8 - ((Location.Y - 21) / 75)) + "";
            return rank + file;
        }

        public static int[] ConvertLocationToIndices(Point Location)
        {
            if (!(Location.X >= 21) && (Location.X < 621))
                return null;
            if (!(Location.Y >= 21) && (Location.Y < 621))
                return null;
            return new int[] { (Location.X - 21) / 75, (Location.Y - 21) / 75 };
        }

        public static Colors getOppositeColor(Colors color)
        {
            if (color == Colors.Black)
                return Colors.White;
            return Colors.Black;
        }

        public static bool AreTagsKingAndKnightOrJustKingAndThereforeInsufficient(InsufficientMaterialTag tag1, InsufficientMaterialTag tag2)
        {
            bool option1 = (tag1 == InsufficientMaterialTag.KingAndKnight)
                &&
                    (tag2 == InsufficientMaterialTag.King
                    &&
                    tag2 == InsufficientMaterialTag.KingAndKnight);
            bool option2 = (tag2 == InsufficientMaterialTag.KingAndKnight)
                &&
                    (tag1 == InsufficientMaterialTag.King
                    &&
                    tag1 == InsufficientMaterialTag.KingAndKnight);


            return option1 || option2;
        }

        public static bool AreTagsBishopsSameColor(InsufficientMaterialTag tag1, InsufficientMaterialTag tag2)
        {
            bool option1 = (tag1 == InsufficientMaterialTag.KingAndBishopsLight)
                &&
                    (tag2 == InsufficientMaterialTag.KingAndBishopsLight);
            bool option2 = (tag2 == InsufficientMaterialTag.KingAndBishopsDark)
                &&
                    (tag1 == InsufficientMaterialTag.KingAndBishopsDark);
            return option1 || option2;
        }

        //gets: index of piece in 2darray. returns: location of said piece in pixels.
        public static Point ConvertIndicesToLocation(int xIndex, int yIndex)
        {
            int TopLeftCornerX = 21 + 75 * (xIndex);
            int TopLeftCornerY = 21 + 75 * (yIndex);
            return new Point(TopLeftCornerX, TopLeftCornerY);
        }

        public static string ConvertIndicesToRankAndFile(int xIndex, int yIndex)
        {
            return Enum.GetName(typeof(Rank), xIndex) + (8 - (yIndex));
        }

        //returns rank and file of first piece from startFileIndex between start and end on rankIndex.
        public static SingleThreatPackage FindFirstPieceOnFileFromKing(ChessPiece[,] board, int rankIndex, int startFileIndex, int endFileIndex)
        {
            List<Point> pointsOfThreat = new List<Point>();

            if (startFileIndex < endFileIndex)
            {
                for (int i = startFileIndex + 1; i <= endFileIndex; i++)
                {
                    pointsOfThreat.Add(new Point(rankIndex, i));
                    if (board[rankIndex, i] != null)
                        return new SingleThreatPackage() { threateningPiece = board[rankIndex, i], pointsOfThreats = pointsOfThreat, isDiagonalThreat = false };
                }
            }
            else
            {
                for (int i = startFileIndex - 1; i >= endFileIndex; i--)
                {
                    pointsOfThreat.Add(new Point(rankIndex, i));
                    if (board[rankIndex, i] != null)
                        return new SingleThreatPackage() { threateningPiece = board[rankIndex, i], pointsOfThreats = pointsOfThreat, isDiagonalThreat = false };
                }
            }
            return null;
        }
     
        //returns rank and file of first piece from startRankIndex between start and end on fileIndex.
        public static SingleThreatPackage FindFirstPieceOnRankFromKing(ChessPiece[,] board, int fileIndex, int startRankIndex, int endRankIndex)
        {
            List<Point> pointsOfThreat = new List<Point>();
            if (startRankIndex < endRankIndex)
            {
                for (int i = startRankIndex + 1; i <= endRankIndex; i++)
                {
                    pointsOfThreat.Add(new Point(i, fileIndex));
                    if (board[i, fileIndex] != null)
                        return new SingleThreatPackage() { threateningPiece = board[i, fileIndex], pointsOfThreats = pointsOfThreat, isDiagonalThreat = false };
                }
            }
            else
            {
                for (int i = startRankIndex - 1; i >= endRankIndex; i--)
                {
                    pointsOfThreat.Add(new Point(i, fileIndex));
                    if (board[i, fileIndex] != null)
                        return new SingleThreatPackage() { threateningPiece = board[i, fileIndex], pointsOfThreats = pointsOfThreat, isDiagonalThreat = false };
                }
            }
            return null;
        }

        // returns rank and file of first piece from start square to end of board, on defined directional diagonal. (-1)&(1) are only possible directions
        public static SingleThreatPackage FindFirstPieceOnDiagonalFromKing(ChessPiece[,] board, int startXIndex, int startYIndex, int directionX, int directionY)
        {
            List<Point> pointsOfThreat = new List<Point>();

            int XIterator = startXIndex + directionX;
            int YIterator = startYIndex + directionY;

            while ((XIterator < 8) && (YIterator < 8) && (XIterator > -1) && (YIterator > -1))
            {
                pointsOfThreat.Add(new Point(XIterator, YIterator));
                if (board[XIterator, YIterator] != null)
                    return new SingleThreatPackage() { threateningPiece = board[XIterator, YIterator], pointsOfThreats = pointsOfThreat, isDiagonalThreat = true };
                XIterator += directionX;
                YIterator += directionY;
            }
            return null;
        }



        public static bool isRankClear(ChessPiece[,] board, int fileIndex, int startRankIndex, int endRankIndex)
        {
            if (startRankIndex < endRankIndex)
            {
                for (int i = startRankIndex + 1; i < endRankIndex; i++)
                    if (board[i, fileIndex] != null)
                        return false;
            }
            else
            {
                for (int i = startRankIndex - 1; i > endRankIndex; i--)
                    if (board[i, fileIndex] != null)
                        return false;
            }
            return true;
        }

        public static bool isFileClear(ChessPiece[,] board, int rankIndex, int startFileIndex, int endFileIndex)
        {
            if (startFileIndex < endFileIndex)
            {
                for (int i = startFileIndex + 1; i < endFileIndex; i++)
                    if (board[rankIndex, i] != null)
                        return false;
            }
            else
            {
                for (int i = startFileIndex - 1; i > endFileIndex; i--)
                    if (board[rankIndex, i] != null)
                        return false;
            }
            return true;
        }

        public static bool isDiagonalClear(ChessPiece[,] board, int startXIndex, int startYIndex, int endXIndex, int endYIndex)
        {

            int steps = Math.Abs(startYIndex - endYIndex) - 1;

            int toAddX = Math.Sign(endXIndex - startXIndex);
            int toAddY = Math.Sign(endYIndex - startYIndex);
            int XIterator = startXIndex + toAddX;
            int YIterator = startYIndex + toAddY;

            for (int i = 0; i < steps; i++, XIterator += toAddX, YIterator += toAddY)
            {
                if (board[XIterator, YIterator] != null)
                    return false;
            }
            return true;
        }



        public static bool isIndexInBounds(int index1, int index2, int index3, int index4)
        {
            return isIndexInBounds(index1, index2) && isIndexInBounds(index3, index4);
        }
        public static bool isIndexInBounds(int index1, int index2)
        {
            return isIndexInBounds(index1) && isIndexInBounds(index2);
        }
        public static bool isIndexInBounds(int index)
        {
            if (index > 7 || index < 0)
                return false;
            return true;
        }




    }
}

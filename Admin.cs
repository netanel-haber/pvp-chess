using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using static Chess___netanel.ChessUtilities;
using System.Timers;

namespace Chess___netanel
{
    partial class Admin
    {
        ChessPiece[,] board;
        Dictionary<Point, ChessPiece>[] collectionsOfPiecesOnBoard = new Dictionary<Point, ChessPiece>[2]; //white:[0], black: [1]
        Dictionary<BoardScreenshot, int> uniqueMoveCounter = new Dictionary<BoardScreenshot, int>(); //compiled screenshot of board after move, counter

        List<ChessMove> moveList = new List<ChessMove>(150);

        int fiftyMovesCursor = 0;

        int curX = -1;
        int curY = -1;
        int finX = -1;
        int finY = -1;
        ChessPiece currentPiece;

        Point[] kingLocations; //white:[0], black: [1]
        Point[] g;
        BitArray kingsChecked = new BitArray(2); //white:[0], black: [1]
        InsufficientMaterialTag[] insufficientMaterial = new InsufficientMaterialTag[2]; //white:[0], black: [1]

        bool didBlackRequestDraw;
        ChessMove MoveBeingBuilt;

        ChessPiece this[string rank, int file]
        {
            get
            {
                return board[(int)Enum.Parse(typeof(Rank), rank + ""), 8 - file];
            }
            set
            {
                board[(int)Enum.Parse(typeof(Rank), rank + ""), 8 - file] = value;
            }
        }

        UI UIForm;

        public Admin(UI userInt)
        {
            MitigateTimers();

            board = ChessBoards.GetStandardBoard(out Point[] kingsLocations);
            kingLocations = kingsLocations;
            updatePieceCollections();

            UIForm = userInt;
            UIForm.PopulateBoard(collectionsOfPiecesOnBoard[0]);
            UIForm.PopulateBoard(collectionsOfPiecesOnBoard[1]);
            UIForm.Disposed += disposedUI;
        }

        private void updatePieceCollections()
        {
            //add all pieces to pieces map
            collectionsOfPiecesOnBoard[0] = new Dictionary<Point, ChessPiece>();
            collectionsOfPiecesOnBoard[1] = new Dictionary<Point, ChessPiece>();
            ChessPiece temp;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    temp = board[i, j];
                    if (temp != null)
                        collectionsOfPiecesOnBoard[(int)temp.Color][new Point(i, j)] = temp;
                }
            }

        }

        public Colors getCurrentTurnColor()
        {
            return blackTimer.Enabled ? Colors.Black : Colors.White;
        }

        public Colors getOppositeTurnColor()
        {
            return whiteTimer.Enabled ? Colors.Black : Colors.White;
        }



        public void HandleMove(int currentXIndex, int currentYIndex, int finalXIndex, int finalYIndex)
        {
            curX = currentXIndex;
            curY = currentYIndex;
            finX = finalXIndex;
            finY = finalYIndex;

            currentPiece = board[curX, curY];
            ChessPiece finalPiece = board[finX, finY];
            bool isFinalEmpty = finalPiece == null;

            MoveBeingBuilt = new ChessMove()
            {
                MovingPiece = currentPiece,
                RemovedPiece = finalPiece,
                IsEat = !isFinalEmpty,
                RankAndFileFinal = new Point(finX, finY),
                RankAndFileCurrent = new Point(curX, curY)
            };


            //Check if same square was clicked twice
            if ((curX == finX) && (curY == finY))
                return;

            //Check if right color is moving
            if (currentPiece.Color != getCurrentTurnColor())
                throw new NotYourTurnException();


            checkGeneralLegalityOfMove(currentPiece, curX, curY, finX, finY, out Point enPassantPoint, ref MoveBeingBuilt);


            if (MoveBeingBuilt.Tag == ChessMoveTag.PawnPromotion)
                UIForm.OpenPromotionDialogAndWaitForResponse(getCurrentTurnColor());


            if (MoveBeingBuilt.Tag == ChessMoveTag.EnPassant)
            {
                int direction = currentPiece.Color == Colors.Black ? 1 : -1;
                MoveBeingBuilt.IsEat = true;
                UIForm.OpenMessageBox("En Passant!");

                //special remove and update because eaten piece is not in final destination
                removePieceOnAllPlatforms(finX, finY - direction, getOppositeTurnColor());
            }

            bool isQueenSideCastle = (MoveBeingBuilt.Tag == ChessMoveTag.QueenSideCastle);
            bool isKingSideCastle = (MoveBeingBuilt.Tag == ChessMoveTag.KingSideCastle);

            if (isQueenSideCastle || isKingSideCastle)
            {   //move king
                movePiecesOnAllPlatforms(curX, curY, finX, finY, currentPiece);
                if (isQueenSideCastle)
                {
                    UIForm.OpenMessageBox("Queen-side castle!");
                    //move rook
                    movePiecesOnAllPlatforms(0, finY, finX + 1, finY, currentPiece);
                }
                if (isKingSideCastle)
                {
                    UIForm.OpenMessageBox("King-side castle!");
                    //move rook
                    movePiecesOnAllPlatforms(7, finY, finX - 1, curY, currentPiece);
                }
                endTurn();
                return;
            }

            coordinateMoveAndRemovalOfPiecesInAllPlatforms(curX, curY, finX, finY);

            endTurn();
        }
        //checks: legality of move according to piece logic, king exposure as a result of the move and if there are pieces on the way to final point.
        public void checkGeneralLegalityOfMove(ChessPiece piece, int currentXIndex, int currentYIndex, int finalXIndex, int finalYIndex, out Point enPassantPoint, ref ChessMove move)
        {
            //king will be specifically checked in tryKingMoving()
            if ((piece.Type != PieceType.Knight) && (piece.Type != PieceType.King))
                checkIfThereIsPieceOnTheWayToFinalDestination(currentXIndex, currentYIndex, finalXIndex, finalYIndex);

            ChessPiece finalDestination = board[finalXIndex, finalYIndex];
            //Check same color trying to occupy square as same color
            if ((finalDestination != null) && finalDestination.Color == piece.Color)
                throw new YouCannotOverrideYourOwnPieceException();

            enPassantPoint = Point.Empty;
            switch (piece.Type)
            {
                case PieceType.Rook:
                    tryRookMoving(currentXIndex, currentYIndex, finalXIndex, finalYIndex);
                    break;
                case PieceType.Knight:
                    tryKnightMoving(currentXIndex, currentYIndex, finalXIndex, finalYIndex);
                    break;
                case PieceType.Bishop:
                    tryBishopMoving(currentXIndex, currentYIndex, finalXIndex, finalYIndex);
                    break;
                case PieceType.Queen:
                    tryQueenMoving(currentXIndex, currentYIndex, finalXIndex, finalYIndex);
                    break;
                case PieceType.King:
                    tryKingMoving(piece as King, currentXIndex, currentYIndex, finalXIndex, finalYIndex, ref move);
                    break;
                case PieceType.Pawn:
                    enPassantPoint = tryPawnMoving(piece as Pawn, currentXIndex, currentYIndex, finalXIndex, finalYIndex, ref move);
                    break;
            }

            if (!tryMoveToCheckKingExposure(currentXIndex, currentYIndex, finalXIndex, finalYIndex, piece.Color, enPassantPoint))
                throw King_CannotExposeOrKeepKingInCheckException.GetExWithMessage();
        }
        private void endTurn()
        {
            //if rook, king or pawn, then set first move over
            IFirstMoveOverPieces piece = currentPiece as IFirstMoveOverPieces;
            if (piece != null)
                piece.SetFirstMoveOver();

            //if king, set location to destination
            King king = piece as King;
            if (king != null)
                kingLocations[(int)king.Color] = new Point(finX, finY);


            //check for check and then checkmate
            Colors colorOfKingToCheck = getOppositeTurnColor();
            ThreatsPackage package = checkIfKingIsUnderCheck(colorOfKingToCheck);
            if (package.isCheck)
            {
                kingsChecked[(int)colorOfKingToCheck] = true;
                MoveBeingBuilt.IsCheck = true;
                MoveBeingBuilt.IsDoubleCheck = package.IsDoubleCheck;

                if (checkMate(package, colorOfKingToCheck))
                {
                    moveList.Add(MoveBeingBuilt);
                    gameEndsOnCheckMate(colorOfKingToCheck);
                    return;
                }

                UIForm.OpenMessageBox(colorOfKingToCheck.ToString() + " is in check!");
            }
            else
                kingsChecked[(int)colorOfKingToCheck] = false;

            //add move to list
            moveList.Add(MoveBeingBuilt);



            //check if 50 moves rule
            if (checkStaleMate())
            {
                staleMateEndGame();
            }
            else if (check3RepetitionRule())
            {
                threeRepetitionRuleEndGame();
            }
            else if (checkInsufficientMaterialBothColors())
            {
                insufficientMaterialEndgame();
            }
            else if (check50MovesRule())
            {
                fiftyMoveRuleEndgame();
            }


            FlipTurns();
        }
        private BoardScreenshot compileBoardScreenshot()
        {
            int[,] screenShot = new int[8, 8];

            int temp = 1;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ChessPiece piece = board[i, j];
                    if (piece != null)
                    {
                        switch (piece.Type)
                        {
                            case PieceType.Bishop:
                                temp = 1;
                                break;
                            case PieceType.Pawn:
                                temp = 2;
                                break;
                            case PieceType.King:
                                temp = 3;
                                break;
                            case PieceType.Queen:
                                temp = 4;
                                break;
                            case PieceType.Rook:
                                temp = 5;
                                break;
                            case PieceType.Knight:
                                temp = 6;
                                break;
                        }
                        temp *= (piece.Color == Colors.Black) ? 19 : 37;
                        screenShot[i, j] = temp;
                    }
                }
            }

            return new BoardScreenshot
            {
                screenshot = screenShot,
                rightToEnPassant = doesScreenshotContainEnPassantAbility(),
                rightToCastleQueensideWhite = doesKingHaveCastlingRights(0, Colors.White),
                rightToCastleKingsideWhite = doesKingHaveCastlingRights(7, Colors.White),
                rightToCastleQueensideBlack = doesKingHaveCastlingRights(0, Colors.Black),
                rightToCastleKingsideBlack = doesKingHaveCastlingRights(7, Colors.Black),
            };

        }

        private ThreatsPackage checkIfKingIsUnderCheck(Colors kingColor)
        {
            Point kingLocation = kingLocations[(int)kingColor];
            int x = kingLocation.X;
            int y = kingLocation.Y;

            List<SingleThreatPackage> lineOfSightThreats = checkAllPossibleLineOfSightThreatsOnKing(x, y, kingColor);
            SingleThreatPackage knightThreat = checkAllPossibleKnightThreatsOnKing(x, y, kingColor);

            ThreatsPackage package = new ThreatsPackage { KnightCheck = knightThreat, LineOfSightThreats = lineOfSightThreats };

            return package;
        }

        private bool checkMate(ThreatsPackage threats, Colors kingColor) //true if checkmate
        {
            bool isDoubleCheck = threats.IsDoubleCheck;
            bool isKnightCheck = threats.KnightCheck != null;

            bool canKingMove = tryAllPossibleKingMoves(kingColor);
            if (canKingMove)
                return false;
            else if (isDoubleCheck)
                return true;


            //established at this point: not double check; king cannot move.

            List<Point> actualPointsOfThreat;
            actualPointsOfThreat = (threats.LineOfSightThreats != null) ? threats.LineOfSightThreats[0].pointsOfThreats : threats.KnightCheck.pointsOfThreats;

            Point threatPiece = actualPointsOfThreat[actualPointsOfThreat.Count - 1]; //last point in threat points of threat list is always threatening piece
            bool canPieceBeEaten = checkMate_TryEating(kingColor, threatPiece);
            if (canPieceBeEaten)
                return false;
            if ((isKnightCheck) && (!canPieceBeEaten))
                return true;

            actualPointsOfThreat.RemoveAt(actualPointsOfThreat.Count - 1);


            //established at this point: single line of sight threat that cannot be eaten; king cannot move.
            bool canBeBlocked = checkMate_TryBlocking(kingColor, actualPointsOfThreat);
            if (canBeBlocked)
                return false;
            return true;

        }
        private bool checkMate_TryEating(Colors kingColor, Point actualThreatPoint) //true if solution exists
        {
            ChessPiece piece;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    piece = board[i, j];
                    if (piece == null)
                        continue;
                    if ((piece.Color == kingColor) && (piece.Type != PieceType.King))
                    {
                        try
                        {
                            ChessMove throwAwayMoveForFunc = new ChessMove();
                            checkGeneralLegalityOfMove(piece, i, j, actualThreatPoint.X, actualThreatPoint.Y, out Point throwAway1, ref throwAwayMoveForFunc);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                        return true;
                    }
                }
            }

            //check if enpassant eating is possible
            bool isElligible = isMostRecentMoveDoublePawnMoveToPoint(actualThreatPoint.X, actualThreatPoint.Y);
            if (!isElligible)
                return false;

            //check if directly adjacent (left) meets requirements
            if (verifyLocationInBoundsAndContainsPawnOfRequestedColor(actualThreatPoint.X - 1, actualThreatPoint.Y, kingColor))
                return true;

            //check if directly adjacent (right) meets requirements
            if (verifyLocationInBoundsAndContainsPawnOfRequestedColor(actualThreatPoint.X + 1, actualThreatPoint.Y, kingColor))
                return true;

            return false;
        }
        private bool checkMate_TryBlocking(Colors kingColor, List<Point> possibleBlockingPoints)
        {
            ChessPiece piece;
            foreach (Point p in possibleBlockingPoints)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        piece = board[i, j];
                        if (piece == null)
                            continue;
                        if (piece.Type == PieceType.King)
                            continue;
                        if (piece.Type == PieceType.Pawn)
                            continue;
                        if (piece.Color == kingColor)
                        {
                            try
                            {
                                ChessMove throwAwayMoveForFunc = new ChessMove();
                                checkGeneralLegalityOfMove(piece, i, j, p.X, p.Y, out Point throwAway1, ref throwAwayMoveForFunc);
                            }
                            catch
                            {
                                continue;
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool checkStaleMate()
        {
            Colors color = getOppositeTurnColor();

            Dictionary<Point, ChessPiece> map = collectionsOfPiecesOnBoard[(int)color];

            ChessPiece square;

            bool result = false;

            foreach (Point p in map.Keys)
            {
                switch (map[p].Type)
                {
                    case PieceType.Pawn:
                        if (tryAllPossiblePawnMoves(map[p].Color, p.X, p.Y))
                            return false;
                        break;
                    case PieceType.Knight:
                        if (tryAllPossibleKnightMoves(p.X, p.Y))
                            return false;
                        break;
                    case PieceType.King:
                        if (tryAllPossibleKingMoves(map[p].Color) || doesKingHaveCastlingRights(0, map[p].Color) || doesKingHaveCastlingRights(7, map[p].Color))
                            return false;
                        break;
                    case PieceType.Rook:
                        if (tryAllPossibleRookMoves(p.X, p.Y))
                            return false;
                        break;
                    case PieceType.Queen:
                        if (tryAllPossibleBishopMoves(p.X, p.Y) || tryAllPossibleRookMoves(p.X, p.Y))
                            return false;
                        break;
                    case PieceType.Bishop:
                        if (tryAllPossibleBishopMoves(p.X, p.Y))
                            return false;
                        break;
                }

            }
            return true;
        }

        private bool check3RepetitionRule()
        {
            BoardScreenshot screenshot = compileBoardScreenshot();

            if (uniqueMoveCounter.ContainsKey(screenshot))
            {
                uniqueMoveCounter[screenshot]++;
                if (uniqueMoveCounter[screenshot] == 3)
                    return true;
                return false;
            }
            else
            {
                uniqueMoveCounter[screenshot] = 1;
                return false;
            }
        }

        private bool checkInsufficientMaterialBothColors()
        {

            insufficientMaterial[0] = calculateMaterialForOneSide(collectionsOfPiecesOnBoard[0]);
            insufficientMaterial[1] = calculateMaterialForOneSide(collectionsOfPiecesOnBoard[1]);


            if (insufficientMaterial[0] == InsufficientMaterialTag.Sufficient)
                return false;

            if (insufficientMaterial[1] == InsufficientMaterialTag.Sufficient)
                return false;

            if (insufficientMaterial[0] != insufficientMaterial[1])
                if (insufficientMaterial[0] > 0 && insufficientMaterial[1] > 0)
                    return false;

            return true;

        }
        private InsufficientMaterialTag calculateMaterialForOneSide(Dictionary<Point, ChessPiece> piecesMap) //true if material is insufficient
        {

            Bishop previousBishop = null;
            int knightCounter = 0;

            ChessPiece[] pieces = new ChessPiece[piecesMap.Count];
            piecesMap.Values.CopyTo(pieces, 0);

            for (int i = 0; i < pieces.Length; i++)
            {
                switch (pieces[i].Type)
                {
                    case PieceType.King:
                        continue;

                    case PieceType.Bishop:
                        {
                            if (previousBishop == null)
                                previousBishop = pieces[i] as Bishop;
                            else
                            {
                                Bishop currentBishop = pieces[i] as Bishop;
                                if (previousBishop.isDarkColor != currentBishop.isDarkColor)
                                    return InsufficientMaterialTag.Sufficient;
                                previousBishop = currentBishop;
                            }
                        }
                        break;
                    case PieceType.Knight:
                        {
                            if (knightCounter == 1)
                                return InsufficientMaterialTag.Sufficient;
                            else
                                knightCounter++;
                        }
                        break;

                    default:
                        return InsufficientMaterialTag.Sufficient;
                }
            }


            if (knightCounter == 1)
                return previousBishop != null ? InsufficientMaterialTag.Sufficient : InsufficientMaterialTag.KingAndKnight;
            else
                return previousBishop == null ? InsufficientMaterialTag.King : (previousBishop.isDarkColor ? InsufficientMaterialTag.KingAndBishopsDark : InsufficientMaterialTag.KingAndBishopsLight);

        }

        private bool check50MovesRule() //true if 50 move rule is true
        {
            if (moveList.Count >= 100)
            {
                for (int i = fiftyMovesCursor; i < fiftyMovesCursor + 100; i++)
                {
                    if (moveList[i].IsEat)
                    {
                        fiftyMovesCursor++;
                        return false;
                    }
                    if (moveList[i].MovingPiece.Type == PieceType.Pawn)
                    {
                        fiftyMovesCursor++;
                        return false;
                    }
                }
                return true;
            }
            return false;
        }



        private void tryQueenMoving(int curXIndex, int curYIndex, int finXIndex, int finYIndex)
        {
            if ((!bishopMovingLogic(curXIndex, curYIndex, finXIndex, finYIndex)) && (!rookMovingLogic(curXIndex, curYIndex, finXIndex, finYIndex)))
                throw QueenException.GetExWithMessage();
        }

        private bool tryAllPossibleKingMoves(Colors kingColor)
        {
            Point kingLocation = kingLocations[(int)kingColor];
            int kingX = kingLocation.X;
            int kingY = kingLocation.Y;
            ChessPiece piece;

            for (int i = kingX - 1; i <= kingX + 1; i++)
            {
                for (int j = kingY - 1; j <= kingY + 1; j++)
                {
                    //same square as king
                    if (i == kingX && j == kingY)
                        continue;

                    //index in bounds of board condition
                    if (!ChessUtilities.isIndexInBounds(i, j))
                        continue;

                    piece = board[i, j];
                    //piece at destination not of same color condition
                    if ((piece != null) && (piece.Color == kingColor))
                        continue;

                    //move does not expose king to further check
                    if (tryMoveToCheckKingExposure(kingX, kingY, i, j, kingColor, Point.Empty))
                        return true;
                }
            }
            return false;
        }
        private void tryKingMoving(King king, int curXIndex, int curYIndex, int finXIndex, int finYIndex, ref ChessMove chessMove)
        {
            int xDif = Math.Abs(finXIndex - curXIndex);
            int yDif = Math.Abs(finYIndex - curYIndex);

            if (!((xDif <= 1) && (yDif <= 1))) //check for castle
            {
                //check if king in right square
                if ((curXIndex != 4) || (curYIndex != king.HomeTurfFile))
                    throw KingException.GetExWithMessage();

                //check attempted castle - king already moved
                if (king.IsFirstMoveOver)
                    throw KingHasAlreadyMovedBeforeException.GetExWithMessage();

                //check castling to relevant square
                if ((finXIndex != 2) && (finXIndex != 6))
                    throw KingException.GetExWithMessage();

                //check attempted castle - king in check
                if (kingsChecked[(int)king.Color])
                    throw KingCannotCastleInCheckException.GetExWithMessage();

                //check attempted castle - rank clear of pieces between relevant rook and king
                int relevantRookRank = curXIndex > finXIndex ? 0 : 7;

                try
                {
                    checkIfThereIsPieceOnTheWayToFinalDestination(curXIndex, king.HomeTurfFile, relevantRookRank, king.HomeTurfFile);
                }
                catch
                {
                    throw King_SpacesBetweenRookAndKingNotClearException.GetExWithMessage();
                }

                //check attempted castle - no move exposes king to check
                if (!isSafeToCastle(relevantRookRank, king.HomeTurfFile, king.Color))
                    throw KingCannotBeExposedWhileCastlingException.GetExWithMessage();


                Rook relevantRook = board[relevantRookRank, king.HomeTurfFile] as Rook;

                //check attempted castle - if relevant rook has previously moved
                if (!((relevantRook != null) && (!relevantRook.IsFirstMoveOver)))
                    throw RookHasAlreadyMovedBeforeException.GetExWithMessage();

                chessMove.Tag = (relevantRook.WhichSide == RookTag.KingSideRook) ?
                     ChessMoveTag.KingSideCastle : ChessMoveTag.QueenSideCastle;
            }

        }
        private bool isSafeToCastle(int rookRank, int relevantFile, Colors color)
        {
            if (rookRank == 7)//kingside
            {
                if (!tryMoveToCheckKingExposure(4, relevantFile, 5, relevantFile, color, Point.Empty))
                    return false;
                if (!tryMoveToCheckKingExposure(4, relevantFile, 6, relevantFile, color, Point.Empty))
                    return false;
            }
            if (rookRank == 0)//queenside
            {
                if (!tryMoveToCheckKingExposure(4, relevantFile, 2, relevantFile, color, Point.Empty))
                    return false;
                if (!tryMoveToCheckKingExposure(4, relevantFile, 3, relevantFile, color, Point.Empty))
                    return false;
            }
            return true;
        }
        private List<SingleThreatPackage> checkAllPossibleLineOfSightThreatsOnKing(int kingX, int kingY, Colors kingColor)
        {
            List<SingleThreatPackage> threats = new List<SingleThreatPackage>();
            SingleThreatPackage result;

            result = ChessUtilities.FindFirstPieceOnRankFromKing(board, kingY, kingX, 7);
            if (checkIfLineOfSightPieceIsActualThreatOnKing(result, kingColor))
                threats.Add(result);

            result = ChessUtilities.FindFirstPieceOnRankFromKing(board, kingY, kingX, 0);
            if (checkIfLineOfSightPieceIsActualThreatOnKing(result, kingColor))
                threats.Add(result);

            result = ChessUtilities.FindFirstPieceOnFileFromKing(board, kingX, kingY, 7);
            if ((threats.Count < 2) && checkIfLineOfSightPieceIsActualThreatOnKing(result, kingColor))
                threats.Add(result);

            result = ChessUtilities.FindFirstPieceOnFileFromKing(board, kingX, kingY, 0);
            if ((threats.Count < 2) && checkIfLineOfSightPieceIsActualThreatOnKing(result, kingColor))
                threats.Add(result);


            result = ChessUtilities.FindFirstPieceOnDiagonalFromKing(board, kingX, kingY, -1, -1);
            if ((threats.Count < 2) && checkIfLineOfSightPieceIsActualThreatOnKing(result, kingColor))
                threats.Add(result);

            result = ChessUtilities.FindFirstPieceOnDiagonalFromKing(board, kingX, kingY, -1, 1);
            if ((threats.Count < 2) && checkIfLineOfSightPieceIsActualThreatOnKing(result, kingColor))
                threats.Add(result);

            result = ChessUtilities.FindFirstPieceOnDiagonalFromKing(board, kingX, kingY, 1, -1);
            if ((threats.Count < 2) && checkIfLineOfSightPieceIsActualThreatOnKing(result, kingColor))
                threats.Add(result);

            result = ChessUtilities.FindFirstPieceOnDiagonalFromKing(board, kingX, kingY, 1, 1);
            if ((threats.Count < 2) && checkIfLineOfSightPieceIsActualThreatOnKing(result, kingColor))
                threats.Add(result);

            if (threats.Count == 0)
                return null;
            return threats;
        }
        private bool checkIfLineOfSightPieceIsActualThreatOnKing(SingleThreatPackage threat, Colors kingColor)
        {
            if (threat == null)
                return false;

            ChessPiece lineOfSightPiece = threat.threateningPiece;
            int steps = threat.pointsOfThreats.Count;
            bool isDiagonal = threat.isDiagonalThreat;


            if (lineOfSightPiece.Color != kingColor)
            {
                switch (lineOfSightPiece.Type)
                {
                    case PieceType.King:
                        if (steps == 1)
                            return true;
                        break;
                    case PieceType.Pawn:
                        if (isDiagonal && steps == 1)
                        {
                            bool rightPawnDirection =
                                ((threat.pointsOfThreats[0].Y < kingLocations[(int)kingColor].Y
                                && lineOfSightPiece.Color == Colors.Black)
                                ||
                                (threat.pointsOfThreats[0].Y > kingLocations[(int)kingColor].Y
                                && lineOfSightPiece.Color == Colors.White));
                            
                            if (rightPawnDirection)
                                return true;
                        }
                        break;
                    case PieceType.Bishop:
                        if (isDiagonal)
                            return true;
                        break;
                    case PieceType.Rook:
                        if (!isDiagonal)
                            return true;
                        break;
                    case PieceType.Queen:
                        return true;
                }
            }
            return false;
        }
        private SingleThreatPackage checkAllPossibleKnightThreatsOnKing(int curXIndex, int curYIndex, Colors kingColor)
        {
            SingleThreatPackage result;

            for (int i = -2; i <= 2; i++)
            {
                for (int j = -2; j <= 2; j++)
                {
                    if ((Math.Abs(i) == 2 && (Math.Abs(j) == 1)) || ((Math.Abs(i) == 1 && (Math.Abs(j) == 2))))
                    {
                        result = checkIfLocationContainsThreateningKnight(curXIndex, curYIndex, 1, 2, kingColor);
                        if (result != null)
                            return result;
                    }
                }
            }
            return null;
        }
        private SingleThreatPackage checkIfLocationContainsThreateningKnight(int currX, int currY, int addToCurX, int addToCurY, Colors kingColor)
        {
            int XPath = currX + addToCurX;
            int YPath = currY + addToCurY;

            if (ChessUtilities.isIndexInBounds(XPath, YPath))
            {
                Knight knight = board[XPath, YPath] as Knight;
                if ((knight != null) && (knight.Color != kingColor))
                    return new SingleThreatPackage()
                    {
                        isThreateningPieceKnight = true,
                        pointsOfThreats = new List<Point>() { new Point(XPath, YPath) }
                    };
            }
            return null;
        }
        //check for king exposure after move - then move pieces back. doesn't check legality of move at all - just in terms of king exposure
        private bool tryMoveToCheckKingExposure(int x1, int y1, int x2, int y2, Colors color, Point enPassantLocation)
        {
            bool result;
            ChessPiece pieceMoving;
            pieceMoving = board[x1, y1];
            ChessPiece pieceEaten;

            if (enPassantLocation == Point.Empty)
            {
                pieceEaten = board[x2, y2];

                board[x2, y2] = board[x1, y1]; //move piece to destination  
                if (board[x1, y1] as King != null)
                    kingLocations[(int)color] = new Point(x2, y2); //update king location to destination
                board[x1, y1] = null; //remove piece from starting location


                result = !checkIfKingIsUnderCheck(color).isCheck;  //now check king exposure             

                //safe return of pieces to previous destinations
                board[x2, y2] = pieceEaten;
                board[x1, y1] = pieceMoving;
                if (board[x1, y1] as King != null)
                    kingLocations[(int)color] = new Point(x1, y1); //update king location to previous location
            }
            else
            {
                pieceEaten = board[enPassantLocation.X, enPassantLocation.Y];
                board[x2, y2] = board[x1, y1]; //move piece to destination            
                board[x1, y1] = null; //remove piece from starting location
                board[enPassantLocation.X, enPassantLocation.Y] = null; //remove en passant piece

                result = !checkIfKingIsUnderCheck(color).isCheck;  //now check king exposure  

                board[x2, y2] = null; //clear final destination
                board[x1, y1] = pieceMoving; //move moved piece back to starting point
                board[enPassantLocation.X, enPassantLocation.Y] = pieceEaten; //resurect en passant piece
            }

            return result; //true if safe
        }
        private bool doesKingHaveCastlingRights(int relevantRookRank, Colors kingColor)
        {
            Point kingLocation = kingLocations[(int)kingColor];


            int relevantFile = (board[kingLocation.X, kingLocation.Y] as King).HomeTurfFile;
            King relevantKing = board[kingLocation.X, kingLocation.Y] as King;
            Rook relevantRook = board[relevantRookRank, relevantFile] as Rook;

            bool isRookElligible = (relevantRook != null) && (!relevantRook.IsFirstMoveOver);
            bool isKingElligible = !relevantKing.IsFirstMoveOver;

            try
            {
                checkIfThereIsPieceOnTheWayToFinalDestination(4, relevantFile, relevantRookRank, relevantFile);
            }
            catch
            {
                return false;
            }


            if (isKingElligible && isRookElligible && isSafeToCastle(relevantRookRank, relevantFile, kingColor))
                return true;

            return false;
        }

        private bool tryAllPossibleKnightMoves(int currX, int currY)
        {
            int toAddX = currX;
            int toAddY = currY;

            for (int i = -2; i < 2; i++)
            {
                for (int j = -2; j < 2; j++)
                {
                    if ((Math.Abs(i) == 2 && (Math.Abs(j) == 1)) || ((Math.Abs(i) == 1 && (Math.Abs(j) == 2))))
                    {
                        toAddX += i;
                        toAddY += j;
                        if (!isIndexInBounds(i, j))
                            return false;
                        try
                        {
                            ChessMove throwAwayMove = null;
                            checkGeneralLegalityOfMove(board[currX, currY], currX, currY, toAddX, toAddY, out Point _, ref throwAwayMove);
                        }
                        catch
                        {
                            toAddX = currX;
                            toAddY = currY;
                            continue;
                        }
                        return true;
                    }
                }
            }
            return false;
        }
        private void tryKnightMoving(int curXIndex, int curYIndex, int finXIndex, int finYIndex)
        {
            int xDif = Math.Abs(finXIndex - curXIndex);
            int yDif = Math.Abs(finYIndex - curYIndex);

            if (!(((xDif == 1) && (yDif == 2)) || ((xDif == 2) && (yDif == 1))))
                throw KnightException.GetExWithMessage();
        }

        private bool tryAllPossibleBishopMoves(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (Math.Abs(i) == 1 && (Math.Abs(j) == 1))
                    {
                        int XIterator = x + i;
                        int YIterator = y + j;
                        while ((XIterator < 8) && (YIterator < 8) && (XIterator > -1) && (YIterator > -1))
                        {
                            ChessMove throwAwayMove = null;
                            try
                            {
                                checkGeneralLegalityOfMove(board[x, y], x, y, XIterator, YIterator, out Point _, ref throwAwayMove);
                            }
                            catch
                            {
                                XIterator += i;
                                YIterator += j;
                                continue;
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void tryBishopMoving(int curXIndex, int curYIndex, int finXIndex, int finYIndex)
        {
            if (!bishopMovingLogic(curXIndex, curYIndex, finXIndex, finYIndex))
                throw BishopException.GetExWithMessage();
        }
        private bool bishopMovingLogic(int curXIndex, int curYIndex, int finXIndex, int finYIndex)
        {
            return Math.Abs(finXIndex - curXIndex) == Math.Abs(finYIndex - curYIndex);
        }

        private bool tryAllPossiblePawnMoves(Colors color, int x, int y)
        {
            int direction = color == Colors.Black ? -1 : 1;
            ChessMove move = new ChessMove();



            try
            {
                if (!isIndexInBounds(y - direction))
                    throw new Exception();
                //regular lateral move
                checkGeneralLegalityOfMove(board[x, y], x, y, x, y - direction, out Point _, ref move);
            }
            catch
            {
                try
                {
                    if (!isIndexInBounds((y - direction) - direction))
                        throw new Exception();
                    //double move
                    checkGeneralLegalityOfMove(board[x, y], x, y, x, (y - direction) - direction, out Point _, ref move);
                }
                catch
                {
                    try
                    {
                        if (!isIndexInBounds(x - 1, y - direction))
                            throw new Exception();
                        //eating or en passant
                        checkGeneralLegalityOfMove(board[x, y], x, y, x - 1, y - direction, out Point _, ref move);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            if (!isIndexInBounds(x + 1, y - direction))
                                throw new Exception();
                            //eating or en passant 2
                            checkGeneralLegalityOfMove(board[x, y], x, y, x + 1, y - direction, out Point _, ref move);
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private Point tryPawnMoving(Pawn pawn, int curXIndex, int curYIndex, int finXIndex, int finYIndex, ref ChessMove chessMove)
        {
            bool isPawnPromotion = (finYIndex == 0) || (finYIndex == 7);

            // check if moving backwards
            int direction = pawn.Color == Colors.Black ? 1 : -1;
            if (Math.Sign(finYIndex - curYIndex) != direction)
                throw PawnCanOnlyGoForwardsException.GetExWithMessage();

            if (curXIndex == finXIndex) //pawn moving laterally
            {
                //check if final lateral sqaure is occupied
                if (board[finXIndex, finYIndex] != null)
                    throw PawnCannotEatLaterallyException.GetExWithMessage();

                int numberOfSquares = Math.Abs(finYIndex - curYIndex);
                switch (numberOfSquares)
                {
                    case 1:
                        if (isPawnPromotion)
                            chessMove.Tag = ChessMoveTag.PawnPromotion;
                        break;
                    case 2:
                        if (pawn.IsFirstMoveOver)
                            throw Pawn_OnlyFirstMoveCanBeDoubleException.GetExWithMessage();
                        chessMove.Tag = ChessMoveTag.DoublePawnMove;
                        break;
                    default:
                        throw PawnCannotMoveMoreThan2SquaresAtAnyTimeException.GetExWithMessage();
                }

                //en passant location never on (0,0)
                return Point.Empty;
            }
            else //pawn moving diagonally.
            {
                int numberOfDiagonalSquares = Math.Abs(finXIndex - curXIndex);
                if (numberOfDiagonalSquares > 1)
                    throw PawnException.GetExWithMessage();

                ChessPiece directlyDiagonal = board[finXIndex, finYIndex];
                bool checkEnPassantElligibility = isMostRecentMoveDoublePawnMoveToPoint(finXIndex, finYIndex - direction);


                if (!checkEnPassantElligibility)
                {
                    if (directlyDiagonal != null)
                    {
                        if (isPawnPromotion)
                            chessMove.Tag = ChessMoveTag.PawnPromotion;
                        return Point.Empty;
                    }
                    else
                        throw PawnException.GetExWithMessage();
                }

                chessMove.Tag = ChessMoveTag.EnPassant;
                chessMove.IsEat = true;
                return new Point(finXIndex, finYIndex - direction);//en passant point
            }
        }
        //existence of directly diagonal piece is impossible if immediate previous move was double pawn move to adjacent square
        private bool isMostRecentMoveDoublePawnMoveToPoint(int x, int y)
        {
            if ((moveList.Count == 0) || (board[x, y] as Pawn == null))
                return false;

            ChessMove recentMove = moveList[moveList.Count - 1];

            bool wasLastMoveToPieceLocation = recentMove.RankAndFileFinal == new Point(x, y);
            bool wasLastMoveTaggedDoublePawnMove = recentMove.Tag == ChessMoveTag.DoublePawnMove;

            return wasLastMoveToPieceLocation && wasLastMoveTaggedDoublePawnMove;
        }
        public bool checkIfPieceAtPointCanBeEnPassanted(Point point)
        {
            //check if enpassant eating is possible
            if (!isMostRecentMoveDoublePawnMoveToPoint(point.X, point.Y))
                return false;

            Colors elligiblePieceColor = board[point.X, point.Y].Color;

            //check if directly adjacent (left) meets requirements
            if (verifyLocationInBoundsAndContainsPawnOfRequestedColor(point.X - 1, point.Y, getOppositeColor(elligiblePieceColor)))
                return true;

            //check if directly adjacent (right) meets requirements
            if (verifyLocationInBoundsAndContainsPawnOfRequestedColor(point.X + 1, point.Y, getOppositeColor(elligiblePieceColor)))
                return true;

            return false;
        }
        private bool doesScreenshotContainEnPassantAbility()
        {
            if (moveList.Count == 0)
                return false;
            ChessMove move = moveList[moveList.Count - 1];

            bool isDoublePawnMove = (move.Tag == ChessMoveTag.DoublePawnMove);
            bool isRightColor = (move.MovingPiece.Color == getCurrentTurnColor());
            if (!(isDoublePawnMove && isRightColor))
                return false;

            return checkIfPieceAtPointCanBeEnPassanted(move.RankAndFileFinal);
        }
        public void RecievePromotionPieceTypeFromUI(PieceType type)
        {
            Colors curColor = getCurrentTurnColor();
            ChessPiece PromotedPiece = null;
            switch (type)
            {
                case PieceType.Queen:
                    PromotedPiece = new Queen(curColor);
                    break;
                case PieceType.Bishop:
                    PromotedPiece = new Bishop(curColor);
                    break;
                case PieceType.Knight:
                    PromotedPiece = new Knight(curColor);
                    break;
                case PieceType.Rook:
                    PromotedPiece = new Rook(curColor, RookTag.PromotedPawn);
                    break;
            }

            currentPiece = PromotedPiece; //update current piece for main move function
            board[curX, curY] = PromotedPiece;
            collectionsOfPiecesOnBoard[(int)curColor][new Point(curX, curY)] = PromotedPiece;

            MoveBeingBuilt.PromotedTo = Enum.GetName(typeof(PieceType), type)[0] + "";
            Point currentLocation = ConvertIndicesToLocation(curX, curY);
            UIForm.ChangePiece(currentLocation.X, currentLocation.Y, type, curColor);
        }
        private bool verifyLocationInBoundsAndContainsPawnOfRequestedColor(int x, int y, Colors color)
        {
            if (!ChessUtilities.isIndexInBounds(x, y))
                return false;
            ChessPiece piece = board[x, y];
            if (piece == null)
                return false;
            return (piece.Type == PieceType.Pawn) && (piece.Color == color);
        }

        private bool tryAllPossibleRookMoves(int currX, int currY)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i == currX)
                    continue;
                ChessMove throwAwayMove = null;
                try
                {
                    checkGeneralLegalityOfMove(board[currX, currY], currX, currY, i, currY, out Point _, ref throwAwayMove);
                }
                catch
                {
                    continue;
                }
                return true;
            }

            for (int i = 0; i < 8; i++)
            {
                if (i == currY)
                    continue;
                ChessMove throwAwayMove = null;
                try
                {
                    checkGeneralLegalityOfMove(board[currX, currY], currX, currY, currX, i, out Point _, ref throwAwayMove);
                }
                catch
                {
                    continue;
                }
                return true;
            }
            return false;
        }
        private void tryRookMoving(int curXIndex, int curYIndex, int finXIndex, int finYIndex)
        {
            if (!rookMovingLogic(curXIndex, curYIndex, finXIndex, finYIndex))
                throw RookException.GetExWithMessage();
        }
        private bool rookMovingLogic(int curXIndex, int curYIndex, int finXIndex, int finYIndex)
        {
            if (!((curXIndex == finXIndex) || (curYIndex == finYIndex)))
                return false;
            return true;
        }


        private void checkIfThereIsPieceOnTheWayToFinalDestination(int curXIndex, int curYIndex, int finXIndex, int finYIndex)
        {
            bool moveAlongRank = curYIndex == finYIndex;
            bool moveAlongFile = curXIndex == finXIndex;

            if (moveAlongRank) //lateral move along rank
            {
                if (!ChessUtilities.isRankClear(board, curYIndex, curXIndex, finXIndex))
                    throw new YouCannotPassThroughAPieceException();
                return;
            }
            if (moveAlongFile) //lateral move along file
            {
                if (!ChessUtilities.isFileClear(board, curXIndex, curYIndex, finYIndex))
                    throw new YouCannotPassThroughAPieceException();
                return;
            }

            if (!bishopMovingLogic(curXIndex, curYIndex, finXIndex, finYIndex))// if not a legal diagonal...
                throw new IllegalMoveException("");

            if (!ChessUtilities.isDiagonalClear(board, curXIndex, curYIndex, finXIndex, finYIndex))
                throw new YouCannotPassThroughAPieceException();
        }

    }

    enum InsufficientMaterialTag { King = 0, KingAndKnight, KingAndBishopsDark, KingAndBishopsLight, Sufficient = 10 }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess___netanel
{
    class PawnException : IllegalMoveException
    {
        public static PawnException GetExWithMessage()
        {
            return new PawnException("Illegal pawn move!");
        }
        public PawnException(string message) : base(message)
        {

        }
    }
    class PawnCanOnlyGoForwardsException : PawnException
    {
        public static new PawnCanOnlyGoForwardsException GetExWithMessage()
        {
            return new PawnCanOnlyGoForwardsException("Pawn can only go forwards!");
        }
        public PawnCanOnlyGoForwardsException(string message) : base(message)
        {

        }
    }
    class PawnCannotEatLaterallyException : PawnException
    {
        public static new PawnCannotEatLaterallyException GetExWithMessage()
        {
            return new PawnCannotEatLaterallyException("Pawn cannot eat laterally!");
        }
        public PawnCannotEatLaterallyException(string message) : base(message) { }
    }
    class Pawn_OnlyFirstMoveCanBeDoubleException : PawnException
    {
        public static new Pawn_OnlyFirstMoveCanBeDoubleException GetExWithMessage()
        {
            return new Pawn_OnlyFirstMoveCanBeDoubleException("Pawn can only skip a square on the first move!");
        }
        public Pawn_OnlyFirstMoveCanBeDoubleException(string message) : base(message) { }

    }
    class PawnCannotMoveMoreThan2SquaresAtAnyTimeException : PawnException
    {

        public static new PawnCannotMoveMoreThan2SquaresAtAnyTimeException GetExWithMessage()
        {
            return new PawnCannotMoveMoreThan2SquaresAtAnyTimeException("Pawn cannot move more than 2 squares at any time!");
        }
        public PawnCannotMoveMoreThan2SquaresAtAnyTimeException(string message) : base(message) { }
    }

    class KnightException : IllegalMoveException
    {
        public static KnightException GetExWithMessage()
        {
            return new KnightException("Illegal knight move!");
        }
        public KnightException(string message) : base(message)
        {

        }
    }

    class RookException : IllegalMoveException
    {
        public static RookException GetExWithMessage()
        {
            return new RookException("Illegal rook move!");
        }
        public RookException(string message) : base(message)
        {

        }
    }
    class RookHasAlreadyMovedBeforeException : RookException
    {
        public static new RookHasAlreadyMovedBeforeException GetExWithMessage()
        {
            return new RookHasAlreadyMovedBeforeException("Rook has already moved before!");
        }
        public RookHasAlreadyMovedBeforeException(string message) : base(message)
        {

        }
    }

    class QueenException : IllegalMoveException
    {
        public static QueenException GetExWithMessage()
        {
            return new QueenException("Illegal queen move!");
        }
        public QueenException(string message) : base(message)
        {

        }
    }

    class BishopException : IllegalMoveException
    {
        public static BishopException GetExWithMessage()
        {
            return new BishopException("Illegal bishop move!");
        }
        public BishopException(string message) : base(message)
        {

        }
    }

    class KingException : IllegalMoveException
    {
        public static KingException GetExWithMessage()
        {
            return new KingException("Illegal king move!");
        }
        public KingException(string message) : base(message)
        {

        }
    }
    class KingHasAlreadyMovedBeforeException : KingException
    {
        public static new KingHasAlreadyMovedBeforeException GetExWithMessage()
        {
            return new KingHasAlreadyMovedBeforeException("King has already moved before!");
        }
        public KingHasAlreadyMovedBeforeException(string message) : base(message)
        {

        }
    }
    class King_SpacesBetweenRookAndKingNotClearException : KingException
    {
        public static new King_SpacesBetweenRookAndKingNotClearException GetExWithMessage()
        {
            return new King_SpacesBetweenRookAndKingNotClearException("Cannot castle with pieces between rook and king!");
        }
        public King_SpacesBetweenRookAndKingNotClearException(string message) : base(message)
        {

        }
    }
    class KingCheckedException : KingException
    {
        public static new KingCheckedException GetExWithMessage()
        {
            return new KingCheckedException("King in check!");
        }
        public KingCheckedException(string message) : base(message)
        {

        }
    }
    class KingCannotCastleInCheckException : KingCheckedException
    {
        public static new KingCannotCastleInCheckException GetExWithMessage()
        {
            return new KingCannotCastleInCheckException("King cannot castle while in check!");
        }
        public KingCannotCastleInCheckException(string message) : base(message)
        {

        }
    }
    class King_CannotExposeOrKeepKingInCheckException : KingException
    {
        public static new King_CannotExposeOrKeepKingInCheckException GetExWithMessage()
        {
            return new King_CannotExposeOrKeepKingInCheckException("You cannot expose or keep king in check!");
        }
        public King_CannotExposeOrKeepKingInCheckException(string message) : base(message)
        {

        }
    }
    class KingCannotBeExposedWhileCastlingException : KingException
    {
        public static new KingCannotBeExposedWhileCastlingException GetExWithMessage()
        {
            return new KingCannotBeExposedWhileCastlingException("King cannot be exposed at all while castling!");
        }
        public KingCannotBeExposedWhileCastlingException(string message) : base(message)
        {

        }
    }


    //general exceptions
    class YouCannotOverrideYourOwnPieceException : Exception
    {
        /*public YouCannotOverrideYourOwnPieceException(string message) : base(message) { } */

    }
    class NotYourTurnException : Exception
    {
        /* public NotYourTurnException(string message) : base(message) { } */
    }
    class YouCannotPassThroughAPieceException : Exception
    {

    }
    class IllegalMoveException : Exception
    {
        public IllegalMoveException(string message) : base(message)
        {

        }
    }
}

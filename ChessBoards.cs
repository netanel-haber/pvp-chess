using System.Drawing;

namespace Chess___netanel
{
    static class ChessBoards
    {
        static ChessPiece[,] board;

        public static ChessPiece[,] GetStandardBoard(out Point[] kingLocations)
        {
            kingLocations = new Point[2];
            board = new ChessPiece[8, 8];

            //init black pieces
            board[0, 0] = new Rook(Colors.Black, RookTag.QueenSideRook);
            board[1, 0] = new Knight(Colors.Black);
            board[2, 0] = new Bishop(Colors.Black);
            (board[2, 0] as Bishop).isDarkColor = false;
            board[3, 0] = new Queen(Colors.Black);

            board[5, 0] = new Bishop(Colors.Black);
            (board[5, 0] as Bishop).isDarkColor = true;
            board[6, 0] = new Knight(Colors.Black);
            board[7, 0] = new Rook(Colors.Black, RookTag.KingSideRook);
            for (int i = 0; i < 8; i++)
                board[i, 1] = new Pawn(Colors.Black);

            board[4, 0] = new King(Colors.Black);
            kingLocations[1] = new Point(4, 0);


            //init white pieces

            for (int i = 0; i < 8; i++)
                board[i, 6] = new Pawn(Colors.White);

            board[0, 7] = new Rook(Colors.White, RookTag.QueenSideRook);
            board[1, 7] = new Knight(Colors.White);
            board[2, 7] = new Bishop(Colors.White);
            (board[2, 7] as Bishop).isDarkColor = true;
            board[3, 7] = new Queen(Colors.White);
            board[5, 7] = new Bishop(Colors.White);
            (board[5, 7] as Bishop).isDarkColor = false;
            board[6, 7] = new Knight(Colors.White);
            board[7, 7] = new Rook(Colors.White, RookTag.KingSideRook);

            board[4, 7] = new King(Colors.White);
            kingLocations[0] = new Point(4, 7);

            return board;
        }

        public static ChessPiece[,] EdgeCase_EnPassantOnlyWayOutOfEdgeCase(out Point[] kingLocations)
        {
            kingLocations = new Point[2];
            board = new ChessPiece[8, 8];

            board[5, 0] = new King(Colors.Black);
            board[0, 1] = new Pawn(Colors.Black);
            board[1, 2] = new Pawn(Colors.Black);
            board[5, 4] = new Rook(Colors.Black, RookTag.KingSideRook);
            board[5, 0] = new King(Colors.Black);
            kingLocations[1] = new Point(5, 0);


            board[0, 5] = new Pawn(Colors.White);
            board[1, 5] = new Pawn(Colors.White);
            board[1, 3] = new Pawn(Colors.White);
            board[1, 7] = new Pawn(Colors.White);
            board[1, 4] = new Knight(Colors.White);
            board[0, 4] = new King(Colors.White);
            kingLocations[0] = new Point(0, 4);

            return board;
        }

        /*
        public static ChessPiece[,] template(out Point[] kingLocations)
        {        
            kingLocations = new Point[2];
            board = new ChessPiece[8, 8];
            /////////////// Body ///////////////////
            return board;
        } 
        */


        /*       public static ChessPiece[,] template(out Point[] kingLocations, int[,] boardScreenShot)
               {        
                   kingLocations = new Point[2];
                   board = new ChessPiece[8, 8];

                   for (int i = 0; i < 8; i++)
                   {
                       for (int j = 0; j < 8; j++)
                       {
                           int temp = boardScreenShot[i, j];
                           Colors tempColor = (temp % 19 == 0) ? Colors.Black : Colors.White;
                           PieceType tempType;

                           int tempResult = (temp % 19 == 0) ? temp / 19 : temp / 37;

                           switch (tempResult)
                           {
                               case 1:
                                   tempType = PieceType.Bishop;
                                   break;
                               case 2:
                                   tempType = PieceType.Pawn;
                                   break;
                               case 3:
                                   tempType = PieceType.King;
                                   break;
                               case 4:
                                   tempType = PieceType.Queen;
                                   break;
                               case 5:
                                   tempType = PieceType.Rook;
                                   break;
                               case 6:
                                   tempType = PieceType.Knight;
                                   break;
                           }


                       }
                   }

                       return board;
               }  
               */

    }
}

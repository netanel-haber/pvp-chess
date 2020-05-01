using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess___netanel
{
    class BoardScreenshot
    {
        public int[,] screenshot;
        public bool rightToCastleKingsideWhite = false;
        public bool rightToCastleQueensideWhite = false;
        public bool rightToCastleQueensideBlack = false;
        public bool rightToCastleKingsideBlack = false;


        public bool rightToEnPassant = false;

        public override int GetHashCode()
        {
            string result = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int temp = screenshot[i, j];
                    result += temp != 0 ? temp + "" : "";
                }
            }
            return result.GetHashCode();
        }

        public static bool CompareCastleRights(BoardScreenshot shot1, BoardScreenshot shot2)
        {
            return (shot1.rightToCastleKingsideWhite == shot2.rightToCastleKingsideWhite)
                && (shot1.rightToCastleQueensideWhite == shot2.rightToCastleQueensideWhite)
                && (shot1.rightToCastleKingsideBlack == shot2.rightToCastleKingsideBlack)
                && (shot1.rightToCastleQueensideBlack == shot2.rightToCastleQueensideBlack);
        }

        public override bool Equals(object obj)
        {
            BoardScreenshot shot = obj as BoardScreenshot;

            if (rightToEnPassant || shot.rightToEnPassant)
                return false;

            return CompareCastleRights(this, shot) && compareTwoBoards(screenshot, shot.screenshot);
        }

        public override string ToString()
        {
            return this.GetHashCode() + "";
        }


        public static bool compareTwoBoards(int[,] board1, int[,] board2)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board1[i, j] != board2[i, j])
                        return false;
                }
            }
            return true;
        }

    }



}

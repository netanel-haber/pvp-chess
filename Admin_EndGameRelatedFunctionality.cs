using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chess___netanel.ChessUtilities;

namespace Chess___netanel
{
    partial class Admin
    {
        int[] endGameAfterMath = new int[2]; //[0] how the game ended - 0 regular ending | 1 draw | 2 for win on time | 3 for resignation 
                                             //[1] losing color - 1 for white | 2 for black


        //these three functions are triggered by UI button events.
        public void DrawRequested()
        {
            didBlackRequestDraw = blackTimer.Enabled;
            UIForm.ToggleVisibilityDrawRequestPanel(didBlackRequestDraw ? "White" : "Black");
        }

        public void fiftyMoveRuleEndgame()
        {
            endGameAfterMath[0] = 1;
            gameEndsOnDraw("---Draw: 50 move repetition rule---");
        }
        public void GameEndsOnResign()
        {
            bool blackResigned = blackTimer.Enabled;
            string resignMessage;
            resignMessage = (blackResigned ? "Black" : "White") + " Resigned!";
            endGameAfterMath[0] = 3; // resignation
            endGameAfterMath[1] = blackResigned ? 2 : 1; // 2 black lost, 1 white lost              
            sendEndGameToUI(resignMessage);
        }
        public void DrawAccepted()
        {
            gameEndsOnDraw("draw - requested by " + (didBlackRequestDraw ? "Black" : "White"));
        }


        private void gameEndsOnCheckMate(Colors loser)
        {
            endGameAfterMath[0] = 0; //checkmate
            endGameAfterMath[1] = (loser == Colors.Black) ? 2 : 1;

            string losermessage = ((loser == Colors.Black) ? "Black" : "White") + " lost - checkmate!";
            sendEndGameToUI(losermessage);
        }


        private void gameEndsOnTime(Colors loser)
        {
            InsufficientMaterialTag timeWinnerMaterial = calculateMaterialForOneSide(collectionsOfPiecesOnBoard[(int)getOppositeColor(loser)]);

            bool isTimeWinnerInsuf = 
                (timeWinnerMaterial != InsufficientMaterialTag.Sufficient)
                &&
                ((timeWinnerMaterial == InsufficientMaterialTag.King)
                ||
                (timeWinnerMaterial == calculateMaterialForOneSide(collectionsOfPiecesOnBoard[(int)loser])));

            if (isTimeWinnerInsuf)
            {
                gameEndsOnDraw("---Draw: Out of time vs. insufficient material---");
                return;
            }

            string losermessage = ((loser == Colors.Black) ? "Black" : "White") + " lost on time!";
            endGameAfterMath[1] = (loser == Colors.Black) ? 2 : 1;
            sendEndGameToUI(losermessage);
        }
        private void gameEndsOnDraw(string message)
        {
            endGameAfterMath[0] = 1;
            sendEndGameToUI(message);
        }

        private void staleMateEndGame()
        {
            endGameAfterMath[0] = 1;
            sendEndGameToUI("---Draw: stalemate---");
        }


        private void threeRepetitionRuleEndGame()
        {
            endGameAfterMath[0] = 1;
            sendEndGameToUI("---Draw: 3 move repetition rule---");
        }

        private void insufficientMaterialEndgame()
        {
            endGameAfterMath[0] = 1;
            sendEndGameToUI("---Draw: Insufficient material---");
        }

        private void sendEndGameToUI(string message)
        {
            StopTheClocksExclemationPoint();
            Invocation2 delg = UIForm.TriggerEndGameForm;
            string result = "";

            bool whiteLost = endGameAfterMath[1] == 1;


            string losingColor = whiteLost ? "White" : "Black";

            switch (endGameAfterMath[0])
            {
                case 1: //game ends on draw
                    result += "1/2-1/2";
                    break;
                case 2: //game ends on time

                    break;
                case 3: //game ends on resignation
                    result += losingColor + " " + "resigned. " + (whiteLost ? "0:1" : "1:0");
                    break;
                case 0: //check mate
                    result += "# " + (whiteLost ? "0:1" : "1:0");
                    break;
            }

            moveList.Add(new ChessMove { IsEndGameInfo = true, EndGameInfo = result });

            UIForm.Invoke(delg, new EndGamePackage { Message = message, MoveList = moveListToString() });
        }

        private string moveListToString()
        {
            string result = "";
            int iterator = 1;

            for (int i = 0; i < moveList.Count; i += 2)
            {
                result += iterator + "." + " " + moveList[i].ToString();
                if ((i + 1) < moveList.Count)
                    result += "  " + moveList[i + 1].ToString();
                result += "\r\n";
                iterator++;
            }
            return result;
        }
    }

    delegate void Invocation2(EndGamePackage pack);
}

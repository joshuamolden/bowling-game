using System;
using System.Collections.Generic;

namespace BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            BowlingScore score = new BowlingScore();

            for (int frameNumber = 1; frameNumber <= 9; frameNumber++)
            {
                GameMessages.FrameNumber(frameNumber);
                GameMessages.InstructionsBeforeEachRoll(frameNumber, "1st", score);

                int pinsKnockedDownOnFirstRoll = score.Roll();

                // Alert user what they rolled
                if (pinsKnockedDownOnFirstRoll == 10)
                {
                    GameMessages.StrikeMessage();
                    score.RecordFrame(pinsKnockedDownOnFirstRoll);
                    continue;
                }
                else
                {
                    GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnFirstRoll, "first");
                }

                // Instructions for second bowl of frame
                GameMessages.InstructionsBeforeEachRoll(frameNumber, "2nd", score);

                // Roll second bowl
                int pinsKnockedDownOnSecondRoll = score.Roll(pinsKnockedDownOnFirstRoll);
                score.RecordFrame(pinsKnockedDownOnFirstRoll, pinsKnockedDownOnSecondRoll);

                if (pinsKnockedDownOnFirstRoll + pinsKnockedDownOnSecondRoll == 10)
                {
                    GameMessages.SpareMessage();
                    continue;
                }
                else
                {
                    GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnSecondRoll, "second");

                }
            }

            GameMessages.FrameNumber(10);
            GameMessages.InstructionsBeforeEachRoll(10, "1st", score);

            int pinsKnockedDownOnFirstRollOfLastFrame = score.Roll();

            // Alert user what they rolled
            if (pinsKnockedDownOnFirstRollOfLastFrame == 10)
            {
                GameMessages.StrikeMessage();
                GameMessages.InstructionsBeforeEachRoll(10, "2nd", score);

                int pinsKnockedDownOnSecondRollOfLastFrameAfterStrike = score.Roll();

                if (pinsKnockedDownOnSecondRollOfLastFrameAfterStrike == 10)
                {
                    GameMessages.StrikeMessage();
                    GameMessages.InstructionsBeforeEachRoll(10, "3rd", score);

                    int pinsKnockedDownOnTirdRollOfLastFrameDoubleStrike = score.Roll();

                    if (pinsKnockedDownOnTirdRollOfLastFrameDoubleStrike == 10)
                    {
                        GameMessages.StrikeMessage();
                    }
                    else
                    {
                        GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnTirdRollOfLastFrameDoubleStrike, "third");
                    }

                    score.RecordFrame(pinsKnockedDownOnFirstRollOfLastFrame, pinsKnockedDownOnSecondRollOfLastFrameAfterStrike, pinsKnockedDownOnTirdRollOfLastFrameDoubleStrike);
                }
                else
                {
                    GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnSecondRollOfLastFrameAfterStrike, "second");
                    GameMessages.InstructionsBeforeEachRoll(10, "3rd", score);

                    int pinsKnockedDownOnLastRollOfTenthFrame = score.Roll(pinsKnockedDownOnSecondRollOfLastFrameAfterStrike);
                    GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnSecondRollOfLastFrameAfterStrike, "third");

                    score.RecordFrame(pinsKnockedDownOnFirstRollOfLastFrame, pinsKnockedDownOnSecondRollOfLastFrameAfterStrike, pinsKnockedDownOnLastRollOfTenthFrame);
                }
            }
            else
            {
                GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnFirstRollOfLastFrame, "first");
                GameMessages.InstructionsBeforeEachRoll(10, "2nd", score);

                int pinsKnockedDownonSecondRollofLastFrame = score.Roll(pinsKnockedDownOnFirstRollOfLastFrame);

                if (pinsKnockedDownOnFirstRollOfLastFrame + pinsKnockedDownonSecondRollofLastFrame == 10)
                {
                    GameMessages.SpareMessage();
                    GameMessages.InstructionsBeforeEachRoll(10, "3rd", score);

                    int pinsKnockedDownOnLastFrameAfterSpare = score.Roll();

                    GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnLastFrameAfterSpare, "third");
                    score.RecordFrame(pinsKnockedDownOnFirstRollOfLastFrame, pinsKnockedDownonSecondRollofLastFrame, pinsKnockedDownOnLastFrameAfterSpare);
                }
                else
                {
                    GameMessages.PinsKnockedDownMessage(pinsKnockedDownonSecondRollofLastFrame, "second");
                    score.RecordFrame(pinsKnockedDownOnFirstRollOfLastFrame, pinsKnockedDownonSecondRollofLastFrame);
                }

            }

            GameMessages.EndingScoreMessage(score);
        }
    }
}

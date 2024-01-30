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

                score.CalculateScore(pinsKnockedDownOnFirstRoll);

                // Alert user what they rolled
                if (pinsKnockedDownOnFirstRoll == 10)
                {
                    GameMessages.StrikeMessage();
                    score.AddStrikeBonus();
                    continue;
                }
                else
                {
                    GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnFirstRoll, "first");
                }

                GameMessages.InstructionsBeforeEachRoll(frameNumber, "2nd", score);

                int pinsKnockedDownOnSecondRoll = score.Roll(pinsKnockedDownOnFirstRoll);

                score.CalculateScore(pinsKnockedDownOnFirstRoll, pinsKnockedDownOnSecondRoll);

                if (pinsKnockedDownOnFirstRoll + pinsKnockedDownOnSecondRoll == 10)
                {
                    GameMessages.SpareMessage();
                    score.AddSpareBonus(pinsKnockedDownOnFirstRoll);
                    score.AddSpareBonus(pinsKnockedDownOnSecondRoll);
                    continue;
                }
                else
                {
                    GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnSecondRoll, "second");
                    score.RecordFrame(pinsKnockedDownOnFirstRoll, pinsKnockedDownOnSecondRoll);
                }
            }

            GameMessages.FrameNumber(10);
            GameMessages.InstructionsBeforeEachRoll(10, "1st", score);

            int pinsKnockedDownOnFirstRollOfLastFrame = score.Roll();

            // Alert user what they rolled
            if (pinsKnockedDownOnFirstRollOfLastFrame == 10)
            {
                GameMessages.StrikeMessage();
                score.CalculateScore(pinsKnockedDownOnFirstRollOfLastFrame);
                score.AddStrikeBonus();

                GameMessages.InstructionsBeforeEachRoll(10, "2nd", score);

                int pinsKnockedDownOnSecondRollOfLastFrameAfterStrike = score.Roll();

                if (pinsKnockedDownOnSecondRollOfLastFrameAfterStrike == 10)
                {
                    GameMessages.StrikeMessage();
                    score.CalculateScore(pinsKnockedDownOnSecondRollOfLastFrameAfterStrike);
                    GameMessages.InstructionsBeforeEachRoll(10, "3rd", score);

                    int pinsKnockedDownOnTirdRollOfLastFrameDoubleStrike = score.Roll();

                    if (pinsKnockedDownOnTirdRollOfLastFrameDoubleStrike == 10)
                    {
                        GameMessages.StrikeMessage();
                        score.CalculateScore(pinsKnockedDownOnTirdRollOfLastFrameDoubleStrike);
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
                    score.CalculateScore(pinsKnockedDownOnSecondRollOfLastFrameAfterStrike);
                    GameMessages.InstructionsBeforeEachRoll(10, "3rd", score);

                    int pinsKnockedDownOnLastRollOfTenthFrame = score.Roll(pinsKnockedDownOnSecondRollOfLastFrameAfterStrike);
                    GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnSecondRollOfLastFrameAfterStrike, "third");

                    score.RecordFrame(pinsKnockedDownOnFirstRollOfLastFrame, pinsKnockedDownOnSecondRollOfLastFrameAfterStrike, pinsKnockedDownOnLastRollOfTenthFrame);
                }
            }
            else
            {
                GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnFirstRollOfLastFrame, "first");
                score.CalculateScore(pinsKnockedDownOnFirstRollOfLastFrame);
                GameMessages.InstructionsBeforeEachRoll(10, "2nd", score);

                int pinsKnockedDownonSecondRollofLastFrame = score.Roll(pinsKnockedDownOnFirstRollOfLastFrame);

                if (pinsKnockedDownOnFirstRollOfLastFrame + pinsKnockedDownonSecondRollofLastFrame == 10)
                {
                    GameMessages.SpareMessage();
                    score.CalculateScore(pinsKnockedDownOnFirstRollOfLastFrame, pinsKnockedDownonSecondRollofLastFrame);
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

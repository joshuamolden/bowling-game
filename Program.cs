using System;
using System.Collections.Generic;

namespace BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int MAX_PINS_PER_FRAME = 10;
            Random randNumOfPinsKnockedDown = new Random();
            int Roll(int pinsKnockedDownOnFirstRoll = 0)
            {
                return randNumOfPinsKnockedDown.Next(MAX_PINS_PER_FRAME + 1 - pinsKnockedDownOnFirstRoll);
            }

            BowlingScore score = new BowlingScore();

            for (int frameNumber = 1; frameNumber <= 9; frameNumber++)
            {
                GameMessages.FrameNumber(frameNumber);
                GameMessages.InstructionsBeforeEachRoll(frameNumber, "1st", score);

                int pinsKnockedDownOnFirstRoll = Roll();

                score.CalculateScore(pinsKnockedDownOnFirstRoll);

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

                int pinsKnockedDownOnSecondRoll = Roll(pinsKnockedDownOnFirstRoll);

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

            int pinsKnockedDownOnFirstRollOfLastFrame = Roll();

            if (pinsKnockedDownOnFirstRollOfLastFrame == 10)
            {
                GameMessages.StrikeMessage();
                score.CalculateScore(pinsKnockedDownOnFirstRollOfLastFrame);
                score.AddStrikeBonus();

                GameMessages.InstructionsBeforeEachRoll(10, "2nd", score);

                int pinsKnockedDownOnSecondRollOfLastFrameAfterStrike = Roll();

                if (pinsKnockedDownOnSecondRollOfLastFrameAfterStrike == 10)
                {
                    GameMessages.StrikeMessage();
                    score.CalculateScore(pinsKnockedDownOnSecondRollOfLastFrameAfterStrike);
                    GameMessages.InstructionsBeforeEachRoll(10, "3rd", score);

                    int pinsKnockedDownOnTirdRollOfLastFrameDoubleStrike = Roll();

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

                    int pinsKnockedDownOnLastRollOfTenthFrame = Roll(pinsKnockedDownOnSecondRollOfLastFrameAfterStrike);
                    GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnLastRollOfTenthFrame, "third");

                    score.RecordFrame(pinsKnockedDownOnFirstRollOfLastFrame, pinsKnockedDownOnSecondRollOfLastFrameAfterStrike, pinsKnockedDownOnLastRollOfTenthFrame);
                }
            }
            else
            {
                GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnFirstRollOfLastFrame, "first");
                score.CalculateScore(pinsKnockedDownOnFirstRollOfLastFrame);
                GameMessages.InstructionsBeforeEachRoll(10, "2nd", score);

                int pinsKnockedDownonSecondRollofLastFrame = Roll(pinsKnockedDownOnFirstRollOfLastFrame);

                if (pinsKnockedDownOnFirstRollOfLastFrame + pinsKnockedDownonSecondRollofLastFrame == 10)
                {
                    GameMessages.SpareMessage();
                    score.CalculateScore(pinsKnockedDownOnFirstRollOfLastFrame, pinsKnockedDownonSecondRollofLastFrame);
                    GameMessages.InstructionsBeforeEachRoll(10, "3rd", score);

                    int pinsKnockedDownOnLastFrameAfterSpare = Roll();

                    GameMessages.PinsKnockedDownMessage(pinsKnockedDownOnLastFrameAfterSpare, "third");
                    score.RecordFrame(pinsKnockedDownOnFirstRollOfLastFrame, pinsKnockedDownonSecondRollofLastFrame, pinsKnockedDownOnLastFrameAfterSpare);
                }
                else
                {
                    GameMessages.PinsKnockedDownMessage(pinsKnockedDownonSecondRollofLastFrame, "second");
                    score.CalculateScore(pinsKnockedDownOnFirstRollOfLastFrame, pinsKnockedDownonSecondRollofLastFrame);
                    score.RecordFrame(pinsKnockedDownOnFirstRollOfLastFrame, pinsKnockedDownonSecondRollofLastFrame);
                }
            }

            GameMessages.EndingScoreMessage(score);
        }
    }
}

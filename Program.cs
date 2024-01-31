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
                Frame currentFrame = new Frame(frameNumber);
                currentFrame.FirstRoll(score);

                if (currentFrame.IsStrike)
                {
                    continue;
                }
                else
                {
                    currentFrame.SecondRoll(score);
                }
            }

            TenthFrame lastFrame = new TenthFrame();

            lastFrame.FirstRoll(score);
            lastFrame.SecondRoll(score);
            if (lastFrame.HasBonusRoll)
            {
                lastFrame.BonusRoll(score);
            }

            GameMessages.EndingScoreMessage(score);
        }
    }
}

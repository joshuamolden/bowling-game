using System;

public class BowlingScore : IBowlingScore
{
    private int MAX_PINS_PER_FRAME = 10;
    private Random randNumOfPinsKnockedDown = new Random();

    private int[] rolls = new int[21];
    private int currentRoll = 0;

    public void RecordFrame(params int[] pinsKnockedDown)
    {
        for (var index = 0; index < pinsKnockedDown.Length; index++)
        {
            rolls[currentRoll++] = pinsKnockedDown[index];
        }
    }

    public int DisplayScore
    {
        get
        {
            var score = 0;
            var rollIndex = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    score += GetBonusScore(rollIndex);
                    rollIndex++;
                }
                else if (IsSpare(rollIndex))
                {
                    score += GetBonusScore(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += GetStandardScore(rollIndex);
                    rollIndex += 2;
                }
            }
            return score;
        }
    }

    public int Roll(int pinsKnockedDownOnFirstRoll = 0)
    {
        return randNumOfPinsKnockedDown.Next(MAX_PINS_PER_FRAME + 1 - pinsKnockedDownOnFirstRoll);
    }

    private bool IsSpare(int rollIndex)
    {
        return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
    }

    private bool IsStrike(int rollIndex)
    {
        return rolls[rollIndex] == 10;
    }

    private int GetStandardScore(int rollIndex)
    {
        return rolls[rollIndex] + rolls[rollIndex + 1];
    }

    private int GetBonusScore(int rollIndex)
    {
        return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
    }

}
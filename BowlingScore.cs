using System;
using System.Linq;
using System.Collections.Generic;
using BowlingGame;

public class BowlingScore : IBowlingScore
{
    private int MAX_PINS_PER_FRAME = 10;
    private Random randNumOfPinsKnockedDown = new Random();
    private int score = 0;
    private List<int> spareBonus = new List<int>();
    private List<int> strikeBonus = new List<int>();
    private int numOfTimesCalled = 1;

    public void RecordFrame(params int[] pinsKnockedDown)
    {
        this.score += pinsKnockedDown.Sum();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Number of Times RecordFrame has been called:\t{numOfTimesCalled++}\n");
        Console.ResetColor();
    }

    public void CalculateScore(int pinsKnockedDownOnFirstRoll, int pinsKnockedDownOnSecondRoll = -1)
    {
        if (spareBonus.Count == 2)
        {
            int[] spareBonusToAray = spareBonus.ToArray();
            this.RecordFrame(spareBonusToAray[0], spareBonusToAray[1], pinsKnockedDownOnFirstRoll);
            spareBonus.Clear();
        }
        else if (strikeBonus.Count == 2)
        {
            int[] strikeBonusToArray = strikeBonus.ToArray();
            this.RecordFrame(strikeBonusToArray[0], strikeBonusToArray[1], pinsKnockedDownOnFirstRoll);
            strikeBonus.Clear();
            strikeBonus.Add(10);
        }
        else if (strikeBonus.Count == 1 && pinsKnockedDownOnSecondRoll != -1)
        {
            int[] strikeBonusToArray = strikeBonus.ToArray();
            this.RecordFrame(strikeBonusToArray[0], pinsKnockedDownOnFirstRoll, pinsKnockedDownOnSecondRoll);
            strikeBonus.Clear();
        }
    }

    public int Roll(int pinsKnockedDownOnFirstRoll = 0)
    {
        // return randNumOfPinsKnockedDown.Next(MAX_PINS_PER_FRAME + 1 - pinsKnockedDownOnFirstRoll);
        return 5;
    }

    public void AddStrikeBonus()
    {
        strikeBonus.Add(10);
    }

    public void AddSpareBonus(int pins)
    {
        spareBonus.Add(pins);
    }

    public int DisplayScore
    {
        get
        {
            return this.score;
        }
    }
}
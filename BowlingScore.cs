using System;
using System.Linq;
using BowlingGame;

public class BowlingScore : IBowlingScore
{
    private int score = 0;
    List<int> spareBonus = new List<int>();
    List<int> strikeBonus = new List<int>();

    public void RecordFrame(params int[] pinsKnockedDown)
    {
        this.score += pinsKnockedDown.Sum();
    }

    public void CalculateScore()
    {
        if (spareBonus.Count == 2)
        {
            int[] spareBonusToAray = spareBonus.ToArray();
            score.RecordFrame(new int[] { spareBonusToAray[0], spareBonusToAray[1], firstRoll });
            spareBonus.Clear();
        }
        else if (strikeBonus.Count == 2)
        {
            int[] strikeBonusToArray = strikeBonus.ToArray();
            score.RecordFrame(new int[] { strikeBonusToArray[0], strikeBonusToArray[1], firstRoll });
            strikeBonus.Clear();
            strikeBonus.Add(10);
        }
        else if (strikeBonus.Count == 1)
        {
            int[] strikeBonusToArray = strikeBonus.ToArray();
            score.RecordFrame(new int[] { strikeBonusToArray[0], firstRoll, secondRoll });
            strikeBonus.Clear();
        }
    }

    public void AddStrikeBonus()
    {
        strikeBonus.Add(10);
    }

    public void AddSpareBonus(int pins)
    {
        spareBonus.Add(pins)
    }

    public int DisplayScore
    {
        get
        {
            return this.score;
        }
    }
}
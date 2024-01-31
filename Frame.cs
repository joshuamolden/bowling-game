using System;

public class Frame
{
    private int MAX_PINS_PER_FRAME = 10;
    private Random randNumOfPinsKnockedDown = new Random();

    private int frameNumber;
    private int pinsKnockedDownOnFistRoll;
    private int pinsKnockedDownOnSecondRoll;
    private bool isStrike = false;


    public Frame(int frameNumber)
    {
        this.frameNumber = frameNumber;
    }

    public bool IsStrike { get { return this.isStrike; } }

    public void FirstRoll(BowlingScore score)
    {
        GameMessages.FrameNumber(this.frameNumber);
        GameMessages.InstructionsBeforeEachRoll(this.frameNumber, "1st", score);

        this.pinsKnockedDownOnFistRoll = this.randNumOfPinsKnockedDown.Next(this.MAX_PINS_PER_FRAME + 1);

        if (this.pinsKnockedDownOnFistRoll == 10)
        {
            score.CalculateScoreOfPastFrame(this.pinsKnockedDownOnFistRoll);
            GameMessages.StrikeMessage();
            score.AddStrikeBonus();
            this.isStrike = true;
        }
        else
        {
            GameMessages.PinsKnockedDownMessage(this.pinsKnockedDownOnFistRoll, "first");
            score.CalculateScoreOfPastFrame(this.pinsKnockedDownOnFistRoll);

        }
    }

    public void SecondRoll(BowlingScore score)
    {
        try
        {
            if (!this.isStrike)
            {
                GameMessages.InstructionsBeforeEachRoll(this.frameNumber, "2nd", score);

                this.pinsKnockedDownOnSecondRoll = this.randNumOfPinsKnockedDown.Next(this.MAX_PINS_PER_FRAME + 1 - this.pinsKnockedDownOnFistRoll);

                if (this.pinsKnockedDownOnFistRoll + this.pinsKnockedDownOnSecondRoll == 10)
                {
                    score.CalculateScoreOfPastFrame(this.pinsKnockedDownOnFistRoll, this.pinsKnockedDownOnSecondRoll);
                    GameMessages.SpareMessage();
                    score.AddSpareBonus(this.pinsKnockedDownOnFistRoll);
                    score.AddSpareBonus(this.pinsKnockedDownOnSecondRoll);
                }
                else
                {
                    GameMessages.PinsKnockedDownMessage(this.pinsKnockedDownOnSecondRoll, "second");
                    score.CalculateScoreOfPastFrame(this.pinsKnockedDownOnFistRoll, this.pinsKnockedDownOnSecondRoll);
                    score.RecordFrame(this.pinsKnockedDownOnFistRoll, this.pinsKnockedDownOnSecondRoll);
                }
            }
            else
            {
                throw new InvalidOperationException("You bowled a strike so you do not have another roll this frame.");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Caught InvalidOperationExcpetion: {ex.Message}");
        }
    }
}
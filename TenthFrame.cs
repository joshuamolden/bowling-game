using System;

public class TenthFrame
{
    private int MAX_PINS_PER_FRAME = 10;
    private Random randNumOfPinsKnockedDown = new Random();

    private int frameNumber = 10;
    private int pinsKnockedDownOnFistRoll;
    private int pinsKnockedDownOnSecondRoll;
    private int pinsKnockedDownOnBonusRoll;
    private bool hasBonusRoll = false;

    public bool HasBonusRoll { get { return this.hasBonusRoll; } }

    public void FirstRoll(BowlingScore score)
    {
        GameMessages.FrameNumber(this.frameNumber);
        GameMessages.InstructionsBeforeEachRoll(this.frameNumber, "1st", score);

        this.pinsKnockedDownOnFistRoll = this.randNumOfPinsKnockedDown.Next(this.MAX_PINS_PER_FRAME + 1);

        if (this.pinsKnockedDownOnFistRoll == 10)
        {
            GameMessages.StrikeMessage();
            this.hasBonusRoll = true;
        }
        else
        {
            GameMessages.PinsKnockedDownMessage(this.pinsKnockedDownOnFistRoll, "1st");
        }

        score.CalculateScoreOfPastFrame(this.pinsKnockedDownOnFistRoll);
    }

    public void SecondRoll(BowlingScore score)
    {
        GameMessages.InstructionsBeforeEachRoll(this.frameNumber, "2nd", score);

        if (this.hasBonusRoll)
        {
            this.pinsKnockedDownOnSecondRoll = this.randNumOfPinsKnockedDown.Next(this.MAX_PINS_PER_FRAME + 1);

            if (this.pinsKnockedDownOnSecondRoll == 10)
            {
                GameMessages.StrikeMessage();
            }
            else
            {
                GameMessages.PinsKnockedDownMessage(this.pinsKnockedDownOnSecondRoll, "2nd");
            }

            score.CalculateScoreOfPastFrame(this.pinsKnockedDownOnFistRoll, this.pinsKnockedDownOnSecondRoll);
        }
        else
        {
            this.pinsKnockedDownOnSecondRoll = this.randNumOfPinsKnockedDown.Next(this.MAX_PINS_PER_FRAME + 1 - this.pinsKnockedDownOnFistRoll);

            if (this.pinsKnockedDownOnFistRoll + this.pinsKnockedDownOnSecondRoll == 10)
            {
                GameMessages.SpareMessage();
                score.CalculateScoreOfPastFrame(this.pinsKnockedDownOnFistRoll, this.pinsKnockedDownOnSecondRoll);
                this.hasBonusRoll = true;
            }
            else
            {
                GameMessages.PinsKnockedDownMessage(this.pinsKnockedDownOnSecondRoll, "2nd");
                score.CalculateScoreOfPastFrame(this.pinsKnockedDownOnFistRoll, this.pinsKnockedDownOnSecondRoll);
                score.RecordFrame(this.pinsKnockedDownOnFistRoll, this.pinsKnockedDownOnSecondRoll);
            }
        }
    }

    public void BonusRoll(BowlingScore score)
    {
        try
        {
            if (this.hasBonusRoll)
            {
                GameMessages.InstructionsBeforeEachRoll(frameNumber, "3rd", score);

                this.pinsKnockedDownOnBonusRoll = this.randNumOfPinsKnockedDown.Next(MAX_PINS_PER_FRAME + 1);

                if (this.pinsKnockedDownOnBonusRoll == 10)
                {
                    GameMessages.StrikeMessage();
                }
                else
                {
                    GameMessages.PinsKnockedDownMessage(this.pinsKnockedDownOnBonusRoll, "3rd");
                }

                score.RecordFrame(this.pinsKnockedDownOnFistRoll, this.pinsKnockedDownOnSecondRoll, this.pinsKnockedDownOnBonusRoll);

            }
            else
            {
                throw new InvalidOperationException("You do not have a bonus roll.");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Caught InvalidOperationExcpetion: {ex.Message}");
        }
    }
}
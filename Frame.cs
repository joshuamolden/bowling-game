using System;

public class Frame : BaseFrame
{
    private bool isStrike = false;

    public bool IsStrike { get { return this.isStrike; } }

    public Frame(int frameNumber) : base(frameNumber)
    {
        this.frameNumber = frameNumber;
    }

    public void FirstRoll(BowlingScore score)
    {
        GameMessages.FrameNumber(this.frameNumber);
        int userInputForFirstRoll = GameMessages.InstructionsBeforeEachRoll(this.frameNumber, "1st", score);

        this.pinsKnockedDownOnFistRoll = userInputForFirstRoll == -1 ? this.Roll() : userInputForFirstRoll;

        if (this.pinsKnockedDownOnFistRoll == 10)
        {
            score.CalculateScoreOfPastFrame(this.pinsKnockedDownOnFistRoll);
            GameMessages.StrikeMessage();
            score.AddStrikeBonus();
            this.isStrike = true;
        }
        else
        {
            GameMessages.PinsKnockedDownMessage(this.pinsKnockedDownOnFistRoll, "1st");
            score.CalculateScoreOfPastFrame(this.pinsKnockedDownOnFistRoll);

        }
    }

    public void SecondRoll(BowlingScore score)
    {
        try
        {
            if (!this.isStrike)
            {
                int userInputForSecondRoll = GameMessages.InstructionsBeforeEachRoll(this.frameNumber, "2nd", score);
                int actualNumberOfPinsKnockedDownOnSecondRoll = userInputForSecondRoll == -1 ? this.Roll(this.pinsKnockedDownOnFistRoll) : userInputForSecondRoll;

                this.pinsKnockedDownOnSecondRoll = this.RollScoreAdjuster(this.pinsKnockedDownOnFistRoll, actualNumberOfPinsKnockedDownOnSecondRoll);

                if (this.pinsKnockedDownOnFistRoll + this.pinsKnockedDownOnSecondRoll == 10)
                {
                    score.CalculateScoreOfPastFrame(this.pinsKnockedDownOnFistRoll, this.pinsKnockedDownOnSecondRoll);
                    GameMessages.SpareMessage();
                    score.AddSpareBonus(this.pinsKnockedDownOnFistRoll);
                    score.AddSpareBonus(this.pinsKnockedDownOnSecondRoll);
                }
                else
                {
                    GameMessages.PinsKnockedDownMessage(this.pinsKnockedDownOnSecondRoll, "2nd");
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
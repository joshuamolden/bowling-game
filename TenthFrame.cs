using System;

public class TenthFrame : BaseFrame
{
    private int pinsKnockedDownOnBonusRoll;
    private bool hasBonusRoll = false;

    public bool HasBonusRoll { get { return this.hasBonusRoll; } }

    public TenthFrame(int frameNumber) : base(frameNumber)
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
        int userInputForSecondRoll = GameMessages.InstructionsBeforeEachRoll(this.frameNumber, "2nd", score);

        if (this.hasBonusRoll)
        {
            this.pinsKnockedDownOnSecondRoll = userInputForSecondRoll == -1 ? this.Roll() : userInputForSecondRoll;

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
            int actualNumberOfPinsKnockedDownOnSecondRoll = userInputForSecondRoll == -1 ? this.Roll(this.pinsKnockedDownOnFistRoll) : userInputForSecondRoll;
            this.pinsKnockedDownOnSecondRoll = this.RollScoreAdjuster(this.pinsKnockedDownOnFistRoll, actualNumberOfPinsKnockedDownOnSecondRoll);

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
                int userInputForBonusRoll = GameMessages.InstructionsBeforeEachRoll(frameNumber, "3rd", score);

                if (this.pinsKnockedDownOnSecondRoll == 10)
                {
                    this.pinsKnockedDownOnBonusRoll = userInputForBonusRoll == -1 ? this.Roll() : userInputForBonusRoll;

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
                    int actualNumberOfPinsKnockedDownOnBonusRoll = userInputForBonusRoll == -1 ? this.Roll(this.pinsKnockedDownOnSecondRoll) : userInputForBonusRoll;
                    this.pinsKnockedDownOnBonusRoll = this.RollScoreAdjuster(this.pinsKnockedDownOnSecondRoll, actualNumberOfPinsKnockedDownOnBonusRoll);

                    GameMessages.PinsKnockedDownMessage(this.pinsKnockedDownOnBonusRoll, "3rd");
                    score.RecordFrame(this.pinsKnockedDownOnFistRoll, this.pinsKnockedDownOnSecondRoll, this.pinsKnockedDownOnBonusRoll);
                }

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
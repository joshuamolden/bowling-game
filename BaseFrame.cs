using System;

public class BaseFrame
{
    private int MAX_PINS_PER_FRAME = 10;
    private Random randNumOfPinsKnockedDown = new Random();

    protected int frameNumber;
    protected int pinsKnockedDownOnFistRoll;
    protected int pinsKnockedDownOnSecondRoll;

    public BaseFrame(int frameNumber)
    {
        this.frameNumber = frameNumber;
    }

    protected int Roll(int pinsAlreadyKnockedDown = 0)
    {
        return this.randNumOfPinsKnockedDown.Next(this.MAX_PINS_PER_FRAME + 1 - pinsAlreadyKnockedDown);
    }

    protected int RollScoreAdjuster(int firstRollPinsKnockedDown, int secondRollPinsKnockedDown)
    {
        if (firstRollPinsKnockedDown + secondRollPinsKnockedDown > 10)
        {
            return MAX_PINS_PER_FRAME - firstRollPinsKnockedDown;
        }
        else
        {
            return secondRollPinsKnockedDown;
        }
    }
}
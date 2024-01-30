using System;

public interface IBowlingScore
{
    void RecordFrame(params int[] pinsKnockedDown);

    int DisplayScore { get; }
}

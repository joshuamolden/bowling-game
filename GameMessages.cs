using System;

public static class GameMessages
{
    public static void InstructionsBeforeEachRoll(int frameNumber, string rollNumber, BowlingScore score)
    {
        Console.WriteLine($"Options for proceeding:\n\t1. Press enter to roll {rollNumber} ball in frame number {frameNumber}\n\t2. Press 't' twice to see your current total score\n");

        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            if (Console.ReadKey().Key == ConsoleKey.T)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\nYour current score is:\t{score.DisplayScore}\nPlease press enter to bowl next ball.\n");
                Console.ResetColor();
            }
        }
    }

    public static void FrameNumber(int frameNumber)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"---------- Frame {frameNumber} ----------\n");
        Console.ResetColor();
    }

    public static void StrikeMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You rolled a strike, nice job!\n");
        Console.ResetColor();
    }

    public static void PinsKnockedDownMessage(int pinsKnockedDown, string rollNumber)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"You knocked down {pinsKnockedDown} pin(s) on your {rollNumber} roll.\n");
        Console.ResetColor();
    }

    public static void SpareMessage()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("You rolled a spare, nice job!\n");
        Console.ResetColor();
    }

    public static void EndingScoreMessage(BowlingScore score)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Your total score for the game was:\t{score.DisplayScore}\n");
        Console.ResetColor();
    }
}
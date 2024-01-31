using System;

public static class GameMessages
{
    public static int InstructionsBeforeEachRoll(int frameNumber, string rollNumber, BowlingScore score)
    {
        while (true)
        {
            Console.WriteLine($"Options for proceeding:\n\t1. Press enter to roll {rollNumber} ball in frame number {frameNumber}\n\t2. Press 't' to see your current total score\n\t3. Type the number of pins you want to knock down this roll (use 'x' for 10 pins).\n");
            ConsoleKeyInfo pressedKey = Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if (pressedKey.Key == ConsoleKey.T)
            {
                Console.WriteLine($"\nYour current score is:\t{score.DisplayScore}\nPlease press enter to bowl next ball.\n");
            }
            else
            {
                string inputAsString = pressedKey.KeyChar.ToString().ToLower();
                if (inputAsString == "x")
                {
                    Console.WriteLine($"\nYou typed:\t{inputAsString} which equates to 10 pins.\n");
                    return 10;
                }
                else if (StringUtility.IsInteger(inputAsString))
                {
                    int numberOfPinsKnockedDown = int.Parse(inputAsString);
                    Console.WriteLine($"\nYou typed:\t{numberOfPinsKnockedDown}\n");
                    return numberOfPinsKnockedDown;
                }
                else
                {
                    Console.WriteLine($"\nCan only accept integer's between 0 and 9.\n");
                }
            }
            Console.ResetColor();
        }
        return -1;
    }

    public static void FrameNumber(int frameNumber)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"---------- Frame {frameNumber} ----------\n");
        Console.ResetColor();
    }

    public static void RecordFrameMessage(int numberOfTimesRecordFrameHasBeenCalled, int totalScore)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Your score after frame {numberOfTimesRecordFrameHasBeenCalled++} is:\t{totalScore}\n");
        Console.ResetColor();
    }

    public static void StrikeMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You rolled a strike, nice job!\n");
        Console.ResetColor();
    }

    public static void SpareMessage()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("You rolled a spare, nice job!\n");
        Console.ResetColor();
    }

    public static void PinsKnockedDownMessage(int pinsKnockedDown, string rollNumber)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"You knocked down {pinsKnockedDown} pin(s) on your {rollNumber} roll.\n");
        Console.ResetColor();
    }

    public static void EndingScoreMessage(BowlingScore score)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Your total score for the game was:\t{score.DisplayScore}\n");
        Console.ResetColor();
    }
}
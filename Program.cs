using System;
using System.Collections.Generic;

namespace BowlingGame
{
    class Program
    {
        static void BowlingGameInstructions(int frameNumber, string rollNumber, BowlingScore score)
        {
            Console.WriteLine($"Options for proceeding:\n\t1. Press enter to roll {rollNumber} ball in frame number {frameNumber}\n\t2. Press 't' twice to see your current total score\n");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                if (Console.ReadKey().Key == ConsoleKey.T)
                {
                    Console.WriteLine($"\nYour current score is:\t{score.DisplayScore}\n\nPlease press enter to bowl next ball");
                }
            }
        }

        static void Main(string[] args)
        {
            int totalPins = 10;
            BowlingScore score = new BowlingScore();
            Random randomNum = new Random();
            // List<int> spareBonus = new List<int>();
            // List<int> strikeBonus = new List<int>();

            for (int frameNumber = 1; frameNumber <= 9; frameNumber++)
            {
                Console.WriteLine($"---------- Frame {frameNumber} ----------\n");

                // Instructions for first bowl of frame
                BowlingGameInstructions(frameNumber, "1st", score);

                // Roll first bowl
                int firstRoll = randomNum.Next(totalPins + 1);

                score.CalculateScore();

                // Alert user what they rolled
                if (firstRoll == 10)
                {
                    Console.WriteLine("You rolled a strike, nice job!\n");
                    score.AddStrikeBonus();
                    continue;
                }
                else
                {
                    Console.WriteLine($"You knocked down {firstRoll} pins\n");
                }

                // Instructions for second bowl of frame
                BowlingGameInstructions(frameNumber, "2nd", score);

                // Roll second bowl
                int secondRoll = randomNum.Next(totalPins + 1 - firstRoll);

                score.CalculateScore();

                if (firstRoll + secondRoll == 10)
                {
                    Console.WriteLine("You rolled a spare, nice job!\n");
                    score.AddSpareBonus(firstRoll);
                    score.AddSpareBonus(secondRoll);
                    continue;
                }
                else
                {
                    Console.WriteLine($"You knocked down {secondRoll} pins.\n");
                    score.RecordFrame(new int[] { firstRoll, secondRoll });
                }
            }

            Console.WriteLine($"---------- Frame 10 ----------\n");

            // Instructions for first bowl of frame
            BowlingGameInstructions(10, "1st", score);

            // Roll first bowl
            int firstRollLastFrame = randomNum.Next(totalPins + 1);
            Console.WriteLine($"You knocked down {firstRollLastFrame} pins\n");

            // Calculate any scores that need to be calculated after first roll
            score.CalculateScore();

            // Alert user what they rolled
            if (firstRollLastFrame == 10)
            {
                Console.WriteLine("You rolled a strike! You get two more rolls\n");
                score.CalculateScore();
                strikeBonus.Add(firstRollLastFrame);
            }
            else
            {
                Console.WriteLine($"You knocked down {firstRollLastFrame} pins\n");
            }

            // Instructions for second bowl of frame
            BowlingGameInstructions(10, "2nd", score);

            // Roll second bowl
            int secondRollLastFrame = randomNum.Next(totalPins + 1 - firstRollLastFrame);
            Console.WriteLine($"You knocked down {firstRollLastFrame} pins\n");

            // Alert user what they rolled
            if (secondRollLastFrame == 10)
            {
                Console.WriteLine("You rolled a strike, nice job!\n");
                if (strikeBonus.Count == 2)
                {
                    int[] strikeBonusToArray = strikeBonus.ToArray();
                    score.RecordFrame(new int[] { strikeBonusToArray[0], strikeBonusToArray[1], firstRollLastFrame });
                    strikeBonus.Clear();
                    strikeBonus.Add(10);
                }
                strikeBonus.Add(firstRollLastFrame);
            }
            else
            {
                Console.WriteLine($"You knocked down {firstRollLastFrame} pins\n");
            }

            if (firstRollLastFrame + secondRollLastFrame == 10)
            {
                Console.WriteLine("You rolled a spare, nice job!\nYou get one more role since it is the last frame!\n");
                spareBonus.Add(firstRollLastFrame);
                spareBonus.Add(secondRollLastFrame);
            }

            if (firstRollLastFrame + secondRollLastFrame >= 10)
            {
                // Instructions for second bowl of frame
                BowlingGameInstructions(10, "3rd", score);

                int thirdRollLastFrame = randomNum.Next(totalPins + 1);

                // Alert to what they scored after second roll
                if (strikeBonus.Count == 2)
                {
                    int[] strikeBonusToArray = strikeBonus.ToArray();
                    score.RecordFrame(new int[] { strikeBonusToArray[0], strikeBonusToArray[1], thirdRollLastFrame });
                    strikeBonus.Clear();
                }
                else
                {
                    int[] spareBonusToAray = spareBonus.ToArray();
                    score.RecordFrame(new int[] { spareBonusToAray[0], spareBonusToAray[1], thirdRollLastFrame });
                    spareBonus.Clear();
                }
            }



            Console.WriteLine($"\nYour total score for the game was:\t{score.DisplayScore}");
        }
    }
}

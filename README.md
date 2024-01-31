# Bowling Game

My goal in this bowling game simulator was to calculate the score of a bowling game as if you were bowling a live game. I accomplished this by allowing the user to interact with the application via the console. Thus, the application accurately captures the score according to the rules of recording the frame score and the total score for the game **AFTER** the frame is completely closed.

## Bowling Rules

Based on my research, the total score of a bowling game is not incremented until a frame is completely clsoed out. What this means is that your score should only be incremented 10 times throughout the game. So if you roll a spare, your score for that frame will not be incremented until the following frames first roll is over. If you roll a strike, it is possible that your score will not be incremented until 2 frames later.

## How To Run Program

This application was created within the .NET framework. The code can be built with the command:

```
dotnet build
```

After you have built the project, all you need to do is run it with the following command:

```
dotnet run
```

## Interact With Game While Playing

After each bowl, you are given three options for how to contiue through the game:

1. You can press the `Enter` key which will bowl a random number
   - If you are on the second roll, your random number will be between the number of pins left standing and 0.
2. You can press the letter `t` which will display to you the current score of the game. Remember, total score will only increment when a frame is closed.
3. You can press any number between `0` and `9` in order to determine the exact number of pins you want to bowl on any give roll.
   - One caveat to this is that if you are on the second roll of a frame, if you input a number that would put that frame over 10 pins, your input will be ignored and instead you will be given the amount of pins needed to give you a spare for that frame.

# Structure of Code

## BaseFrame.cs

This is a parent class that both Frame.cs and TenthFrame.cs inherit. Though Frame.cs and TenthFrame.cs differ from one another, much of their functionality can be shared.

## BowlingScore.cs

This file contains all of the code relating to incrementing the score for each frame as well as the total/overall score.

## Frame.cs

This file contains the logic for tracking the pins knocked down for any given frame between frame `1` and frame `9`. It doesn't have the logic for frame `10` because frame `10` has it's own special rules to account for.

## GameMessages.cs

This static class contains all of the methods that print out information to the console while you are playing the game.

## IBowlingSoore.cs

This is the original interface that was required to be implmented.

## Program.cs

This file contains the logic for the actual bowling of the ball and the updating of the frame you are in. The 10th frame is handled separately from frames 1-9 as there are many special scenarios to account for in the 10th frame.

## StringUtility.cs

This static class contains one string helper method to determine if a string is an interger.

## TenthFrame.cs

This file contains all of the logic to properly handle the tenth frame scoring.

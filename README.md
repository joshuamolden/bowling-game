# Bowling Game

My goal in this bowling game simulator was to calculate the score of a bowling game as if you were bowling a live bowling game. Unlike an actual bowling game, you don't have any control of the ball. But the goal was not to simulate an actual bowling game, but merely to score a bowling game.

My implementation simulates how a bowling scoring algoritim would work as if you were bowling and were randomly knocking down pins on every roll. Thus, the application accurately captures the score according to the rules of recording the frame score and/or the total score for the game **AFTER** the frame is completely closed.

## Bowling Rules

Based on my research, the total score of a bowling game is not incremented until a frame is completely clsoed out. What this means is that your score should only be incremented 10 times throughout the game. So if you roll a spare, your score for that frame will not be incremented until the following frames first roll is over. If you roll a strike, it is possible that your score will not be incremented until 2 frames later.

Additionally, the 10th frame has to account for many different scenarios that have to be accounted for. My code (though not easy to follow) accounts for every scenario and properly scores the bowling game as if you were bowling it live.

## How To Run Program

This application was created within the .NET framework. The code simply needs to be built with the command:

```
dotnet build
```

After you have built the project, all you need to do is run it with the following command:

```
dotnet run
```

## Interact With Game While Playing

After each bowl, you are able to check the total score by typing `tt`. This will display to you the total score at that point in the game. In order to "bowl" the next ball, press `Enter`.

# Structure of Code

## BowlingScore.cs

This file contains all of the code relating to calculating the score of the bowling game.

## GameMessages.cs

This static class contains all of the methods the print out information to the console while you are "bowling".

## IBowlingSoore.cs

This is the original interface that was required to be implmented

## Program.cs

This file contains the logic for the actual bowling of the ball and the updating of the frame you are in. The 10th frame is handled separately from frames 1-9 as there are many special scenarios to account for in the 10th frame.

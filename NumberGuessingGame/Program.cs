using System;

namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What difficulty would you like? (E), (M), (H)");
                string difficulty = Console.ReadLine() ?? string.Empty;

                int minimum = 1;
                int maximum = 10;

                if (difficulty.Equals("E", StringComparison.OrdinalIgnoreCase))
                {
                    maximum = 10;
                }
                else if (difficulty.Equals("M", StringComparison.OrdinalIgnoreCase))
                {
                    maximum = 50;
                }
                else if (difficulty.Equals("H", StringComparison.OrdinalIgnoreCase))
                {
                    maximum = 100;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Defaulting to Easy.");
                    maximum = 10;
                }

                // Start the game
                var game = new NumberGuessing();
                game.GenerateRandomNumber(minimum, maximum);

                while (true)
                {
                    Console.WriteLine($"Guess a number between {minimum} and {maximum}:");
                    var input = Console.ReadLine();
                    if (!int.TryParse(input, out int guess))
                    {
                        Console.WriteLine("Please enter a valid integer.");
                        continue;
                    }

                    var result = game.MakeGuess(guess);
                    if (result == GuessResult.Correct)
                    {
                        Console.WriteLine("Correct! You guessed the number.");
                        break;
                    }
                    else if (result == GuessResult.TooLow)
                    {
                        Console.WriteLine("Too low.");
                    }
                    else
                    {
                        Console.WriteLine("Too high.");
                    }
                }

                Console.WriteLine("Do you want to play again? (Y) OR (N)");
                var playAgain = Console.ReadLine() ?? string.Empty;
                if (!playAgain.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }
    }
}

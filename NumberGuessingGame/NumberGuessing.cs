using System;

namespace NumberGuessingGame
{
    internal class NumberGuessing
    {
        private int numberToGuess = 0;
        private int minimum;
        private int maximum;

        public void GenerateRandomNumber(int minimum, int maximum)
        {
            Random rand = new Random();
            // Make maximum inclusive
            numberToGuess = rand.Next(minimum, maximum + 1);

            this.minimum = minimum;
            this.maximum = maximum;
        }

        public GuessResult MakeGuess(int guess)
        {
            if (guess == numberToGuess)
            {
                return GuessResult.Correct;
            }
            else if (guess < numberToGuess)
            {
                return GuessResult.TooLow;
            }
            else
            {
                return GuessResult.TooHigh;
            }
        }

    }

}

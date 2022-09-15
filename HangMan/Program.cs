using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static System.Random;
using System.Text;

namespace HangMan
{
    internal class Program
    {





        static void Main(string[] args)
        {

            Random random = new Random();

            List<string> wordBank = new List<string>{
                "sheep", "Laugh", "scarab", "leopard", "tomato", "apple", "snake", "lizzard", "strawberry", "snickers", "jeans", "coat", "cow", "yard", "sun", "moon", "lightning"
            };

            //string[] wordBank = { "sheep", "Laugh", "scarab", "leopard", "tomato", "apple"};

            string wordToGuess = wordBank[random.Next(0, wordBank.Count)];
            string wordToGuessUppercase = wordToGuess.ToLower();

            StringBuilder display = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                display.Append('_');

            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 10;
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;

            while (!won && lives > 0)
            {
                Console.WriteLine("Guess a Letter: ");

                input = Console.ReadLine().ToLower();
                guess = input[0];

                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                    continue;
                }

                if (wordToGuessUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuessUppercase[i] == guess)
                        {
                            display[i] = wordToGuess[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == wordToGuess.Length)
                        won = true;
                }
                else
                {
                    incorrectGuesses.Add(guess);
                    Console.WriteLine($"Current live: {lives}", guess);
                    lives--;
                }

                Console.WriteLine(display.ToString());
            }

            if (won)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("You lost! It was '{0}'", wordToGuess);
                Console.Write("Press ENTER to exit....");
            }

            Console.ReadLine();

        }
    }
}
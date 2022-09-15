using System;
using static System.Random;
using System.Text;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t\t\t\t\t\tWelcome To HangMan!");

            Random random = new Random();

            // Creating my list with words //
            List<string> wordBank = new List<string>{
                "sheep", "Laugh", "scarab", "leopard", "tomato", "apple", "snake", "lizzard", "strawberry", "snickers", "jeans", "coat", "cow", "yard", "sun", "moon", "lightning"
            };

            //Generate random word from list, since list we use count instead of length. //
            string wordToGuess = wordBank[random.Next(0, wordBank.Count)];
            // Takes the random word and make all letters to lowercase //
            string wordToGuessLowerCase = wordToGuess.ToLower();

            // Creates a new string where i take the word and it's length, I then loop it and append _ for each letter //
            StringBuilder display = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                display.Append('_');

            // Creating 2 separeted list, one for correct guess and one for incorrect. I can check something in the list with the contain method
            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            // Deklaring lives and a bool for the while loop, also a lettersRevealed to display letters once correct.
            int lives = 9;
            bool won = false;
            int lettersRevealed = 0;

            string? input;
            char guess;

            while (!won && lives >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nGuess a Letter: ");
                //takes the char that's sent from the players input and makes it to lowercase, I also make sure that it only takes the first index from the inpu.
                //incase the player types more than 1 chars. 
                input = Console.ReadLine().ToLower();
                guess = input[0];

                // Here we have a condition to check if the guessed letter is correct or incorrect
                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("\t '{0}', Has already been found, try another letter!", guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("\tYou've already tried '{0}', and it was wrong!", guess);
                    continue;
                }

                if (wordToGuessLowerCase.Contains(guess))
                {
                    // adds the letter input to the list correctGuesses
                    correctGuesses.Add(guess);

                    //Logic behind the display //
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuessLowerCase[i] == guess)
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    // adds the letter input to the list incorrectGuesses
                    incorrectGuesses.Add(guess);
                    Console.Clear();
                    Console.WriteLine($"\tCurrent live: {lives}", guess);
                    // decrement lives if guess is wrong
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
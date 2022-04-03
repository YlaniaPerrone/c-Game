using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hangman
{
    public class gameHangmanV2
    {
        public static void V2Hangman()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("---------- Hangman's game ----------");


            //register arrayWord
            string[] words = { "human", "surprise", "holiday" };


            // chooce random word
            var random = new Random();

            var randomWord = "";
            randomWord = words[random.Next(0, words.Length)];
            Console.Write(randomWord + "\n");


            //show number Letter word
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"The word to guess contains {randomWord.Length} letters");


            //show grid "replace char with *"
            char[] wordToFind = new Char[randomWord.Length];

            string repaclaStar = Regex.Replace(randomWord, "[a-z]", "*");
            wordToFind = repaclaStar.ToCharArray();
            Console.Write(repaclaStar);


            // create list wrongLetters
            var wrongLetters = new List<char>();


            char characterEnter;

            var count = 10;

            do
            {
                Console.WriteLine();

                //show number of tries
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nYou have {count} chances");


                //ask again if this is not a char
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("write a character : ");

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    // } while (!char.IsControl(regex)  );
                } while (!char.TryParse(Console.ReadLine(), out characterEnter));


                //check if char exist in randomWord
                if (randomWord.Contains(characterEnter))
                {
                    for (var j = 0; j < randomWord.Length; j++)
                    {
                        if (randomWord[j] == characterEnter)
                        {
                            wordToFind[j] = characterEnter;
                        }
                    }
                }
                else
                {
                    count--;

                    if (!wrongLetters.Contains(characterEnter))
                    {
                        wrongLetters.Add(characterEnter);
                    }
                }

                //convert wordToFind char in string
                string showLetter = new string(wordToFind);

                //show the letters found
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(showLetter);

                //show wrongLetters
                Console.Write("\nWrong letters : ");
                foreach (var letters in wrongLetters)
                    Console.Write(letters);
            } while (count > 0 && wordToFind.Contains('*'));


            Console.WriteLine();
            if (!wordToFind.Contains('*'))
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Bingo");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Oh no !!  The word was {randomWord}");
            }
        }
    }
}
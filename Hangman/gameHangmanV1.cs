using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    public class gameHangmanV1
    {
        public static void V1Hangman()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("---------- Hangman's game  ----------");


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

            for (var i = 0; i < wordToFind.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                wordToFind[i] = '*';
                Console.Write(wordToFind[i]);
            }


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

                //show the letters found
                foreach (var charac in wordToFind)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(charac);
                }

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
                Console.WriteLine($"Oh no  !! The word was {randomWord}");
            }
        }
    }
}
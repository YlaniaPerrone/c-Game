using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hangman
{
    public class F_Hangman
    {
        public static string GetWordRandom(string[] words)
        {
            var random = new Random();

            var randomWord = "";
            randomWord = words[random.Next(0, words.Length)];

            return randomWord;
        }

        public static char[] HiddenWordToCharArray(string word)
        {
            string replaceStar = Regex.Replace(word, "[a-z]", "*");
            return replaceStar.ToCharArray();
        }

        public static char[] checkcharacterInWord(char[] hiddenWord, string word, char character)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == character)
                {
                    hiddenWord[i] = character;
                }
            }

            return hiddenWord;
        }

        static List<char> RegisterWrongLetters(char letter, List<char> wrongLetters)
        {
            if (!wrongLetters.Contains(letter)) wrongLetters.Add(letter);

            return wrongLetters;
        }

        static List<char> ShowWrongLetters(List<char> wrongLetters)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Wrong letters : ");

            foreach (var item in wrongLetters)
            {
                Console.Write(item + " ");
            }

            return wrongLetters;
        }

        public static void playGame(string wordToFind, char characterEnter)
        {
            Console.WriteLine("\n ------ Hangman's Game -----");
            Console.WriteLine("Rule of the game : Find the film");

            int count = 6;

            string[] words = new[]
                { "babares", "spartacus", "vikings", "the last kingdom", "lupin", "adu", "outer banks" };
            wordToFind = GetWordRandom(words);
            char[] HiddenWord = HiddenWordToCharArray(wordToFind);

            //show word 
            Console.WriteLine(wordToFind);

            List<char> wrongLetters = new List<char>();

            do
            {
                Console.WriteLine("\n");
                //show hanged man
                Console.ForegroundColor = ConsoleColor.White;
                displayHangman(count);

                //show star
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(HiddenWord);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"You have {count} tries");

                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Enter a character : ");
                } while (!char.TryParse(Console.ReadLine().ToLower(), out characterEnter) ||
                         !char.IsLetter(characterEnter));

                if (wordToFind.Contains(characterEnter))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    HiddenWord = checkcharacterInWord(HiddenWord, wordToFind, characterEnter);
                }
                else
                {
                    wrongLetters = RegisterWrongLetters(characterEnter, wrongLetters);
                    count--;
                }

                ShowWrongLetters(wrongLetters);
            } while (HiddenWord.Contains('*') && count > 0);

            if (!HiddenWord.Contains('*'))
            {
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(wordToFind);
                Console.WriteLine("Bingo !!!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine("\n");
                displayHangman(count);
                Console.Write($"Game 0ver !! The word was  ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(wordToFind);
            }
        }

        public static int displayHangman(int tries)
        {
            switch (tries)
            {
                case 0:
                    Console.WriteLine("The man died");
                    Console.WriteLine(" ┌─────┐");
                    Console.WriteLine(" |     0");
                    Console.WriteLine(" |    /|\\");
                    Console.WriteLine(" |    / \\");
                    Console.WriteLine(" | ");
                    Console.WriteLine("───");

                    // Console.WriteLine(" \u250C\u2500\u2500\u2500\u2510");
                    // Console.WriteLine(" \u2502   0");
                    // Console.WriteLine(" \u2502  /\u2502\\ ");
                    // Console.WriteLine(" \u2502  / \\");
                    // Console.WriteLine("\u2500\u2500\u2500");
                    break;
                case 1:
                    Console.WriteLine(" ┌─────┐");
                    Console.WriteLine(" |     0");
                    Console.WriteLine(" |    /|\\");
                    Console.WriteLine(" |    / ");
                    Console.WriteLine(" | ");
                    Console.WriteLine("───");
                    break;
                case 2:
                    Console.WriteLine(" ┌─────┐");
                    Console.WriteLine(" |     0");
                    Console.WriteLine(" |    /|\\");
                    Console.WriteLine(" | ");
                    Console.WriteLine(" | ");
                    Console.WriteLine("───");
                    break;
                case 3:
                    Console.WriteLine(" ┌─────┐");
                    Console.WriteLine(" |     0");
                    Console.WriteLine(" |    /| ");
                    Console.WriteLine(" | ");
                    Console.WriteLine(" | ");
                    Console.WriteLine("───");
                    break;
                case 4:
                    Console.WriteLine(" ┌─────┐");
                    Console.WriteLine(" |     0");
                    Console.WriteLine(" |    /");
                    Console.WriteLine(" | ");
                    Console.WriteLine(" | ");
                    Console.WriteLine("───");
                    break;
                case 5:
                    Console.WriteLine(" ┌─────┐");
                    Console.WriteLine(" |     0");
                    Console.WriteLine(" |    ");
                    Console.WriteLine(" | ");
                    Console.WriteLine(" | ");
                    Console.WriteLine("───");
                    break;
                case 6:
                    Console.WriteLine(" ┌─────┐");
                    Console.WriteLine(" |     ");
                    Console.WriteLine(" |    ");
                    Console.WriteLine(" | ");
                    Console.WriteLine(" | ");
                    Console.WriteLine("───");
                    break;
            }

            return tries;
        }
    }
}
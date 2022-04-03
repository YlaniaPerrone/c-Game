using System;
using System.Linq;


namespace HeadsOrTails
{
    public class f_gameHeads
    {
        static bool choicePlayer()
        {
            int choicePlayer;
            do
            {
                Console.WriteLine("Who starts? ? \n" +
                                  "1. You \n" +
                                  "2. Computer \n");
                int.TryParse(Console.ReadLine(), out choicePlayer);
            } while (choicePlayer != 1 && choicePlayer != 2);

            return choicePlayer == 1;
        }

        static string getWord(string[] game)
        {
            Random random = new Random();
            string word = game[random.Next(0, game.Length)];

            return word;
        }

        static string choiceHeadsOrFace(string wordToFind, string wordInput, string[] arrayWord)
        {
            do
            {
                Console.WriteLine(wordToFind);
                Console.Write("Heads or Tails ?  ");
                wordInput = Console.ReadLine();
            } while (!arrayWord.Contains(wordInput));


            return wordInput;
        }

        static string showChoice(string choice)
        {
            if (choice == "heads")
            {
                return "tails";
            }

            return "heads";
        }

        static void ComputerVsPlayer(bool isPlayer, string word, string wordInput)
        {
            string player = "player";
            string computer = "computer";

            if (isPlayer)
            {
                Console.WriteLine($"{player} : {wordInput}");
                Console.WriteLine($"{computer} : {showChoice(wordInput)}");
            }
            else
            {
                Console.WriteLine($"{player} : {showChoice(wordInput)}");
                Console.WriteLine($"{computer} : {wordInput}");
            }

            if ((isPlayer && word == wordInput) || (!isPlayer && word != wordInput))
            {
                Console.WriteLine("You win");
            }
            else if ((isPlayer && word != wordInput) || (!isPlayer && word == wordInput))
            {
                Console.WriteLine("Womputer win");
            }
        }

        static void check(string wordToFind, string wordInput)
        {
            if (wordToFind == wordInput)
            {
                Console.WriteLine("Win");
            }
            else
            {
                Console.WriteLine("Lost");
            }
        }

        static char playAgain()
        {
            Console.WriteLine("again ? ");
            char again = Console.ReadLine()[0];

            if (again != 'n')
            {
                playGame();
            }

            return again;
        }

        public static void playGame()
        {
            int choiceNbrplayer;
            string wordInput = "";

            string[] arrayWord = { "heads", "tails" };
            string wordToFind = getWord(arrayWord);


            do
            {
                Console.WriteLine("Game \n" +
                                  "1. alone \n" +
                                  "2. with computer\n");
                int.TryParse(Console.ReadLine(), out choiceNbrplayer);
            } while (choiceNbrplayer != 1 && choiceNbrplayer != 2);


            switch (choiceNbrplayer)
            {
                case 1:

                    wordInput = choiceHeadsOrFace(wordToFind, wordInput, arrayWord);

                    check(wordToFind, wordInput);

                    playAgain();


                    break;

                case 2:

                    bool isPlayer = choicePlayer();

                    string choice = "";

                    if (isPlayer)
                    {
                        choice = choiceHeadsOrFace(wordToFind, wordInput, arrayWord);
                    }
                    else
                    {
                        choice = getWord(arrayWord);
                    }


                    ComputerVsPlayer(isPlayer, wordToFind, choice);

                    Console.WriteLine("\n");
                    playAgain();

                    break;
            }
        }
    }
}
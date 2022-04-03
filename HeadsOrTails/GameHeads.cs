using System;
using System.Linq;


namespace HeadsOrTails
{
    public class GameHeads
    {
        public static void playGame()
        {
            int chooseNbrJoueur;

            string[] game = { "pile", "face" };

            do
            {
                Console.WriteLine("jeu \n" +
                                  "1. solo \n" +
                                  "2. avec ordi \n");
                int.TryParse(Console.ReadLine(), out chooseNbrJoueur);
            } while (chooseNbrJoueur != 1 && chooseNbrJoueur != 2);


            string wordInputJoueur = " ";

            Random random = new Random();
            string chooseWord = game[random.Next(0, game.Length)];

            char? again = ' ';
            int chooseJoueur;
            string chooseOrdi = " ";

            do
            {
                Console.WriteLine(chooseWord);

                do
                {
                    Console.WriteLine("Qui commence ? \n" +
                                      "1. vous \n" +
                                      "2. ordi \n");
                    int.TryParse(Console.ReadLine(), out chooseJoueur);
                } while (chooseJoueur != 1 && chooseJoueur != 2);

                chooseOrdi = game[random.Next(0, game.Length)];

                if (chooseJoueur == 1)
                {
                    do
                    {
                        Console.Write("Pile ou face ?  ");
                        wordInputJoueur = Console.ReadLine();
                    } while (!game.Contains(wordInputJoueur));
                }
                else
                {
                    if (chooseOrdi == "pile")
                    {
                        wordInputJoueur = "face";
                    }
                    else wordInputJoueur = "pile";
                }


                Console.WriteLine($"Vous : {wordInputJoueur} \n" +
                                  $"Ordi : {chooseOrdi}");


                if (chooseWord == wordInputJoueur)
                {
                    Console.WriteLine("gagné");
                }
                else
                {
                    Console.WriteLine("Ordi gagne");
                }

                Console.WriteLine("again ? n pour quitter ");
                again = Console.ReadLine()[0];
            } while (again != 'n');
        }
    }
}
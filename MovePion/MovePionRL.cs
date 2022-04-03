using System;

namespace MovePion
{
    public class MovePionRL
    {
        public static void MovePion()
        {
            int[] Array = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int indexPion = 0;
            ConsoleKeyInfo touche;

            do
            {
                Console.WriteLine("\n");

                for (int i = 0; i < Array.Length; i++)
                {
                    Console.Write(Array[i] + "\t");
                }

                Console.WriteLine("\n");

                Console.WriteLine("put r for right \n" +
                                  "put l for left \n");
                touche = Console.ReadKey();

                switch (touche.Key)
                {
                    case ConsoleKey.R:
                        if (indexPion < Array.Length - 1)
                        {
                            Array[indexPion] = 0;
                            indexPion++;
                            Array[indexPion] = 1;
                        }

                        break;
                    case ConsoleKey.L:
                        if (indexPion > 0)
                        {
                            Array[indexPion] = 0;
                            indexPion--;
                            Array[indexPion] = 1;
                        }

                        break;
                    default:
                        Console.WriteLine("Touch invalid");
                        break;
                }
            } while (touche.Key != ConsoleKey.S);
        }
    }
}
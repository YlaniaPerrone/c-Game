using System;

namespace MovePion
{
    public class MovePionRLTD
    {
        /**
         * Grille de Jeu
         * 
         * Créer une grille de 15 cases sur 15 cases
         * Placer dans la première case un pion (P) qui va pouvoir
         * se déplacer au sein de la grille en utilisant les touches
         * HAUT, BAS, GAUCHE, DROITE (Console.ReadKey())
         * 
         * Vous devez gérer les bords et empêcher votre pion de "sortir"
         * de la grille
         * 
         * Placer aléatoirement une sortie (S) dans votre grille
         * Quand le pion se déplace jusqu'à la sortie, votre programme
         * s'arrête 
         * 
         * Affichage :
         *  - Créer une grille stylisée (cfr -> Aide_Bordures())
         */
        public static void MovePion()
        {
            Console.WriteLine("----- MovePion Game -----");
            int x, y, newIndexPositionY = 0, newIndexPositionX = 0;

            // int[,] array = new int[4, 4]
            // {
            //     { 1, 0, 0, 0 },
            //     { 0, 0, 0, 0 },
            //     { 0, 0, 0, 0 },
            //     { 0, 0, 0, 0 }
            // };
            // char[,] array = new Char[4,4] {
            //     
            //                      {'0','*','*','*'},
            //                      {'*','*','*','*'},
            //                      {'*','*','*','*'},
            //                      {'*','*','*','*'}
            //                  
            // };

            char[,] array = { {'0','*','*','*'}, {'*','*','*','*'}, {'*','*','*','*'}, {'*','*','*','*'} };
            
            Console.WriteLine("\n");
            
            ConsoleKeyInfo touch;
            do
            {
                //recupere taille tableau x & y

                for (y = 0; y < array.GetLength(0); y++)
                {
                    // Console.WriteLine(y);
                    for (x = 0; x < array.GetLength(1); x++)
                    {
                        // Console.WriteLine(x);
                        Console.Write(array[y, x]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.Write("Press <-, ->, UpArrow, DownArrow),");
                Console.Write("U -- up left,");
                Console.Write("R -- Up Right, \n");
                Console.Write("D -- down right,");
                Console.Write("L -- Down Left : ");
                touch = Console.ReadKey();
                Console.WriteLine();
                
                bool isMove = false;
                
                for (y = 0; y < array.GetLength(0); y++)
                {
                    for (x = 0; x < array.GetLength(1); x++)
                    {
                        if (array[y, x] == '0')
                        {
                            switch (touch.Key)
                            {
                                case ConsoleKey.RightArrow:
                                case ConsoleKey.LeftArrow:

                                    newIndexPositionX = touch.Key == ConsoleKey.LeftArrow ? x - 1 : x + 1;
                                    newIndexPositionY = y;
                                    break;

                                case ConsoleKey.UpArrow:
                                case ConsoleKey.DownArrow:

                                    newIndexPositionY = touch.Key == ConsoleKey.DownArrow ? y + 1 : y - 1;
                                    newIndexPositionX = x;
                                    
                                    break;

                                case ConsoleKey.U: //up left

                                    newIndexPositionX = x - 1;
                                    newIndexPositionY = y - 1;
                                    break;

                                case ConsoleKey.R: // Up Right
                                    newIndexPositionX = x + 1;
                                    newIndexPositionY = y - 1;

                                    break;

                                case ConsoleKey.D: // down right

                                    newIndexPositionX = x + 1;
                                    newIndexPositionY = y + 1;

                                    break;

                                case ConsoleKey.L: // Down Left

                                    newIndexPositionX = x - 1;
                                    newIndexPositionY = y + 1;
                                    
                                    break;
                            }
                            
                            if ((newIndexPositionX >= 0 && newIndexPositionX < array.GetLength(1)) &&
                                newIndexPositionY >= 0 && newIndexPositionY < array.GetLength(0))
                            {
                                array[y, x] = '*';
                                array[newIndexPositionY, newIndexPositionX] = '0';
                                isMove = true;
                                break;
                            }
                        }
                    }
                    if (isMove)
                    {
                        break;
                    }
                }

            } while (touch.Key != ConsoleKey.S);
        }
    }
}
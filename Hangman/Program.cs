using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hangman
{
    class Program
    {
        /*
         * Jeu du Pendu
         * 
         * Réaliser un jeu du pendu qui va demander à l'utilisateur
         * de trouver un mot en un nombre fixé d'essais.
         * 
         * Créer un tableau de string qui va stocker quelques mots à trouver
         * Choisir aléatoirement un mot pour la partie (Random --> cfr AideRandom)
         * Lancer la partie
         * 
         * La partie se termine :
         *  - soit quand le joueur trouve en moins d'essais que le nombre maximal fixé (VICTOIRE)
         *  - soit quand le joueur ne trouve pas (DEFAITE)
         *  
         *  Affichage :
         *  Le mot à trouver doit apparaître sous cette forme  * * * * * * * *
         *  ou chaque étoile représente un caractère.
         *  Remplacer les étoiles par les lettres déjà trouvées  * * a * t * *
         *  Afficher le nombre d'essais restants
         *  Afficher une notification de victoire ou défaite à la fin
         *  
         *  Bonus : 
         *  Afficher aussi le pendu à chaque étape 
         */


        public static void Main(string[] args)
        {
            #region hangmanV1

            // gameHangmanV1.V1Hangman();

            #endregion

            #region hangmanV1

            // gameHangmanV2.V2Hangman();

            #endregion

            FHangman();
        }


        #region Hangman V2

        #endregion

        #region functionHangman

        static void FHangman()
        {
            string randomWord = "";
            // F_Hangman.GetWordRandom(randomWord);
            char character = ' ';
            F_Hangman.playGame(randomWord, character);
        }

        #endregion
    }
}
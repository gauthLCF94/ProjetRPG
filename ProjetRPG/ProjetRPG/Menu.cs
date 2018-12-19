using ProjetRPG;
using ProjetRPG.Stones;
using ProjetRPG.Stones.InfinityStones;
using ProjetRPG.Characters;
using ProjetRPG.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Menu
    {
        #region Methodes

        public static void ShowMenu()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1 : Start Game");
            Console.WriteLine("2 : Load Game");
            Console.WriteLine("3 : About");
            Console.WriteLine("4 : Exit");
        }

        public static int AskChoice(string question, int min, int max)
        {
            int c = -1;

            Console.WriteLine();
            Console.WriteLine(question);
            try
            {
                c = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrez un chiffre entre " + min + " et " + max);
            }
            

            while ((c > max) || (c < min))
            {
                try
                {
                    c = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrez un chiffre entre " + min + " et " + max);
                }
            }

            return c;
        }

        public static void LoadGame()
        {
            //TODO LoadGame Menu
            Console.WriteLine("Fonction indisponible pour le moment");
            Console.ReadLine();
        }

        public static void About()
        {
            Console.Clear();
            Console.WriteLine("Dans ce jeu, vous incarnez Thanos le Titan Fou !");
            Console.WriteLine("Votre but ? Sauver l'univers !");
            Console.WriteLine("La surpopulation de l'univers va le mener à sa perte !");
            Console.WriteLine("Votre monde a déjà succombé et vous ne laisserez pas d'autres mondes subir le même sort !");
            Console.WriteLine("Vous devez rassemblez les 6 Pierres d'Infinitées et unir leurs pouvoir pour supprimer la moitié des êtres vivants de l'univers pour le salut de l'autre moitié.");
            Console.WriteLine("Mais des soit-disant \"Héros\" se dressent contre vous !");
            Console.ReadLine();
        }

        public static void Exit()
        {
        }
        #endregion

    }
}

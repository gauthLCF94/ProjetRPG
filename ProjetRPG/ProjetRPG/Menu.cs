using ProjetRPG;
using ProjetRPG.Stones;
using ProjetRPG.Stones.InfinityStones;
using ProjetRPG.Characters;
using ProjetRPG.Map;
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

        public void ShowMenu()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1 : Start Game");
            Console.WriteLine("2 : Load Game");
            Console.WriteLine("3 : About");
            Console.WriteLine("4 : Exit");
        }

        public static int AskChoice(int min, int max)
        {
            int c = int.Parse(Console.ReadLine());

            while ((c > max) || (c < min))
            {
                Console.WriteLine("Que voulez-vous faire ?");
                c = int.Parse(Console.ReadLine());
            }

            return c;
        }

        public void StartGame()
        {
            //TODO MENU Lancer une nouvelle partie
        }

        public void LoadGame()
        {
            //TODO MENU Charger une partie
        }

        public void Exit()
        {
            //TODO MENU Quitter le jeu
        }
        #endregion

    }
}

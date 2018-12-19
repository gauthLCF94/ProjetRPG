using ProjetRPG;
using ProjetRPG.Stones;
using ProjetRPG.Stones.InfinityStones;
using ProjetRPG.Characters;
using ProjetRPG.Characters.Boss;
using ProjetRPG.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop);

            Player player;
            Map map;

            bool end = false;
            
            while (!end)
            {
                Menu.ShowMenu();

                switch (Menu.AskChoice("Que voulez-vous faire ?", 1, 4))
                {
                    case 1:
                        player = new Player();
                        map = new Map();

                        Game.MainGame(player, map);

                        break;
                    case 2:
                        Menu.LoadGame();
                        break; //TODO LoadGame goto default;
                    case 3:
                        Menu.About();
                        Console.Clear();
                        break;
                    case 4:
                        end = true;
                        break;
                }
            }
            
            //Console.ReadLine();
        }
    }
}

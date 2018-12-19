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
using System.Threading;

namespace ProjetRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

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

                        Menu.About();
                        
                        Console.WriteLine("Vous commencez votre périple avec déjà en votre possession la Pierre du Pouvoir");
                        Console.ReadLine();

                        Console.WriteLine("Votre aventure commence ...");
                        Thread.Sleep(1000);
                        Console.WriteLine(@"
  __  __          _____ _   _ _______ ______ _   _          _   _ _______   _ 
 |  \/  |   /\   |_   _| \ | |__   __|  ____| \ | |   /\   | \ | |__   __| | |
 | \  / |  /  \    | | |  \| |  | |  | |__  |  \| |  /  \  |  \| |  | |    | |
 | |\/| | / /\ \   | | | . ` |  | |  |  __| | . ` | / /\ \ | . ` |  | |    | |
 | |  | |/ ____ \ _| |_| |\  |  | |  | |____| |\  |/ ____ \| |\  |  | |    |_|
 |_|  |_/_/    \_\_____|_| \_|  |_|  |______|_| \_/_/    \_\_| \_|  |_|    (_)
                        ");
                        Console.ReadLine();

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

using ProjetRPG;
using ProjetRPG.Stones;
using ProjetRPG.Stones.InfinityStones;
using ProjetRPG.Characters;
using ProjetRPG.Characters.Boss;
using ProjetRPG.Board;
using System;
using System.IO;
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

            bool endMain = false;
            
            while (!endMain)
            {
                Game.Title();
                Menu.ShowMenu();

                switch (Menu.AskChoice("Que voulez-vous faire ?", 1, 4))
                {
                    case 1:
                        player = new Player();
                        map = new Map();

                        Game.Title();
                        Game.Speech();
                        
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
                        
                        if (Game.winGame)
                            Game.EndGame();
                        else
                            Game.GameOver();
                        break;
                    case 2:
                        try
                        {
                            Menu.LoadGame();
                        }
                        catch (DirectoryNotFoundException)
                        {
                            Console.WriteLine("Aucune sauvegarde n'a été trouvé ...");
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        Menu.About();
                        Console.Clear();
                        break;
                    case 4:
                        endMain = true;
                        break;
                }
            }
        }
    }
}

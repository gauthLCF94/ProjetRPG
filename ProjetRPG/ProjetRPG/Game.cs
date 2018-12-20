using ProjetRPG;
using ProjetRPG.Stones;
using ProjetRPG.Stones.InfinityStones;
using ProjetRPG.Characters;
using ProjetRPG.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjetRPG.Characters.Boss;

namespace ProjetRPG
{
    class Game
    {
        public static bool end;
        public static bool skipToEnd;
        public static bool winGame;
        
        #region Methodes

        public static void MainGame(Player player, Map map)
        {
            end = false;
            skipToEnd = false;
            winGame = false;

            while (!end)
            {
                if (!map.box[player.position[0], player.position[1]].visited)
                {
                    if (map.box[player.position[0], player.position[1]].ennemy != null)
                    {
                        Ennemy e = map.box[player.position[0], player.position[1]].ennemy;
                        if (e.Name == "Vision")
                        {
                            if (player.Fight(e))
                            {
                                Console.ReadLine();
                                Console.Clear();

                                Map mapFinalBoss = new Map(1);

                                if (player.Fight(mapFinalBoss.box[0,0].ennemy))
                                {
                                    end = true;
                                    skipToEnd = true;
                                    winGame = true;
                                }
                                else
                                {
                                    end = true;
                                    skipToEnd = true;
                                }
                            }
                            else
                            {
                                end = true;
                                skipToEnd = true;
                            }
                        }
                        else
                        {
                            if (!player.Fight(e))
                            {
                                end = true;
                                skipToEnd = true;
                            }
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Stone s = map.box[player.position[0], player.position[1]].stone;
                        player.PickUp(s);
                    }
                    map.box[player.position[0], player.position[1]].visited = true;
                }
                else
                    Console.WriteLine("Vous êtes déjà venu par ici ...");
                
                if (!skipToEnd)
                {
                    if (player.lifePoints > 0)
                    {
                        bool next = false;
                        while (!next)
                        {
                            Console.WriteLine("1 : Avancer");
                            Console.WriteLine("2 : Regarder dans l'inventaire");
                            Console.WriteLine("3 : Voir la carte");
                            Console.WriteLine("4 : Voir les statistiques");
                            Console.WriteLine("5 : Sauvegarder");
                            int c = Menu.AskChoice("Qu'allez-vous faire ?", 1, 5);

                            switch (c)
                            {
                                case 1:
                                    next = true;
                                    player.Move();
                                    break;
                                case 2:
                                    player.ShowInventory();
                                    int c1 = Menu.AskChoice("Que voulez-vous ?", 1, 3);
                                    switch (c1)
                                    {
                                        case 1:
                                            player.ShowStoneInventory();
                                            int c2 = Menu.AskChoice("Quelle pierre voulez-vous utiliser ?", 1, 4);
                                            switch (c2)
                                            {
                                                case 1:
                                                    if (player.stoneInventory["Pierre de Soin"] > 0)
                                                    {
                                                        Heal h = new Heal();
                                                        h.Use(player);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Vous n'avez plus de pierre de soin ...");
                                                    }
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Ce n'est pas le moment d'utiliser ça !");
                                                    break;
                                                case 3:
                                                    if (player.stoneInventory["Pierre d'Amélioration"] > 0)
                                                    {
                                                        Booster b = new Booster();
                                                        b.Use(player);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Vous n'avez plus de pierre d'amélioration ...");
                                                    }
                                                    break;
                                                case 4:
                                                    Console.Clear();
                                                    continue;
                                            }
                                            break;
                                        case 2:
                                            player.ShowInfinityStoneInventory();
                                            int c3 = Menu.AskChoice("Quelle Pierre d'Infinitées voulez-vous utiliser ?", 1, 7);
                                            switch (c3)
                                            {
                                                case 4:
                                                    Witch e = new Witch();
                                                    player.UseInfinityStone(c3, e);
                                                    break;
                                                case 7:
                                                    Console.Clear();
                                                    continue;
                                                default:
                                                    Console.WriteLine("Il serait plus prudent de ne pas utiliser cette Pierre maintenant");
                                                    break;
                                            }
                                            break;
                                        case 3:
                                            Console.Clear();
                                            continue;
                                    }
                                    break;
                                case 3:
                                    map.ShowMap(player);
                                    break;
                                case 4:
                                    player.ShowStats();
                                    break;
                                case 5:
                                    player.Save(map);
                                    break;
                            }
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
            }
        }

        public static void Title()
        {
            Console.WriteLine(@"
                             ________  ________   ________  ________   
                            |\   ____\|\   ___  \|\   __  \|\   __  \  
                            \ \  \___|\ \  \\ \  \ \  \|\  \ \  \|\  \ 
                             \ \_____  \ \  \\ \  \ \   __  \ \   ____\
                              \|____|\  \ \  \\ \  \ \  \ \  \ \  \___|
                                ____\_\  \ \__\\ \__\ \__\ \__\ \__\   
                               |\_________\|__| \|__|\|__|\|__|\|__|   
                               \|_________|     
                                         _________  ___  ___  _______      
                                        |\___   ___\\  \|\  \|\  ___ \     
                                        \|___ \  \_\ \  \\\  \ \   __/|    
                                             \ \  \ \ \   __  \ \  \_|/__  
                                              \ \  \ \ \  \ \  \ \  \_|\ \ 
                                               \ \__\ \ \__\ \__\ \_______\
                                                \|__|  \|__|\|__|\|_______| 
                                     ___       __   ________  ________  ___       ________     
                                    |\  \     |\  \|\   __  \|\   __  \|\  \     |\   ___ \    
                                    \ \  \    \ \  \ \  \|\  \ \  \|\  \ \  \    \ \  \_|\ \   
                                     \ \  \  __\ \  \ \  \\\  \ \   _  _\ \  \    \ \  \ \\ \  
                                      \ \  \|\__\_\  \ \  \\\  \ \  \\  \\ \  \____\ \  \_\\ \ 
                                       \ \____________\ \_______\ \__\\ _\\ \_______\ \_______\
                                        \|____________|\|_______|\|__|\|__|\|_______|\|_______|
            ");
        }

        public static void Speech()
        {
            Console.Clear();
            Title();
            Console.WriteLine("Dans ce jeu, vous incarnez Thanos le Titan Fou !");
            Console.WriteLine("Votre but ? Sauver l'univers !");
            Console.WriteLine("La surpopulation de l'univers va le mener à sa perte !");
            Console.WriteLine("Votre monde a déjà succombé et vous ne laisserez pas d'autres mondes subir le même sort !");
            Console.WriteLine("Vous devez rassemblez les 6 Pierres d'Infinitées et unir leurs pouvoir");
            Console.WriteLine("pour supprimer la moitié des êtres vivants de l'univers pour le salut de l'autre moitié.");
            Console.WriteLine("Mais des soit-disant \"Héros\" se dressent contre vous !");
            Console.ReadLine();
        }

        public static void EndGame()
        {
            Console.Clear();
            Console.WriteLine(@"
                         ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄ 
                        ▐░░░░░░░░░░░▌▐░░▌      ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
                        ▐░█▀▀▀▀▀▀▀▀▀ ▐░▌░▌     ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌
                        ▐░▌          ▐░▌▐░▌    ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌
                        ▐░█▄▄▄▄▄▄▄▄▄ ▐░▌ ▐░▌   ▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌
                        ▐░░░░░░░░░░░▌▐░▌  ▐░▌  ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
                         ▀▀▀▀▀▀▀▀▀█░▌▐░▌   ▐░▌ ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ 
                                  ▐░▌▐░▌    ▐░▌▐░▌▐░▌       ▐░▌▐░▌          
                         ▄▄▄▄▄▄▄▄▄█░▌▐░▌     ▐░▐░▌▐░▌       ▐░▌▐░▌          
                        ▐░░░░░░░░░░░▌▐░▌      ▐░░▌▐░▌       ▐░▌▐░▌          
                         ▀▀▀▀▀▀▀▀▀▀▀  ▀        ▀▀  ▀         ▀  ▀        
            ");
            Thread.Sleep(2000);
            Console.WriteLine("Thanos vient de claquer des doigts ...");
            Thread.Sleep(2000);
            Console.WriteLine("La moitié des êtres vivants de l'univers a disparu ...");
            Thread.Sleep(2000);
            Console.WriteLine("Vous avez sauvé le monde !...");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine(@"
  _______   _______   ___       ___   _______   ___   _______   _______   _______   ___   _______   ______    _______       __ 
 |   _   | |   _   | |   |     |   | |   _   | |   | |       | |   _   | |       | |   | |   _   | |   _  \  |   _   |     |  |
 |.  |___| |.  |___| |.  |     |.  | |.  |___| |.  | |.|   | | |.  |   | |.|   | | |.  | |.  |   | |.  |   | |   |___|     |  |
 |.  __)   |.  __)_  |.  |___  |.  | |.  |___  |.  | `-|.  |-' |.  _   | `-|.  |-' |.  | |.  |   | |.  |   | |____   |     |  |
 |:  |     |:  |   | |:  |   | |:  | |:  |   | |:  |   |:  |   |:  |   |   |:  |   |:  | |:  |   | |:  |   | |:  |   |     |__| 
 |::.|     |::.. . | |::.. . | |::.| |::.. . | |::.|   |::.|   |::.|:. |   |::.|   |::.| |::.. . | |::.|   | |::.. . |      __   
 `---'     `-------' `-------' `---' `-------' `---'   `---'   `--- ---'   `---'   `---' `-------' `--- ---' `-------'     |__|  
            ");
            end = true;
            Console.ReadLine();
            Console.Clear();
        }

        public static void GameOver()
        {
            Console.Clear();
            Console.WriteLine(@"
                               ___________      _____          ______   ______________
                              /          /     /     \        /      \  \__          /
                             /    ______/     /   _   \      /        \   |    _____/
                            /     \   ___    /   / \   \    /    \ /   \  |    __)__
                            \      \__\  \  /   /___\   \  /      Y     \ |         \
                             \            \/      |      \/       |      \|          \
                              \_________  /\______|____  /\_______|____  //________  /
                                        \/             \/              \/          \/
                                                  ____________ _____       _______________________________
                                                  \           \\    \     /    /\__          /\______     \
                                                   \_______    \\    \   /    /  |    ______/   |          \
                                                     /    |     \\    \ /    /   |    __)__     |        __/
                                                    /     |      \\    Y    /    |         \    |         \
                                                   /      |       \\       /     |          \   |     |    \
                                                   \____________  / \___  /      /________  /   |_____|__  /
                                                                \/      \/                \/             \/
            ");
            Console.WriteLine();
            Console.WriteLine("Vous avez échoué ... L'univers, surpeuplé, étouffera ... Vous n'avez pas réussi à le sauver ...");
            Console.ReadLine();
            end = true;
            Console.Clear();
            Console.ReadLine();
        }
        
        #endregion
    }
}

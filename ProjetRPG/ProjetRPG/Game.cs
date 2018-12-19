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
        static bool end;

        #region Methodes

        public static void MainGame(Player player, Map map)
        {
            end = false;

            while (!end)
            {
                if (!map.box[player.position[0], player.position[1]].visited)
                {
                    if (map.box[player.position[0], player.position[1]].ennemy != null)
                    {
                        Ennemy e = map.box[player.position[0], player.position[1]].ennemy;
                        if (e.Name == "Vision")
                        {
                            Thor T = new Thor();
                            player.Fight(e, T);
                        }
                        else
                        {
                            player.Fight(e);
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

                if (player.lifePoints > 0)
                {
                    bool next = false;

                    while (!next)
                    {
                        Console.WriteLine("1 : Avancer");
                        Console.WriteLine("2 : Regarder dans l'inventaire");
                        Console.WriteLine("3 : Voir la carte");
                        Console.WriteLine("4 : Voir les statistiques");
                        int c = Menu.AskChoice("Qu'allez-vous faire ?", 1, 4);

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
                                map.ShowMap();
                                break;
                            case 4:
                                player.ShowStats();
                                break;
                        }
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }
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

 ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄            ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄  ▄▄▄▄▄▄▄▄▄▄▄ 
▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌          ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░▌      ▐░▌▐░░░░░░░░░░░▌
▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀ ▐░▌           ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀  ▀▀▀▀█░█▀▀▀▀  ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌ ▀▀▀▀█░█▀▀▀▀  ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░▌░▌     ▐░▌▐░█▀▀▀▀▀▀▀▀▀ 
▐░▌          ▐░▌          ▐░▌               ▐░▌     ▐░▌               ▐░▌          ▐░▌     ▐░▌       ▐░▌     ▐░▌          ▐░▌     ▐░▌       ▐░▌▐░▌▐░▌    ▐░▌▐░▌          
▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄ ▐░▌               ▐░▌     ▐░▌               ▐░▌          ▐░▌     ▐░█▄▄▄▄▄▄▄█░▌     ▐░▌          ▐░▌     ▐░▌       ▐░▌▐░▌ ▐░▌   ▐░▌▐░█▄▄▄▄▄▄▄▄▄ 
▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌               ▐░▌     ▐░▌               ▐░▌          ▐░▌     ▐░░░░░░░░░░░▌     ▐░▌          ▐░▌     ▐░▌       ▐░▌▐░▌  ▐░▌  ▐░▌▐░░░░░░░░░░░▌
▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀ ▐░▌               ▐░▌     ▐░▌               ▐░▌          ▐░▌     ▐░█▀▀▀▀▀▀▀█░▌     ▐░▌          ▐░▌     ▐░▌       ▐░▌▐░▌   ▐░▌ ▐░▌ ▀▀▀▀▀▀▀▀▀█░▌
▐░▌          ▐░▌          ▐░▌               ▐░▌     ▐░▌               ▐░▌          ▐░▌     ▐░▌       ▐░▌     ▐░▌          ▐░▌     ▐░▌       ▐░▌▐░▌    ▐░▌▐░▌          ▐░▌
▐░▌          ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄  ▄▄▄▄█░█▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄  ▄▄▄▄█░█▄▄▄▄      ▐░▌     ▐░▌       ▐░▌     ▐░▌      ▄▄▄▄█░█▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▐░▌     ▐░▐░▌ ▄▄▄▄▄▄▄▄▄█░▌
▐░▌          ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░▌     ▐░▌       ▐░▌     ▐░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌      ▐░░▌▐░░░░░░░░░░░▌
 ▀            ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀       ▀         ▀       ▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀        ▀▀  ▀▀▀▀▀▀▀▀▀▀▀ 
                                                                                                                                                                         

            ");
            end = true;
            Console.ReadLine();
            Console.Clear();
        }

        public static void GameOver()
        {
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(@"
            
 ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄       ▄▄  ▄▄▄▄▄▄▄▄▄▄▄       ▄▄▄▄▄▄▄▄▄▄▄  ▄               ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄ 
▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░▌     ▐░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░▌             ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░▌░▌   ▐░▐░▌▐░█▀▀▀▀▀▀▀▀▀      ▐░█▀▀▀▀▀▀▀█░▌ ▐░▌           ▐░▌ ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌
▐░▌          ▐░▌       ▐░▌▐░▌▐░▌ ▐░▌▐░▌▐░▌               ▐░▌       ▐░▌  ▐░▌         ▐░▌  ▐░▌          ▐░▌       ▐░▌
▐░▌ ▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▐░▌ ▐░▐░▌ ▐░▌▐░█▄▄▄▄▄▄▄▄▄      ▐░▌       ▐░▌   ▐░▌       ▐░▌   ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌
▐░▌▐░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌  ▐░▌  ▐░▌▐░░░░░░░░░░░▌     ▐░▌       ▐░▌    ▐░▌     ▐░▌    ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
▐░▌ ▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌   ▀   ▐░▌▐░█▀▀▀▀▀▀▀▀▀      ▐░▌       ▐░▌     ▐░▌   ▐░▌     ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀█░█▀▀ 
▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌               ▐░▌       ▐░▌      ▐░▌ ▐░▌      ▐░▌          ▐░▌     ▐░▌  
▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄      ▐░█▄▄▄▄▄▄▄█░▌       ▐░▐░▌       ▐░█▄▄▄▄▄▄▄▄▄ ▐░▌      ▐░▌ 
▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌        ▐░▌        ▐░░░░░░░░░░░▌▐░▌       ▐░▌
 ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀  ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀▀▀▀▀▀▀▀▀▀          ▀          ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀ 
                                                                                                                   
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

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
using ProjetRPG.Characters.Boss;

namespace ProjetRPG.Board
{
    class Map
    {
        #region Variables

        public Case[,] box;

        #endregion

        #region Constructeurs

        public Map()
        {
            box = new Case[5, 5];
            box[0, 0] = new Case(new Gamorra());
            box[0, 1] = new Case(new Warrior());
            box[0, 2] = new Case(new Heal());
            box[0, 3] = new Case(new CaptainAmerica());
            box[0, 4] = new Case(new Vision());
            box[1, 0] = new Case(new StarLord());
            box[1, 1] = new Case(new Booster());
            box[1, 2] = new Case(new Witch());
            box[1, 3] = new Case(new ScarletWitch());
            box[1, 4] = new Case(new Attack());
            box[2, 0] = new Case(new Witch());
            box[2, 1] = new Case(new Heal());
            box[2, 2] = new Case(new Witch());
            box[2, 3] = new Case(new Booster());
            box[2, 4] = new Case(new Witch());
            box[3, 0] = new Case(new Warrior());
            box[3, 1] = new Case(new Attack());
            box[3, 2] = new Case(new Warrior());
            box[3, 3] = new Case(new Heal());
            box[3, 4] = new Case(new SpiderMan());
            box[4, 0] = new Case(new Hulk());
            box[4, 1] = new Case(new Booster());
            box[4, 2] = new Case(new Warrior());
            box[4, 3] = new Case(new IronMan());
            box[4, 4] = new Case(new DoctorStrange());
        }

        public Map(int x)
        {
            x = 1;
            box = new Case[x , x];
            box[0, 0] = new Case(new Thor());
        }

        #endregion

        #region Methodes

        public void ShowMap(Player player)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    try
                    {
                        if (player.position[0] == x && player.position[1] == y)
                            box[x, y].DisplayPlayer();
                        else
                            box[x, y].Display();
                    }
                    catch (NullReferenceException)
                    {
                        Console.Write("[n]");
                    }
                    if (y == 4)
                    {
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine();
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("P");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] : Votre position actuelle");
            Console.WriteLine();
            Console.WriteLine("[B] : Boss");
            Console.WriteLine("[E] : Ennemy");
            Console.WriteLine("[P] : Pierre (Une pierre de pouvoir moins puissante qu'une pierre d'Infinitée mais peut être utile en combat)");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("x");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] : Emplacement déjà visité");
        }

        #endregion
    }
}

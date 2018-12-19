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
        //TODO Class Map
        #region Variables

        public Case[,] map;

        #endregion

        #region Constructeurs

        public Map()
        {
            map = new Case[5, 5];
            map[0, 0] = new Case(new Gamorra());
            map[0, 1] = new Case(new Warrior());
            map[0, 2] = new Case(new Heal());
            map[0, 3] = new Case(new CaptainAmerica());
            map[0, 4] = new Case(new Vision());
            map[1, 0] = new Case(new StarLord());
            map[1, 1] = new Case(new Booster());
            map[1, 2] = new Case(new Witch());
            map[1, 3] = new Case(new ScarletWitch());
            map[1, 4] = new Case(new Attack());
            map[2, 0] = new Case(new Witch());
            map[2, 1] = new Case(new Heal());
            map[2, 2] = new Case(new Witch());
            map[2, 3] = new Case(new Booster());
            map[2, 4] = new Case(new Witch());
            map[3, 0] = new Case(new Warrior());
            map[3, 1] = new Case(new Attack());
            map[3, 2] = new Case(new Warrior());
            map[3, 3] = new Case(new Heal());
            map[3, 4] = new Case(new SpiderMan());
            map[4, 0] = new Case(new Hulk());
            map[4, 1] = new Case(new Booster());
            map[4, 2] = new Case(new Warrior());
            map[4, 3] = new Case(new IronMan());
            map[4, 4] = new Case(new DoctorStrange());
        }

        #endregion

        #region Methodes

        public void ShowMap()
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    try
                    {
                        map[x, y].Display();
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
        }

        #endregion
    }
}

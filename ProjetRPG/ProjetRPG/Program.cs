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
            //TODO Main Program
            Map map = new Map();
            map.ShowMap();

            Console.ReadLine();
        }
    }
}

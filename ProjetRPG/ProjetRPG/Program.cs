﻿using ProjetRPG;
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
    class Program
    {
        static void Main(string[] args)
        {
            //TODO Main Program
            Player p = new Player();
            Warrior w = new Warrior();

            p.Fight(w);

            Console.ReadLine();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG.Characters.Boss
{
    class SpiderMan : Warrior
    {
        public SpiderMan()
        {
            name = "SpiderMan";
            lifePoints = 22;
            maxLifePoints = lifePoints;
            force = 4;
            stamina = 7;
        }
    }
}

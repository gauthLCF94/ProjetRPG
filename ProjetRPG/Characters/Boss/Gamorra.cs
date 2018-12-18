using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG.Characters.Boss
{
    class Gamorra : Warrior
    {
        public Gamorra()
        {
            name = "Gamorra";
            lifePoints = 25;
            maxLifePoints = lifePoints;
            force = 7;
            stamina = 7;
            drop = 'i';
        }
    }
}

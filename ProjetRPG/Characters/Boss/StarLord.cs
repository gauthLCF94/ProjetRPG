using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG.Characters.Boss
{
    class StarLord : Warrior
    {
        public StarLord()
        {
            name = "StarLord";
            lifePoints = 20;
            maxLifePoints = lifePoints;
            force = 5;
            stamina = 5;
            drop = 'i';
        }
    }
}

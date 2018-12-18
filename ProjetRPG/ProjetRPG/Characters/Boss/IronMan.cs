using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG.Characters.Boss
{
    class IronMan : Warrior
    {
        public IronMan()
        {
            name = "Iron Man";
            lifePoints = 25;
            maxLifePoints = lifePoints;
            force = 5;
            stamina = 9;
            drop = DropType();
        }
    }
}

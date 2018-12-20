using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG.Characters.Boss
{
    class BlackPanther : Warrior
    {
        public BlackPanther()
        {
            name = "Black Panther";
            type = EnnemyType.Boss;
            lifePoints = 30;
            maxLifePoints = lifePoints;
            force = 6;
            stamina = 5;
            drop = DropType();
        }
    }
}

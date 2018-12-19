using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG.Characters.Boss
{
    class Vision : Witch
    {
        public Vision()
        {
            name = "Vision";
            type = EnnemyType.Boss;
            lifePoints = 12;
            maxLifePoints = lifePoints;
            force = 2;
            stamina = 2;
            mana = 20;
            spirit = 7;
            drop = 'i';
        }
    }
}

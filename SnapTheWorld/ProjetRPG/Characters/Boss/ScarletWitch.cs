using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG.Characters.Boss
{
    class ScarletWitch : Witch
    {
        public ScarletWitch()
        {
            name = "Scarlet Witch";
            type = EnnemyType.Boss;
            lifePoints = 18;
            maxLifePoints = lifePoints;
            force = 0;
            stamina = 2;
            mana = 2000000;
            spirit = 10;
            drop = DropType();
        }
    }
}

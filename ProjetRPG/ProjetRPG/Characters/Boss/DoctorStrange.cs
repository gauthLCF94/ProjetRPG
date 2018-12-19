using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG.Characters.Boss
{
    class DoctorStrange : Witch
    {
        public DoctorStrange()
        {
            name = "Docteur Strange";
            type = EnnemyType.Boss;
            lifePoints = 15;
            maxLifePoints = lifePoints;
            force = 1;
            stamina = 3;
            mana = 100000;
            spirit = 9;
            drop = 'i';
        }
    }
}

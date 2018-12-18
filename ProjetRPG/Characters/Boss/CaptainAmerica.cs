using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG.Characters.Boss
{
    class CaptainAmerica : Warrior
    {
        public CaptainAmerica()
        {
            name = "Captain America";
            lifePoints = 30;
            maxLifePoints = lifePoints;
            force = 7;
            stamina = 7;
            drop = DropType();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG.Characters.Boss
{
    class Hulk : Warrior
    {
        public Hulk()
        {
            name = "Hulk";
            lifePoints = 20;
            maxLifePoints = lifePoints;
            force = 5;
            stamina = 6;
            drop = 'i';
        }

        public override int Attack()
        {
            return base.Attack();
        }

    }
}

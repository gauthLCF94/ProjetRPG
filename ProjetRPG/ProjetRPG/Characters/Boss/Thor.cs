using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG.Characters.Boss
{
    class Thor : Witch
    {
        public Thor()
        {
            name = "Thor";
            type = EnnemyType.Boss;
            lifePoints = 50;
            maxLifePoints = lifePoints;
            force = 10;
            stamina = 9;
            mana = 5;
            spirit = 9;
            drop = 'i';
        }

        public override int Spell()
        {
            mana -= 5;
            return spirit;
        }

        public override int Attack()
        {
            if (mana - 5 < 0)
                return base.Attack();
            else
                return Spell();
        }
    }
}

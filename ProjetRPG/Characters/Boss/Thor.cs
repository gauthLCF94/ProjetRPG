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
            lifePoints = 50;
            maxLifePoints = lifePoints;
            force = 10;
            stamina = 9;
            mana = 5;
            spirit = 9;
        }

        public override void Spell(Fighter cible)
        {
            cible.lifePoints -= spirit;
            mana -= 5;
        }

        public override void Attack(Fighter cible)
        {
            if (mana - 5 < 0)
                base.Attack(cible);
            else
                Spell(cible);
        }
    }
}

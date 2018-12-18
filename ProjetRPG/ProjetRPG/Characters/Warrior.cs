using ProjetRPG;
using ProjetRPG.Stones;
using ProjetRPG.Stones.InfinityStones;
using ProjetRPG.Characters;
using ProjetRPG.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Warrior : Ennemy
    {
        #region Constructeurs

        public Warrior()
        {
            name = "Guerrier téméraire";
            lifePoints = 20;
            maxLifePoints = lifePoints;
            force = 3;
            stamina = 4;
            drop = DropType();
        }

        #endregion

        #region Methodes

        public override int Attack()
        {
            return base.Attack();
        }

        #endregion
    }
}

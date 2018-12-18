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

namespace ProjetRPG.Stones
{
    abstract class InfinityStone : Stone
    {
        #region Variables

        protected int stoneLifePoints;
        protected int stoneForcePoints;
        protected int stoneStaminaPoints;

        #endregion

        #region Methodes

        public void Upgrade(Player cible)
        {
            cible.lifePoints += StoneLifePoints;
            cible.force += StoneForcePoints;
            cible.stamina += StoneStaminaPoints;
        }

        public virtual int SpecialAttack(Player player)
        {
            return 0;
        }

        #endregion



    }
}

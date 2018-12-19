using ProjetRPG;
using ProjetRPG.Stones;
using ProjetRPG.Stones.InfinityStones;
using ProjetRPG.Characters;
using ProjetRPG.Board;
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
        protected int invIndex;

            #region Getter/Setter
            
        public int InvIndex
        {
            get { return invIndex; }
        }

            #endregion
       
        #endregion

        #region Methodes

        public void Upgrade(Player cible)
        {
            cible.lifePoints += stoneLifePoints;
            cible.force += stoneForcePoints;
            cible.stamina += stoneStaminaPoints;
        }

        public virtual int SpecialAttack(Player player)
        {
            return 0;
        }

        #endregion



    }
}

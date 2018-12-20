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

        public string Upgrade(Player cible)
        {
            cible.maxLifePoints += stoneLifePoints;
            cible.force += stoneForcePoints;
            cible.stamina += stoneStaminaPoints;

            string s = "Votre maximum de points de vie a augmenté de " + stoneLifePoints
                + " points, votre force a augmenté de " + stoneForcePoints
                + " points, et votre endurance a augmenté de " + stoneStaminaPoints
                + " points.";

            return s;
        }

        #endregion
    }
}

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

namespace ProjetRPG.Stones.InfinityStones
{
    class PowerStone : InfinityStone
    {
        #region Constructeurs

        public PowerStone()
        {
            name = "Pierre du Pouvoir";
            power = 6;
            stoneLifePoints = 5;
            stoneForcePoints = 3;
            stoneStaminaPoints = 1;
            description = "Un des six Pierres d'Infinité. Améliore votre santé maximal de " + stoneLifePoints +
                " points, votre force de " + stoneForcePoints + " points, et votre endurance de " + stoneStaminaPoints + " points." +
                " Attaque spéciale : inflige " + power * 2 + " points de dégâts à l'adversaire" ;
        }

        #endregion
    }
}

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
    class SoulStone : InfinityStone
    {
        #region Constructeurs

        public SoulStone()
        {
            name = "Pierre de l'Âme";
            power = 5;
            stoneLifePoints = 5;
            stoneForcePoints = 1;
            stoneStaminaPoints = 3;
            description = "Un des six Pierres d'Infinité. Améliore votre santé maximal de " + stoneLifePoints +
                " points, votre force de " + stoneForcePoints + " points, et votre endurance de " + stoneStaminaPoints + " points." +
                " Attaque spéciale : inflige " + power * 4 + " points de dégâts à l'adversaire et " + power + " à vous-même.";
        }

        #endregion
    }
}

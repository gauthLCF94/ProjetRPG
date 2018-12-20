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

namespace ProjetRPG.Stones.InfinityStones
{
    class PowerStone : InfinityStone
    {
        #region Constructeurs

        public PowerStone()
        {
            name = "Pierre du Pouvoir";
            invIndex = 0;
            power = 6;
            stoneLifePoints = 5;
            stoneForcePoints = 3;
            stoneStaminaPoints = 1;
            description = "Un des six Pierres d'Infinité.\nAméliore votre santé maximal de " + stoneLifePoints +
                " points, votre force de " + stoneForcePoints + " points, et votre endurance de " + stoneStaminaPoints + " points." +
                "\nAttaque spéciale : inflige " + power * 2 + " points de dégâts à l'adversaire" ;
            type = StoneType.Infinity;
        }

        #endregion
    }
}

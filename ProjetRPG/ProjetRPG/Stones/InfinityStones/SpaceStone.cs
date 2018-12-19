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
    class SpaceStone : InfinityStone
    {
        #region Constructeurs

        public SpaceStone()
        {
            name = "Pierre de l'Espace";
            invIndex = 1;
            power = 0;
            stoneLifePoints = 5;
            stoneForcePoints = 1;
            stoneStaminaPoints = 2;
            description = "Un des six Pierres d'Infinité.\nAméliore votre santé maximal de " + stoneLifePoints +
                " points, votre force de " + stoneForcePoints + " points, et votre endurance de " + stoneStaminaPoints + " points." +
                "\nAttaque spéciale : vous permet d'infliger le double de vos dégats de base.";
            type = StoneType.Infinity;
        }

        #endregion
    }
}

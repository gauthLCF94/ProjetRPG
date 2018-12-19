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
    class MindStone : InfinityStone
    {

        #region Constructeurs

        public MindStone()
        {
            name = "Pierre de l'Esprit";
            invIndex = 5;
            power = 0;
            stoneLifePoints = 2;
            stoneForcePoints = 2;
            stoneStaminaPoints = 2;
            description = "Un des six Pierres d'Infinité.\nAméliore votre santé maximal de " + stoneLifePoints +
                " points, votre force de " + stoneForcePoints + " points, et votre endurance de " + stoneStaminaPoints + " points." +
                "\nAttaque spéciale : double votre endurance jusqu'à la fin du combat.";
            type = StoneType.Infinity;
        }

        #endregion
    }
}

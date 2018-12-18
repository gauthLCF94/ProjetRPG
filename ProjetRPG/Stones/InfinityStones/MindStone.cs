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
    class MindStone : InfinityStone
    {

        #region Constructeurs

        public MindStone()
        {
            name = "Pierre de l'Esprit";
            power = 0;
            stoneLifePoints = 2;
            stoneForcePoints = 2;
            stoneStaminaPoints = 2;
            description = "Un des six Pierres d'Infinité. Améliore votre santé maximal de " + stoneLifePoints +
                " points, votre force de " + stoneForcePoints + " points, et votre endurance de " + stoneStaminaPoints + " points." +
                " Attaque spéciale : double votre endurance jusqu'à la fin du combat.";
        }

        #endregion
    }
}

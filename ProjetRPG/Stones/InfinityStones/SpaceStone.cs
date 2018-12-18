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
    class SpaceStone : InfinityStone
    {
        #region Constructeurs

        public SpaceStone()
        {
            name = "Pierre de l'Espace";
            power = 0;
            stoneLifePoints = 5;
            stoneForcePoints = 1;
            stoneStaminaPoints = 2;
            description = "Un des six Pierres d'Infinité. Améliore votre santé maximal de " + stoneLifePoints +
                " points, votre force de " + stoneForcePoints + " points, et votre endurance de " + stoneStaminaPoints + " points." +
                " Attaque spéciale : vous permet d'infliger le double de vos dégats de base."; 
        }

        #endregion
    }
}

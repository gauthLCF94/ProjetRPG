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
    class RealityStone : InfinityStone
    {
        #region Constructeurs

        public RealityStone()
        {
            name = "Pierre de Réalité";
            power = 0;
            stoneLifePoints = 10;
            stoneForcePoints = 1;
            stoneStaminaPoints = 1;
            description = "Un des six Pierres d'Infinité. Améliore votre santé maximal de " + stoneLifePoints +
                " points, votre force de " + stoneForcePoints + " points, et votre endurance de " + stoneStaminaPoints + " points." +
                " Attaque spéciale : augmente vos points de vie de " + stoneLifePoints * 4 + " jusqu'à la fin du combat." +
                "Si vos points de vie sont inférieur à " + stoneLifePoints * 4 + " à la fin du combat, vous mourrez ...";
        }

        #endregion

        #region Getter/Setter

        public int StoneLifePoints
        {
            get { return StoneLifePoints; }
        }

        #endregion
    }
}

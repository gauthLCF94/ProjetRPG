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
    class TimeStone : InfinityStone
    {
        #region Constructeurs

        public TimeStone()
        {
            name = "Pierre du Temps";
            invIndex = 3;
            power = 0;
            stoneLifePoints = 5;
            stoneForcePoints = 5;
            stoneStaminaPoints = 5;
            description = "Un des six Pierres d'Infinité. Améliore votre santé maximal de " + stoneLifePoints +
                " points, votre force de " + stoneForcePoints + " points, et votre endurance de " + stoneStaminaPoints + " points." +
                " Attaque spéciale : vous rend tous vos points de vie.";
        }

        #endregion
    }
}

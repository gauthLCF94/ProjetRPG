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
    class Booster : Stone
    {
        #region Constructeurs

        public Booster()
        {
            name = "Pierre d'Amélioration";
            power = 1;
            description = "Une pierre de pouvoir qui améliore vos statistiques de force et d'endurance de " + power + ".";
        }

        #endregion

        #region Methodes

        public void Use(Player cible)
        {
            cible.stamina += power;
            cible.force += power;
            cible.stoneInventory["Pierre d'Amélioration"] -= 1;
        }

        #endregion

    }
}

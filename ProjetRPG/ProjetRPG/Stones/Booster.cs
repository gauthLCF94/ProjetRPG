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
            name = "Gemme d'Amélioration";
            power = 1;
            description = "Une gemme de pouvoir qui améliore vos statistiques de force et d'endurance de " + power + ".";
            type = StoneType.Booster;
        }

        #endregion

        #region Methodes

        public void Use(Player cible)
        {
            cible.stamina += power;
            cible.force += power;
            cible.stoneInventory["Gemme d'Amélioration"] -= 1;
            Console.WriteLine("Votre force a augmenté de " + power + " point !");
            Console.WriteLine("Votre endurance a augmenté de " + power + " point !");
        }

        #endregion

    }
}

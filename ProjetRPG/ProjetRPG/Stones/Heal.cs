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

namespace ProjetRPG.Stones
{
    class Heal : Stone
    {
        #region Constructeur

        public Heal()
        {
            name = "Pierre de Soin";
            power = 7;
            description = "Une pierre de pouvoir qui rend " + power + " points de vie.";
        }

        #endregion

        #region Methodes

        public void Use(Player cible)
        {
            Console.WriteLine("Vous utilisez " + name);
            if (cible.lifePoints + power > cible.MaxLifePoints)
            {
                cible.lifePoints = cible.MaxLifePoints;
                Console.WriteLine("Vos points de vie ont été restaurés au maximum, vous avez " + cible.MaxLifePoints + " points de vie.");
            }
            else
            { 
                cible.lifePoints += power;
                Console.WriteLine("Vos points de vie ont été réstaurés de " + power + ", vous avez " + cible.lifePoints + " points de vie.");
            }
            cible.stoneInventory["Pierre de Soin"] -= 1;
        }

        #endregion

    }
}

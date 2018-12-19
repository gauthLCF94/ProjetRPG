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
    class Attack : Stone
    {
        #region Constructeur

        public Attack()
        {
            name = "Pierre de Dégâts";
            power = 15;
            description = "Un pierre de pouvoir qui inflige " + power + " points de dégâts à l'adversaire.";
        }

        #endregion

        #region Methodes

        public void Use(Ennemy cible, Player player)
        {
            cible.lifePoints -= power;
            player.stoneInventory["Pierre de Dégâts"] -= 1;
            Console.WriteLine(cible.Name + " perd " + power + " points de vie !");
        }

        #endregion
    }
}

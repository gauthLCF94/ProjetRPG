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
            name = "Gemme de Dégâts";
            power = 15;
            description = "Un gemme de pouvoir qui inflige " + power + " points de dégâts à l'adversaire.";
            type = StoneType.Attack;
        }

        #endregion

        #region Methodes

        public void Use(Ennemy cible, Player player)
        {
            cible.lifePoints -= power;
            player.stoneInventory["Gemme de Dégâts"] -= 1;
            Console.WriteLine("Vous lancez la gemme de toutes vos forces sur " + cible.Name + " !");
            Console.WriteLine("La gemme explose et inflige " + power + " points de dégâts !");
        }

        #endregion
    }
}

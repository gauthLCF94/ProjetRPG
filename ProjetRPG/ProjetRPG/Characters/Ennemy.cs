﻿using ProjetRPG;
using ProjetRPG.Stones;
using ProjetRPG.Stones.InfinityStones;
using ProjetRPG.Characters;
using ProjetRPG.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    abstract class Ennemy : Fighter
    {
        public enum EnnemyType { Boss, Witch, Warrior };

        #region Variables

        protected char drop;
        protected EnnemyType type;

        #region Getter/Setter

        public char Drop
        {
            get { return drop; }
        }

        public EnnemyType Type
        {
            get { return type; }
        }

            #endregion

        #endregion

        #region Methodes

        public override bool AreYouDead()
        {
            return base.AreYouDead();
        }

        protected char DropType()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            switch (r.Next() % 3)
            {
                case 0:
                    return 'h'; // h -> heal
                case 1:
                    return 'a'; // a -> attack
                case 2:
                    return 'b'; // b -> booster
                default:
                    return 'h';
            }
        }

        #endregion

    }
}

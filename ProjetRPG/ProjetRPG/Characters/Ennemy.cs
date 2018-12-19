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

            if (r.Next() % 100 < 50)
            {
                r = new Random(DateTime.Now.Millisecond);
                if (r.Next() % 100 < 50)
                    return 'a';
                else
                    return 'h';
            }
            else
                return 'b';
        }

        #endregion

    }
}

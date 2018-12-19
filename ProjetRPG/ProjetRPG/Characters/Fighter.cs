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

namespace ProjetRPG.Characters
{
    class Fighter
    {
        #region Variables

        protected string name;
        public int lifePoints;
        public int maxLifePoints;
        public int force;
        public int stamina;

        #endregion

        #region Getter/Setter
        
        public string Name
        {
            get { return name; }
        }
        
        #endregion

        #region Methodes

        public virtual int Attack()
        {
           return force + (stamina /3);
        }

        public void Damage(int degats)
        {
            lifePoints -= degats;
        }
        
        public bool Protect()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            if (r.Next() % 100 > stamina)
                return false;
            else
                return true;
        }

        public virtual bool AreYouDead()
        {
            if (lifePoints <= 0)
            {
                Console.WriteLine(Name + " est K.O ...");
                return true;
            }
            else
            {
                Console.WriteLine(Name + " n'a plus que " + lifePoints + " points de vie.");
                return false;
            }
        }

        #endregion
    }
}

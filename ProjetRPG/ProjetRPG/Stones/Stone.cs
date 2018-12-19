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
    abstract class Stone
    {
        #region Variables

        protected string name;
        protected string description;
        protected int power;

            #region Getter/Setter

        public string Name
        {
            get { return name; }
        }

        public int Power
        {
            get { return power; }
        }

            #endregion

        #endregion
    }
}

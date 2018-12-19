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
        public enum StoneType {Booster, Heal, Attack, Infinity};

        protected string name;
        protected string description;
        protected int power;
        protected StoneType type;

            #region Getter/Setter

        public string Name
        {
            get { return name; }
        }

        public int Power
        {
            get { return power; }
        }
        
        public StoneType Type
        {
            get { return type; }
        }

        public string Description
        {
            get { return description; }
        }

        #endregion

        #endregion

        #region Methodes

        public string Desc()
        {
            return Description;
        }

        #endregion
    }
}

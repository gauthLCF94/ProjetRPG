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
    abstract class Stone
    {
        #region Variables

        protected string name;
        protected string description;
        protected int power;

        #endregion

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

        #region Methodes

        public void PickUp()
        {
            //TODO Stone PickUp()
        }

        public void Leave()
        {
            //TODO Stone Leave()
        }

        #endregion



    }
}

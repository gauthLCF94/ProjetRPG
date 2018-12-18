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

namespace ProjetRPG
{
    abstract class Ennemy : Fighter
    {
        #region Variables

        protected char drop;

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

        public virtual Stone WhatYouDrop(Ennemy E)
        {
            switch (E.drop)
            {
                case 'h':
                    return new Heal();
                case 'a':
                    return new Attack();
                case 'b':
                    return new Booster();
                case 'i':
                    switch (E.name)
                    {
                        case "Hulk":
                            return new SpaceStone();
                        case "Vision":
                            return new MindStone();
                        case "Docteur Strange":
                            return new TimeStone();
                        case "Gamorra":
                            return new SoulStone();
                        case "StarLord":
                            return new RealityStone();
                        default:
                            return new SpaceStone();
                    }
                default:
                    return new Heal();
            }
        }

        #endregion

    }
}

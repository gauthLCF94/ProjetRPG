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

namespace ProjetRPG.Characters
{
    class Player : Fighter
    {
        #region Variables

        InfinityStone[] InfinityStoneInventory = new InfinityStone[6];
        Dictionary <string, int> StoneInventory = new Dictionary<string, int>();

        #endregion

        #region Constructeurs
        public Player()
        {
            name = "Thanos";
            lifePoints = 30;
            maxLifePoints = lifePoints;
            force = 7;
            stamina = 6;
            StoneInventory.Add("Pierre de soin", 1);
            StoneInventory.Add("Pierre d'attaque", 1);
            StoneInventory.Add("Pierre d'amélioration", 0);
        }

        #endregion

        #region Methodes
        
        // Les attaques du joueur
        //Attaque basique
        public override int Attack()
        {
            return base.Attack();
        }

        //Attaques spéciales
        public void TimeStoneSA()
        {
            lifePoints = maxLifePoints;
            Console.WriteLine("Vos points de vie ont été complètement restaurés.");
        }
        
        public int SpaceStoneSA()
        {
            return Attack() * 2;
        }

        public int SoulStoneSA(SoulStone x)
        {
            return x.Power;
        }

        public int RealityStoneSA(RealityStone x)
        {
            lifePoints += x.StoneLifePoints;
            return x.StoneLifePoints;
        }

        public int PowerStoneSA(PowerStone x)
        {
            return x.Power * 2;
        }

        public int MindStoneSA()
        {
            int playerStamina = stamina;
            stamina = stamina * 2;
            return playerStamina;
        }
        //Fin attaques

        //Déplacement
        public void Move()
        {
            Console.WriteLine("1 : Aller en haut");
            Console.WriteLine("2 : Aller à droite");
            Console.WriteLine("3 : Aller en bas");
            Console.WriteLine("4 : Aller à gauche");
            Console.WriteLine("5 : Retour");
            int c = Menu.AskChoice(1, 4);

            switch (c)
            {
                case 1:
                    //Bouger vers le haut
                    break;
                case 2:
                    //bouger vers la droite
                    break;
                case 3:
                    //bouger vers le bas
                    break;
                case 4:
                    //bouger vers la gauche
                    break;
                case 5:
                    //retour
                    break;
            }
        }
        
        //Inventaire
        public void ShowInventory()
        {
            Console.WriteLine("INVENTAIRE");
            Console.WriteLine("1 : Poche à pierres");
            Console.WriteLine("2 : Poche à Pierres d'Infinitées");
        }

        public void ShowStoneInventory()
        {
            Console.WriteLine("POCHE A PIERRE");
            foreach (KeyValuePair<string, int> stone in StoneInventory)
            {
                Console.WriteLine(stone.Key + " : " + stone.Value);
            }
        }

        public void ShowInfinityStoneInventory()
        {
            Console.WriteLine("POCHE A PIERRES D'INFINITEES");
            for (int i = 0; i < InfinityStoneInventory.Length; i++)
            {
                Console.WriteLine(i + 1 + " : " + InfinityStoneInventory[i].Name);
            }
        }

        //Mort
        public override bool AreYouDead()
        {
            if (lifePoints <= 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}

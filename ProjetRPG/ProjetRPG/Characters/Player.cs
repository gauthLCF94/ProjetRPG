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

        public InfinityStone[] infinityStoneInventory = new InfinityStone[6];
        protected Dictionary <string, int> stoneInventory = new Dictionary<string, int>();

        #endregion

        #region Constructeurs
        public Player()
        {
            name = "Thanos";
            lifePoints = 30;
            maxLifePoints = lifePoints;
            force = 7;
            stamina = 6;
            infinityStoneInventory[0] = new PowerStone();
            stoneInventory.Add("Pierre de Soin", 1);
            stoneInventory.Add("Pierre de Dégâts", 1);
            stoneInventory.Add("Pierre d'Amélioration", 0);
        }

        #endregion

        #region Methodes

            #region Attaques

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

        public bool RealityStoneSA(RealityStone x)
        {
            lifePoints += x.StoneLifePoints;
            return true;
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

        #endregion

            #region Combat

        public void Fight(Ennemy cible)
        {
            int tour = 0;

            bool RSused = false;
            bool endFight = false;
            bool win = false;

            Console.Clear();
            Console.WriteLine(cible.Name + " vous barre le chemin.");
            Console.ReadLine();

            while (!endFight)
            {
                tour++;

                Console.WriteLine(cible.Name + " a " + cible.lifePoints + " points de vie.");
                Console.WriteLine("Vous avez " + lifePoints + " points de vie.");
                Console.ReadLine();
                Console.WriteLine(" ");
                Console.WriteLine("1 : Attaquer");
                Console.WriteLine("2 : Utiliser une attaque spéciale");
                Console.WriteLine("3 : Utiliser une pierre");
                int c = Menu.AskChoice(1, 3);

                switch (c)
                {
                    case 1:
                        if (cible.Protect())
                            Console.WriteLine(cible.Name + " se protége et ne subit pas de dégâts.");
                        else
                        {
                            int PlayerDegat = Attack();
                            cible.Damage(PlayerDegat);
                            Console.WriteLine(cible.Name + " perd " + PlayerDegat + " points de vie.");
                            if (cible.AreYouDead())
                            {
                                win = true;
                                endFight = true;
                            }
                        }
                        break;
                    case 2:
                        ShowInfinityStoneInventory();
                        UseInfinityStone(Menu.AskChoice(1, 6), cible);
                        if (cible.AreYouDead())
                        {
                            win = true;
                            endFight = true;
                        }
                        break;
                    case 3:
                        ShowStoneInventory();
                        UseStone(Menu.AskChoice(1, 3), cible);
                        if (cible.AreYouDead())
                        {
                            win = true;
                            endFight = true;
                        }
                        break;
                }

                if (endFight == false)
                {
                    Console.ReadLine();
                    Console.WriteLine(cible.Name + " va attaquer !");
                    if (Protect())
                        Console.WriteLine("Vous vous protégez et ne subissez pas de dégâts.");
                    else
                    {
                        int EnnemyDegat = cible.Attack();
                        Damage(EnnemyDegat);
                        Console.WriteLine("Vous perdez " + EnnemyDegat + " points de vie.");
                        if (AreYouDead())
                        {
                            endFight = true;
                        }
                        break;
                    }
                }
            }

            if (win)
            {
                Console.WriteLine("Vous avez vaincu " + cible.Name + ".");
                if (RSused == true)
                {
                    lifePoints -= 40;
                }
            }
            else
            {
                Console.WriteLine(cible.Name + " vous a tué.");
                Game.GameOver();
            }
        }

            #endregion

            #region Deplacement

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

            #endregion

            #region Inventaire
        
        public void ShowInventory()
        {
            Console.WriteLine("INVENTAIRE");
            Console.WriteLine("1 : Poche à pierres");
            Console.WriteLine("2 : Poche à Pierres d'Infinitées");
        }

        public void ShowStoneInventory()
        {
            int count = 1;

            Console.WriteLine("POCHE A PIERRE");
            foreach (KeyValuePair<string, int> stone in stoneInventory)
            {
                Console.WriteLine(count + " : " + stone.Key + " (" + stone.Value + ")");
                count++;
            }
        }

        public void UseStone(int c, Ennemy cible)
        {
            switch (c)
            {
                case 1:
                    if (stoneInventory["Pierre de Soin"] > 0)
                    {
                        Heal h = new Heal();
                        h.Use(this);
                    }
                    else
                        Console.WriteLine("Vous n'avez plus de pierre de soin");
                    break;

                case 2:
                    if (stoneInventory["Pierre de Dégâts"] > 0)
                    {
                        Attack a = new Attack();
                        a.Use(cible);
                    }
                    else
                        Console.WriteLine("Vous n'avez plus de pierre de dégâts");
                    break;

                case 3:
                    if (stoneInventory["Pierre d'Amélioration"] > 0)
                    {
                        Booster b = new Booster();
                        b.Use(this);
                    }
                    else
                        Console.WriteLine("Vous n'avez plus de pierre d'amélioration");
                    break;
            }
        }

        public void ShowInfinityStoneInventory()
        {
            Console.WriteLine("POCHE A PIERRES D'INFINITEES");
            for (int i = 0; i < infinityStoneInventory.Length; i++)
            {
                try
                {
                    Console.WriteLine(i + 1 + " : " + infinityStoneInventory[i].Name);
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine(i + 1 + " : Vide");
                }
            }
        }

        public void UseInfinityStone(int c, Ennemy cible)
        {
            switch (c)
            {
                case 1:
                    if (infinityStoneInventory[c-1] != null)
                    {
                        PowerStone p = new PowerStone();
                        cible.Damage(PowerStoneSA(p));
                    }
                    else
                    {
                        Console.WriteLine("Vous n'êtes pas en possession de cette pierre ...");
                    }
                    break;
                case 2:
                    if (infinityStoneInventory[c - 1] != null)
                    {
                        cible.Damage(SpaceStoneSA());
                    }
                    else
                    {
                        Console.WriteLine("Vous n'êtes pas en possession de cette pierre ...");
                    }
                    break;
                case 3:
                    if (infinityStoneInventory[c - 1] != null)
                    {
                        RealityStone r = new RealityStone();
                        bool RSused = RealityStoneSA(r);
                    }
                    else
                    {
                        Console.WriteLine("Vous n'êtes pas en possession de cette pierre ...");
                    }
                    break;
                case 4:
                    if (infinityStoneInventory[c - 1] != null)
                    {
                        TimeStoneSA();
                    }
                    else
                    {
                        Console.WriteLine("Vous n'êtes pas en possession de cette pierre ...");
                    }
                    break;
                case 5:
                    if (infinityStoneInventory[c - 1] != null)
                    {
                        SoulStone s = new SoulStone();
                        SoulStoneSA(s);
                    }
                    else
                    {
                        Console.WriteLine("Vous n'êtes pas en possession de cette pierre ...");
                    }
                    break;
                case 6:
                    if (infinityStoneInventory[c - 1] != null)
                    {
                        MindStoneSA();
                    }
                    else
                    {
                        Console.WriteLine("Vous n'êtes pas en possession de cette pierre ...");
                    }
                    break;
            }
        }

        public void PickUp(Stone x)
        {
            switch (x.Name)
            {
                case "Pierre de Soin":
                    stoneInventory[x.Name] += 1;
                    break;
                case "Pierre de Dégâts":
                    stoneInventory[x.Name] += 1;
                    break;
                case "Pierre d'Amélioration":
                    stoneInventory[x.Name] += 1;
                    break;
            }
        }
            #endregion

        public override bool AreYouDead()
        {
            if (lifePoints > 0)
                return false;
            else
                return true;
        }

        #endregion
    }
}

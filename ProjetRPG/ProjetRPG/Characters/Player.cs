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
    class Player : Fighter
    {
        #region Variables

        public InfinityStone[] infinityStoneInventory = new InfinityStone[6];
        public Dictionary <string, int> stoneInventory = new Dictionary<string, int>();

        public bool usedRS;
        public int usedMS;

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
            usedRS = false;
            usedMS = 0;
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
            
            bool endFight = false;
            bool win = false;
            bool usedSA = false;

            int usingStone = 0;
            int endRegenSA = 0;
            int usingSA = 0;

            Console.Clear();
            Console.WriteLine(cible.Name + " vous barre le chemin.");
            Console.ReadLine();

            while (!endFight)
            {
                tour++;

                #region Actions du joueur

                Console.WriteLine(cible.Name + " a " + cible.lifePoints + " points de vie.");
                Console.WriteLine("Vous avez " + lifePoints + " points de vie.");
                Console.ReadLine();
                Console.WriteLine("1 : Attaquer");
                Console.WriteLine("2 : Utiliser une attaque spéciale");
                Console.WriteLine("3 : Utiliser une pierre");
                int c = Menu.AskChoice("Que faire ?", 1, 3);

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
                        if (!usedSA)
                        {
                            ShowInfinityStoneInventory();
                            if (UseInfinityStone(Menu.AskChoice("Quelle Pierre d'Infinité voulez-vous utilisez ?", 1, 6), cible))
                            {
                                usedSA = true;
                                endRegenSA = tour + 2;
                                if (cible.AreYouDead())
                                {
                                    win = true;
                                    endFight = true;
                                }
                                break;
                            }
                            else
                            {
                                if (usingSA == 0)
                                {
                                    usingSA++;
                                    goto case 2;
                                }
                                else
                                {
                                    usingSA = 0;
                                    Console.WriteLine("Vous avez perdu trop de temps !");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.Write("Vous ne pouvez pas utiliser vos Pierres d'Infinités pour l'instant !");
                            if (tour == endRegenSA)
                            {
                                usedSA = false;
                            }
                            goto default;
                        }
                    case 3:
                        ShowStoneInventory();
                        if (!UseStone(Menu.AskChoice("Quelle pierre voulez-vous utilisez ?", 1, 3), cible, this))
                        {
                            if (usingStone == 0)
                            {
                                usingStone++;
                                goto case 3;
                            }
                            else
                            {
                                usingStone = 0;
                                Console.WriteLine("Vous avez perdu trop de temps !");
                                break;
                            }
                        }
                        else
                        {
                            if (cible.AreYouDead())
                            {
                                win = true;
                                endFight = true;
                            }
                            break;
                        }
                        
                    default:
                        Console.WriteLine("1 : Attaquer");
                        Console.WriteLine("2 : Utiliser une attaque spéciale");
                        Console.WriteLine("3 : Utiliser une pierre");
                        c = Menu.AskChoice("Que faire ?", 1, 3);
                        if (c == 1)
                        {
                            goto case 1;
                        }
                        else if (c == 2)
                        {
                            Console.Write("Vous ne pouvez pas utiliser vos Pierres d'Infinités pour l'instant ...");
                            Console.WriteLine("Vous avez perdu trop de temps !");
                        }
                        else
                        {
                            goto case 3;
                        }
                        break;
                }

                #endregion

                #region Action du PNJ Ennemy

                if (endFight == false)
                {
                    Console.ReadLine();
                    Console.WriteLine(cible.Name + " attaque !");
                    if (Protect())
                        Console.WriteLine("Vous vous protégez et ne subissez pas de dégâts.");
                    else
                    {
                        int EnnemyDegat = cible.Attack();
                        Damage(EnnemyDegat);
                        Console.WriteLine("Vous perdez " + EnnemyDegat + " points de vie.");
                        if (AreYouDead() == true)
                            endFight = true;
                    }
                }

                #endregion
            }

            if (win)
            {
                Console.WriteLine("Vous avez vaincu " + cible.Name + ".");
                if (usedRS == true)
                {
                    lifePoints -= 40;
                    usedRS = false;
                    Console.WriteLine("Vous perdez 40 points de vie à cause du contre-coup de la Pierre de Réalité");
                    if (AreYouDead())
                    {
                        Console.WriteLine("Le contre-coup a été trop violent, et vous vous écroulez ... ");
                        Game.GameOver();
                    }
                }
                if (usedMS != 0)
                {
                    stamina = usedMS;
                    usedMS = 0;
                    Console.WriteLine("L'effet de la Pierre de l'Esprit s'est dissipé ...");
                }
                switch (switch_on)
                {
                    default:
                }
                Console.WriteLine("Vous fouillez le cadavre " + cible.Name + " ");
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
            int c = Menu.AskChoice("Où voulez-vous aller ?", 1, 4);

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

        public bool UseStone(int c, Ennemy cible, Player player)
        {
            switch (c)
            {
                case 1:
                    if (stoneInventory["Pierre de Soin"] > 0)
                    {
                        if (lifePoints == maxLifePoints)
                        {
                            Console.WriteLine("Vos points de vie sont déjà au maximum !");
                            return false;
                        }
                        else
                        {
                            Heal h = new Heal();
                            h.Use(this);
                            return true;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez plus de pierre de soin");
                        return false;
                    }
                case 2:
                    if (stoneInventory["Pierre de Dégâts"] > 0)
                    {
                        Attack a = new Attack();
                        a.Use(cible, player);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez plus de pierre de dégâts");
                        return false;
                    }
                case 3:
                    if (stoneInventory["Pierre d'Amélioration"] > 0)
                    {
                        Booster b = new Booster();
                        b.Use(this);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez plus de pierre d'amélioration");
                        return false;
                    }
                default:
                    return false;
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

        public bool UseInfinityStone(int c, Ennemy cible)
        {
            int degat;

            switch (c)
            {
                case 1:
                    if (infinityStoneInventory[c-1] != null)
                    {
                        PowerStone p = new PowerStone();
                        degat = PowerStoneSA(p);
                        cible.Damage(degat);
                        Console.WriteLine(cible.Name + " perd " + degat + " points de vie");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Vous n'êtes pas en possession de cette pierre ...");
                        return false;
                    }
                case 2:
                    if (infinityStoneInventory[c - 1] != null)
                    {
                        degat = SpaceStoneSA();
                        cible.Damage(degat);
                        Console.WriteLine(cible.Name + " perd " + degat + " points de vie");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Vous n'êtes pas en possession de cette pierre ...");
                        return false;
                    }
                case 3:
                    if (infinityStoneInventory[c - 1] != null)
                    {
                        RealityStone r = new RealityStone();
                        usedRS = RealityStoneSA(r);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Vous n'êtes pas en possession de cette pierre ...");
                        return false;
                    }
                case 4:
                    if (infinityStoneInventory[c - 1] != null)
                    {
                        TimeStoneSA();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Vous n'êtes pas en possession de cette pierre ...");
                        return false;
                    }
                case 5:
                    if (infinityStoneInventory[c - 1] != null)
                    {
                        SoulStone s = new SoulStone();
                        SoulStoneSA(s);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Vous n'êtes pas en possession de cette pierre ...");
                        return false;
                    }
                case 6:
                    if (infinityStoneInventory[c - 1] != null)
                    {
                        usedMS = MindStoneSA();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Vous n'êtes pas en possession de cette pierre ...");
                        return false;
                    }
                default:
                    return false;
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

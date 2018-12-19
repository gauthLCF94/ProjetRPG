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
using ProjetRPG.Characters.Boss;
using System.Threading;

namespace ProjetRPG.Characters
{
    class Player : Fighter
    {
        #region Variables
        
        public int[] position = new int[2];

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
            new PowerStone().Upgrade(this);
            stoneInventory.Add("Pierre de Soin", 1);
            stoneInventory.Add("Pierre de Dégâts", 1);
            stoneInventory.Add("Pierre d'Amélioration", 0);
            usedRS = false;
            usedMS = 0;
            position[0] = 4;
            position[1] = 0;
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
            Console.WriteLine("Vous avez " + lifePoints + " points de vie.");
            Console.ReadLine();
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
            Console.WriteLine("Votre endurance a doublé !");
            return playerStamina;
        }

        #endregion

            #region Combat

        public bool Fight(Ennemy cible)
        {
            int tour = 0;
            
            bool endFight = false;
            bool win = false;
            bool usedSA = false;

            int usingStone = 0;
            int endRegenSA = 0;
            int usingSA = 0;

            Console.Clear();
            Console.WriteLine("Vous allez vous battre contre " + cible.Name);
            Console.ReadLine();

            while (!endFight)
            {
                tour++;
                Console.WriteLine(cible.Name + " a " + cible.lifePoints + " points de vie.");
                Console.WriteLine("Vous avez " + lifePoints + " points de vie.");
                Console.ReadLine();

                #region Actions du joueur

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
                            int c2 = Menu.AskChoice("Quelle Pierre d'Infinité voulez-vous utilisez ?", 1, 7);
                            if (c2 == 7)
                            {
                                continue;
                            }
                            else
                            {
                                if (UseInfinityStone(c2, cible))
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
                                        break;
                                    }
                                    else
                                    {
                                        usingSA = 0;
                                        Console.WriteLine("Vous avez perdu trop de temps !");
                                        break;
                                    }
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
                        int c3 = Menu.AskChoice("Quelle pierre voulez-vous utilisez ?", 1, 3);
                        if (c3 == 3)
                        {
                            continue;
                        }
                        else
                        {
                            if (!UseStone(c3, cible, this))
                            {
                                if (usingStone == 0)
                                {
                                    usingStone++;
                                    break;
                                }
                                else
                                {
                                    usingStone = 0;
                                    Console.WriteLine("Vous avez perdu trop de temps !");
                                    Console.ReadLine();
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
                Console.WriteLine();

                #endregion
            }

            if (win)
            {
                Console.WriteLine("Vous avez vaincu " + cible.Name + ".");
                AddStone(cible.Drop, cible, this);
                if (usedRS == true)
                {
                    lifePoints -= 40;
                    usedRS = false;
                    Console.WriteLine("Vous perdez 40 points de vie à cause du contre-coup de la Pierre de Réalité");
                    if (AreYouDead())
                    {
                        Console.WriteLine("Le contre-coup a été trop violent, et vous vous écroulez ... ");
                        Game.GameOver();
                        return false;
                    }
                }
                if (usedMS != 0)
                {
                    stamina = usedMS;
                    usedMS = 0;
                    Console.WriteLine("L'effet de la Pierre de l'Esprit s'est dissipé ...");
                }
                return true;
            }
            else
            {
                Console.WriteLine(cible.Name + " vous a tué.");
                Game.GameOver();
                return false;
            }
        }

        public void Fight(Ennemy vision, Thor thor)
        {
            Fight(vision);
            Console.ReadLine();
            Console.Clear();
            Fight(thor);
            Console.ReadLine();
            Console.Clear();
            
            Game.EndGame();
        }

            #endregion

            #region Deplacement

        public void Move()
        {
            Console.WriteLine("Il est temps de partir !");
            Console.WriteLine();
            Console.WriteLine("1 : Aller vers le haut");
            Console.WriteLine("2 : Aller vers la droite");
            Console.WriteLine("3 : Aller vers le bas");
            Console.WriteLine("4 : Aller vers la gauche");
            int c = Menu.AskChoice("Où voulez-vous aller ?", 1, 4);
            Console.WriteLine();
            switch (c)
            {
                case 1:
                    if (position[0] == 0)
                    {
                        Console.WriteLine("Déplacement impossible");
                        goto default;
                    }
                    else if (position[0] - 1 == 0 && position[1] == 4)
                    {
                        int count = 0;
                        for (int i = 0; i < infinityStoneInventory.Length; i++)
                        {
                            if (infinityStoneInventory[i] != null)
                                count++;
                        }
                        if (count > 5)
                        {
                            Console.WriteLine("Il vaudrait mieux récupérer d'autres Pierres d'Infinitées avant d'aller par là !..");
                            goto default;
                        }
                        break;
                    }
                    else
                    {
                        position[0] -= 1;
                        Console.WriteLine("Vous allez vers le haut");
                        break;
                    }
                case 2:
                    if (position[1] == 4)
                    {
                        Console.WriteLine("Déplacement impossible");
                        goto default;
                    }
                    else if (position[0] - 1 == 0 && position[1] == 4)
                    {
                        int count = 0;
                        for (int i = 0; i < infinityStoneInventory.Length; i++)
                        {
                            if (infinityStoneInventory[i] != null)
                                count++;
                        }
                        if (count > 5)
                        {
                            Console.WriteLine("Il vaudrait mieux récupérer d'autres Pierres d'Infinitées avant d'aller par là !..");
                            goto default;
                        }
                        break;
                    }
                    else
                    {
                        position[1] += 1;
                        Console.WriteLine("Vous allez vers la droite");
                        break;
                    }
                case 3:
                    if (position[0] == 4)
                    {
                        Console.WriteLine("Déplacement impossible");
                        goto default;
                    }
                    else
                    {
                        position[0] += 1;
                        Console.WriteLine("Vous allez vers le bas");
                        break;
                    }
                case 4:
                    if (position[1] == 0)
                    {
                        Console.WriteLine("Déplacement impossible");
                        goto default;
                    }
                    else
                    {
                        position[1] -= 1;
                        Console.WriteLine("Vous allez vers la gauche");
                        break;
                    }
                default:
                    Console.ReadLine();
                    Console.Clear();
                    Move();
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
            Console.WriteLine("3 : Retour");
        }

        public void ShowStoneInventory()
        {
            int count = 1;

            Console.WriteLine("POCHE A PIERRE\n");
            foreach (KeyValuePair<string, int> stone in stoneInventory)
            {
                Console.WriteLine(count + " : " + stone.Key + " (" + stone.Value + ")");
                if (count == 1)
                {
                    Console.Write("\t" + new Heal().Description + "\n\n");
                }
                else if (count == 2)
                {
                    Console.Write("\t" + new Attack().Description + "\n\n");
                }
                else
                {
                    Console.Write("\t" + new Booster().Description + "\n\n");
                }
                
                count++;
            }
            Console.WriteLine("4 : Retour");
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

        public void AddStone(char c, Ennemy cible, Player player)
        {
            switch (c)
            {
                case 'h':
                    stoneInventory["Pierre de Soin"] += 1;
                    Console.WriteLine("En fouillant le cadavre, vous trouvez une Pierre de Soin et l'ajoutez à votre inventaire.");
                    break;
                case 'a':
                    stoneInventory["Pierre de Dégâts"] += 1;
                    Console.WriteLine("En fouillant le cadavre, vous trouvez une Pierre de Dégâts et l'ajoutez à votre inventaire.");
                    break;
                case 'b':
                    stoneInventory["Pierre d'Amélioration"] += 1;
                    Console.WriteLine("En fouillant le cadavre, vous trouvez une Pierre d'Amélioration et l'ajoutez à votre inventaire.");
                    break;
                case 'i':
                    switch (cible.Name)
                    {
                        case "Hulk":
                            infinityStoneInventory[1] = new SpaceStone();
                            Console.WriteLine("Vous trouvez la Pierre de l'Espace !");
                            Console.WriteLine("La Pierre de l'Espace est ajouté à votre inventaire et une nouvelle capacité spéciale est disponible.");
                            Console.WriteLine(new SpaceStone().Upgrade(player));
                            break;
                        case "StarLord":
                            infinityStoneInventory[2] = new RealityStone();
                            Console.WriteLine("Vous trouvez la Pierre de Réalité !");
                            Console.WriteLine("La Pierre de Réalité est ajouté à votre inventaire et une nouvelle capacité spéciale est disponible.");
                            Console.WriteLine(new RealityStone().Upgrade(player));
                            break;
                        case "Docteur Strange":
                            infinityStoneInventory[3] = new TimeStone();
                            Console.WriteLine("Vous trouvez la Pierre du Temps !");
                            Console.WriteLine("La Pierre du Temps est ajouté à votre inventaire et une nouvelle capacité spéciale est disponible.");
                            Console.WriteLine(new TimeStone().Upgrade(player));
                            break;
                        case "Gamorra":
                            infinityStoneInventory[4] = new SoulStone();
                            Console.WriteLine("Vous trouvez la Pierre de l'Âme !");
                            Console.WriteLine("La Pierre de l'Âme est ajouté à votre inventaire et une nouvelle capacité spéciale est disponible.");
                            Console.WriteLine(new SoulStone().Upgrade(player));
                            break;
                        case "Vision":
                            infinityStoneInventory[5] = new MindStone();
                            Console.WriteLine("Vous trouvez la Pierre de l'Esprit !");
                            Console.WriteLine("La Pierre de l'Esprit est ajouté à votre inventaire et une nouvelle capacité spéciale est disponible.");
                            Console.WriteLine(new MindStone().Upgrade(player));
                            break;
                        default:
                            goto default;
                    }
                    break;
                default:
                    Game.EndGame();
                    break;
            }
        }

        public void ShowInfinityStoneInventory()
        {
            Console.WriteLine("POCHE A PIERRES D'INFINITEES");
            Console.WriteLine();
            for (int i = 0; i < infinityStoneInventory.Length; i++)
            {
                try
                {
                    Console.WriteLine(i + 1 + " : " + infinityStoneInventory[i].Name);
                    switch (i)
                    {
                        case 0:
                            Console.WriteLine(new PowerStone().Description);
                            break;
                        case 1:
                            Console.WriteLine(new SpaceStone().Description);
                            break;
                        case 2:
                            Console.WriteLine(new RealityStone().Description);
                            break;
                        case 3:
                            Console.WriteLine(new TimeStone().Description);
                            break;
                        case 4:
                            Console.WriteLine(new SoulStone().Description);
                            break;
                        case 5:
                            Console.WriteLine(new MindStone().Description);
                            break;
                    }
                    Console.WriteLine();
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine(i + 1 + " : Vide");
                }
            }
            Console.WriteLine("7 : Retour");
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
                        Console.WriteLine("Vos points de vie ont été augmenté de " + r.StoneLifePoints + " points.");
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
                        degat = SoulStoneSA(s);
                        cible.Damage(degat * 4);
                        Damage(degat);
                        Console.WriteLine("Vous sacrifiez " + degat + " de vos points de vie, et infligez " + degat * 4 + " points de dégâts à " + cible.Name + ".");
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
                    Console.WriteLine("Vous trouvez une Pierre de Soin et l'ajoutez à votre inventaire.");
                    break;
                case "Pierre de Dégâts":
                    stoneInventory[x.Name] += 1;
                    Console.WriteLine("Vous trouvez une Pierre de Dégâts et l'ajoutez à votre inventaire.");
                    break;
                case "Pierre d'Amélioration":
                    stoneInventory[x.Name] += 1;
                    Console.WriteLine("Vous trouvez une Pierre d'Amélioration et l'ajoutez à votre inventaire.");
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

        public void ShowStats()
        {
            Console.Clear();
            Console.WriteLine(Name);
            Console.WriteLine("Points de vie : " + lifePoints + "/" + maxLifePoints);
            Console.WriteLine();
            Console.WriteLine("Force : " + force);
            Console.WriteLine("Endurance : " + stamina);
            Console.WriteLine();
            Console.WriteLine("Attaque : " + (force + (stamina / 3)) + " (Force + (Stamina/3))");
            Console.WriteLine("Chances de bloquer : " + stamina + "%");
            Console.ReadLine();
        }

        #endregion
    }
}

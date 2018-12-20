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
using System.IO;

namespace ProjetRPG
{
    class Menu
    {
        #region Methodes

        public static void ShowMenu()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1 : Start Game");
            Console.WriteLine("2 : Load Game");
            Console.WriteLine("3 : About");
            Console.WriteLine("4 : Exit");
        }

        public static int AskChoice(string question, int min, int max)
        {
            int c = -1;

            Console.WriteLine();
            Console.WriteLine(question);
            try
            {
                c = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrez un chiffre entre " + min + " et " + max);
            }
            

            while ((c > max) || (c < min))
            {
                try
                {
                    c = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrez un chiffre entre " + min + " et " + max);
                }
            }

            return c;
        }

        public static void LoadGame()
        {
            Console.Clear();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\STW";
            DirectoryInfo savedGame = new DirectoryInfo(path);
            FileInfo[] files = savedGame.GetFiles();

            Console.WriteLine("Sauvegarde(s) disponible(s) : ");

            int counter = 0;
            foreach (FileInfo f in files)
            {
                counter++;
                Console.WriteLine(counter + " : " + f.Name);
            }

            int c = AskChoice("Quelle sauvegarde faut-il charger ?", 1, counter);

            string fileToLoad = files[counter - 1].Name;
            int[] statPlayer = new int[13];
            List<int[]> posVisited = new List<int[]>();

            using (StreamReader sr = new StreamReader(path + @"\" + fileToLoad))
            {
                int count = 0;
                string l;
                while ((l = sr.ReadLine()) != null)
                {
                    try
                    {
                        statPlayer[count] = int.Parse(l);
                    }
                    catch(FormatException)
                    {
                        string[] s = l.Split(',');
                        int[] p = new int[2];
                        for (int i = 0; i < s.Length; i++)
                        {
                            p[i] = int.Parse(s[i]);
                        }
                        posVisited.Add(p);
                    }
                    finally
                    {
                        count++;
                    }
                }
            }

            Player player = new Player(statPlayer);
            Map map = new Map(posVisited);

            Console.Clear();
            Console.WriteLine("Sauvegarde chargée avec succés !");
            Console.ReadLine();
            Console.Clear();

            Game.MainGame(player, map);

            if (Game.winGame)
                Game.EndGame();
            else
                Game.GameOver();

            Console.ReadLine();
        }

        public static void About()
        {
            Console.Clear();
            Game.Title();
            Console.WriteLine();
            Console.WriteLine("Ce jeu a été crée par Gauthier LECOUFFE.");
            Console.ReadLine();
        }

        #endregion

    }
}

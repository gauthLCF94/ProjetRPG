﻿using ProjetRPG;
using ProjetRPG.Stones;
using ProjetRPG.Stones.InfinityStones;
using ProjetRPG.Characters;
using ProjetRPG.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG.Board
{
    class Case
    {
        #region Variables

        public Ennemy ennemy;
        public Stone stone;
        public bool visited;

        #endregion

        #region Constructeur
        
        public Case(Ennemy e)
        {
            ennemy = e;
            visited = false;
        }

        public Case(Stone s)
        {
            stone = s;
            visited = false;
        }

        #endregion

        #region Methodes

        public void Display()
        {
            if (visited)
            {
                Console.Write('[');
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write('X');
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(']');
            }
            else
            {
                if (ennemy == null)
                {
                    Console.Write("[P]");
                }
                else
                {
                    switch (ennemy.Type)
                    {
                        case Ennemy.EnnemyType.Boss:
                            Console.Write("[B]");
                            break;
                        default:
                            Console.Write("[E]");
                            break;
                    }
                }
            }
        }

        public void DisplayPlayer()
        {
            Console.Write('[');
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write('P');
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(']');
        }

        #endregion
    }
}

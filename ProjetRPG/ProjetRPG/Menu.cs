using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Menu
    {
        public static int AskChoice(int min, int max)
        {
            int c = int.Parse(Console.ReadLine());

            while ((c > max) || (c < min))
            {
                c = int.Parse(Console.ReadLine());
            }

            return c;
        }
    }
}

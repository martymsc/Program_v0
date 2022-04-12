using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra_v0
{
    public class Character
    {
        public string Name;
        public int Lives;
        public int Kills;
        

        public bool fight()
        {


            bool dmg = false;
            return dmg;
        }
        public static int RandomGen(int Min = 0, int Max = 12 )
        {
            Random r = new Random();
            int rInt = r.Next(Min, Max);

            return rInt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra_v0
{
    //Třída která slouží jako předloha pro vytvoření objektu hráče a nepřítele
    public class Character
    {
        public string Name;
        public int Lives;
        public int Kills;
        

        //Metoda používaná pro simulaci hodu kostokou
        public static int RandomGen(int Min = 0, int Max = 12 )
        {
            Random r = new Random();
            int rInt = r.Next(Min, Max);
            

            return rInt;
        }
    }
}

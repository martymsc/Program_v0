﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra_v0
{
    public class AllMethods
    {
        //Funkce vypíše vložené řady, TxtToPrint, je řetězec slov na vypsání, numC je seznam řádků na které slova vypsat
        //Funkce dále čeká na vstup uživtele a aktuální volbu zobrazuje změnou barvy textu a pozadí
        //Funkce vrací číso řádky který zvolil uživatel
        public static int PrintOut(string[] TxtToPrint, int[] numC)
        {
            int SSteps = numC[0];
            int Ent = 0;

            while (Ent == 0)
            {
                for (int i = 0; i < TxtToPrint.Count(); i++)
                {
                    if (SSteps == numC[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                        Console.ResetColor();

                    CenterWrite(TxtToPrint[i], numC[i]);


                }
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        SSteps--;
                        break;
                    case ConsoleKey.DownArrow:
                        SSteps++;
                        break;
                    case ConsoleKey.Escape:
                        Ent = -1000;
                        break;

                    case ConsoleKey.Enter:
                        Ent = SSteps;
                        break;
                }
                if (SSteps > numC.Last())
                {
                    SSteps--;
                }
                if (SSteps < numC[0])
                {
                    SSteps++;
                }

            }

            Console.Write(Ent);
            return Ent;

        }
        //Funkce centrování textu v konzoli,(slovo na centr, č.řádku)
        public static void CenterWrite(string txt = "aohj", int collom = 0)
        {

            Console.SetCursorPosition((Console.WindowWidth - txt.Length) / 2, collom);
            Console.WriteLine(txt);
        }
    }
}
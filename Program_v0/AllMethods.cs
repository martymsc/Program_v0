using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hra_v0.Character;
using System.Threading;
using System.IO;

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
                    Console.ResetColor();

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


            return Ent;

        }

        //Funkce centrování textu v konzoli,(slovo na centr, č.řádku)

        public static void CenterWrite(string txt = "aohj", int collom = 0, int writeDurationMilliseconds = 0)
        {
            Console.SetCursorPosition((Console.WindowWidth - txt.Length) / 2, collom);
            foreach (char c in txt)
            {
                Console.Write(c);
                int sleepDuration = writeDurationMilliseconds / txt.Length;
                Thread.Sleep(sleepDuration);
            }

        }

        public static void SlowWrite(string txt = "aohj", int writeDurationMilliseconds = 500)
        {

            foreach (char c in txt)
            {
                Console.Write(c);
                int sleepDuration = writeDurationMilliseconds / txt.Length;
                Thread.Sleep(sleepDuration);
            }
        }


        public static void ScoreboardRead(String cesta = "Vysledky.txt")
        {
            Console.Clear();
            int i = 4;
            CenterWrite(".................Scoreboard.................", 1, 300);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            CenterWrite("     Jmeno:                                             Max podlaží:      ", 3);
            Console.ResetColor();




            StreamReader reader = new StreamReader(cesta);

            while (!reader.EndOfStream)
            {
                Console.SetCursorPosition(26, i);
                Console.Write(reader.ReadLine());
                
                i++;
            }

            reader.Close();

            Console.ReadKey();
            


        }
        //Po smrti hráče uloží jeho výsledek do tabulky výsledků
        public static void ScoreboardWrite(string Name, int Podlazi,String cesta = "Vysledky.txt")
        {
            StreamWriter writer = new StreamWriter(cesta, true);
            string NameWrite = Name + "                                                 " + Podlazi;
            writer.WriteLine(NameWrite);


            writer.Close();
        }

        public static int roll()
        {
            Random r = new Random();
            int rInt = r.Next(1, 12);

           return rInt;
        }

      

    }
}

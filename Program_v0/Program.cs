using System;
using System.Linq;

namespace Program_v0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MainMenu();

            //game();
            // Console.WriteLine(UserInput(3,10));
            MainMenu();



        }


        //Funkce startvního menu, získám z něho volbu uživatele
        static void MainMenu(int chosed = 0)
        {
            //Array s textem co vypsat na řádky
            String[] TextMenu = new string[4] { "1 -- Začít novou hru", "2 -- Nahrát uloženou hru", "3 -- Scoreboard", "4 -- Ukončit hru" };
            //Array s číslama řádků na který text vypsat, čísla na sebe musí navazovat
            int[] TextMenuP = new int[4] { 2, 3, 4, 5, };
            CenterWrite(".............Výtejte ve hře............", 0);
            CenterWrite("Vyberte jednu z možností:", 1);

            int Chosed =  PrintOut(TextMenu, TextMenuP);


           
        }


        //Funkce hry
        static void game()
        {
            Console.WriteLine("ahoj");
        }



        //Funkce centrování textu v konzoli,(slovo na centr, č.řádku)
        static void CenterWrite(string txt = "aohj", int collom = 0)
        {

            Console.SetCursorPosition((Console.WindowWidth - txt.Length) / 2, collom);
            Console.WriteLine(txt);
        }

        
        //Funkce vypíše vložené řady, TxtToPrint, je řetězec slov na vypsání, numC je seznam řádků na které slova vypsat
        //Funkce dále čeká na vstup uživtele a aktuální volbu zobrazuje změnou barvy textu a pozadí
        //Funkce vrací číso řádky který zvolil uživatel
        static int PrintOut(string[] TxtToPrint, int[] numC )
        {
            int SSteps = numC[0];
            int Ent = 0;

            while(Ent == 0)
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

    }
}

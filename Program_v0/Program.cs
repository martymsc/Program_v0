using System;
using System.Linq;
using static Hra_v0.AllMethods;

namespace Program_v0
{
    class Program
    {
        static void Main(string[] args)
        {

            MainMenu();



        }


        //Funkce startvního menu, získám z něho volbu uživatele
        static void MainMenu(int chosed = 0)
        {
            //Array s textem co vypsat na řádky
            String[] TextMenu = new string[4] { "1 -- Začít novou hru", "2 -- Nahrát uloženou hru", "3 -- Scoreboard", "4 -- Ukončit hru" };
            //Array s číslama řádků na který text vypsat, čísla na sebe musí navazovat
            int[] TextMenuP = new int[4] { 2, 3, 4, 5, };
            Hra_v0.AllMethods.CenterWrite(".............Výtejte ve hře............", 0);
            Hra_v0.AllMethods.CenterWrite("Vyberte jednu z možností:", 1);

            int Chosed = Hra_v0.AllMethods.PrintOut(TextMenu, TextMenuP);

            switch(Chosed)
            {
                case 2:
                    game();
                    break;
                case 3:
                    LoadData();
                    break;
                case 4:
                    Scoreboard();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }


        //Funkce hry
        static void game()
        {
            Console.WriteLine("ahoj");
        }



       

    }
}

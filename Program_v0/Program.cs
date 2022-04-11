using System;
using System.Linq;
using static Hra_v0.AllMethods;
using static Hra_v0.Character;

namespace Program_v0
{
    class Program
    {
        static void Main(string[] args)
        {
            //MainMenu();
            //PlayerCreation();
            Game();
            


        }


        //Funkce startvního menu, získám z něho volbu uživatele
        static void MainMenu(int chosed = 0)
        {
            Console.Clear();
            //Array s textem co vypsat na řádky
            String[] TextMenu = new string[3] { "1 -- Začít novou hru", "2 -- Scoreboard", "3 -- Ukončit hru" };
            //Array s číslama řádků na který text vypsat, čísla na sebe musí navazovat
            int[] TextMenuP = new int[3] { 2, 3, 4, };
            Hra_v0.AllMethods.CenterWrite(".............Výtejte ve hře............", 0);
            Hra_v0.AllMethods.CenterWrite("Vyberte jednu z možností:", 1);

            int Chosed = Hra_v0.AllMethods.PrintOut(TextMenu, TextMenuP);

            switch(Chosed)
            {
                case 2:
                    Game();
                    break;
                case 3:
                    Scoreboard();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }


        
        public static void PlayerCreation()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            CenterWrite("Zadejte svoje jméno:");
            Console.ResetColor();
            string NName = Console.ReadLine();
            Hra_v0.Character Player = new Hra_v0.Character();
            Player.Name = NName;
            Player.Lives = 4;
            Console.WriteLine(Player.Name);
        }
        //Funkce hry
        static void Game()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            CenterWrite("Zadejte svoje jméno:");
            Console.ResetColor();
            string NName = Console.ReadLine();
            Hra_v0.Character Player = new Hra_v0.Character();
            Player.Name = NName;
            Player.Lives = 4;
            Console.WriteLine(Player.Name);

            while (Player.Lives != 0)
            {

            }
        }



    }
}

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
            MainMenu();
            //PlayerCreation();
            //Game();
            


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


        
        //public void PlayerCreation()
        //{
        //    Console.ForegroundColor = ConsoleColor.Black;
        //    Console.BackgroundColor = ConsoleColor.White;
        //    CenterWrite("Zadejte svoje jméno:");
        //    Console.ResetColor();
        //    string NName = Console.ReadLine();
        //    Hra_v0.Character Player = new Hra_v0.Character();
        //    Player.Name = NName;
        //    Player.Lives = 4;
            
        //    Console.WriteLine(Player.Name);
        //}
        //Funkce hry
        static void Game()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            CenterWrite("Zadejte svoje jméno:");
            Console.ResetColor();
            Console.SetCursorPosition(0, 3);
            string NName = Console.ReadLine();
            Hra_v0.Character Player = new Hra_v0.Character();
            Player.Name = NName;
            Player.Lives = 4;
            Player.Kills = 0;
            Console.Clear();



            //Main Game loop, běží dokud má Hráč více jak 0 životů
            for (int Round = 0; Player.Lives > 0; Round++)
            {
                int Initialroll;
                int SecRoll;
                bool Bigger = false;
                bool Draw = true;


                Console.Clear();
                //Vytvoření nového nepřítele
                string[] EnemyName = new string[10] { "Nick1", "Nick2", "Nick3", "Nick4", "Nick5", "Nick6", "Nick7", "Nick8", "Nick9", "Nick10" };
                Random r = new Random();
                int rInt = r.Next(0, 10);

                Hra_v0.Character enemy = new Hra_v0.Character();
                enemy.Name = EnemyName[rInt];
                enemy.Lives = 1;

                while (enemy.Lives > 0)
                {
                    while (Draw == true)
                    {

                        Console.SetCursorPosition(0, 0);
                        Console.Write("Podlaží: ");
                        Console.Write(Round);
                        Console.Write("  Životy:");
                        Console.WriteLine(Player.Lives);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        CenterWrite("Nepřítel: ");
                        Console.ResetColor();
                        CenterWrite(enemy.Name, 1);

                        Initialroll = roll();
                        CenterWrite("První hod kostkou:        ", 3);

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        Console.Write(Initialroll);
                        Console.Write(" ");
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");

                        Console.Write("Bude další hod vyšší, nebo nižší než hod aktuální?(1-12)");
                        string[] Options = new string[2] { "Vyšší", "Nižší" };
                        int[] Position = new int[2] { 6, 7 };
                        if (PrintOut(Options, Position) == 6)
                        {
                            Bigger = true;
                        }
                        else { Bigger = false; }



                        SecRoll = roll();
                        CenterWrite("Druhý hod kostkou je:       ", 10);

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        Console.Write(SecRoll);
                        Console.Write(" ");
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");

                        SecRoll = Initialroll;

                        if (SecRoll > Initialroll & Bigger == true)
                        {
                            enemy.Lives--;
                            WinFrame();
                            Draw = false;
                        }
                        if (SecRoll > Initialroll & Bigger != true)
                        {
                            Player.Lives--;
                            Draw = false;
                        }
                        if (SecRoll == Initialroll)
                        {
                            Console.Write("Draw");
                            Draw = true;
                        }
                        if (SecRoll < Initialroll & Bigger == true)
                        {
                            Player.Lives--;
                            Draw = false;
                        }
                        if (SecRoll < Initialroll & Bigger != true)
                        {
                            enemy.Lives--;
                            Draw = false;
                        }
                    }



                        while (true) ;








                    Player.Kills = Round;
                }
            }
        }

        //public static void EnemyCreation()
        //{
        //    int EnemyCount = 0;

        //string[] EnemyName = new string[10] {"Nick1", "Nick2", "Nick3", "Nick4", "Nick5", "Nick6", "Nick7", "Nick8", "Nick9", "Nick10" };


        //    Random r = new Random();
        //    int rInt = r.Next(0, 10);

        //    Hra_v0.Character enemy = new Hra_v0.Character();
        //    enemy.Name = EnemyName[rInt];
           
            
        //}
        public static void WinFrame()
        {

        }

    }
}




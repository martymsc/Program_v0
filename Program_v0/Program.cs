using System;
using System.Linq;
using static Hra_v0.AllMethods;
using static Hra_v0.Character;
using System.Threading;

namespace Program_v0
{
    class Program
    {
        static void Main(string[] args)
        {
            String cesta = "Vysledky.txt";
            MainMenu();
            
        }

        //Funkce startvního menu, získám z něho volbu uživatele, podle té se spusí metoda hry, score, nebo se hra ukončí
        static void MainMenu(int chosed = 0)
        {
                Console.Clear();
                //Array s textem co vypsat na řádky
                String[] TextMenu = new string[3] { "1 -- Začít novou hru", "2 -- Scoreboard", "3 -- Ukončit hru" };
                //Array s číslama řádků na který text vypsat, čísla na sebe musí navazovat
                int[] TextMenuP = new int[3] { 2, 3, 4, };
                
            while (true)
            {
                Hra_v0.AllMethods.CenterWrite(".............Výtejte ve hře............", 0,1000);
                Hra_v0.AllMethods.CenterWrite("Vyberte jednu z možností:", 1,1);
                int Chosed = Hra_v0.AllMethods.PrintOut(TextMenu, TextMenuP);
            
                switch (Chosed)
                {
                    case 2:
                        Game();
                        chosed = 0;
                        Console.Clear();
                        break;
                    case 3:
                        ScoreboardRead();
                        chosed = 0;
                        Console.Clear();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
            
        }

       

        //Funkce hry
        static public void Game()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            CenterWrite("Zadejte svoje jméno:",1 ,300);
            Console.ResetColor();
            Console.SetCursorPosition(5, 3);
            string NName = Console.ReadLine();

            //Ošetření vstupu jmena
            while(string.IsNullOrEmpty(NName) == true )
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                CenterWrite("Hej jméno je povinný jako:", 1, 300);
                Console.ResetColor();
                Console.SetCursorPosition(5, 3);
                NName = Console.ReadLine();

            }

            //Vytvoření objektu hráče 
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
                //Vytvoření objektu nepřítele
                string[] EnemyName = new string[10] { "Slime", "Zelený Skřet", "Bezhlavý Rytíř", "Ropucha", "Dvojhlavá zmije", "Obří stonožka", "Živá Hhína", "Muší král", "Zombík", "Houbový goblin" };
                Random r = new Random();
                int rInt = r.Next(0, 10);

                Hra_v0.Character enemy = new Hra_v0.Character();
                enemy.Name = EnemyName[rInt];
                enemy.Lives = 1;

                while (enemy.Lives != 0 & Player.Lives != 0)
                {
                    Draw = true;
                    while (Draw == true)
                    {

                        Console.SetCursorPosition(0, 0);
                        Console.Write("Podlaží: ");
                        Console.Write(Round);
                        Console.Write("  Životy:");
                        Console.WriteLine(Player.Lives);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        CenterWrite("Nepřítel: ", 0, 300);
                        Console.ResetColor();
                        CenterWrite(enemy.Name, 1,200);
                        Console.WriteLine();
                        CenterWrite("Životy nepřítele:    ", 2);
                        Console.Write(enemy.Lives);



                        Initialroll = roll();
                        CenterWrite("První hod kostkou:        ", 4);

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        Console.Write(Initialroll);
                        Console.Write(" ");
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");

                        Console.SetCursorPosition(8,6);
                        SlowWrite("Bude další hod vyšší, nebo nižší než hod aktuální?(1-12)");
                        string[] Options = new string[2] { "Vyšší", "Nižší" };
                        int[] Position = new int[2] { 8, 9 };
                        if (PrintOut(Options, Position) == 8)
                        {
                            Bigger = true;
                        }
                        else { Bigger = false; }



                        SecRoll = roll();
                        CenterWrite("Druhý hod kostkou je:       ", 11,1000);

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        Console.Write(SecRoll);
                        Console.Write(" ");
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");


                        //Úspěšný útok na nepřítele, ztrácí jeden život
                        if (SecRoll > Initialroll & Bigger == true)
                        {
                            Console.WriteLine();
                            enemy.Lives--;
                            Draw = false;
                            if (enemy.Lives == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                SlowWrite("        Úspěšný útok na nepřítele, ztrácí jeden život. Postupuješ do dašího podlaží");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                SlowWrite("        Úspěšný útok! nepřítel ztrácí jeden život.");
                                Console.ResetColor();
                            }
                        }

                        //Hráč ztrácí jeden život
                        if (SecRoll > Initialroll & Bigger != true)
                        {
                            Console.WriteLine();
                            Player.Lives--;
                            
                            Draw = false;
                            if (Player.Lives == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                SlowWrite("        Nepřítel tě zranil, ztrácíš jeden život. Jsi mrtev.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                SlowWrite("        Nepřítel tě zranil, ztrácíš jeden život.");
                                Console.ResetColor();
                            }
                        }

                        //Remíza
                        if (SecRoll == Initialroll)
                        {
                            Console.WriteLine();
                            Draw = true;
                            SlowWrite("        Remíza, hraješ znovu.");
                        }

                        //Hráč ztrácí jeden život
                        if (SecRoll < Initialroll & Bigger == true)
                        {
                            Player.Lives--;
                            Draw = false;
                            Console.WriteLine();
                            if (Player.Lives == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                SlowWrite("        Nepřítel tě zranil, ztrácíš jeden život. Jsi mrtev.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                SlowWrite("        Nepřítel tě zranil, ztrácíš jeden život.");
                                Console.ResetColor();
                            }
                        }

                        //Úspěšný útok na nepřítele, ztrácí jeden život
                        if (SecRoll < Initialroll & Bigger != true)
                        {
                            Console.WriteLine();
                            enemy.Lives--;
                            Draw = false;
                            if (enemy.Lives == 0) 
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                SlowWrite("        Úspěšný útok na nepřítele, ztrácí jeden život. Postupuješ do dašího podlaží");
                                Console.ResetColor();
                            }
                            else 
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                SlowWrite("        Úspěšný útok! nepřítel ztrácí jeden život.");
                                Console.ResetColor();
                            }
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                Player.Kills = Round;
            }

            ScoreboardWrite(Player.Name, Player.Kills);
            Console.Clear();
            CenterWrite("Byl jsi v podzemí zabit, dosažené podlaží: ", 2, 500);
            Console.Write(Player.Kills);

            Console.ReadKey();

            ScoreboardRead();

            Console.ReadKey();


        }

        
       
        
    }
}




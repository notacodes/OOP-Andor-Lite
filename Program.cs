namespace AndorOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("  ___            _              _     _ _       \n / _ \\          | |            | |   (_) |      \n/ /_\\ \\_ __   __| | ___  _ __  | |    _| |_ ___ \n|  _  | '_ \\ / _` |/ _ \\| '__| | |   | | __/ _ \\\n| | | | | | | (_| | (_) | |    | |___| | ||  __/\n\\_| |_/_| |_|\\__,_|\\___/|_|    \\_____/_|\\__\\___|");
            Console.WriteLine(" ");
            Console.WriteLine("********************************************************************************");
            string[] texts = {
                "Willkommen in Andor!",
                "In diesem Spiel kannst du einen Helden auswählen und gegen Monster kämpfen.",
                "Jeder Held hat unterschiedliche Stärken und Schwächen.",
                "Gewinne Kämpfe, um Münzen zu sammeln und deinen Helden stärker zu machen.",
                "Stärkepunkte verbessern dauerhaft die Angriffskraft deines Helden.",
                "Willenskraft bestimmt, wie viel Schaden dein Held aushalten kann.",
                "Viel Glück!"
            };

            foreach (string line in texts)
            {
                foreach (char c in line)
                {
                    Console.Write(c);
                    Thread.Sleep(40); 
                }
                Console.WriteLine(); 
            }
            Console.WriteLine("********************************************************************************");
            Console.WriteLine(" ");
            Console.WriteLine("Wähle deinen Helden: (1) Magier, (2) Bogenschütze, (3) Zwerg");
            string choice = Console.ReadLine();
            
            Held held;
            switch (choice)
            {
                case "1":
                    held = new Magier("Elyndor");
                    break;
                case "2":
                    held = new Bogenschütze("Kaedor");
                    break;
                case "3":
                    held = new Zwerg("Thargan");
                    break; 
                default:
                    Console.WriteLine("Ungültige Wahl, Standardheld wird erstellt.");
                    held = new Zwerg("Thargan");
                    break;
            }
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("Dein Held wurde erstellt.");
            held.PrintInfo();

            while (held.isAlive)
            {
                Console.WriteLine("********************************************************************************");
                Console.WriteLine("Wähle eine Aktion: (1) Handeln, (2) Angreifen, (3) Info anzeigen, (4) Beenden");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        held.Trade();
                        break;
                    case "2":
                        Monster monster = Monster.CreateRandomMonster();
                        held.Attack(monster);
                        break;
                    case "3":
                        held.PrintInfo();
                        break;
                    case "4":
                        Console.WriteLine("Spiel beendet.");
                        return;
                    default:
                        Console.WriteLine("Ungültige Aktion.");
                        break;
                }
            }

            Console.WriteLine("Das Spiel ist vorbei.");
        }
    }
}
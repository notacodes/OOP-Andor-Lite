namespace AndorOOP;

internal abstract class Held
{
   internal int Stärkepunkte { get; set;}
    internal int Willenskraft { get; set; }
    internal string[] Inventar { get; set; }
    internal string Name { get; set; }
    internal bool isInventarFull {get; set;}
    internal int emptySlots {get; set;}
    internal int Coins {get; set;}
    internal bool isAlive {get; set;}
    

    internal Held(string name)
    {
        this.Stärkepunkte = 3;
        this.Willenskraft = 10;
        this.Inventar = new string[3]
        {
            "Leer",
            "Leer",
            "Leer"
        };
        this.Name = name;
        this.isInventarFull = false;
        this.emptySlots = 3;
        this.isAlive = true;
        this.Coins = 2;
        
    }

    internal virtual void Trade()
    {
        bool buying = true;
        Console.WriteLine("**************** Handeln ****************");

        while (buying)
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Du hast {this.Coins} Münzen.");
            Console.WriteLine("Was möchtest du kaufen ? (1) Stärkepunkte (2) Willenspunkt (3) Item (4) nichts");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine(
                        "Ein Stärkepunkt kostet 3 Münzen. Möchtest du einen Stärkepunkt kaufen ? (j) oder (n)");
                    string choice2 = Console.ReadLine();
                    if (choice2 == "j")
                    {
                        if (this.Coins >= 3)
                        {
                            this.GetStärkepunkte(1);
                            this.Coins -= 3;
                        }
                        else
                        {
                            Console.WriteLine("Du hast nicht genug Münzen.");
                        }
                    }

                    break;
                case "2":
                    Console.WriteLine("3 Willenpunkte kosten 1 Münze. Möchtest du dir das kaufen ? (j) oder (n)");
                    string choice3 = Console.ReadLine();
                    if (choice3 == "j")
                    {
                        if (this.Coins >= 1)
                        {
                            this.GetWillenskraft(3);
                            this.Coins -= 1;
                        }
                        else
                        {
                            Console.WriteLine("Du hast nicht genug Münzen.");
                        }
                    }

                    break;
                case "3":
                    Console.WriteLine("Ein Item kostet 3 Münzen. Welches Item möchtest du kaufen: (1) Rune, (2) Heilung, (3) Gift");
                    string choice4 = Console.ReadLine();
                    if (choice4 == "1")
                    {
                        if (this.Coins >= 3)
                        {
                            if(this.GetAbility("Rune") == true){
                                this.Coins -= 3;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Du hast nicht genug Münzen.");
                        }
                    }
                    else if (choice4 == "2")
                    {
                        if (this.Coins >= 3)
                        {
                            if (this.GetAbility("Heilung") == true)
                            {
                                this.Coins -= 3;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Du hast nicht genug Münzen.");
                        }
                    }
                    else if (choice4 == "3")
                    {
                        if (this.Coins >= 3)
                        {
                            if (this.GetAbility("Gift"))
                            {
                                this.Coins -= 3;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Du hast nicht genug Münzen.");
                        }
                    }
                    break;
                case "4":
                    Console.WriteLine("Du hast nichts gekauft.");
                    buying = false;
                    break;
                default:
                    Console.WriteLine("Ungültige Wahl.");
                    break;
            }
        }
    }

    internal virtual void Attack(Monster monster)
    {
        bool attack = true;
        bool usedRune = false;
        while (attack)
        {
            Console.WriteLine($"Du greifst einen {monster.Name} an.");
            if (this.Inventar[0] != "Leer" || this.Inventar[1] != "Leer" || this.Inventar[2] != "Leer")
            {
                Console.WriteLine("Möchtest du ein Item benutzen ? (j) oder (n)");
                string choice11 = Console.ReadLine();
                if (choice11 == "j")
                {
                    for (int i = 0; i < this.Inventar.Length; i++)
                    {
                        if (this.Inventar[i] != "Leer")
                        {
                            Console.WriteLine((i + 1) + ". " + this.Inventar[i]);
                        }
                    }

                    Console.WriteLine("Welches Item möchtest du benutzen ? (1), (2) oder (3)");
                    string choice10 = Console.ReadLine();
                    if (this.Inventar[int.Parse(choice10) - 1] == "Rune")
                    {
                        Console.WriteLine("Du hast die Rune benutzt und hast deine Stärkepunkte temporär verdoppelt.");
                        this.GetStärkepunkte(this.Stärkepunkte * 2);
                        usedRune = true;
                        this.Inventar[int.Parse(choice10) - 1] = "Leer";
                        this.emptySlots++;
                    }
                    else if (this.Inventar[int.Parse(choice10) - 1] == "Heilung")
                    {
                        Console.WriteLine("Du hast die Heilung benutzt und hast 6 Willenspunkte erhalten.");
                        this.GetWillenskraft(6);
                        Console.WriteLine($"Du hast jetzt {this.Willenskraft} Willenspunkte.");
                        this.Inventar[int.Parse(choice10) - 1] = "Leer";
                        this.emptySlots++;
                    }
                    else if (this.Inventar[int.Parse(choice10) - 1] == "Gift")
                    {
                        Console.WriteLine("Du hast das Gift benutzt und hast dem Monster 4 Willenspunkte abgezogen.");
                        monster.GetDamage(3);
                        Console.WriteLine($"Der {monster.Name} hat noch {monster.Willenskraft} Willenspunkte.");
                        this.Inventar[int.Parse(choice10) - 1] = "Leer";
                        this.emptySlots++;
                    }
                }
            }
            Console.WriteLine("Würfle! (press enter)");
            Console.ReadLine();
            Random rnd = new Random();
            int diceHeld = rnd.Next(1, 7);
            Console.WriteLine("Ich habe eine " + diceHeld + " gewürfelt.");
            int powerHeld = diceHeld + this.Stärkepunkte;
            Console.WriteLine($"Meine Stärke für diesen Kampf ist {powerHeld}.");
            Console.WriteLine(" ");
            Console.WriteLine($"Der {monster.Name} würfelt! (press enter)");
            Console.ReadLine();
            int diceMonster = rnd.Next(1, 7);
            Console.WriteLine($"Der {monster.Name} hat eine {diceMonster} gewürfelt.");
            int powerMonster = diceMonster + monster.Stärkepunkte;
            Console.WriteLine($"Die Stärke des Monsters für diesen Kampf ist {powerMonster}.");
            Console.WriteLine(" ");
            Console.WriteLine("Los gehts! (press enter)");
            Console.ReadLine();

            if (powerHeld > powerMonster)
            {
                monster.GetDamage(powerHeld - powerMonster);
                Console.WriteLine($"Du hast den {monster.Name} getroffen und hast ihm {powerHeld - powerMonster} Willenspunkte abgezogen!");
                Console.WriteLine($"Der {monster.Name} hat noch {monster.Willenskraft} Willenspunkte.");
                if (monster.isAlive == false)
                {
                    Console.WriteLine("Du hast das Monster besiegt.");
                    attack = false;
                    Console.WriteLine(
                        $"Was möchtest du erhalten ? {monster.CoinAward} Coins (press c) oder {monster.CoinAward} Willenspunkte (press w) ?");
                    string choice = Console.ReadLine();
                    if (choice == "w")
                    {
                        this.GetWillenskraft(monster.CoinAward);
                        Console.WriteLine("Du hast jetze " + this.Willenskraft + " Willenspunkte.");
                        break;
                    }
                    else if (choice == "c")
                    {
                        this.GetCoins(monster.CoinAward);
                        Console.WriteLine("Du hast jetze " + this.Coins + " Coins.");
                        break;
                    }
                }

            }
            else if (powerHeld < powerMonster)
            {
                this.GetDamage(powerMonster - powerHeld);
                Console.WriteLine($"Der {monster.Name} hat dich getroffen und hat dir {powerMonster - powerHeld} Willenspunkte abgezogen!");
                Console.WriteLine("Du hast noch " + this.Willenskraft + " Willenspunkte.");
                if (this.Willenskraft <= 0)
                {
                    this.isAlive = false;
                    attack = false;
                    Console.WriteLine("Du wurdest besiegt.");
                    Console.WriteLine("Das Spiel ist vorbei.");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Es ist ein Unentschieden.");
            }
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("Die Runde ist vorbei. Möchtest du fliehen oder nochmals kämpfen ? (f) oder (k)");
            string choice2 = Console.ReadLine();
            if (choice2 == "f")
            {
                attack = false;
            }

            if (usedRune == true)
            {
                this.GetStärkepunkte(this.Stärkepunkte / 2);
                usedRune = false;
            }
        }
        
    }

    internal virtual bool GetAbility(string ability)
    {
        for (int i = 0; i < this.Inventar.Length; i++)
        {
            if (this.Inventar[i] == "Leer")
            {
                this.Inventar[i] = ability;
                Console.WriteLine("Du hast die Fähigkeit " + ability + " erhalten.");
                this.emptySlots--;
                return true;
            }
        }

        if (this.emptySlots == 0)
        {
            this.isInventarFull = true;
            Console.WriteLine("Dein Inventar ist voll.");
            return false;
        }

        return false;
    }
    
    internal virtual void GetStärkepunkte(int stärkepunkte)
    {
        this.Stärkepunkte += stärkepunkte;
        Console.WriteLine("Du hast " + stärkepunkte + " Stärkepunkte erhalten.");
        Console.WriteLine("Du hast " + this.Stärkepunkte + " Stärkepunkte.");
    }

    internal virtual void GetWillenskraft(int willenskraft)
    {
        this.Willenskraft += willenskraft;
        Console.WriteLine("Du hast " + willenskraft + " Willenspunkte erhalten.");
    }
    
    internal virtual void PrintInfo()
    {
        Console.WriteLine("Name: " + this.Name);
        Console.WriteLine("Stärkepunkte: " + this.Stärkepunkte);
        Console.WriteLine("Willenspunkte: " + this.Willenskraft);
        Console.WriteLine("Münzen: " + this.Coins);
        Console.WriteLine("Inventar: ");
        foreach (string item in this.Inventar)
        {
            Console.WriteLine(item);
        }
    }
    
    internal virtual void GetDamage(int schaden)
    {
        this.Willenskraft -= schaden;
        if (this.Willenskraft <= 0)
        {
            this.isAlive = false;
        }
        Console.WriteLine("Du hast jetzt " + this.Willenskraft + " Willenspunkte.");
    }
    
    internal virtual void GetCoins(int coins)
    {
        this.Coins += coins;
        Console.WriteLine("Du hast " + coins + " Münzen erhalten.");
        Console.WriteLine("DU hast jetz " + this.Coins + " Münzen.");
    }
    
}

namespace AndorOOP
{
    internal class Monster
    {
        internal int Willenskraft { get; set; }
        internal int Stärkepunkte { get; set; }
        internal string Name { get; set; }
        internal bool isAlive { get; set; }
        internal int CoinAward { get; }

        private static Random random = new Random();

        internal Monster(string name, int willenskraft, int stärkepunkte, int coinaward)
        {
            this.Name = name;
            this.Willenskraft = willenskraft;
            this.Stärkepunkte = stärkepunkte;
            this.isAlive = true;
            this.CoinAward = coinaward;
        }

        internal static Monster CreateRandomMonster()
        {
            MonsterType type = (MonsterType)random.Next(0, 3);

            switch (type)
            {
                case MonsterType.Gor:
                    return new Monster("Gor", 5, 3, 2);
                case MonsterType.Ork:
                    return new Monster("Ork", 7, 4, 3);
                case MonsterType.Troll:
                    return new Monster("Troll", 10, 5, 4);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal void Angriff(Held held)
        {
            held.GetDamage(this.Stärkepunkte);
        }

        internal void GetDamage(int damage)
        {
            this.Willenskraft -= damage;
            if (this.Willenskraft <= 0)
            {
                this.isAlive = false;
            }
        }
    }
}
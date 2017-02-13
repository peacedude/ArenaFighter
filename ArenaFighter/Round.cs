using System;

namespace ArenaFighter
{
    public class Round
    {
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        Fight fight = new Fight();

        private int enemyHP;
        private int heroHP;
        private int enemyStrength;
        private int heroStrength;

        private int diceThrow;



        public int ThrowDice()
        {
            diceThrow = rnd.Next(1, 6);
            return diceThrow;
        }

        public void DoRound(int hStr, int eStr, int hHP, int eHP, int hDmg, int eDmg, string name)
        {
            HeroHP = hHP;
            enemyHP = eHP;
            int heroDice = ThrowDice();
            int enemyDice = ThrowDice();
            int heroRoll = heroDice + hStr;
            int enemyRoll = enemyDice + eStr;
            if (heroDice + hStr > enemyDice + eStr)
            {
                enemyHP = eHP - hDmg;

                Console.WriteLine("----------\n" + "Rolls: You " + heroRoll + " (" + hStr + "+" + heroDice + ") vs "
                    + name + " " + enemyRoll + "(" + eStr + "+" + enemyDice + ")");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You deal " + hDmg + " to " + name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Remaining Health: You(" + heroHP + "), " + name + " (");
                if (enemyHP <= 0)
                {
                    Console.Write("Dead");
                    Console.Write(")\n----------\n");
                }
                else
                    Console.Write(enemyHP + ")\n----------\n");
                Console.ReadKey(true);
            }
            else if (heroDice + hStr < enemyDice + eStr)
            {
                heroHP = hHP - eDmg;
                Console.WriteLine("----------\n" + "Rolls: You " + heroRoll + " (" + hStr + "+" + heroDice + ") vs "
                    + name + " " + enemyRoll + "(" + eStr + "+" + enemyDice + ")");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(name + " deals " + eDmg + " to " + "you");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Remaining Health: You (");
                if (heroHP <= 0)
                {
                    Console.Write("Dead");
                    Console.Write("), " + name + " (" + enemyHP + ")\n----------\n");
                }
                else
                    Console.Write(heroHP + "), " + name + " (" + enemyHP + ")\n----------\n");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("\n----------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You both strike and miss");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("----------\n");

                Console.ReadKey(true);
            }


        }
        public int EnemyHP
        {
            get
            {
                return enemyHP;
            }

            set
            {
                enemyHP = value;
            }
        }

        public int HeroHP
        {
            get
            {
                return heroHP;
            }

            set
            {
                heroHP = value;
            }
        }

        public int EnemyStrength
        {
            get
            {
                return enemyStrength;
            }

            set
            {
                enemyStrength = value;
            }
        }

        public int HeroStrength
        {
            get
            {
                return heroStrength;
            }

            set
            {
                heroStrength = value;
            }
        }

    }

}

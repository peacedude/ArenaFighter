using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class CharGen
    {
        private int health;
        private int strength;
        private int damage;
        private int maxHealth;
        private int gold;
        private int score;
        private int goldCost;
        private bool alive;
        private string name;
        private bool PlayerWantsOut;
        private string killer;
        private List<string> kills = new List<string>();
        Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }

        public int Strength
        {
            get
            {
                return strength;
            }

            set
            {
                strength = value;
            }
        }

        public int Damage
        {
            get
            {
                return damage;
            }

            set
            {
                damage = value;
            }
        }

        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }

            set
            {
                maxHealth = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public bool Alive
        {
            get
            {
                return alive;
            }

            set
            {
                alive = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool PlayerWantsOut1
        {
            get
            {
                return PlayerWantsOut;
            }

            set
            {
                PlayerWantsOut = value;
            }
        }

        public string Killer
        {
            get
            {
                return killer;
            }

            set
            {
                killer = value;
            }
        }

        public int Gold
        {
            get
            {
                return gold;
            }

            set
            {
                gold = value;
            }
        }

        public int GoldCost
        {
            get
            {
                return goldCost;
            }

            set
            {
                goldCost = value;
            }
        }

        public CharGen()
        {

        }

        public void GetChar()
        {
            Console.WriteLine("Name: {0}\nHealth: {1}\nStrength: {2}\nDamage: {3}\nGold: {4}\n", Name, Health, Strength, Damage, Gold);
        }
        public void AddScore()
        {
            score++;
        }
        public bool GetAlive()
        {
            return alive;
        }
        public void SetKeepOn(bool value)
        {
            PlayerWantsOut = value;
        }

        public bool GetKeepOn()
        {
            return PlayerWantsOut;
        }
        public void GetMenu()
        {
            Console.Clear();
            GetChar();
            Console.WriteLine("Press 'F' to fight\nPress 'S' to surrender");
            bool endLoop = false;
            if (Gold >= GoldCost)
            {
                Console.WriteLine("\nPress D To Upgrade Damage. Cost: {0}", goldCost);

            }

            endLoop = false;
            while (endLoop == false)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.F:
                        endLoop = true;
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("\nYou surrendered!");
                        Console.ReadKey(true);
                        endLoop = true;
                        SetKeepOn(false);
                        break;
                    case ConsoleKey.D:
                        if (gold >= goldCost)
                        {
                            gold = gold - goldCost;
                            Damage++;
                            goldCost = goldCost + 2;
                            GetMenu();
                            endLoop = true;
                        }
                        break;
                    default:
                        break;

                }
            }
        }
        public void GetStats()
        {
            Console.Clear();
            Console.WriteLine("Final statistics:\n\nName: {0}\nHealth: {1}\nStrength: {2}\nDamage: {3}\nGold: {4}\n\nScore: {5}\n", Name, MaxHealth, Strength, Damage, Gold, Score);
            if (kills.Count > 0)
            {
                Console.WriteLine("You killed: ");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string name in kills)
            {
                Console.WriteLine(name);
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (killer != null)
            {
                Console.WriteLine("Killed by:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(killer);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void AddKill(string name)
        {
            kills.Add(name);
        }
        public void CreateCharacter(string heroName)
        {
            if (heroName == "EasyMode")
            {
                Strength = 30;
                Health = 30;
                MaxHealth = 30;
                Damage = 30;
                Gold = 30;
                GoldCost = 1;
                Score = 0;

            }
            else
            {
                Strength = rnd.Next(4, 8);
                if (heroName == "Kill me")
                    Health = 1;
                else
                    Health = rnd.Next(6, 10);
                MaxHealth = Health;
                Damage = rnd.Next(1, 4);
                if (heroName == "Gold") gold = 300;
                else
                    Gold = 0;
                GoldCost = 1;
                Score = 0;
            }
            if (heroName == null)
            {
                Name = GenerateEnemyName();

            }
            else
            {
                Name = heroName;
            }


        }
        private string GenerateEnemyName()
        {
            string[] enemyNames;
            enemyNames = new string[13];
            enemyNames[0] = "Olof";
            enemyNames[1] = "Hilda";
            enemyNames[2] = "Per";
            enemyNames[3] = "Brynhild";
            enemyNames[4] = "Siv";
            enemyNames[5] = "Arne";
            enemyNames[6] = "Harald";
            enemyNames[7] = "Ivar";
            enemyNames[8] = "Olav";
            enemyNames[9] = "Rolf";
            enemyNames[10] = "RagnHild";
            enemyNames[11] = "Gudrun";
            enemyNames[12] = "Ulf";

            string[] enemyLastNames;
            enemyLastNames = new string[10];
            enemyLastNames[0] = "Ahlberg";
            enemyLastNames[1] = "Beck";
            enemyLastNames[2] = "Blom";
            enemyLastNames[3] = "Brand";
            enemyLastNames[4] = "Brant";
            enemyLastNames[5] = "Byquist";
            enemyLastNames[6] = "Randel";
            enemyLastNames[7] = "Thorburn";
            enemyLastNames[8] = "Thurstan";
            enemyLastNames[9] = "Westerberg";

            return enemyNames[rnd.Next(0, 12)] + " " + enemyLastNames[rnd.Next(0, 10)];
        }
    }
}

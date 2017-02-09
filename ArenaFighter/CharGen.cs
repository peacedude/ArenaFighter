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
        private int maxHealth;
        private int strength;
        private int damage;
        private int score;
        private bool alive;
        private string name;
        private bool PlayerWantsOut;
        private List<string> kills = new List<string>();
        Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public CharGen()
        {

        }

        public void GetChar()
        {
            Console.WriteLine("Name: " + GetName() + "\nHealth: " + GetHealth() + "\nStrength: " + GetStrength() + "\nDamage: " + GetDamage() + "\n");
        }
        public int GetHealth()
        {
            return health;
        }
        public int GetStrength()
        {
            return strength;
        }
        public int GetDamage()
        {
            return damage;
        }
        public string GetName()
        {
            return name;
        }
        public int GetMaxHealth()
        {
            return maxHealth;
        }
        public int GetScore()
        {
            return score;
        }
        public void AddScore()
        {
            score++;
        }
        public void SetMaxHealth(int value)
        {
            maxHealth = value;
        }
        public void SetHealth(int value)
        {
            health = value;
        }
        private void SetStrength(int value)
        {
            strength = value;
        }
        private void SetDamage(int value)
        {
            damage = value;
        }
        private void SetName(string value)
        {
            name = value;
        }
        public void SetAlive(bool value)
        {
            alive = value;
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
            do
            {
                if (Console.ReadKey(true).Key == ConsoleKey.F)
                {
                    Console.WriteLine("Fight!");
                    endLoop = true;
                }

                else if (Console.ReadKey(true).Key == ConsoleKey.S)
                {
                    Console.WriteLine("You surrendered!");
                    endLoop = true;
                    SetKeepOn(false);
                }

            } while (endLoop == false);
        }
        public void GetStats()
        {
            if (GetHealth() <= 0)
            {
                Console.Clear();
                Console.WriteLine("Final statistics:\n\nName: " + GetName() + "\nHealth: Dead" + "\nStrength: " + GetStrength() + "\nDamage: " + GetDamage() + "\n" + "Kills:");
                foreach(string name in kills)
                {
                    Console.WriteLine(name);
                }
            }
            Console.Clear();
            Console.WriteLine("Final statistics:\n\nName: " + GetName() + "\nHealth: " + GetMaxHealth() + "\nStrength: " + GetStrength() + "\nDamage: " + GetDamage() + "\n\nScore: " + score + "\n");
            foreach (string name in kills)
            {
                Console.WriteLine("You won against " + name);
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
                SetStrength(30);
                SetHealth(30);
                SetMaxHealth(30);
                SetDamage(30);
                score = 0;

            }
            else
            {
                SetStrength(rnd.Next(4, 7));
                SetHealth(rnd.Next(6, 10));
                SetMaxHealth(GetHealth());
                SetDamage(rnd.Next(1, 4));
                score = 0;
            }
            if (heroName == null)
            {
                string[] enemyNames;
                enemyNames = new string[3];
                enemyNames[0] = "Olof";
                enemyNames[1] = "Hilda";
                enemyNames[2] = "Per";

                SetName(enemyNames[rnd.Next(0, 2)]);

            }
            else
            {
                SetName(heroName);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class Program
    {
        static void Main(string[] args)
        {
            string heroName = null;
            do
            {
                Console.Clear();
                Console.Write("Enter the name of your fighter: ");
                heroName = Console.ReadLine();
            } while (string.IsNullOrEmpty(heroName));

            CharGen hero = new CharGen();
            hero.CreateCharacter(heroName);
            hero.SetKeepOn(true);
            hero.GetMenu();
            if(hero.GetKeepOn() == true)
            {
                do
                {
                    CharGen enemy = new CharGen();
                    Fight fight = new Fight();
                    enemy.CreateCharacter(null);
                    fight.SetHero(hero.GetHealth(), hero.GetStrength(), hero.GetDamage());
                    fight.SetEnemy(enemy.GetHealth(), enemy.GetStrength(), enemy.GetDamage());
                    fight.Battle();
                    Console.Clear();
                    Console.WriteLine("Player:");
                    hero.GetChar();
                    Console.WriteLine("Enemy:");
                    enemy.GetChar();
                    Console.ReadKey(true);

                    hero.SetHealth(fight.heroHP());
                    enemy.SetHealth(fight.enemyHP());
                    if(enemy.GetHealth() <= 0)
                    {
                        hero.AddKill(enemy.GetName());
                        hero.AddScore();
                    }
                    
                    hero.GetMenu();
                
                } while (hero.GetHealth() >= 0 && hero.GetKeepOn() == true);
            }
            hero.GetStats();

            Console.ReadKey(true);

        }
    }
}

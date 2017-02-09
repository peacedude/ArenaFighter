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
            Console.ForegroundColor = ConsoleColor.White;
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
                while (hero.Health >= 0 && hero.GetKeepOn() == true)
                {
                    CharGen enemy = new CharGen();
                    Fight fight = new Fight();
                    enemy.CreateCharacter(null);
                    enemy.Gold = 1;
                    fight.SetHero(hero.Health, hero.Strength, hero.Damage);
                    fight.SetEnemy(enemy.Health, enemy.Strength, enemy.Damage, enemy.Name);
                    
                    Console.Clear();
                    Console.WriteLine("Player:");
                    hero.GetChar();
                    Console.WriteLine("Enemy:");
                    enemy.GetChar();

                    Console.WriteLine("Press any key to attack... \n");

                    Console.ReadKey(true);
                    Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");

                    fight.Battle();

                    hero.Health = fight.heroHealth;
                    enemy.Health = fight.enemyHealth;
                    if(enemy.Health <= 0)
                    {
                        hero.AddKill(enemy.Name);
                        Console.WriteLine("You defeated " + enemy.Name + " in the arena!");
                        Console.ReadKey(true);
                        hero.AddScore();
                        hero.Gold = enemy.Gold + hero.Gold;
                        hero.Health = hero.MaxHealth;

                        hero.GetMenu();
                    }
                    if (hero.Health <= 0)
                    {
                        Console.WriteLine(enemy.Name + "killed you in the arena!");
                        hero.SetKeepOn(false);
                        hero.Killer = enemy.Name;
                    }
                    
                    
                
                } 
            }
            hero.GetStats();

            Console.ReadKey(true);

        }
    }
}

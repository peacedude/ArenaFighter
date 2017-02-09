using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class Fight
    {
        int heroHealth;
        int heroStrength;
        int heroDamage;
        int enemyHealth;
        int enemyStrength;
        int enemyDamage;

        string heroName;
        public void SetHero(int health, int strength, int damage)
        {
            heroHealth = health;
            heroStrength = strength;
            heroDamage = damage; 
        }
        public void SetEnemy(int health, int strength, int damage)
        {
            enemyHealth = health;
            enemyStrength = strength;
            enemyDamage = damage;
        }
        public int heroHP()
        {
            return heroHealth;
        }
        public int enemyHP()
        {
            return enemyHealth;
        }
        public bool Battle()
        {
            do
            {
                Round round = new Round();
                round.DoBattle();
                if (enemyHealth <= 0)
                    return true;
                else if (heroHealth <= 0)
                    return false;


            } while (heroHealth > 0 && enemyHealth > 0);
        }
    }
}

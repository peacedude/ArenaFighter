using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class Fight
    {
        public int heroHealth;
        public int heroStrength;
        public int heroDamage;
        public int enemyHealth;
        public int enemyStrength;
        public int enemyDamage;

        public string enemyName;

        public int EnemyHealth
        {
            get
            {
                return enemyHealth;
            }

            set
            {
                enemyHealth = value;
            }
        }

        public int HeroHealth
        {
            get
            {
                return heroHealth;
            }

            set
            {
                heroHealth = value;
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

        public int HeroDamage
        {
            get
            {
                return heroDamage;
            }

            set
            {
                heroDamage = value;
            }
        }

        public int EnemyHealth1
        {
            get
            {
                return enemyHealth;
            }

            set
            {
                enemyHealth = value;
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

        public int EnemyDamage
        {
            get
            {
                return enemyDamage;
            }

            set
            {
                enemyDamage = value;
            }
        }

        public string EnemyName
        {
            get
            {
                return enemyName;
            }

            set
            {
                enemyName = value;
            }
        }

        public void SetHero(int health, int strength, int damage)
        {
            heroHealth = health;
            heroStrength = strength;
            heroDamage = damage;
        }
        public void SetHeroHP(int health)
        {
            heroHealth = health;
        }
        public void SetEnemy(int health, int strength, int damage, string name)
        {
            enemyHealth = health;
            enemyStrength = strength;
            enemyDamage = damage;
            enemyName = name;
        }
        public int GetheroHP()
        {
            return heroHealth;
        }
        public int GetenemyHP()
        {
            return enemyHealth;
        }
        public void Battle()
        {
            while (heroHealth > 0 && enemyHealth > 0)
            {
                Round round = new Round();
                round.DoRound(heroStrength, enemyStrength, heroHealth, enemyHealth, heroDamage, enemyDamage, enemyName);

                {
                    if (round.HeroHP < HeroHealth)
                        heroHealth = heroHealth - enemyDamage;
                    else if (round.EnemyHP < EnemyHealth)
                        EnemyHealth = EnemyHealth - HeroDamage;

                }
            }
        }
    }
}

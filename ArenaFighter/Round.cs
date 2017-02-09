using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class Round
    {
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        Fight fight = new Fight();

        private int enemyHP;

        private int diceThrow;

        public int ThrowDice()
        {
            diceThrow = rnd.Next(1, 6);
            return diceThrow;
        }
        
        public void DoBattle()
        {
            enemyHP = fight.enemyHP();

                
        }
        public void Test()
        {
            
        }

    }

}

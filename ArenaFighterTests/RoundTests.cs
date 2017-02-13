using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArenaFighter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter.Tests
{
    [TestClass()]
    public class RoundTests
    {
        [TestMethod()]
        public void ThrowDiceTest()
        {
            
            Round round = new Round();
            int diceThrow = round.ThrowDice();
            if(diceThrow <= 0)
                Assert.Fail();
        }
    }
}
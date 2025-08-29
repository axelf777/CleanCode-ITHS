using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCode.Data;

namespace CleanCodeTests
{
    [TestClass()]
    public class PlayerDataTests
    {
        [TestMethod()]
        public void PlayerDataConstructorTest()
        {
            PlayerData player = new("Alice");
            Assert.AreEqual("Alice", player.Name);
        }

        [TestMethod()]
        public void PlayerUpdateTest()
        {
            PlayerData player = new("Bobber");
            player.Update(7);
            Assert.AreEqual(7, player.TotalGuesses);
        }

        [TestMethod()]
        public void PlayerResetGuessesTest()
        {
            PlayerData player = new("Charlie");
            player.Update(5);
            player.ResetGuesses();
            Assert.AreEqual(0, player.TotalGuesses);
        }
    }

}
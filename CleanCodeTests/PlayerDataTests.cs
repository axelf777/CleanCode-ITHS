using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Tests
{
    [TestClass()]
    public class PlayerDataTests
    {
        [TestMethod()]
        public void PlayerDataConstructorTest()
        {
            PlayerData player = new PlayerData("Alice");
            Assert.AreEqual("Alice", player.Name);
        }

        [TestMethod()]
        public void PlayerUpdateTest()
        {
            PlayerData player = new PlayerData("Bobber");
            player.Update(7);
            Assert.AreEqual(7, player.TotalGuesses);
        }

        [TestMethod()]
        public void PlayerResetGuessesTest()
        {
            PlayerData player = new PlayerData("Charlie");
            player.Update(5);
            player.ResetGuesses();
            Assert.AreEqual(0, player.TotalGuesses);
        }
    }

}
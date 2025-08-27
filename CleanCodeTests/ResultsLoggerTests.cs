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
    public class ResultsLoggerTests
    {
        [TestMethod()]
        public void SaveAndRetrievePlayerDataTest()
        {
            PlayerData player = new PlayerData("TestPlayer", 5);
            ResultsLogger.SavePlayerData(player);
            List<PlayerData> topPlayers = ResultsLogger.RetrieveTopPlayers();
            Assert.IsTrue(topPlayers.Any(p => p.Name == "TestPlayer" && p.totalGuesses >= 5));
        }
    }
}
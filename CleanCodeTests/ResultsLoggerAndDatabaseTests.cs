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
    public class ResultsLoggerAndDatabaseTests
    {
        [TestMethod()]
        public void SaveAndRetrievePlayerDataTest()
        {
            using (var context = new PlayerDbContext())
            {
                context.Players.RemoveRange(context.Players);
                context.SaveChanges();
            }

            PlayerData player1 = new PlayerData("Alice");
            PlayerData player2 = new PlayerData("Bob");
            IGameTypes mooGame = new MooGame();
            IGameTypes masterMindGame = new MastermindGame();
            player1.Update(5);
            player2.Update(3);
            ResultsLogger.SavePlayerData(player1, mooGame.GameName);
            ResultsLogger.SavePlayerData(player2, masterMindGame.GameName);
            List<PlayerModel> mooGamePlayers = ResultsLogger.RetrieveTopPlayers(mooGame.GameName);
            List<PlayerModel> masterMindGamePlayers = ResultsLogger.RetrieveTopPlayers(masterMindGame.GameName);
            Assert.IsTrue(mooGamePlayers.Any(p => p.Name == "Alice" && p.TotalGuesses == 5 && p.GameType == mooGame.GameName));
            Assert.IsTrue(masterMindGamePlayers.Any(p => p.Name == "Bob" && p.TotalGuesses == 3 && p.GameType == masterMindGame.GameName));
        }
    }
}
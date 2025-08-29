using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCode.Game;
using CleanCode.Services;
using CleanCode;

namespace CleanCodeTests
{
    [TestClass()]
    public class IntegrationTests
    {
        [TestMethod()]
        public void GameLoopIntegrationTest()
        {
            // This one test basically tests everything
            FakeUserIO fakeIO = new(
                "",                         // empty name
                "SuperLongNameDefientelyWontWork", // too long
                "|",                        // invalid character
                "Timmy",                    // valid name
                "3",                        // invalid game type
                "1",                        // choose MooGame
                "n",                        // do not cheat
                "5678",                     // should return blank
                "4321",                     // should return CCCC
                "1234",                     // correct guess
                "n"                         // to exit
            );
            GameContextFactory contextFactory = new(fakeIO, new FakeGameData());
            GameEngine gameEngine = new(contextFactory, new PlayerSetupService(fakeIO));
            gameEngine.Run();

            var outputs = fakeIO.Outputs;

            Assert.IsTrue(outputs.Any(o => o.Contains("Enter a user name:")));
            Assert.IsTrue(outputs.Any(o => o.Contains("Please enter a valid user name:")));
            Assert.IsTrue(outputs.Any(o => o.Contains("Hello Timmy!")));

            Assert.IsTrue(outputs.Any(o => o.StartsWith("Select game type:")));
            Assert.IsTrue(outputs.Any(o => o.Contains("Please enter a valid choice")));
            Assert.IsTrue(outputs.Any(o => o.Contains("New game of Moo")));
            Assert.IsTrue(outputs.Any(o => o.StartsWith("The rules are:")));

            Assert.IsTrue(outputs.Any(o => o.Contains("Do you want to cheat?")));

            Assert.IsFalse(outputs.Any(o => o.Contains("For practice"))); // We answer no so shouldnt show up


            Assert.IsTrue(outputs.Any(o => o.Contains("Enter your guess")));
            Assert.IsTrue(outputs.Any(o => o.Contains("CCCC")));

            Assert.IsTrue(outputs.Any(o => o.Contains("Congratulations!")));
            Assert.IsTrue(outputs.Any(o => o.Contains("Top Players:")));

            Assert.IsTrue(outputs.Any(o => o.Contains("Do you want to play again?")));
        }
    }
}
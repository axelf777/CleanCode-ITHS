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
    public class GameDataTests
    {
        private IGameTypes _mooGame = new MooGame();
        private IGameTypes _masterMindGame = new MastermindGame();

        [TestMethod()]
        public void GameDataConstructor_And_MakeGoalNumbers_Test()
        {
            GameData game = new GameData();
            game.SetGameData(_mooGame);
            Assert.AreEqual(4, game.Goal.Length);
            foreach (int number in game.Goal)
            {
                int numberValue = (int)char.GetNumericValue((char)number);
                Assert.IsTrue(numberValue >= 0 && numberValue <= 9);
            }
            Assert.AreEqual(4, game.Goal.Distinct().Count());

            GameData game2 = new GameData();
            game2.SetGameData(_masterMindGame);
            foreach (int number in game2.Goal)
            {
                int numberValue = (int)char.GetNumericValue((char)number);
                Assert.IsTrue(numberValue >= 0 && numberValue <= 6);
            }
        }


        [TestMethod()]
        public void IsCorrectGuessTest()
        {
            GameData game = new GameData();
            game.SetGameData(_mooGame);
            game.LastGuess = game.Goal;
            game.LastGuess = "1234";
            if (game.Goal != "1234")
            {
                Assert.IsFalse(game.IsCorrectGuess());
            }
            else
            {
                game.LastGuess = "5678";
                Assert.IsFalse(game.IsCorrectGuess());
            }
        }

        [TestMethod()]
        public void PrintBullsAndCowsTest()
        {
            GameData game = new GameData();
            game.SetGameData(_mooGame);
            game.LastGuess = game.Goal;
            Assert.AreEqual("BBBB", game.PrintCorrectAndMisplacedChars());

            var allDigits = "0123456789".ToList();
            var excluded = game.Goal.ToCharArray();
            var noMatchGuess = new string(allDigits
                .Except(excluded)
                .Take(4)
                .ToArray());

            game.LastGuess = noMatchGuess;
            Assert.AreEqual("", game.PrintCorrectAndMisplacedChars());

            var oneMatchGuess = game.Goal[0] + new string(allDigits
                .Except(excluded)
                .Take(3)
                .ToArray());

            game.LastGuess = oneMatchGuess;
            Assert.AreEqual(1, game.PrintCorrectAndMisplacedChars().Length);

            var twoMatchGuess = new string(new[] { game.Goal[0], game.Goal[1] })
                + new string(allDigits
                .Except(excluded)
                .Take(2)
                .ToArray());

            game.LastGuess = twoMatchGuess;
            Assert.AreEqual(2, game.PrintCorrectAndMisplacedChars().Length);

            var threeMatchGuess = new string(new[] { game.Goal[0], game.Goal[1], game.Goal[2] })
                + new string(allDigits
                .Except(excluded)
                .Take(1)
                .ToArray());

            game.LastGuess = threeMatchGuess;
            Assert.AreEqual(3, game.PrintCorrectAndMisplacedChars().Length);

            GameData game2 = new GameData();
            game2.SetGameData(_masterMindGame);
            game2.LastGuess = game2.Goal;
            Assert.AreEqual("WWWW", game2.PrintCorrectAndMisplacedChars());
        }
    }
}
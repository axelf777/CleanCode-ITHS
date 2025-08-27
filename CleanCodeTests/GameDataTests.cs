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
        [TestMethod()]
        public void GameDataConstructor_And_MakeGoalNumbers_Test()
        {
            GameData game = new GameData();
            Assert.AreEqual(4, game.Goal.Length);
            foreach (int number in game.Goal)
            {
                int numberValue = (int)char.GetNumericValue((char)number);
                Assert.IsTrue(numberValue >= 0 && numberValue <= 9);
            }
            Assert.AreEqual(4, game.Goal.Distinct().Count());
        }

        [TestMethod()]
        public void RestartGameTest()
        {
            GameData game = new GameData();
            Assert.IsTrue(game.RestartGame("yes"));
            Assert.IsTrue(game.RestartGame("y"));
            Assert.IsFalse(game.RestartGame("no"));
            Assert.IsFalse(game.RestartGame("n"));
            Assert.IsFalse(game.RestartGame(""));
            Assert.IsFalse(game.RestartGame(null));
        }

        [TestMethod()]
        public void IsCorrectGuessTest()
        {
            GameData game = new GameData();
            game.LastGuess = game.Goal;
            Assert.IsTrue(game.IsCorrectGuess());
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
            game.LastGuess = game.Goal;
            Assert.AreEqual("BBBB", game.PrintBullsAndCows());

            var allDigits = "0123456789".ToList();
            var excluded = game.Goal.ToCharArray();
            var noMatchGuess = new string(allDigits
                .Except(excluded)
                .Take(4)
                .ToArray());

            game.LastGuess = noMatchGuess;
            Assert.AreEqual("", game.PrintBullsAndCows());

            var oneMatchGuess = game.Goal[0] + new string(allDigits
                .Except(excluded)
                .Take(3)
                .ToArray());

            game.LastGuess = oneMatchGuess;
            Assert.AreEqual(1, game.PrintBullsAndCows().Length);

            var twoMatchGuess = new string(new[] { game.Goal[0], game.Goal[1] })
                + new string(allDigits
                .Except(excluded)
                .Take(2)
                .ToArray());

            game.LastGuess = twoMatchGuess;
            Assert.AreEqual(2, game.PrintBullsAndCows().Length);

            var threeMatchGuess = new string(new[] { game.Goal[0], game.Goal[1], game.Goal[2] })
                + new string(allDigits
                .Except(excluded)
                .Take(1)
                .ToArray());

            game.LastGuess = threeMatchGuess;
            Assert.AreEqual(3, game.PrintBullsAndCows().Length);

        }


        [TestMethod()]
        public void IsValidInputTest()
        {
            string validInput = "1234";
            string shortInput = "123";
            string longInput = "12345";
            string nonDigitInput = "12a4";
            string repeatingInput = "1123";
            string emptyInput = "";
            string nullInput = null;

            Assert.IsFalse(GameData.IsValidInput(emptyInput));
            Assert.IsTrue(GameData.IsValidInput(validInput));
            Assert.IsFalse(GameData.IsValidInput(shortInput));
            Assert.IsFalse(GameData.IsValidInput(longInput));
            Assert.IsFalse(GameData.IsValidInput(nonDigitInput));
            Assert.IsFalse(GameData.IsValidInput(repeatingInput));
            Assert.IsFalse(GameData.IsValidInput(nullInput));
        }
    }
}
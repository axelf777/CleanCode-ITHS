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
    public class GameEngineTests
    {
        [TestMethod()]
        public void GameEngineConstructor_And_AskForPlayerName_ValidInput_Test()
        {
            // This one test basically tests everything
            FakeUserIO fakeIO = new FakeUserIO(
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

            GameEngine gameEngine = new GameEngine(fakeIO, new FakeGameData());
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

        internal class FakeGameData : IGameData
        {
            public string? Goal { get; private set; } = "1234";
            public string? LastGuess { get; set; }
            private IGameTypes? _gameType;
            public void SetGameData(IGameTypes gameType)
            {
                _gameType = gameType;
                LastGuess = "";
            }
            public bool IsCorrectGuess()
            {
                return LastGuess == Goal;
            }
            public string PrintCorrectAndMisplacedChars()
            {
                int correct = 0, misplaced = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (Goal[i] == LastGuess[i])
                    {
                        correct++;
                    }
                    else if (Goal.Contains(LastGuess[i]))
                    {
                        misplaced++;
                    }
                }
                return $"{new string(_gameType.CorrectChar, correct)}{new string(_gameType.MisplacedChar, misplaced)}";
            }
        }
        internal class FakeUserIO : IUserIO
        {
            private Queue<string> _inputs = new Queue<string>();
            public List<string> Outputs = new List<string>();
            public FakeUserIO(params string[] inputs)
            {
                foreach (string input in inputs)
                {
                    _inputs.Enqueue(input);
                }
            }
            public string Read()
            {
                return _inputs.Dequeue();
            }
            public void Write(string message)
            {
                Outputs.Add(message);
            }
        }
    }
}
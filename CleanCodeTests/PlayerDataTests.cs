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
            PlayerData player = new PlayerData("Alice", 5);
            Assert.AreEqual(1, player.numberOfGames);
            Assert.AreEqual(5, player.totalGuesses);
        }

        [TestMethod()]
        public void PlayerUpdateTest()
        {
            PlayerData player = new PlayerData("Bobber", 10);
            player.Update(7);
            Assert.AreEqual(2, player.numberOfGames);
            Assert.AreEqual(17, player.totalGuesses);
        }

        [TestMethod()]
        public void PlayerAverageTest()
        {
            PlayerData player = new PlayerData("Charlemagne", 20);
            player.Update(10);
            double average = player.Average();
            Assert.AreEqual(15.0, average);
        }

        [TestMethod()]
        public void PlayerEqualityTest()
        {
            PlayerData player1 = new PlayerData("Dora", 8);
            PlayerData player2 = new PlayerData("Dora", 15);
            PlayerData player3 = new PlayerData("Eve", 8);
            Assert.IsTrue(player1.Equals(player2));
            Assert.IsFalse(player1.Equals(player3));
        }

        [TestMethod()]
        public void PlayerHashCodeTest()
        {
            PlayerData player1 = new PlayerData("Frank", 12);
            PlayerData player2 = new PlayerData("Frank", 20);
            Assert.AreEqual(player1.GetHashCode(), player2.GetHashCode());
        }

        [TestMethod()]
        public void GameEngineConstructor_And_AskForPlayerName_ValidInput_Test()
        {
            FakeUserIO fakeIO = new FakeUserIO("", "SuperLongNameDefientelyWontWork", "|", "Timmy");
            PlayerData player = PlayerData.AskForPlayerName(fakeIO);
            Assert.AreEqual("Timmy", player.Name);
            int numberOfExpectedOutputs = 4;
            Assert.AreEqual(numberOfExpectedOutputs, fakeIO.Outputs.Count);
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
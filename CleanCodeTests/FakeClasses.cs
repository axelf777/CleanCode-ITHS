using CleanCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeTests
{
    public class FakeGameData : IGameData
    {
        public string? Goal { get; } = "1234";
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
    public class FakeUserIO : IUserIO
    {
        private readonly Queue<string> _inputs = new();
        public List<string> Outputs = new();
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

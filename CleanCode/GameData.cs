using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class GameData : IGameData
    {
        public string? Goal { get; private set; }
        public string? LastGuess { get; set; }
        private IGameTypes? _gameType;
        public void SetGameData(IGameTypes gameType)
        {
            _gameType = gameType;
            LastGuess = "";
            Goal = MakeGoalNumbers();
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

        private string MakeGoalNumbers()
        {
            Random randomGenerator = new Random();
            string goal = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(_gameType.MaximumAllowedDigit);
                string randomDigit = "" + random;
                if (!_gameType.AllowDuplicates)
                {
                    while (goal.Contains(randomDigit))
                    {
                        random = randomGenerator.Next(_gameType.MaximumAllowedDigit);
                        randomDigit = "" + random;
                    }
                }

                goal = goal + randomDigit;
            }
            return goal;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class GameData
    {
        public string Goal { get; private set; }
        public string LastGuess { get; set; }
        public GameData()
        {
            Goal = MakeGoalNumbers();
            LastGuess = "";
        }
        public bool RestartGame(string answer)
        {
            if (answer != null && answer != "" && answer.Substring(0, 1) == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsCorrectGuess()
        {
            return LastGuess == Goal;
        }

        public string PrintBullsAndCows()
        {
            int bulls = 0, cows = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Goal[i] == LastGuess[i])
                {
                    bulls++;
                }
                else if (Goal.Contains(LastGuess[i]))
                {
                    cows++;
                }
            }
            return $"{new string('B', bulls)}{new string('C', cows)}";
        }
        public static string MakeGoalNumbers()
        {
            Random randomGenerator = new Random();
            string goal = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (goal.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                goal = goal + randomDigit;
            }
            return goal;
        }

        public static bool IsValidInput(string input)
        {
            return input != null
                && input.Length == 4
                && input.All(char.IsDigit)
                && input.Distinct().Count() == 4;
        }
    }
}

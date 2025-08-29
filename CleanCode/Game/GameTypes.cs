using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Game
{
    public class MooGame : IGameTypes
    {
        public int MaximumAllowedDigit { get { return 10; } }
        public bool AllowDuplicates { get { return false; } }
        public string GameName { get { return "Moo-game"; } }
        public char CorrectChar { get { return 'B'; } }
        public char MisplacedChar { get { return 'C'; } }
        public string Rules
        {
            get
            {
                return "- The goal is to guess a 4-digit number.\n" +
                       "- Digits range from 0 to 9.\n" +
                       "- Duplicates are not allowed.\n" +
                       "- After each guess, you'll receive feedback in the form of 'B' (bulls) and 'C' (cows).\n" +
                       "- An 'B' indicates a correct digit in the correct position.\n" +
                       "- An 'C' indicates a correct digit in the wrong position.\n" +
                       "- Blank means a digit does not exist.\n" +
                       "- Example: If the goal is 1234 and your guess is 1325, you'll get BCC.";
            }
        }
    }

    public class MastermindGame : IGameTypes
    {
        public int MaximumAllowedDigit { get { return 7; } }
        public bool AllowDuplicates { get { return true; } }
        public string GameName { get { return "Mastermind"; } }
        public char CorrectChar { get { return 'W'; } }
        public char MisplacedChar { get { return 'B'; } }
        public string Rules
        {
            get
            {
                return "- The goal is to guess a 4-digit number.\n" +
                       "- Digits range from 0 to 6.\n" +
                       "- Duplicates are allowed.\n" +
                       "- After each guess, you'll receive feedback in the form of 'W' (white) and 'B' (black).\n" +
                       "- A 'W' indicates a correct digit in the correct position.\n" +
                       "- A 'B' indicates a correct digit in the wrong position.\n" +
                       "- Blank means a digit does not exist.\n" +
                       "- Example: If the goal is 1234 and your guess is 1325, you'll get WBB.";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CleanCode.Services;


namespace CleanCode.Game
{
    public class GameSession
    {
        private readonly GameContext _context;
        public GameSession(GameContext gameContext)
        {
            _context = gameContext;
        }
        public int Play(bool isCheatEnabled)
        {
            _context.Io.Write($"New game of {_context.GameType.GameName}:\n");
            _context.Io.Write($"The rules are:\n{_context.GameType.Rules}\n");
            if (isCheatEnabled)
            {
                _context.Io.Write($"For practice (;-)), number is: {_context.Game.Goal}\n");
            }
            int guessCount = 0;
            while (!_context.Game.IsCorrectGuess())
            {
                _context.Io.Write("Enter your guess (4 digits):");
                string guess = _context.Io.Read();
                while (!InputValidatorService.IsValidInput(guess, _context.GameType))
                {
                    if (!_context.GameType.AllowDuplicates)
                    {
                        _context.Io.Write("Please enter a valid 4-digit number with no repeating digits:");
                    }
                    else
                    {
                        _context.Io.Write("Please enter a valid 4-digit number:");
                    }
                    guess = _context.Io.Read();
                }
                _context.Game.LastGuess = guess;
                guessCount++;
                _context.Io.Write(_context.Game.PrintCorrectAndMisplacedChars());
            }
            return guessCount;
        }

        public bool PlayAgain()
        {
            _context.Io.Write("Do you want to play again? (y/n)");
            string answer = _context.Io.Read();
            return InputValidatorService.IsYesOrNo(answer);
        }
    }
}

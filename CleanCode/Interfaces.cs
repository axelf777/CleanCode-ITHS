using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public interface IUserIO
    {
        void Write(string message);
        string Read();
    }

    public interface IGameTypes
    {
        int MaximumAllowedDigit { get; }
        bool AllowDuplicates { get; }
        string GameName { get; }
        string Rules { get; }
        char CorrectChar { get; }
        char MisplacedChar { get; }
    }

    public interface IGameData
    {
        string Goal { get; }
        string LastGuess { get; set; }
        bool IsCorrectGuess();
        string PrintCorrectAndMisplacedChars();
        void SetGameData(IGameTypes gameType);

    }
}

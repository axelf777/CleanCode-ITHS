using CleanCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CleanCode.Game;

namespace CleanCode.Services
{
    public class PlayerSetupService
    {
        private readonly IUserIO _io;
        public PlayerSetupService(IUserIO io )
        {
            _io = io;
        }

        public PlayerData AskForPlayerName()
        {
            _io.Write("Enter a user name:");
            string name = _io.Read();
            while (!InputValidatorService.IsValidName(name))
            {
                _io.Write("Please enter a valid user name:");
                name = _io.Read();
            }
            _io.Write($"Hello {name}!");
            return new PlayerData(name);
        }
        public IGameTypes AskForGameType()
        {
            _io.Write("Select game type:\n1. Moo-game\n2. Mastermind\n");
            string choice = _io.Read();
            while (choice != "1" && choice != "2")
            {
                _io.Write("Please enter a valid choice (1 or 2):");
                choice = _io.Read();
            }
            if (choice == "1")
            {
                return new MooGame();
            }
            else
            {
                return new MastermindGame();
            }
        }
        public bool IsCheatEnabled()
        {
            _io.Write("Do you want to cheat? (y/n)");
            string answer = _io.Read();
            return InputValidatorService.IsYesOrNo(answer);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanCode
{
    public class PlayerSetupService
    {
        private readonly IUserIO _io;
        private readonly InputValidatorService _inputService;
        public PlayerSetupService(IUserIO io, InputValidatorService inputService )
        {
            _io = io;
            _inputService = inputService;   
        }

        public PlayerData AskForPlayerName()
        {
            _io.Write("Enter a user name:");
            string name = _io.Read();
            while (!_inputService.IsValidName(name))
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
        public bool AskIfTheyWannaCheat()
        {
            _io.Write("Do you want to cheat? (y/n)");
            string answer = _io.Read();
            return _inputService.IsYesOrNo(answer);
        }
    }
}

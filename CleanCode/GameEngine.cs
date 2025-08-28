using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class GameEngine
    {
        private PlayerData? _player;
        private IUserIO _io;
        private IGameTypes? _gameType; 
        private IGameData _game;
        private InputValidatorService _inputService;
        private PlayerSetupService _playerService;

        public GameEngine(IUserIO io, IGameData gameData)
        {
            _io = io;
            _game = gameData;
            _inputService = new InputValidatorService();
            _playerService = new PlayerSetupService(io, _inputService);
        }

        public void Run()
        {
            _player = _playerService.AskForPlayerName();
            bool gameLoop = true;
            while (gameLoop)
            {
                _gameType = _playerService.AskForGameType();
                _game.SetGameData(_gameType);
                _io.Write($"New game of {_gameType.GameName}:\n");
                _io.Write($"The rules are:\n{_gameType.Rules}\n");
                if (_playerService.AskIfTheyWannaCheat())
                {
                    _io.Write($"For practice (;-)), number is: {_game.Goal}\n");
                }

                int guessCount = PlayOneGame();
                _player.Update(guessCount);
                ResultsLogger.SavePlayerData(_player, _gameType.GameName);
                PrintResults();

                _io.Write("Do you want to play again? (y/n)");
                string answer = _io.Read();
                _player.ResetGuesses();
                gameLoop = _inputService.IsYesOrNo(answer);

            }
        }

        private int PlayOneGame()
        {
            int guessCount = 0;
            while (!_game.IsCorrectGuess())
            {
                _io.Write("Enter your guess (4 digits):");
                string guess = _io.Read();
                while (!_inputService.IsValidInput(guess, _gameType))
                {
                    if (!_gameType.AllowDuplicates)
                    {
                        _io.Write("Please enter a valid 4-digit number with no repeating digits:");
                    }
                    else
                    {
                        _io.Write("Please enter a valid 4-digit number:");
                    }
                    guess = _io.Read();
                }
                _game.LastGuess = guess;
                guessCount++;
                _io.Write(_game.PrintCorrectAndMisplacedChars());
            }
            return guessCount;
        }

        private void PrintResults()
        {
            _io.Write("Congratulations! It took " + _player.TotalGuesses + " guesses\n");
            List<PlayerModel> topPlayers = ResultsLogger.RetrieveTopPlayers(_gameType.GameName);
            if (topPlayers != null)
            {
                _io.Write("Top Players:\n");
                foreach (var topPlayer in topPlayers)
                {
                    _io.Write($"{topPlayer.Name} - {topPlayer.NumberOfGames} games - {topPlayer.TotalGuesses} guesses - {topPlayer.Average().ToString("F2")} average guesses");
                }
            }
        }

       
    }
}

using CleanCode.Data;
using CleanCode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Game
{
    public class GameEngine
    {
        private readonly GameContextFactory _contextFactory;
        private readonly PlayerSetupService _playerService;

        public GameEngine(GameContextFactory contextFactory, PlayerSetupService playerService)
        {
            _contextFactory = contextFactory;
            _playerService = playerService;
        }

        public void Run()
        {
            PlayerData player = _playerService.AskForPlayerName();
            GameSession session;
            do
            {
                IGameTypes gameType = _playerService.AskForGameType();
                bool isCheatEnabled = _playerService.IsCheatEnabled();

                GameContext context = _contextFactory.Create(gameType);
                session = new(context);
                int guessCount = session.Play(isCheatEnabled);

                player.Update(guessCount);
                ResultsLogger.SavePlayerData(player, context.GameType.GameName);

                ResultPrinterService resultPrinter = new(context.Io, context.GameType, player);
                resultPrinter.PrintResults();

                player.ResetGuesses();

            } while (session.PlayAgain());
        }
    }
}

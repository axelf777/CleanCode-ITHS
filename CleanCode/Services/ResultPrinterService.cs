using CleanCode.Data;
using CleanCode.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Services
{
    public class ResultPrinterService
    {
        private readonly IUserIO _io;
        private readonly IGameTypes _gameType;
        private readonly PlayerData _player;
        public ResultPrinterService(IUserIO io, IGameTypes gameType , PlayerData player)
        {
            _io = io;
            _gameType = gameType;
            _player = player;
        }
        public void PrintResults()
        {
            _io.Write("Congratulations! It took " + _player.TotalGuesses + " guesses\n");
            List<PlayerModel> topPlayers = ResultsLogger.RetrieveTopPlayers(_gameType.GameName);
            if (topPlayers != null)
            {
                _io.Write("Top Players:\n");
                foreach (var topPlayer in topPlayers)
                {
                    _io.Write($"{topPlayer.Name} - {topPlayer.NumberOfGames} games - {topPlayer.TotalGuesses} guesses - {(double)topPlayer.TotalGuesses / topPlayer.NumberOfGames:F2} average guesses");
                }
            }
        }
    }
}

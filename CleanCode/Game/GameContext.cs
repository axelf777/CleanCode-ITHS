using CleanCode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Game
{
    public class GameContext
    {
        public IUserIO Io { get; }
        public IGameData Game { get; }
        public IGameTypes GameType { get; }

        public GameContext(IUserIO io, IGameData game, IGameTypes gameType)
        {
            Io = io;
            Game = game;
            GameType = gameType;
        }
    }

    public class GameContextFactory
    {
        private readonly IUserIO _io;
        private readonly IGameData _game;

        public GameContextFactory(IUserIO io, IGameData game)
        {
            _io = io;
            _game = game;
        }

        public GameContext Create(IGameTypes gameType)
        {
            _game.SetGameData(gameType);
            return new GameContext(_io, _game, gameType);
        }
    }

}

using CleanCode.Data;
using CleanCode.Game;
using CleanCode.Services;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace CleanCode
{
    internal static class Program
    {
        static void Main()
        {
            ConsoleIOService consoleIO = new();
            GameData gameData = new();
            GameContextFactory contextFactory = new(consoleIO, gameData);
            PlayerSetupService playerService = new(consoleIO);
            GameEngine gameEngine = new(contextFactory, playerService);
            gameEngine.Run();
        }
    }
}
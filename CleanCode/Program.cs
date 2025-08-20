using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace CleanCode
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.Run();
        }
    }
}
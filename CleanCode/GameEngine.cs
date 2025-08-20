using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class GameEngine
    {
        private readonly PlayerData _player;
        public GameEngine() {
            _player = PlayerData.AskForPlayerName();
        }
        public void Run()
        {
            bool gameLoop = true;
            while (gameLoop)
            {
                GameData game = new GameData();
                Console.WriteLine("New game:\n");
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + game.Goal + "\n");

                int guessCount = PlayOneGame(game);
                _player.Update(guessCount);
                ResultsLogger.SavePlayerData(_player);
                ShowResults();

                Console.WriteLine("Do you want to play again? (y/n)");
                string answer = Console.ReadLine();
                gameLoop = game.RestartGame(answer);

            }
        }

        private int PlayOneGame(GameData game)
        {
            int guessCount = 0;
            while (!game.IsCorrectGuess())
            {
                Console.WriteLine("Enter your guess (4 digits, no repeating):");
                string guess = Console.ReadLine();
                while (!GameData.IsValidInput(guess))
                {
                    Console.WriteLine("Please enter a valid 4-digit number with no repeating digits:");
                    guess = Console.ReadLine();
                }
                game.LastGuess = guess;
                guessCount++;
                Console.WriteLine(game.PrintBullsAndCows());
            }
            return guessCount;
        }

        private void ShowResults()
        {
            Console.WriteLine("Congratulations! It took " + _player.totalGuesses + " guesses\n");
            List<PlayerData> topPlayers = ResultsLogger.RetrieveTopPlayers();
            if (topPlayers != null)
            {
                Console.WriteLine("Top Players:\n");
                foreach (var topPlayer in topPlayers)
                {
                    Console.WriteLine($"{topPlayer.Name} - {topPlayer.numberOfGames} games - {topPlayer.totalGuesses} guesses - {topPlayer.Average().ToString("F2")} average guesses");
                }
            }
        }
    }
}

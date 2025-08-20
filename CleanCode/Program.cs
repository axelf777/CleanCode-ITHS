using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gameLoop = true;
            PlayerData player = PlayerData.AskForPlayerName();

            while (gameLoop)
            {
                GameData game = new GameData();
                Console.WriteLine("New game:\n");
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + game.goalNumbers + "\n");
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
                    game.lastGuess = guess;
                    guessCount++;
                    Console.WriteLine(game.PrintBullsAndCows());
                }
                player.Update(guessCount);
                ResultsLog.SavePlayerData(player);
                Console.WriteLine(ResultsLog.RetrieveTopPlayers());
                Console.WriteLine("Correct, it took " + player.totalGuesses + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (!game.RestartGame(answer))
                {
                    gameLoop = false;
                }
            }
        }
        class ResultsLog
        {
            public static void SavePlayerData(PlayerData player)
            {
                using (var output = new StreamWriter("result.txt", append: true))
                {
                    output.WriteLine(player.Name + "|" + player.totalGuesses);
                }
            }

            public static string RetrieveTopPlayers()
            {
                if (!File.Exists("result.txt"))
                {
                    return "No results found.";
                }
                List<PlayerData> playerResults = new List<PlayerData>();
                using (var input = new StreamReader("result.txt"))
                {
                    string line;
                    PlayerData player;
                    while ((line = input.ReadLine()) != null)
                    {
                        string[] nameAndScore = line.Split('|');
                        if (nameAndScore.Length == 2 && int.TryParse(nameAndScore[1], out int guesses))
                        {
                            player = new PlayerData(nameAndScore[0], guesses);
                            int doesPlayerExist = playerResults.IndexOf(player);

                            if (doesPlayerExist < 0)
                            {
                                playerResults.Add(player);
                            }
                            else
                            {
                                playerResults[doesPlayerExist].Update(guesses);
                            }
                        }
                    }
                }
                var topPlayers = playerResults.OrderBy(p => p.Average()).Take(10);
                string result = "Top Players:\n";
                foreach (var player in topPlayers)
                {
                    result += ($"{player.Name} - {player.numberOfGames} games - {player.totalGuesses} guesses - {player.Average().ToString("F2")} average guesses\n");
                }

                return result;
            }
        }
        class GameData
        {
            public string goalNumbers { get; private set; }
            public string lastGuess { get; set; }
            public GameData()
            {
                goalNumbers = MakeGoalNumbers();
                lastGuess = "";
            }
            public bool RestartGame(string answer)
            {
                if (answer != null && answer != "" && answer.Substring(0, 1) == "y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool IsCorrectGuess()
            {
                if (lastGuess == goalNumbers)
                    {
                    Console.WriteLine("Congratulations! You guessed the number!");
                    return true;
                }
                else {
                    return false;
                }
            }

            public string PrintBullsAndCows()
            {
                int bulls = 0, cows = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (goalNumbers[i] == lastGuess[i])
                    {
                        bulls++;
                    }
                    else if (goalNumbers.Contains(lastGuess[i]))
                    {
                        cows++;
                    }
                }
                return $"{new string('B', bulls)}{new string('C', cows)}";
            }
            public static string MakeGoalNumbers()
            {
                Random randomGenerator = new Random();
                string goal = "";
                for (int i = 0; i < 4; i++)
                {
                    int random = randomGenerator.Next(10);
                    string randomDigit = "" + random;
                    while (goal.Contains(randomDigit))
                    {
                        random = randomGenerator.Next(10);
                        randomDigit = "" + random;
                    }
                    goal = goal + randomDigit;
                }
                return goal;
            }

            public static bool IsValidInput(string input)
            {
                return input != null
                    && input.Length == 4
                    && input.All(char.IsDigit)
                    && input.Distinct().Count() == 4;
            }
        }
        class PlayerData
        {
            public string Name { get; private set; }
            public int numberOfGames { get; private set; }
            public int totalGuesses { get; private set; }


            public PlayerData(string name, int guesses)
            {
                this.Name = name;
                numberOfGames = 1;
                totalGuesses = guesses;
            }

            public void Update(int guesses)
            {
                numberOfGames++;
                totalGuesses += guesses;
            }

            public static PlayerData AskForPlayerName()
            {
                Console.WriteLine("Enter a user name:");
                string name = Console.ReadLine();
                while (string.IsNullOrEmpty(name) || name.Length > 20 || name.Contains("|"))
                {
                    Console.WriteLine("Please enter a valid user name:");
                    name = Console.ReadLine();
                }
                PlayerData player = new PlayerData(name, 0);

                return player;
            }

            public double Average()
            {
                return (double)totalGuesses / numberOfGames;
            }


            public override bool Equals(Object p)
            {
                return Name.Equals(((PlayerData)p).Name);
            }


            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
        }
    }
}
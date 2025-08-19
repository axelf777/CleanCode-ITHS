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
                GameData game = new GameData(player);
                Console.WriteLine("New game:\n");
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + game.goalNumbers + "\n");
                game.AskForPlayerInput();

                
                //string guess = Console.ReadLine();

                //int nGuess = 1;
                //string bbcc = checkBC(goal, guess);
                //Console.WriteLine(bbcc + "\n");
                //while (bbcc != "BBBB,")
                //{
                //    nGuess++;
                //    guess = Console.ReadLine();
                //    Console.WriteLine(guess + "\n");
                //    bbcc = checkBC(goal, guess);
                //    Console.WriteLine(bbcc + "\n");
                //}
                //StreamWriter output = new StreamWriter("result.txt", append: true);
                //output.WriteLine(player.Name + "#&#" + nGuess);
                //output.Close();
                //showTopList();
                Console.WriteLine("Correct, it took " + player.totalGuess + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    gameLoop = false;
                }
                

                //static string checkBC(string goal, string guess)
                //{
                //    int cows = 0, bulls = 0;
                //    guess += "    ";     // if player entered less than 4 chars
                //    for (int i = 0; i < 4; i++)
                //    {
                //        for (int j = 0; j < 4; j++)
                //        {
                //            if (goal[i] == guess[j])
                //            {
                //                if (i == j)
                //                {
                //                    bulls++;
                //                }
                //                else
                //                {
                //                    cows++;
                //                }
                //            }
                //        }
                //    }
                //    return "BBBB".Substring(0, bulls) + "|" + "CCCC".Substring(0, cows);
                //}


                //static void showTopList()
                //{
                //    StreamReader input = new StreamReader("result.txt");
                //    List<PlayerData> results = new List<PlayerData>();
                //    string line;
                //    while ((line = input.ReadLine()) != null)
                //    {
                //        string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                //        string name = nameAndScore[0];
                //        int guesses = Convert.ToInt32(nameAndScore[1]);
                //        PlayerData pd = new PlayerData(name);
                //        int pos = results.IndexOf(pd);
                //        if (pos < 0)
                //        {
                //            results.Add(pd);
                //        }
                //        else
                //        {
                //            results[pos].Update(guesses);
                //        }


                //    }
                //    results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
                //    Console.WriteLine("player   games average");
                //    foreach (PlayerData p in results)
                //    {
                //        Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
                //    }
                //    input.Close();
                //}
            }
        }

        class GameData
        {
            PlayerData player;
            public string goalNumbers;
            public string lastGuess;
            public GameData(PlayerData player)
            {
                this.player = player;
                goalNumbers = MakeGoalNumbers();
                lastGuess = "";
            }
            public bool AskForPlayerInput()
            {
                while (!IsCorrectGuess())
                {
                    Console.WriteLine("Enter your guess (4 digits, no repeating):");
                    string guess = Console.ReadLine();
                    while (!IsValidInput(guess))
                    {
                        Console.WriteLine("Please enter a valid 4-digit number with no repeating digits:");
                        guess = Console.ReadLine();
                    }
                    lastGuess = guess;
                    PrintBullsAndCows();
                }
                return true;
            }

            private bool IsCorrectGuess()
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

            private void PrintBullsAndCows()
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
                Console.WriteLine($"{new string('B', bulls)}{new string('C', cows)}");
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

            private static bool IsValidInput(string input)
            {
                if (input == null || input.Length != 4)
                {
                    return false;
                }
                foreach (char c in input)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[i] == input[j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        class PlayerData
        {
            public string Name { get; private set; }
            public int NGames { get; private set; }
            public int totalGuess { get; private set; }


            public PlayerData(string name)
            {
                this.Name = name;
                NGames = 1;
                totalGuess = 0;
            }

            public void Update(int guesses)
            {
                totalGuess += guesses;
                NGames++;
            }

            public static PlayerData AskForPlayerName()
            {
                Console.WriteLine("Enter a user name:");
                string name = Console.ReadLine();
                while (string.IsNullOrEmpty(name) || name.Length > 20)
                {
                    Console.WriteLine("Please enter a valid user name:");
                    name = Console.ReadLine();
                }
                PlayerData player = new PlayerData(name);

                return player;
            }

            public void SavePlayerData()
            {
                using (var output = new StreamWriter("result.txt", append: true))
                {
                    output.WriteLine(Name + "#&#" + totalGuess);
                }
            }

            public double Average()
            {
                return (double)totalGuess / NGames;
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
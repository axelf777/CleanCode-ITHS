using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public static class ResultsLogger
    {
        private const string FileName = "result.txt";
        public static void SavePlayerData(PlayerData player)
        {
            using (var output = new StreamWriter(FileName, append: true))
            {
                output.WriteLine(player.Name + "|" + player.totalGuesses);
            }
        }

        public static List<PlayerData> RetrieveTopPlayers()
        {
            if (!File.Exists(FileName))
            {
                return null;
            }
            List<PlayerData> playerResults = new List<PlayerData>();
            using (var input = new StreamReader(FileName))
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
            List<PlayerData> topPlayers = playerResults.OrderBy(p => p.Average()).Take(10).ToList();
            return topPlayers;
        }
    }
}

using CleanCode.Data;
using CleanCode.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Services
{
    public static class ResultsLogger
    {
        public static void SavePlayerData(PlayerData player, string gameType)
        {
            using var db = new PlayerDbContext();
            var existing = db.Players.FirstOrDefault(p => p.Name == player.Name && p.GameType == gameType);

            if (existing != null)
            {
                existing.TotalGuesses += player.TotalGuesses;
                existing.NumberOfGames ++;
                db.Update(existing);
            }
            else
            {
                PlayerModel playerModel = new()
                {
                    Name = player.Name,
                    TotalGuesses = player.TotalGuesses,
                    NumberOfGames = 1,
                    GameType = gameType
                };
                db.Players.Add(playerModel);
            }
            db.SaveChanges();
        }

        public static List<PlayerModel> RetrieveTopPlayers(string gameType)
        {
            using var db = new PlayerDbContext();
            return db.Players
                .Where(p => p.GameType == gameType)
                .OrderBy(p => (double)p.TotalGuesses / p.NumberOfGames)
                .Take(10)
                .ToList();
        }
    }
}

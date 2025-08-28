using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfGames { get; set; }
        public int TotalGuesses { get; set; }
        public string GameType { get; set; }
        public double Average()
        {
            return (double)TotalGuesses / NumberOfGames;
        }

    }
}

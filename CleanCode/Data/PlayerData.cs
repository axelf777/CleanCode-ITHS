using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Data
{
    public class PlayerData
    {
        public string Name { get; }
        public int TotalGuesses { get; private set; }

        public PlayerData(string name)
        {
            Name = name;
            TotalGuesses = 0;
        }

        public void Update(int guesses)
        {
            TotalGuesses += guesses;
        }
        public void ResetGuesses()
        {
            TotalGuesses = 0;
        }
    }

}

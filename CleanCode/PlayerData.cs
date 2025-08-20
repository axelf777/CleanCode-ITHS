using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class PlayerData
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

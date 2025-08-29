using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Services
{
    public class ConsoleIOService : IUserIO
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}

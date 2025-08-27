using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public interface IUserIO
    {
        void Write(string message);
        string Read();
    }
}

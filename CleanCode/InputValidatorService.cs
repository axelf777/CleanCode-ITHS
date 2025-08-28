using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class InputValidatorService
    {
        public bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length <= 20 && !name.Contains("|");
        }

        public bool IsValidInput(string input, IGameTypes gameType)
        {
            return input != null
                && input.Length == 4
                && input.All(char.IsDigit)
                && (gameType.AllowDuplicates || input.Distinct().Count() == 4);
        }

        public bool IsYesOrNo(string input)
        {
            return !string.IsNullOrEmpty(input) && input.StartsWith("y", StringComparison.OrdinalIgnoreCase);
        }
    }
}

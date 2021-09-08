using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Helpers
{
    public static class Helpers
    {
        public static bool ValidateInstructions(string instructions)
        {
            return instructions.ToArray().Where(w => w != 'L' && w != 'R' && w != 'M').Count() != 0;
        }
    }
}

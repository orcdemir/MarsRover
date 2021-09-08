using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.Enums.Enums;

namespace MarsRover.Extensions
{
    public static class CompassExtension
    {
        public static string ToFriendlyString(this Compass compass)
        {
            switch (compass)
            {
                case Compass.East: return "E";
                case Compass.North: return "N";
                case Compass.South: return "S";
                case Compass.West: return "W";
                default: return "";
            }
        }
    }
}

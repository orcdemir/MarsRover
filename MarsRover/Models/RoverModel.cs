using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.Enums.Enums;

namespace MarsRover.Models
{
    public class RoverModel
    {
        public Compass Compass { get; set; }
        public int RoverId { get; set; }
        public string Instructions { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Compass CalculateCompass(char instruction)
        {
            // W N E S
            // 1 2 3 4
            switch (instruction)
            {
                case 'L': return ((int)Compass - 1 == -1) ? Compass.South : Compass - 1;
                case 'R': return ((int)Compass + 1 == 4) ? Compass.West : Compass + 1;
                default: return Compass;
            }
        }

        public void CalculateNewCoordinates()
        {
            switch (Compass)
            {
                case Compass.West: X--; break;
                case Compass.North: Y++; break;
                case Compass.East: X++; break;
                case Compass.South: Y--; break;
                default: break;
            }
        }
    }
}

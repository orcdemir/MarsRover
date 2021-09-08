using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class PlateauModel
    {
        public RoverModel[,] Matrix { get; set; }
        public List<RoverModel> Rovers { get; set; } = new List<RoverModel>();

        public void RunInstructions()
        {
            foreach (var rover in Rovers)
            {
                foreach (var cmd in rover.Instructions.ToArray())
                {
                    if (cmd == 'L' || cmd == 'R') rover.Compass = rover.CalculateCompass(cmd);
                    if (cmd == 'M') MoveRoverOnTheMars(rover);
                }
            }
        }

        private void MoveRoverOnTheMars(RoverModel rover)
        {
            Matrix[rover.X, rover.Y] = null;
            rover.CalculateNewCoordinates();
            Matrix[rover.X, rover.Y] = rover;
        }
    }
}

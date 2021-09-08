using MarsRover.Extensions;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.Enums.Enums;

namespace MarsRover
{
    public class Program
    {
        public static int[] GetMatrixSize(string[] matrixStr)
        {
            return new int[2] { Convert.ToInt32(matrixStr[0]) + 1, Convert.ToInt32(matrixStr[1]) + 1 };
        }

        public static void GetRoverQuestionsAndSetValues(RoverModel rover)
        {
            do
            {
                Console.WriteLine("Enter rover position");
                string[] roverInput = Console.ReadLine().Split(' ');

                rover.X = Convert.ToInt32(roverInput[0]);
                rover.Y = Convert.ToInt32(roverInput[1]);

                switch (roverInput[2].ToUpper())
                {
                    case "E": rover.Compass = Compass.East; break;
                    case "W": rover.Compass = Compass.West; break;
                    case "N": rover.Compass = Compass.North; break;
                    case "S": rover.Compass = Compass.South; break;
                    default: rover.Compass = Compass.None; break;
                }

            } while (rover.Compass == Compass.None);

            string instructions;
            do
            {
                Console.WriteLine("Enter rover instructions");
                instructions = Console.ReadLine().ToUpper();
            } while (Helpers.Helpers.ValidateInstructions(instructions));

            rover.Instructions = instructions;
        }

        static void Main(string[] args)
        {
            PlateauModel plateau = new PlateauModel();
            plateau.Rovers.Add(new RoverModel() { Compass = Compass.None, RoverId = 1 });
            plateau.Rovers.Add(new RoverModel() { Compass = Compass.None, RoverId = 2 });

            string[] matrixStr;
            do
            {
                Console.WriteLine("Enter matrix size with white space");
                matrixStr = Console.ReadLine().Split(' ');
            } while (matrixStr.Length != 2);


            int[] matrixSize = GetMatrixSize(matrixStr);
            plateau.Matrix = new RoverModel[matrixSize[0], matrixSize[1]];

            foreach (var rover in plateau.Rovers)
            {
                GetRoverQuestionsAndSetValues(rover);
                plateau.Matrix[rover.X, rover.Y] = rover;
            }

            plateau.RunInstructions();

            foreach (var rover in plateau.Rovers)
            {
                Console.WriteLine("{0} {1} {2}", rover.X, rover.Y, rover.Compass.ToFriendlyString());
            }

            //foreach (var rover in plateau.Matrix)
            //{
            //    if (rover != null)
            //    {
            //        Console.WriteLine("{0} {1} {2}", rover.X, rover.Y, rover.Compass.ToFriendlyString());
            //    }
            //}

            Console.ReadLine();
        }
    }
}

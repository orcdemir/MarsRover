using MarsRover.Models;
using NUnit.Framework;
using static MarsRover.Enums.Enums;

namespace MarsRover.UnitTest
{
    public class MarsRoverNUnitTest
    {
        RoverModel _roverModel1;
        RoverModel _roverModel2;

        [SetUp]
        public void Setup()
        {
            _roverModel1 = new RoverModel() { Compass = Compass.North, X = 1, Y = 2 };
            _roverModel2 = new RoverModel() { Compass = Compass.East, X = 3, Y = 3 };
        }

        [Test]
        public void TestCalculateCompassLForRover1()
        {
            foreach (var cmd in "L".ToCharArray())
            {
                Compass compass = _roverModel1.CalculateCompass(cmd);
                _roverModel1.Compass = compass;
            }

            Assert.AreEqual(Compass.West, _roverModel1.Compass);
        }

        [Test]
        public void TestCalculateCompassLMLMLMLMMForRover1()
        {
            foreach (var cmd in "LMLMLMLMM".ToCharArray())
            {
                Compass compass = _roverModel1.CalculateCompass(cmd);
                _roverModel1.Compass = compass;
            }

            Assert.AreEqual(Compass.North, _roverModel1.Compass);
        }

        [Test]
        public void TestCalculateCompassMForRover2()
        {
            foreach (var cmd in "R".ToCharArray())
            {
                Compass compass = _roverModel2.CalculateCompass(cmd);
                _roverModel2.Compass = compass;
            }

            Assert.AreEqual(Compass.South, _roverModel2.Compass);
        }

        [Test]
        public void TestCalculateCompassMMRMMRMRRMForRover2()
        {
            foreach (var cmd in "MMRMMRMRRM".ToCharArray())
            {
                Compass compass = _roverModel2.CalculateCompass(cmd);
                _roverModel2.Compass = compass;
            }

            Assert.AreEqual(Compass.East, _roverModel2.Compass);
        }

        [Test]
        public void TestCalculateNewCoordinatesXForRover1()
        {
            _roverModel1.CalculateNewCoordinates();
            Assert.AreEqual(1, _roverModel1.X);
        }

        [Test]
        public void TestCalculateNewCoordinatesYForRover1()
        {
            _roverModel1.CalculateNewCoordinates();
            Assert.AreEqual(3, _roverModel1.Y);
        }

        [Test]
        public void TestCalculateNewCoordinatesXForRover2()
        {
            _roverModel2.CalculateNewCoordinates();
            Assert.AreEqual(4, _roverModel2.X);
        }

        [Test]
        public void TestCalculateNewCoordinatesYForRover2()
        {
            _roverModel2.CalculateNewCoordinates();
            Assert.AreEqual(3, _roverModel2.Y);
        }

        [Test]
        public void TestGetMatrixSize()
        {
            string[] matrixSizeInput = { "5", "5" };
            var actualOutput = Program.GetMatrixSize(matrixSizeInput);
            int[] expectedOutput = { 6, 6 };

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
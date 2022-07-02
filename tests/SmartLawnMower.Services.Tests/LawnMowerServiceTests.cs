using SmartLawnMower.Infrastructure.Enums;
using SmartLawnMower.Infrastructure.Models;
using Xunit;

namespace SmartLawnMower.Services.Tests
{
    public class LawnMowerServiceTests
    {
        private static readonly GardenDimensions GardenDimensions = new() { Length = 6, Width = 3 };

        [Fact]
        public void WhenLawnMowerIsFacingNorthAtInitialPosition_MoveIsInvokedOnce_Expect_StepIncrementInYCoordinate()
        {
            //Arrange
            var initialCoordinate = new Coordinates { X = 0, Y = 0 };
            var lawnMower = new LawnMower()
            {
                GardenDimensions = GardenDimensions
            };

            var lawnMowerService = new LawnMowerService(lawnMower);

            //Act
            var result = lawnMowerService.Move().Result;

            //Assert
            Assert.Equal(initialCoordinate.Y + 1, result.Coordinates.Y);
        }

        [Fact]
        public void WhenLawnMowerIsFacingEastAtInitialPosition_MoveIsInvokedOnce_Expect_StepIncrementInXCoordinate()
        {
            //Arrange
            var initialCoordinate = new Coordinates { X = 0, Y = 0 };
            var lawnMower = new LawnMower()
            {
                Coordinates = initialCoordinate,
                Orientation = Orientation.East,
                GardenDimensions = GardenDimensions
            };

            var lawnMowerService = new LawnMowerService(lawnMower);

            //Act
            var result = lawnMowerService.Move().Result;

            //Assert
            Assert.Equal(initialCoordinate.X + 1, result.Coordinates.X);
        }

        [Fact]
        public void WhenLawnMowerIsFacingWestAtInitialPosition_MoveIsInvokedOnce_Expect_Null()
        {
            //Arrange
            var lawnMower = new LawnMower()
            {
                Coordinates = new Coordinates { X = 0, Y = 0 },
                Orientation = Orientation.West,
                GardenDimensions = GardenDimensions
            };

            var lawnMowerService = new LawnMowerService(lawnMower);

            //Act
            var result = lawnMowerService.Move().Result;

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void WhenLawnMowerIsFacingSouthAtInitialPosition_MoveIsInvokedOnce_Expect_Null()
        {
            //Arrange
            var lawnMower = new LawnMower()
            {
                Coordinates = new Coordinates { X = 0, Y = 0 },
                Orientation = Orientation.South,
                GardenDimensions = GardenDimensions
            };

            var lawnMowerService = new LawnMowerService(lawnMower);

            //Act
            var result = lawnMowerService.Move().Result;

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void WhenLawnMowerIsAtAnyPoint_MoveIsInvokedOnce_Expect_StepIncrementInOrientedDirection()
        {
            //Arrange
            var someCoordinate = new Coordinates { X = 2, Y = 3 };
            var lawnMower = new LawnMower()
            {
                Coordinates = someCoordinate,
                Orientation = Orientation.East,
                GardenDimensions = GardenDimensions
            };

            var lawnMowerService = new LawnMowerService(lawnMower);

            //Act
            var result = lawnMowerService.Move().Result;

            //Assert
            Assert.Equal(someCoordinate.X + 1, result.Coordinates.X);
        }

        [Fact]
        public void WhenLawnMowerIsAtEdgeOfAnySideInSomeOrientedDirection_MoveIsInvokedOnce_Expect_Null()
        {
            //Arrange
            var lawnMower = new LawnMower()
            {
                Coordinates = new Coordinates { X = 2, Y = 3 },
                Orientation = Orientation.North,
                GardenDimensions = GardenDimensions
            };

            var lawnMowerService = new LawnMowerService(lawnMower);

            //Act
            var result = lawnMowerService.Move().Result;

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void WhenLawnMowerIsAtAnyCoordinate_ResetIsInvoked_Expect_InitialPosition()
        {
            //Arrange
            var lawnMower = new LawnMower()
            {
                Coordinates = new Coordinates { X = 2, Y = 3 },
                Orientation = Orientation.North,
                GardenDimensions = GardenDimensions
            };

            var lawnMowerService = new LawnMowerService(lawnMower);

            //Act
            var result = lawnMowerService.Reset(GardenDimensions).Result;

            //Assert
            Assert.Equal(0, result.Coordinates.X);
            Assert.Equal(0, result.Coordinates.Y);
            Assert.Equal(Orientation.North, result.Orientation);
            Assert.Equal(lawnMower.GardenDimensions, result.GardenDimensions);
        }

        [Fact]
        public void WhenLawnMowerIsFacingNorth_TurnIsInvokedWithClockWise_Expect_OrientationChangedToEast()
        {
            //Arrange
            var lawnMower = new LawnMower()
            {
                Coordinates = new Coordinates { X = 2, Y = 3 },
                Orientation = Orientation.North,
                GardenDimensions = GardenDimensions
            };

            var lawnMowerService = new LawnMowerService(lawnMower);

            //Act
            var result = lawnMowerService.Turn(TurningDirection.Clockwise).Result;

            //Assert
            Assert.Equal(Orientation.East, result.Orientation);
        }

        [Fact]
        public void WhenLawnMowerIsFacingNorth_TurnIsInvokedWithAntiClockWise_Expect_OrientationChangedToWest()
        {
            //Arrange
            var lawnMower = new LawnMower()
            {
                Coordinates = new Coordinates { X = 2, Y = 3 },
                Orientation = Orientation.North,
                GardenDimensions = GardenDimensions
            };

            var lawnMowerService = new LawnMowerService(lawnMower);

            //Act
            var result = lawnMowerService.Turn(TurningDirection.AntiClockwise).Result;

            //Assert
            Assert.Equal(Orientation.West, result.Orientation);
        }

        [Fact]
        public void WhenLawnMowerIsFacingEast_TurnIsInvokedWithClockWise_Expect_OrientationChangedToSouth()
        {
            //Arrange
            var lawnMower = new LawnMower()
            {
                Coordinates = new Coordinates { X = 2, Y = 3 },
                Orientation = Orientation.East,
                GardenDimensions = GardenDimensions
            };

            var lawnMowerService = new LawnMowerService(lawnMower);

            //Act
            var result = lawnMowerService.Turn(TurningDirection.Clockwise).Result;

            //Assert
            Assert.Equal(Orientation.South, result.Orientation);
        }

        [Fact]
        public void WhenLawnMowerIsFacingEast_TurnIsInvokedWithAntiClockWise_Expect_OrientationChangedToNorth()
        {
            //Arrange
            var lawnMower = new LawnMower()
            {
                Coordinates = new Coordinates { X = 2, Y = 3 },
                Orientation = Orientation.East,
                GardenDimensions = GardenDimensions
            };

            var lawnMowerService = new LawnMowerService(lawnMower);

            //Act
            var result = lawnMowerService.Turn(TurningDirection.AntiClockwise).Result;

            //Assert
            Assert.Equal(Orientation.North, result.Orientation);
        }
    }
}
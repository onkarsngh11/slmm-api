using Moq;
using SmartLawnMower.Api.Controllers;
using SmartLawnMower.Infrastructure.Contracts;
using SmartLawnMower.Infrastructure.Enums;
using SmartLawnMower.Infrastructure.Models;
using Xunit;

namespace SmartLawnMower.Services.Tests
{
    public class LawnMowerControllerTests
    {
        private static readonly GardenDimensions _gardenDimensions = new() { Length = 6, Width = 3 };
        readonly LawnMower lawnMower = new() { GardenDimensions = _gardenDimensions };
        private readonly Mock<ILawnMowerService> _lawnMowerService = new();

        [Fact]
        public void When_MoveActionIsCalled_Expect_NotNullResult()
        {
            //Arrange
            _lawnMowerService.Setup(lms => lms.Move()).ReturnsAsync(lawnMower);
            var lawnMowerController = new LawnMowerController(_lawnMowerService.Object);

            //Act
            var lawnMowerResult = lawnMowerController.Move();

            //Assert
            Assert.NotNull(lawnMowerResult);
        }

        [Fact]
        public void When_TurnActionIsCalled_Expect_NotNullResult()
        {
            //Arrange
            _lawnMowerService.Setup(lms => lms.Turn(TurningDirection.Clockwise)).ReturnsAsync(lawnMower);
            var lawnMowerController = new LawnMowerController(_lawnMowerService.Object);

            //Act
            var lawnMowerResult = lawnMowerController.Turn(TurningDirection.Clockwise);

            //Assert
            Assert.NotNull(lawnMowerResult);
        }

        [Fact]
        public void When_ResetActionIsCalled_Expect_NotNullResult()
        {
            //Arrange
            _lawnMowerService.Setup(lms => lms.Reset(_gardenDimensions)).ReturnsAsync(lawnMower);
            var lawnMowerController = new LawnMowerController(_lawnMowerService.Object);

            //Act
            var lawnMowerResult = lawnMowerController.Reset(_gardenDimensions);

            //Assert
            Assert.NotNull(lawnMowerResult);
        }

        [Fact]
        public void When_GetCurrentPositionActionIsCalled_Expect_NotNullResult()
        {
            //Arrange
            _lawnMowerService.Setup(lms => lms.GetCurrentPosition()).ReturnsAsync(lawnMower);
            var lawnMowerController = new LawnMowerController(_lawnMowerService.Object);

            //Act
            var lawnMowerResult = lawnMowerController.Position();

            //Assert
            Assert.NotNull(lawnMowerResult);
        }
    }
}

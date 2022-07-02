using SmartLawnMower.Infrastructure.Contracts;
using SmartLawnMower.Infrastructure.Enums;
using SmartLawnMower.Infrastructure.Models;

namespace SmartLawnMower.Services
{
    public class LawnMowerService : ILawnMowerService
    {
        private LawnMower Mower { get; set; }

        readonly int timeTakenToMove = 5000;
        readonly int timeTakenToTurn = 2000;

        public LawnMowerService(LawnMower mower)
        {
            Mower = mower;
        }

        public async Task<LawnMower> GetCurrentPosition()
        {
            return await Task.Run(() => Mower);
        }

        public async Task<LawnMower> Move()
        {
            return await Task.Run(() =>
            {
                Coordinates nextCoordinate = Mower.GetNextCoordinate();
                if (nextCoordinate.IsWithinGarden(Mower.GardenDimensions))
                {
                    Mower.Coordinates = nextCoordinate;
                    Thread.Sleep(timeTakenToMove);
                    return GetCurrentPosition();
                }
                return Task.FromResult<LawnMower>(null);
            });
        }

        public async Task<LawnMower> Turn(TurningDirection turningDirection)
        {
            return await Task.Run(() =>
            {
                switch (Mower.Orientation)
                {
                    case Orientation.North:
                        Mower.Orientation = turningDirection == TurningDirection.Clockwise ? Orientation.East : Orientation.West;
                        break;
                    case Orientation.East:
                        Mower.Orientation = turningDirection == TurningDirection.Clockwise ? Orientation.South : Orientation.North;
                        break;
                    case Orientation.South:
                        Mower.Orientation = turningDirection == TurningDirection.Clockwise ? Orientation.West : Orientation.East;
                        break;
                    case Orientation.West:
                        Mower.Orientation = turningDirection == TurningDirection.Clockwise ? Orientation.North : Orientation.South;
                        break;
                }
                Thread.Sleep(timeTakenToTurn);
                return GetCurrentPosition();
            });
        }

        public async Task<LawnMower> Reset(GardenDimensions dimensions)
        {
            return await Task.Run(() =>
            {
                Mower.Coordinates.X = 0;
                Mower.Coordinates.Y = 0;
                Mower.Orientation = Orientation.North;
                Mower.GardenDimensions = dimensions;

                return GetCurrentPosition();
            });
        }
    }
}

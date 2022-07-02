using SmartLawnMower.Infrastructure.Enums;

namespace SmartLawnMower.Infrastructure.Models
{
    public class LawnMower
    {
        public Coordinates Coordinates { get; set; } = new Coordinates() { X = 0, Y = 0 };
        public Orientation Orientation { get; set; }
        public GardenDimensions GardenDimensions { get; set; } = new GardenDimensions() { Length = 0, Width = 0 };

        public Coordinates GetNextCoordinate()
        {
            var nextCoordinates = new Coordinates();
            var orientation = Orientation;
            var coordinates = Coordinates;
            if (orientation == Orientation.North)
            {
                nextCoordinates = new Coordinates()
                {
                    X = coordinates.X,
                    Y = coordinates.Y + 1
                };
            }
            else if (orientation == Orientation.South)
            {
                nextCoordinates = new Coordinates()
                {
                    X = coordinates.X,
                    Y = coordinates.Y - 1
                };
            }
            else if (orientation == Orientation.East)
            {
                nextCoordinates = new Coordinates()
                {
                    X = coordinates.X + 1,
                    Y = coordinates.Y
                };
            }
            else if (orientation == Orientation.West)
            {
                nextCoordinates = new Coordinates()
                {
                    X = coordinates.X - 1,
                    Y = coordinates.Y
                };
            }
            return nextCoordinates;
        }
    }
}
namespace SmartLawnMower.Infrastructure.Models
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsWithinGarden(GardenDimensions dimensions)
        {
            return X >= 0 && X <= dimensions.Length
                && Y >= 0 && Y <= dimensions.Width;
        }
    }
}
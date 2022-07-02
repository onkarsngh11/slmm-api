namespace SmartLawnMower.Api
{
    public static class Constants
    {
        public const string OutOfGardenError = "OutOfGarden";
        public const string OutOfGardenMessage = "Mower can not move as next step is falling out of garden dimensions";
        public const string InvalidDimensionsError = "InvalidDimensions";
        public const string InvalidDimensionsMessage = "Dimensions should have positive integer values";
    }
}

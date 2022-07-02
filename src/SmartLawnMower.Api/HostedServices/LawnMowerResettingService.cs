using SmartLawnMower.Infrastructure.Enums;
using SmartLawnMower.Infrastructure.Models;

namespace SmartLawnMower.Api.HostedServices
{
    public class LawnMowerResettingService : BackgroundService
    {
        private readonly LawnMower _lawnMower;
        private readonly IConfiguration _configuration;

        public LawnMowerResettingService(LawnMower lawnMower, IConfiguration configuration)
        {
            _lawnMower = lawnMower;
            _configuration = configuration;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                var gardenDimensions = _configuration.GetSection("GardenDimensions").Get<GardenDimensions>();
                _lawnMower.Coordinates.X = 0;
                _lawnMower.Coordinates.Y = 0;
                _lawnMower.Orientation = Orientation.North;
                _lawnMower.GardenDimensions = gardenDimensions;
            });
        }
    }
}

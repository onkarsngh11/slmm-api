using SmartLawnMower.Infrastructure.Enums;
using SmartLawnMower.Infrastructure.Models;

namespace SmartLawnMower.Infrastructure.Contracts
{
    public interface ILawnMowerService
    {
        Task<LawnMower> GetCurrentPosition();
        Task<LawnMower> Move();
        Task<LawnMower> Turn(TurningDirection turningDirection);
        Task<LawnMower> Reset(GardenDimensions dimensions);
    }
}
using Microsoft.AspNetCore.Mvc;
using SmartLawnMower.Infrastructure.Contracts;
using SmartLawnMower.Infrastructure.Enums;
using SmartLawnMower.Infrastructure.Models;

namespace SmartLawnMower.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class LawnMowerController : ControllerBase
    {
        private readonly ILawnMowerService _lawnMowerService;

        public LawnMowerController(ILawnMowerService lawnMowerService)
        {
            _lawnMowerService = lawnMowerService;
        }

        [HttpGet]
        [Route("CurrentPosition")]
        public async Task<ActionResult> Position()
        {
            var mowerPosition = await _lawnMowerService.GetCurrentPosition();

            return Ok(mowerPosition);
        }

        [HttpPost]
        [Route("Turn")]
        public async Task<ActionResult> Turn(TurningDirection turningDirection)
        {
            var mowerPosition = await _lawnMowerService.Turn(turningDirection);

            return Ok(mowerPosition);
        }

        [HttpPost]
        [Route("Move")]
        public async Task<ActionResult> Move()
        {
            var mowerPosition = await _lawnMowerService.Move();
            if (mowerPosition == null)
            {
                return BadRequest(
                    new BadRequestResponse() 
                    { 
                        Error = Constants.OutOfGardenError, 
                        Message = Constants.OutOfGardenMessage 
                    });
            }
            return Ok(mowerPosition);
        }

        [HttpPost]
        [Route("Reset")]
        public async Task<ActionResult> Reset(GardenDimensions dimensions)
        {
            if (dimensions.Length < 0 || dimensions.Width < 0)
            {
                return BadRequest(new BadRequestResponse() {
                    Error = Constants.InvalidDimensionsError,
                    Message = Constants.InvalidDimensionsMessage
                });
            }
                
            var mowerPosition = await _lawnMowerService.Reset(dimensions);

            return Ok(mowerPosition);
        }
    }
}
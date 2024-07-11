using BusinessLogic.Contracts;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace VehicleFleetApi.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IVehicleService _vehicleService;

        public VehicleController(ILogger<VehicleController> logger, IVehicleService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        [HttpGet]
        [Route("Generate")]
        public IEnumerable<Vehicle> GetVehicles()
        {
            var vehicles = Enumerable.Range(0, 5)
                .Select(i => _vehicleService.GenerateVehicle(i))
                .ToList();
            return vehicles;
        }
    }
}

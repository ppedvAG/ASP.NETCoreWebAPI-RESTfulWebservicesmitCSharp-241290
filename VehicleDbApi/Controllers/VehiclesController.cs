using BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;
using VehicleDbApi.Mappers;
using VehicleDbApi.Models;

namespace VehicleDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleServiceAsync _vehicleService;

        public VehiclesController(IVehicleServiceAsync vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetVehicles()
        {
            var result = await _vehicleService.GetVehicles();
            return Ok(result.Select(obj => obj.ToDto()));
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDto>> GetVehicle(int id)
        {
            var vehicle = await _vehicleService.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle.ToDto();
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, VehicleDto vehicle)
        {
            try
            {
                await _vehicleService.UpdateVehicle(id, vehicle.ToEntity());
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostVehicle(VehicleDto vehicle)
        {
            // Required Fields ueberpruefen
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var id = await _vehicleService.AddVehicle(vehicle.ToEntity());
                var newVehicle = await _vehicleService.GetVehicle(id);
                return Ok(newVehicle.ToDto());
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            try
            {
                await _vehicleService.DeleteVehicle(id);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}

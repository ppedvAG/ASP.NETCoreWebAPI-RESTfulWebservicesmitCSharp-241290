using BusinessLogic.Contracts;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleFleetV2Api.Controllers
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IVehicleService _vehicleService;

        public VehicleController(ILogger<VehicleController> logger, IVehicleService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        // GET: api/<VehicleController>
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<Vehicle>> Get()
        {
            var result = _vehicleService.GetVehicles();
            return Ok(result);
        }

        // GET api/<VehicleController>/5
        [HttpGet]
        [Route("GetSingle/{id:int:min(1)}")]
        public ActionResult<Vehicle> Get(int id)
        {
            var result = _vehicleService.GetVehicle(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<VehicleController>
        [HttpPost]
        [Route("Create")]
        public ActionResult<Vehicle> Post([FromBody] Vehicle value)
        {
            try
            {
                _vehicleService.AddVehicle(value);

                var updated = _vehicleService.GetVehicle(value.Id);
                return Ok(updated);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT api/<VehicleController>/5
        [HttpPut]
        [Route("Update/{id:int:min(1)}")]
        public ActionResult<Vehicle> Put(int id, [FromBody] Vehicle value)
        {
            try
            {
                var updated = _vehicleService.UpdateVehicle(id, value);
                return Ok(updated);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete]
        [Route("Delete/{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _vehicleService.DeleteVehicle(id);
                return NoContent(); // 202
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

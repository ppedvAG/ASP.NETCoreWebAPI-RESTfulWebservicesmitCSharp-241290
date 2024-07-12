using BusinessLogic;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleDbApi.Controllers;
using VehicleDbApi.Models;

namespace VehicleFleetTestProject
{
    [TestClass]
    public class VehicleDbApiTestUsingLocalDb
    {
        private readonly DemoDbContext _context = new TestDbContext().CreateDbContext();

        [TestCleanup]
        public void Cleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public async Task GetVehicles_FromService_ReturnsVehicles()
        {
            // Arrange
            var expectedCount = PredefinedTestData.Vehicles.Count();
            var service = new VehicleDbService(_context);

            // Act
            var result = await service.GetVehicles();

            // Assert
            Assert.IsNotNull(result, "Expected result not to be null.");
            Assert.AreEqual(expectedCount, result.Count(), "Expected 2 vehicles.");
        }

        [TestMethod]
        public async Task GetVehicles_FromController_ReturnsVehicles()
        {
            // Arrange
            var expectedCount = PredefinedTestData.Vehicles.Count();
            var service = new VehicleDbService(_context);
            var controller = new VehiclesController(service);

            // Act
            var response = await controller.GetVehicles();
            var result = response.Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(result, "Expected an OkObjectResult.");
            Assert.IsNotNull(result.Value, "Expected value of result not to be null.");
            Assert.IsInstanceOfType<IEnumerable<VehicleDto>>(result.Value, "Expected result type of IEnumerable<VehicleDto>.");

            var vehicles = result.Value as IEnumerable<VehicleDto>;
            Assert.AreEqual(expectedCount, vehicles.Count(), "Expected 2 vehicles.");

            // Mit CollectionAssert koennen wir ausgewaehlte Properties vergleichen
            // Merke: Wir vergleichen Entities gegen DTOs weshalb wir Properties (in anonyme Objects) extrahieren muessen
            var expected = PredefinedTestData.Vehicles.Select(v => new
            {
                v.Manufacturer,
                v.Model,
                v.Fuel,
                v.Type
            }).ToArray();
            var actual = vehicles.Select(v => new
            {
                v.Manufacturer,
                v.Model,
                v.Fuel,
                v.Type
            }).ToArray();
            CollectionAssert.AreEquivalent(expected, actual, "Expected vehicles to be equivalent.");
        }
    }
}

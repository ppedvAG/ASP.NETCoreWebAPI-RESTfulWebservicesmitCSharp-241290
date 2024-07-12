using BusinessLogic;
using BusinessLogic.Services;
using VehicleDbApi.Controllers;

namespace VehicleFleetTestProject
{
    [TestClass]
    public class VehicleServiceTestUsingLocalDb
    {
        private readonly DemoDbContext _context = new TestDbContext().CreateDbContext();

        [TestCleanup]
        public void Cleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public async Task GetVehicles_ReturnsVehicles()
        {
            // Arrange
            var expectedCount = PredefinedTestData.Vehicles.Count();
            var service = new VehicleDbService(_context);
            var controller = new VehiclesController(service);

            // Act
            var result = await service.GetVehicles();

            // Assert
            Assert.IsNotNull(result, "Expected result not to be null.");
            Assert.AreEqual(expectedCount, result.Count(), "Expected 2 vehicles.");
        }
    }
}

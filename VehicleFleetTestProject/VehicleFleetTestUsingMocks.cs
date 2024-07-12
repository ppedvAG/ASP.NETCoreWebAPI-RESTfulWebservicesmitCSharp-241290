using BusinessLogic.Contracts;
using BusinessLogic.Models;
using Microsoft.Extensions.Logging;
using Moq;
using VehicleFleetApi.Controllers;

namespace VehicleFleetTestProject
{
    [TestClass]
    public class VehicleFleetTestUsingMocks
    {
        [TestMethod]
        public void GetVehicles_ReturnsVehicles()
        {
            // Arrange
            var logger = Mock.Of<ILogger<VehicleController>>();
            var mockService = new Mock<IVehicleService>();
            mockService.Setup(m => m.GenerateVehicle(It.IsAny<int>())).Returns(
            new Vehicle
            {
                Id = 1,
                Manufacturer = "Unit Testing"
            });
            var controller = new VehicleController(logger, mockService.Object);

            // Act
            var result = controller.GetVehicles();

            // Assert
            Assert.IsNotNull(result, "Expected result not to be null.");
            Assert.AreEqual(5, result.Count(), "Expected exact 5 elements.");
        }
    }
}
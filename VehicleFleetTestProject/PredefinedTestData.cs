using BusinessLogic.Models;
using System.Drawing;

namespace VehicleFleetTestProject
{
    public class PredefinedTestData
    {
        public static Vehicle[] Vehicles => new[]
        {
            new Vehicle
            {
                Manufacturer = "Unit Testing",
                Model = "Test",
                Fuel = "Diesel",
                Color = KnownColor.Black,
                TopSpeed = 100,
                Type = "Test"
            },
            new Vehicle
            {
                Manufacturer = "Another Test",
                Model = "Another Model",
                Fuel = "Electro",
                Color = KnownColor.Black,
                TopSpeed = 100,
                Type = "Test"
            }
        };
    }
}

using Bogus;
using BusinessLogic.Contracts;
using BusinessLogic.Models;
using System.Drawing;

namespace BusinessLogic.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly Faker _faker = new Faker();

        public const int ReservedSystemColorNameCount = 27;
        public static readonly int ColorCount = Enum.GetValues(typeof(KnownColor)).Length;

        public Vehicle CreateVehicle(int id)
        {
            var topSpeed = Random.Shared.Next(10, 25) * 10;
            var color = (KnownColor)Random.Shared.Next(ReservedSystemColorNameCount, ColorCount);
            return new Vehicle
            {
                Id = id,
                Manufacturer = _faker.Vehicle.Manufacturer(),
                Model = _faker.Vehicle.Model(),
                Type = _faker.Vehicle.Type(),
                Fuel = _faker.Vehicle.Fuel(),
                TopSpeed = topSpeed,
                Color = color
            };
        }
    }
}

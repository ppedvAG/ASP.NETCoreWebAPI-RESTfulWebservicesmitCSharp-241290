using BusinessLogic.Contracts;
using BusinessLogic.Models;
using System.Drawing;

namespace BusinessLogic.Services
{
    public class VehicleDbService : IVehicleService
    {
        private readonly Bogus.Faker _faker = new();
        private readonly DemoDbContext _context;

        public VehicleDbService(DemoDbContext context)
        {
            _context = context;
        }

        public Vehicle GenerateVehicle(int id)
        {
            var topSpeed = Random.Shared.Next(10, 25) * 10;
            var color = (KnownColor)Random.Shared.Next(StaticVehicleService.ReservedSystemColorNameCount, StaticVehicleService.ColorCount);
            return new Vehicle
            {
                // Id = id, // ID wird von der Datenbank gesetzt
                Manufacturer = _faker.Vehicle.Manufacturer(),
                Model = _faker.Vehicle.Model(),
                Type = _faker.Vehicle.Type(),
                Fuel = _faker.Vehicle.Fuel(),
                TopSpeed = topSpeed,
                Color = color
            };
        }

        #region CRUD Operations

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _context.Vehicles.ToArray();
        }

        public Vehicle GetVehicle(int id)
        {
            return _context.Vehicles.FirstOrDefault(x => x.Id == id);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (GetVehicle(vehicle.Id) == null)
            {
                _context.Vehicles.Add(vehicle);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Vehicle already exists");
            }
        }

        public Vehicle UpdateVehicle(int id, Vehicle vehicle)
        {
            var existing = GetVehicle(id);
            if (existing != null)
            {
                _context.Vehicles.Remove(existing);
                _context.Vehicles.Add(vehicle);
                _context.SaveChanges();

                return GetVehicle(id);
            }
            else
            {
                throw new InvalidOperationException("Vehicle does not exist");
            }
        }

        public void DeleteVehicle(int id)
        {
            var existing = GetVehicle(id);
            if (existing != null)
            {
                _context.Vehicles.Remove(existing);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Vehicle does not exist");
            }
        }

        #endregion
    }
}

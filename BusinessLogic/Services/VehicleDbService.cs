using BusinessLogic.Contracts;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BusinessLogic.Services
{
    public class VehicleDbService : IVehicleServiceAsync
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

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _context.Vehicles.ToArrayAsync();
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AddVehicle(Vehicle vehicle)
        {
            var result = _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<Vehicle> UpdateVehicle(int id, Vehicle vehicle)
        {
            var existing = await GetVehicle(id);
            if (existing != null)
            {
                _context.Entry(vehicle).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return await GetVehicle(id);
            }
            else
            {
                throw new InvalidOperationException("Vehicle does not exist");
            }
        }

        public async Task DeleteVehicle(int id)
        {
            var existing = await GetVehicle(id);
            if (existing != null)
            {
                _context.Vehicles.Remove(existing);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Vehicle does not exist");
            }
        }

        #endregion
    }
}

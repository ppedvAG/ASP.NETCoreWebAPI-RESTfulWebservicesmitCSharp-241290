using Bogus;
using BusinessLogic.Contracts;
using BusinessLogic.Models;
using System.Drawing;

namespace BusinessLogic.Services
{
    public class StaticVehicleService : IVehicleService
    {
        private readonly Faker _faker = new Faker();

        public const int ReservedSystemColorNameCount = 27;
        public static readonly int ColorCount = Enum.GetValues(typeof(KnownColor)).Length;

        // Zu Demonstrationszwecken wird ein statischer Dummy-Datensatz verwendet.
        // Static Members sollten im Web-Context NIE verwendet werden. Gruende:
        //      1. Weil REST per se zustandslos sein muss
        //      2. Potentielle Speicherlecks weil statische Members ueber die gesamte Laufzeit des Servers gehalten werden (Monate)
        //      3. Concurrency Problem wenn mehrere Clients simultan auf die gleichen Daten zugreifen
        private static readonly List<Vehicle> _vehicleFleet =
        [
            new Vehicle
            {
                Id = 1,
                Manufacturer = "Toyota",
                Model = "Corolla",
                Type = "Sedan",
                Fuel = "Petrol",
                TopSpeed = 110,
                Color = KnownColor.Blue
            },
            new Vehicle
            {
                Id = 2,
                Manufacturer = "Toyota",
                Model = "Camry",
                Type = "Sedan",
                Fuel = "Petrol",
                TopSpeed = 110,
                Color = KnownColor.Red
            },
            new Vehicle
            {
                Id = 3,
                Manufacturer = "Nissan",
                Model = "Altima",
                Type = "Sedan",
                Fuel = "Petrol",
                TopSpeed = 110,
                Color = KnownColor.Green
            }
        ];

        public Vehicle GenerateVehicle(int id)
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

        #region CRUD Operations

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicleFleet;
        }

        public Vehicle GetVehicle(int id)
        {
            return _vehicleFleet.FirstOrDefault(x => x.Id == id);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (GetVehicle(vehicle.Id) == null)
            {
                _vehicleFleet.Add(vehicle);
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
                var index = _vehicleFleet.IndexOf(existing);
                _vehicleFleet[index] = vehicle;
                return _vehicleFleet[index];
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
                _vehicleFleet.Remove(existing);
            }
            else
            {
                throw new InvalidOperationException("Vehicle does not exist");
            }
        }

        #endregion
    }
}

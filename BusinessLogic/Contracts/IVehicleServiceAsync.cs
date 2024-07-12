using BusinessLogic.Models;

namespace BusinessLogic.Contracts
{
    public interface IVehicleServiceAsync
    {
        Task<int> AddVehicle(Vehicle vehicle);
        Task DeleteVehicle(int id);
        Vehicle GenerateVehicle(int id);
        Task<Vehicle> GetVehicle(int id);
        Task<IEnumerable<Vehicle>> GetVehicles();
        Task<Vehicle> UpdateVehicle(int id, Vehicle vehicle);
    }
}
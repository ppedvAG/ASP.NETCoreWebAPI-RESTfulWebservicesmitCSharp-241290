using BusinessLogic.Models;

namespace BusinessLogic.Contracts
{
    public interface IVehicleService
    {
        Vehicle GenerateVehicle(int id);

        #region CRUD Operations

        IEnumerable<Vehicle> GetVehicles();

        Vehicle GetVehicle(int id);

        void AddVehicle(Vehicle vehicle);

        Vehicle UpdateVehicle(int id, Vehicle vehicle);

        void DeleteVehicle(int id);

        #endregion
    }
}
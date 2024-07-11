using BusinessLogic.Models;

namespace BusinessLogic.Contracts
{
    public interface IVehicleService
    {
        Vehicle CreateVehicle(int id);
    }
}
using BusinessLogic.Models;
using System.Drawing;
using VehicleDbApi.Models;

namespace VehicleDbApi.Mappers
{
    /**
     * Wir wollen verhindern, dass das Entity-Objekt (Vehicle) direkt in der WebAPI Schicht verwendet wird.
     * Die WebAPI Schicht sollte nur das DTO-Objekt (VehicleDto) verwenden.
     * Der Mapper kann darüber hinaus Abhängigkeiten auflösen und auch Felder konvertieren oder berechnen, die in der Datenbank evtl. nicht vorkommen.
     * 
     * Alternativ zu diesem Ansatz gibt es noch das AutoMapper Package, das nicht zu empfehlen ist. 
     * (macht debuggen schwierig und das Auflösen von Abhängigkeiten ist nicht einfach)
     * 
     * Weitere Alternative ist mittels T4 Code zu generieren. An die Entity Klassen werden mittels partial Interfaces angehängt welche dann
     * in den Controllern verwendet werden können.
     */
    public static class VehicleMapper
    {
        public static Vehicle ToEntity(this VehicleDto vehicle)
        {
            Enum.TryParse<KnownColor>(vehicle.Color, out var color);
            return new Vehicle
            {
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Type = vehicle.Type,
                Fuel = vehicle.Fuel,
                TopSpeed = vehicle.TopSpeed,
                Color = color
            };
        }

        public static VehicleResponseDto ToDto(this Vehicle vehicle)
        {
            return new VehicleResponseDto
            {
                Id = vehicle.Id,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Type = vehicle.Type,
                Fuel = vehicle.Fuel,
                TopSpeed = vehicle.TopSpeed,
                Color = vehicle.Color.ToString()
            };
        }
    }
}

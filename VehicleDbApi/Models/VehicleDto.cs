using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace VehicleDbApi.Models
{
    public class VehicleResponseDto : VehicleDto
    {
        public int Id { get; set; }
    }

    public class VehicleDto
    {
        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Fuel { get; set; }

        [Required]
        public int TopSpeed { get; set; }

        [Required]
        public string Color { get; set; }
    }
}

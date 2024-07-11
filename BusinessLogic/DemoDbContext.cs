using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class DemoDbContext : DbContext
    {

        // Default Constructor wird nur benoetigt um einmalig die Datenbank zu erstellen
        // dotnet ef migrations add InitVehicleDb
        // dotnet ef database update
#if DEBUG
        public DemoDbContext() : base(CreateDbOptions())
        {
        }

        private static DbContextOptions<DemoDbContext> CreateDbOptions()
        {
            var builder = new DbContextOptionsBuilder<DemoDbContext>();
            builder.UseSqlServer("Data Source=(localdb)\\ASPNetWebApiKurs_240711;Initial Catalog=DemoDb;Integrated Security=True;Encrypt=False");
            return builder.Options;
        }
#endif

        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Vehicle> Vehicles { get; set; }
    }
}

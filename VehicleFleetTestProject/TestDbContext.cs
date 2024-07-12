using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace VehicleFleetTestProject
{
    internal class TestDbContext
    {
        private const string ConnectionString = "Data Source=(localdb)\\ASPNetWebApiKurs_240711;Initial Catalog=UnitTestDatabase;Integrated Security=True;Encrypt=False";

        public TestDbContext()
        {
            using(var context = CreateDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.AddRange(PredefinedTestData.Vehicles);
                context.SaveChanges();
            }
        }

        public DemoDbContext CreateDbContext()
        {
            var builder = new DbContextOptionsBuilder<DemoDbContext>()
                .UseSqlServer(ConnectionString);
            return new DemoDbContext(builder.Options);
        }
    }
}

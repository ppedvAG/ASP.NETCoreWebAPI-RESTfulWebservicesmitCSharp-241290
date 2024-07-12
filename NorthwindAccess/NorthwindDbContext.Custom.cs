using Microsoft.EntityFrameworkCore;

namespace NorthwindAccess.Models
{
    public partial class NorthwindDbContext
    {
#if DEBUG
        public NorthwindDbContext() : base(CreateDbOptions())
        {
        }

        private static DbContextOptions<NorthwindDbContext> CreateDbOptions()
        {
            var builder = new DbContextOptionsBuilder<NorthwindDbContext>();
            builder.UseSqlServer("Data Source=(localdb)\\ASPNetWebApiKurs_240711;Initial Catalog=Northwind_240711;Integrated Security=True;Encrypt=False");
            return builder.Options;
        }
#endif
    }
}

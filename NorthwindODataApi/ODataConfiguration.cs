using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using NorthwindAccess.Models;

namespace NorthwindODataApi
{
    public static class ODataConfiguration
    {
        public static void AddOdata(this IMvcBuilder builder)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Category>("Categories");
            modelBuilder.EntitySet<Customer>("Customers");
            modelBuilder.EntitySet<Employee>("Employees");
            modelBuilder.EntitySet<Order>("Orders");
            modelBuilder.EntityType<Order>().HasRequired(o => o.Customer);
            modelBuilder.EntityType<Order>().HasRequired(o => o.Employee);

            modelBuilder.EntitySet<Product>("Products");
            modelBuilder.EntitySet<Shipper>("Shippers");
            modelBuilder.EntitySet<Supplier>("Suppliers");
            modelBuilder.EntitySet<Territory>("Territories");

            builder.AddOData(options => options
                .Select()
                .Filter()
                .OrderBy()
                .Count()
                .Expand()
                .SetMaxTop(20) // wieviele Items pro "Page" geladen werden sollen
                .AddRouteComponents("odata", modelBuilder.GetEdmModel())
            );
        }
    }
}

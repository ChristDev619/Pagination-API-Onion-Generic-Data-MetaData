using Microsoft.EntityFrameworkCore;
using Pagination_API_Onion_Generic_Data_MetaData.Domain;
using System.Collections.Generic;

namespace Pagination_API_Onion_Generic_Data_MetaData.API.Infrastructure.Database
{
    // DbContext (if using EF Core)
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}

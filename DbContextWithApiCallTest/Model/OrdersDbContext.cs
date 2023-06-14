using DbContextWithApiCallTest.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DbContextWithApiCallTest.Model
{
    public class OrdersDbContext : DbContext, IDbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> dbContextOptions) : base(dbContextOptions)
        {
           
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}

using DbContextWithApiCallTest.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbContextWithApiCallTest.Model.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("order")
                .HasKey(x => x.Id);

            builder.HasData(new Order()
            {
                Id = 1,
                Status = "Begin",
                Updated = DateTime.UtcNow,
            });
        }
    }
}

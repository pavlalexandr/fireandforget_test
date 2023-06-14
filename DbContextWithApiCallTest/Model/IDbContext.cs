using DbContextWithApiCallTest.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbContextWithApiCallTest.Model
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}

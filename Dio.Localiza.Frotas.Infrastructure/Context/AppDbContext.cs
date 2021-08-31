using Dio.Localiza.Frotas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dio.Localiza.Frotas.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
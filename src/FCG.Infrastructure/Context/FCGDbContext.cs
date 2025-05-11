using FCG.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infrastructure.Context;

public class FCGDbContext : DbContext
{
    public FCGDbContext(DbContextOptions<FCGDbContext> options) : base(options)
    {
        
    }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FCGDbContext).Assembly);
    }
}

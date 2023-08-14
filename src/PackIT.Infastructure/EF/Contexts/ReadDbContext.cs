using Microsoft.EntityFrameworkCore;
using PackIT.Domain.Entities;
using PackIT.Infastructure.EF.Config;
using PackIT.Infastructure.EF.Models;

namespace PackIT.Infastructure.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
  public DbSet<PackingListReadModel> PackingLists { get; set; } = null!;

  public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
  {
    
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema("packing");
    var configuration = new ReadConfiguration();
    modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);
    modelBuilder.ApplyConfiguration<PackingItemReadModel>(configuration);
    base.OnModelCreating(modelBuilder);
  }
}

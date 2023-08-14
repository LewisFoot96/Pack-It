using Microsoft.EntityFrameworkCore;
using PackIT.Domain.Entities;
using PackIT.Infastructure.EF.Config;
using PackIT.Infastructure.EF.Models;

namespace PackIT.Infastructure.EF.Contexts;

internal sealed class WriteDbContext: DbContext
{
  public DbSet<PackingList> PackingLists { get; set; } = null!;

  public WriteDbContext(DbContextOptions<ReadDbContext> options) : base(options)
  {
    
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema("packing");
    var configuration = new WriteConfiguration();
    modelBuilder.ApplyConfiguration<PackingList>(configuration);
    modelBuilder.ApplyConfiguration<PackingList>(configuration);
  }
}

using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PackIT.Infastructure.EF.Models;

namespace PackIT.Infastructure.EF.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<PackingListReadModel>, IEntityTypeConfiguration<PackingItemReadModel>
{
  public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
  {
    builder.ToTable("PackingLists");
    builder.HasKey(p1 => p1.Id);

    builder.Property(p1 => p1.Localisation).HasConversion(l => l.ToString(), l => LocalisationReadModel.Create(l));

    builder.HasMany(p1 => p1.Items)
      .WithOne(pi => pi.PackingList);
  }

  public void Configure(EntityTypeBuilder<PackingItemReadModel> builder)
  {
    builder.ToTable("PackingItems");
  }
}

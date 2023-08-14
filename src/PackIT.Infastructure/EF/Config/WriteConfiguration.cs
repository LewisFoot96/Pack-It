using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObject;

namespace PackIT.Infastructure.EF.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<PackingList>, IEntityTypeConfiguration<PackingItem>
{
  public void Configure(EntityTypeBuilder<PackingList> builder)
  {
    builder.HasKey(p1 => p1.Id);

    var localisationConverter = new ValueConverter<Localisation, string>(l => l.ToString(), l => Localisation.Create(l));

    var packingListConverter =
      new ValueConverter<PackingListName, string>(pln => pln.Value, pln => new PackingListName(pln));

    builder.Property(pl => pl.Id).HasConversion(id => id.Value, id => new PackingListId(id));
    builder.Property(typeof(Localisation), "_localisation").HasConversion(localisationConverter).HasColumnName("Localisation");
    builder.Property(typeof(PackingListName), "_name").HasConversion(packingListConverter).HasColumnName("Name");
    builder.HasMany(typeof(PackingItem), "_items");

    builder.ToTable("PackingLists");
  }

  public void Configure(EntityTypeBuilder<PackingItem> builder)
  {
    builder.Property<Guid>("Id");
    builder.Property(pi => pi.Name);
    builder.Property(pi => pi.Quantity);
    builder.Property(pi => pi.IsPacked);
    
    builder.ToTable("PackingItems");
    
  }
}

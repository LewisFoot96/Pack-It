using PackIT.Domain.ValueObject;

namespace PackIT.Infastructure.EF.Models;

internal class PackingListReadModel
{
  public Guid Id { get; set; }
  public int Version { get; set; }
  public string Name { get; set; } = null!;
  public LocalisationReadModel Localisation { get; set; } = null!;
  public ICollection<PackingItemReadModel> Items { get; set; } = null!;
}

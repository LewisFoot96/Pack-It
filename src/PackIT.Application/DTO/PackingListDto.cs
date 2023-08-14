using PackIT.Domain.ValueObject;

namespace PackIT.Application.DTO;

public class PackingListDto
{
  public Guid Id { get; set; }
  public string Name { get; set; } = null!;
  public LocalisationDto Localisation { get; set; } = null!;
  public IEnumerable<PackingItemDto> Items { get; set; } = null!;
}

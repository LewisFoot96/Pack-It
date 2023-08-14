namespace PackIT.Application.DTO;

public class PackingItemDto
{
  public string Name { get; set; } = null!;
  public uint Quantity { get; set; }
  public bool IsPacked { get; set; }
}

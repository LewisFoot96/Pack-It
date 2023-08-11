using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObject;

public record PackingItem
{
  public string Name { get; }
  
  public uint Quantity { get; }
  
  public bool IsPacked { get; init; } //Initialised in constructor or object intiailser. 

  public PackingItem(string name, uint quantity)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      throw new EmptyPackingItemNameException();
    }
    Name = name;
    Quantity = quantity;
    IsPacked = false;
  }
}

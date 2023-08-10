using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class PackingItemGuidEmptyException : PackItException
{
  public PackingItemGuidEmptyException() : base("Packing item Guid empty.")
  {
  }
}

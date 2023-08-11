using PackIT.Domain.ValueObject;

namespace PackIT.Domain.Policies.Gender;

internal class MaleGenderPolicy : IPackingItemsPolicy
{
  public bool IsApplicable(PolicyData data) => data.Gender is Const.Gender.Male;

  public IEnumerable<PackingItem> GenerateItems(PolicyData data) => new List<PackingItem>
  {
    new PackingItem("Laptop", 1), new PackingItem("Beer", 10), new PackingItem("Book", (uint)Math.Ceiling(data.Days/7m))
  };
}

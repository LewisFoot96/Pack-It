using PackIT.Domain.ValueObject;

namespace PackIT.Domain.Policies.Gender;

public class FemaleGenderPolicy : IPackingItemsPolicy
{
  public bool IsApplicable(PolicyData data)
    => data.Gender is Const.Gender.Female;

  public IEnumerable<PackingItem> GenerateItems(PolicyData data)
    => new List<PackingItem>
    {
      new("Lipstick", 1),
      new("Powder", 1),
      new("Eyeliner", 1)
    };
}

using PackIT.Domain.ValueObject;

namespace PackIT.Domain.Policies;

public interface IPackingItemsPolicy
{
  bool IsApplicable(PolicyData data);

  IEnumerable<PackingItem> GenerateItems(PolicyData data);

}

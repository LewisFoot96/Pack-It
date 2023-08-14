using PackIT.Application.DTO;

namespace PackIT.Application.Services;

public interface IPackingLIstReadService
{
  Task<bool> ExistsByNameAsync(string name);
}

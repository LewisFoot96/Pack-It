using PackIT.Domain.Const;
using PackIT.Domain.ValueObject;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands;

public record CreatePackingListWithItems(Guid Id, string Name, ushort Days, Gender Gender, LocalisationWriteModel Localisation) : ICommand
{
  
}

public record LocalisationWriteModel(string City, string Country);

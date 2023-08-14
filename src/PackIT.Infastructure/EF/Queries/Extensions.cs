using PackIT.Application.DTO;
using PackIT.Infastructure.EF.Models;

namespace PackIT.Infastructure.EF.Queries;

internal static class Extensions
{
  public static PackingListDto AsDto(this PackingListReadModel readModel) =>
    new()
    {
      Id = readModel.Id,
      Name = readModel.Name,
      Localisation = new LocalisationDto
      {
        City = readModel.Localisation.City,
        Country = readModel.Localisation.Country,
      }, 
      Items = readModel.Items.Select(pi => new PackingItemDto
      {
        Name = pi.Name,
        Quantity = pi.Quantity,
        IsPacked = pi.IsPacked
      })
    };
}

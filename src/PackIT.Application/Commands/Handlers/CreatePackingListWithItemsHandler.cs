using PackIT.Application.Exceptions;
using PackIT.Application.Services;
using PackIT.Domain.Exceptions;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObject;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers;

public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
{

  private readonly IPackingListRepository _repository;
  private readonly IPackingListFactory _factory;
  private readonly IPackingLIstReadService _readService;
  private readonly IWeatherService _weatherService;

  public CreatePackingListWithItemsHandler(IPackingListRepository repository, IPackingListFactory factory, IPackingLIstReadService readService, IWeatherService weatherService)
  {
    _repository = repository;
    _factory = factory;
    _readService = readService;
    _weatherService = weatherService;
  }

  public async Task HandleAsync(CreatePackingListWithItems command)
  {
    var (id, name, days, gender, localisationWriteModel) = command;
    if (await _readService.ExistsByNameAsync(name))
    {
      throw new PackingListAlreadyExistsException(name);
    }

    var localisation = new Localisation(localisationWriteModel.City, localisationWriteModel.Country);
    var weather = await _weatherService.GetWeatherAsync(localisation);

    if (weather is null)
    {
      throw new MissingLocalisationWeatherException(localisation);
    }

    var packingList = _factory.CreateWithDefaultItems(id, name, days, gender, localisation, weather.Temperature);

    await _repository.AddAsync(packingList);
  }
}

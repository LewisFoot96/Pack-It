using PackIT.Application.DTO.External;
using PackIT.Application.Services;
using PackIT.Domain.ValueObject;

namespace PackIT.Infastructure.Services;

internal sealed class DumpWeatherService : IWeatherService
{
  public Task<WeatherDTO> GetWeatherAsync(Localisation localisation) =>
    Task.FromResult(new WeatherDTO(new Random().Next(5, 30))); //For testing purposes, we should be getting this from an API. 
}

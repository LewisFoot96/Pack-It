namespace PackIT.Domain.ValueObject;

public record Localisation(string City, string Country)
{
  public static Localisation Create(string value)
  {
    var splitLocalisationString = value.Split(",");
    return new Localisation(splitLocalisationString.First(), splitLocalisationString.Last());
  }

  public override string ToString()
    => $"{City},{Country}";

}

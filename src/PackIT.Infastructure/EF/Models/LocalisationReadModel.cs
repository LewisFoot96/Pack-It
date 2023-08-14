namespace PackIT.Infastructure.EF.Models;

internal class LocalisationReadModel
{
  public string City { get; set; } = null!;
  public string Country { get; set; } = null!;

  public static LocalisationReadModel Create(string value)
  {
    var splitLocalisation = value.Split(',');
    return new LocalisationReadModel()
    {
      City = splitLocalisation.First(),
      Country = splitLocalisation.Last()
        
    };
  }

  public override string ToString()
  {
    return $"{City},{Country}";
  }
}

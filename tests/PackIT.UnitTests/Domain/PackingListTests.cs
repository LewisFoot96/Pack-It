using PackIT.Domain.Entities;
using PackIT.Domain.Exceptions;
using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObject;
using Shouldly;
using Xunit;

namespace PackIT.UnitTests.Domain;

public class PackingListTests
{
  [Fact]
  public void AddItem_Throws_PackingItemAlreadyExistsException_When_There_Is_Already_Item_With_The_Same_Name()
  {
    //Arrange
    var packingList = GetPackngList();
    packingList.AddPackingItem(new PackingItem("Item 1", 1));
    
    //Act
    var exception = Record.Exception(() => packingList.AddPackingItem(new PackingItem("Item 1", 1)));
    
    exception.ShouldNotBeNull();
    exception.ShouldBeOfType<PackingItemAlreadyExistsException>();
  }

  
  
  #region ARRAGNGE
  
  private PackingList GetPackngList()
  {
    var packingList = _factory.Create(Guid.NewGuid(), "MyList", Localisation.Create("Warsaw, Poland"));
    return packingList;
  }

  private readonly IPackingListFactory _factory;

  public PackingListTests()
  {
    _factory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolicy>());
  }
  
  #endregion
}

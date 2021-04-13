using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  /// <summary>
  /// 
  /// </summary>
  public class OrderTests
  {
    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_CreateOrder()
    {
      // arrange
      var sut = new Order(
        new Customer("John"),
        new ChicagoStore(),
        new VeganPizza()
      );

      // act
      var customer = sut.Customer;
      var store = sut.Store;
      var pizza = sut.Pizza;

      // assert
      Assert.Equal("John", $"{customer}");
      Assert.Equal("Chicago Store", $"{store}");
      Assert.Equal("Vegan Pizza", $"{pizza}");
    }
  }
}

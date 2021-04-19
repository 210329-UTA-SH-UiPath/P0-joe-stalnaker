using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;
using Xunit;
using System;

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
      var pizzas = new List<APizza>();
      pizzas.Add(new VeganPizza());
      var sut = new Order(
        new Customer(0, "John"),
        new ChicagoStore(),
        pizzas,
        DateTime.Now
      );

      // act
      var customer = sut.Customer;
      var store = sut.Store;
      var pizza = sut.Pizzas[0];

      // assert
      Assert.Equal("John", $"{customer}");
      Assert.Equal("Chicago Store", $"{store}");
      Assert.Equal("Vegan Pizza", $"{pizza}");
    }
  }
}

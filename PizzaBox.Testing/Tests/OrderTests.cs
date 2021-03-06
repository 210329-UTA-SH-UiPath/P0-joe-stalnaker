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
      pizzas = sut.Pizzas;

      // assert
      Assert.Equal(sut.Customer, customer);
      Assert.Equal(sut.Store, store);
      Assert.Equal(sut.Pizzas, pizzas);
    }
  }
}

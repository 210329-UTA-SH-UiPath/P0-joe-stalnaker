using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;
using Xunit;
using System;

namespace PizzaBox.Testing.Tests
{
  /// <summary></summary>
  public class CustomerTests
  {
    /// <summary></summary>
    [Fact]
    public void Test_AddOderToCustomer()
    {
      // arrange
      var sut = new Customer(0, "John");
      var pizzas = new List<APizza>();
      pizzas.Add(new VeganPizza());
      var order = new Order(
        new Customer(0, "John"),
        new ChicagoStore(),
        pizzas,
        DateTime.Now
      );

      // act
      sut.Orders.Add(order);

      // assert
      Assert.Contains(order, sut.Orders);
    }
  }
}
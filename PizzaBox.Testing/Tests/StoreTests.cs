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
  public class StoreTests
  {
    /*<summary></summary>*/
    [Fact]
    public void Test_StoreName()
    {
      // arrange
      var sut = new ChicagoStore();

      // act
      var actual = sut.Name;

      // assert
      Assert.True(actual == sut.Name);
    }
    [Fact]
    public void Test_AddOrderToStore()
    {//arrange
      var sut = new ChicagoStore();
      var pizzas = new List<APizza>();
      pizzas.Add(new VeganPizza());
      var order = new Order(
        new Customer(0, "John"),
        new ChicagoStore(),
        pizzas,
        DateTime.Now
      );
      sut.Orders.Add(order);
      //actual
      var actual = sut.Orders;
      //assert
      Assert.Contains(order, actual);
    }
  }
}

using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Singletons;
using System.Collections.Generic;
using Xunit;
using System;


namespace PizzaBox.Testing.Tests
{
  public class SingletonTests
  {
    [Fact]
    public void Test_CustomerSingleton()
    {
      //arrange
      var sut = CustomerSingleton.Instance;
      var customer = new Customer(0, "John");
      sut.AddCustomer(customer);

      // act
      var actual = sut.Customers;
      // assert
      Assert.Contains(customer, actual);
    }
    [Fact]
    public void Test_PizzaSingleton()
    {
      //arrange
      var sut = PizzaSingleton.Instance;
      // act
      var actual = sut.Pizzas;
      // assert
      Assert.Equal(sut.Pizzas, actual);
    }
    [Fact]
    public void Test_StoreSingleton()
    {
      //arrange
      var sut = StoreSingleton.Instance;
      // act
      var actual = sut.Stores;
      // assert
      Assert.Equal(sut.Stores, actual);
    }
    [Fact]
    public void Test_OrderSingleton()
    {
      //arrange
      var sut = OrderSingleton.Instance;
      var pizzas = new List<APizza>();
      pizzas.Add(new VeganPizza());
      var order = new Order(
        new Customer(0, "John"),
        new ChicagoStore(),
        pizzas,
        DateTime.Now
      );
      sut.AddOrder(order);
      // act
      var actual = sut.Orders[0];
      // assert
      Assert.Contains(actual, sut.Orders);
    }
    [Fact]
    public void Test_StringStingleton()
    {
      //arrange
      var sut = StringSingleton.Instance;
      // act
      var actual = sut.Strings;
      // assert
      Assert.Equal(actual, sut.Strings);
    }
  }
}
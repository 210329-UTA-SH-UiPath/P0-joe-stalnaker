using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client
{
  /// <summary>
  /// 
  /// </summary>
  internal class Program
  {
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;
    private static readonly StringSingleton _stringSingleton = StringSingleton.Instance;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
      Run();
    }

    /// <summary>
    /// 
    /// </summary>
    // private static void Run()
    // {
    //   var order = new Order();

    //   Console.WriteLine("Welcome to PizzaBox");
    //   DisplayStoreMenu();

    //   order.Customer = new Customer();
    //   order.Store = SelectStore();
    //   order.Pizza = SelectPizza();
    //   _orderSingleton.AddOrder(order);
    //   Console.WriteLine($"Orders:");
    //   _orderSingleton.ShowOrders();

    //   _orderSingleton.Save();
    // }
    private static void Run()
    {
      var running = true;
      while (running)
      {
        DisplayMainMenu();
        var command = SelectMainMenuOption();
        switch (command)
        {
          case 1:
            DisplayStores();
            break;
          case 2:
            DisplayOrders();
            break;
          case 3:
            CreateOrder();
            break;
          case 4:
            running = false;
            break;
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void DisplayMainMenu()
    {
      Console.WriteLine(_stringSingleton.Strings[0]);
    }

    /// <summary>
    /// 
    /// </summary>
    private static void DisplayOrders()
    {
      foreach (Order order in _orderSingleton.Orders)
      {
        Console.WriteLine(order);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void DisplayPizzas()
    {
      var index = 0;

      foreach (var item in _pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void DisplayStores()
    {
      var index = 0;

      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static int SelectMainMenuOption()
    {
      var input = int.Parse(Console.ReadLine()); // be careful (think execpetion/error handling)

      return input;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static APizza SelectPizza()
    {
      var input = int.Parse(Console.ReadLine());
      var pizza = _pizzaSingleton.Pizzas[input - 1];
      return pizza;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static AStore SelectStore()
    {
      var input = int.Parse(Console.ReadLine()); // be careful (think execpetion/error handling)
      return _storeSingleton.Stores[input - 1];
    }
    private static void CreateOrder()
    {
      DisplayCustomerPrompt();
      var customer = new Customer(Console.ReadLine());
      DisplayStores();
      DisplayListPrompt();
      var store = SelectStore();
      DisplayPizzas();
      DisplayListPrompt();
      var pizza = SelectPizza();
      _orderSingleton.Orders.Add(new Order(customer, store, pizza));
    }
    private static void DisplayCustomerPrompt()
    {
      Console.Write(_stringSingleton.Strings[2]);
    }
    private static void DisplayListPrompt()
    {
      Console.Write(_stringSingleton.Strings[3]);
    }
  }
}

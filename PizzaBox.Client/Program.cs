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
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;

    /// <summary></summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
      Run();
    }

    /// <summary></summary>
    private static void Run()
    {
      var running = true;
      while (running)
      {
        DisplayMainMenu();
        var command = SelectMenuOption();
        switch (command)
        {
          case 1:
            DisplayStores();
            break;
          case 2:
            DisplaySalesByStore();
            break;
          case 3:
            DisplayOrdersByStore();
            break;
          case 4:
            DisplayOrdersByCustomer();
            break;
          case 5:
            DisplayPizzasInOrder();
            break;
          case 6:
            CreateOrder();
            break;
          case 7:
            running = false;
            break;
        }
      }
    }

    /// <summary></summary>
    private static void DisplayMainMenu()
    {
      Console.WriteLine(_stringSingleton.Strings[0]);
    }
    /// <summary></summary>
    private static void DisplayStores()
    {
      var index = 0;

      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }
    /// <summary></summary>
    private static void DisplaySalesByStore()
    {
      DisplayStores();
      DisplayListPrompt();
      var store = SelectStore();
      DisplaySalesMenu();
      DisplayLedger(store.GetLedger(SelectMenuOption()));
    }
    /// <summary></summary>
    public static void DisplayLedger(Dictionary<DateTime, int> ledger)
    {
      foreach (KeyValuePair<DateTime, int> entry in ledger)
      {
        Console.WriteLine($"{0}: {1}", entry.Key, entry.Value);
      }
    }
    /// <summary></summary>
    private static void DisplayOrdersByStore()
    {
      DisplayStores();
      DisplayListPrompt();
      var store = SelectStore();
      DisplayOrders(store.Orders);
    }
    /// <summary></summary>
    private static void DisplayOrdersByCustomer()
    {
      DisplayCustomers();
      DisplayListPrompt();
      var customer = SelectCustomer();
      DisplayOrders(customer.Orders);
    }
    /// <summary></summary>
    public static void DisplayCustomers()
    {
      foreach (Customer customer in _customerSingleton.Customers) ;
    }
    /// <summary></summary>
    private static void DisplayOrders(List<Order> orders)
    {
      var index = 0;
      foreach (Order order in orders)
      {
        Console.WriteLine($"{++index} - {order}");
      }
    }
    /// <summary></summary>
    private static void DisplayPizzasInOrder()
    {
      DisplayOrders(_orderSingleton.Orders);
      DisplayListPrompt();
      Order order = SelectOrder();
      DisplayPizzas(order.Pizzas);
    }
    /// <summary></summary>
    private static void DisplayPizzas(List<APizza> pizzas)
    {
      var index = 0;

      foreach (var item in pizzas)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }
    /// <summary></summary>
    /// <returns>int</returns>
    private static int SelectMenuOption()
    {
      var input = int.Parse(Console.ReadLine()); // be careful (think execpetion/error handling)

      return input;
    }
    /// <summary></summary>
    /// <returns>int</returns>
    private static int SelectTime()
    {
      var input = SelectMenuOption(); // be careful (think execpetion/error handling)

      return input;
    }
    /// <summary></summary>
    /// <returns></returns>
    private static APizza SelectPizza()
    {
      return _pizzaSingleton.Pizzas[SelectMenuOption() - 1];
    }
    /// <summary></summary>
    /// <returns>Customer</returns>
    private static Customer SelectCustomer()
    {
      return _customerSingleton.Customers[SelectMenuOption() - 1];
    }

    /// <summary></summary>
    /// <returns></returns>
    private static AStore SelectStore()
    {
      return _storeSingleton.Stores[SelectMenuOption() - 1];
    }

    /// <summary></summary>
    /// <returns></returns>
    private static Order SelectOrder()
    {
      return _orderSingleton.Orders[SelectMenuOption() - 1];
    }
    private static void CreateOrder()
    {
      DisplayCustomerPrompt();
      var customer = new Customer(Console.ReadLine());
      DisplayStores();
      DisplayListPrompt();
      var store = SelectStore();
      DisplayPizzas(_pizzaSingleton.Pizzas);
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
    private static void DisplaySalesMenu()
    {
      Console.Write(_stringSingleton.Strings[4]);
      DisplayListPrompt();
    }
    private static void DisplayTimePrompt()
    {
      Console.WriteLine(_stringSingleton.Strings[5]);
    }
  }
}

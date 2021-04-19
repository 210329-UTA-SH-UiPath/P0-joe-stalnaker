using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class OrderSingleton
  {
    private static OrderSingleton _instance;
    private static readonly FileRepository _fileRepository = new FileRepository();
    private const string _path = @"B:\Employment\Revature\Training\projects\P0-joe-stalnaker\order.xml";
    public List<Order> Orders { get; set; }
    public static OrderSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new OrderSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private OrderSingleton()
    {
      Orders = new List<Order>();
      //Orders = _fileRepository.ReadFromFile<Order>(_path);
    }
    public bool Save()
    {
      return _fileRepository.WriteToFile<Order>(_path, Orders);
    }
    public void AddOrder(Order order)
    {
      ShowOrders();
      Orders.Add(order);
      ShowOrders();
    }
    public void ShowOrders()
    {
      foreach (Order order in Orders)
      {
        Console.WriteLine(order);
      }
    }
  }
}

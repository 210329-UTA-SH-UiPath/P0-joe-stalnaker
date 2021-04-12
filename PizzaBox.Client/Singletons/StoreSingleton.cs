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
  public class StoreSingleton
  {
    private static StoreSingleton _instance;
    private static readonly FileRepository _fileRepository = new FileRepository();
    private const string _storePath = @"store.xml";
    private const string _orderPath = @"order.xml";
    public List<AStore> Stores { get; set; }
    public List<Order> Orders { get; set; }
    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StoreSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private StoreSingleton()
    {
      Stores = _fileRepository.ReadFromFile<AStore>(_storePath);
      Orders = new List<Order>();
      //Orders = _fileRepository.ReadFromFile<Order>(_orderPath);
    }
    public bool Save()
    {
      return (
        _fileRepository.WriteToFile<AStore>(_storePath, Stores)
        &&
      _fileRepository.WriteToFile<Order>(_orderPath, Orders));
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

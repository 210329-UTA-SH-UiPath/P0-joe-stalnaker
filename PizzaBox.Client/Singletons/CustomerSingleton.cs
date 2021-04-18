using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary></summary>
  public class CustomerSingleton
  {
    private static CustomerSingleton _instance;
    private static readonly FileRepository _fileRepository = new FileRepository();
    private const string _path = @"customers.xml";
    public List<Customer> Customers { get; set; }
    public static CustomerSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new CustomerSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private CustomerSingleton()
    {
      Customers = new List<Customer>();
    }
    public bool Save()
    {
      return _fileRepository.WriteToFile<Customer>(_path, Customers);
    }
    public void AddCustomer(Customer newCustomer)
    {
      Boolean found = false;
      foreach (Customer customer in Customers)
      {
        if (newCustomer.ID == customer.ID)
        {
          found = true;
          break;
        }
      }
      if (!found) Customers.Add(newCustomer);
    }
    public Customer GetCustomer(int id)
    {
      foreach (Customer customer in Customers)
      {
        if (customer.ID == id) return customer;
      }
      return null;
    }
    public void ShowCustomers()
    {
      foreach (Customer customer in Customers)
      {
        Console.WriteLine(customer);
      }
    }
  }
}

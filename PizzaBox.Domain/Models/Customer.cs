using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Customer
  {
    public string Name { get; set; }
    public List<Order> Orders { get; set; }

    public Customer(string name)
    {
      Name = name;
      Orders = new List<Order>();
    }
    public override string ToString()
    {
      return Name;
    }
  }
}
using PizzaBox.Domain.Abstracts;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(Customer))]
  [XmlInclude(typeof(APizza))]
  [XmlInclude(typeof(AStore))]
  [XmlInclude(typeof(MeatPizza))]
  [XmlInclude(typeof(HawiianPizza))]
  public class Order
  {
    public AStore Store { get; set; }
    public Customer Customer { get; set; }
    public List<APizza> Pizzas { get; set; }
    public DateTime DateTime { get; set; }
    public Order() : base() { }
    public Order(Customer customer, AStore store, List<APizza> pizzas, DateTime dateTime)
    {
      Customer = customer;
      Store = store;
      Pizzas = pizzas;
      DateTime = dateTime;
    }
    public decimal Price()
    {
      decimal price = 0;
      foreach (APizza pizza in Pizzas)
      {
        price += pizza.Price();
      }
      return price;
    }
    public bool AddPizza(APizza pizza)
    {
      Pizzas.Add(pizza);
      return true;
    }
    public override string ToString()
    {
      string order = $"{DateTime} {Store.Name} {Customer.Name} {Price()}";
      foreach (APizza pizza in Pizzas)
      {
        order += $" {pizza.Name}";
      }
      return order;
    }
  }
}

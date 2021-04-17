using PizzaBox.Domain.Abstracts;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(Customer))]
  [XmlInclude(typeof(APizza))]
  [XmlInclude(typeof(AStore))]
  [XmlInclude(typeof(MeatPizza))]
  [XmlInclude(typeof(VeganPizza))]
  public class Order
  {
    public AStore Store { get; set; }
    public Customer Customer { get; set; }
    public List<APizza> Pizzas { get; set; }
    public Order(Customer customer, AStore store, APizza pizza)
    {
      Customer = customer;
      Store = store;
      Pizzas = new List<APizza>();
      AddPizza(pizza);
    }
    public bool AddPizza(APizza pizza)
    {
      Pizzas.Add(pizza);
      return true;
    }
    public override string ToString()
    {
      return $"{Store} {Customer} {Pizzas}";
    }
  }
}

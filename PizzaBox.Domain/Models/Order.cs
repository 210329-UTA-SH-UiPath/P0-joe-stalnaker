using PizzaBox.Domain.Abstracts;
using System.Xml.Serialization;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(Customer))]
  [XmlInclude(typeof(APizza))]
  [XmlInclude(typeof(MeatPizza))]
  [XmlInclude(typeof(VeganPizza))]
  public class Order
  {
    private AStore Store { get; set; }
    private Customer Customer { get; set; }
    private APizza Pizza { get; set; }
    public Order(Customer customer, AStore store, APizza pizza)
    {
      Customer = customer;
      Store = store;
      Pizza = pizza;
    }
    public override string ToString()
    {
      return $"{Store} {Customer} {Pizza}";
    }
  }
}

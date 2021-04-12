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
    public AStore Store { get; set; }
    public Customer Customer { get; set; }
    public APizza Pizza { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public void Save()
    {

    }
    public override string ToString()
    {
      return $"{Store} {Customer} {Pizza}";
    }
  }
}

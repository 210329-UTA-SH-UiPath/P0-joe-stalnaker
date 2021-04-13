using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Crust : AComponent
  {
    public string Type { set; get; }
    public Crust()
    {
      Type = "";
    }
    public Crust(string type)
    {
      Type = type;
    }

  }
}

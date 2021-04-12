using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class MeatPizza : APizza
  {
    public MeatPizza()
    {
      Type = "Meat Pizza";
    }

    public override void AddToppings()
    {
      Toppings.Add(new Topping());
    }
  }
}

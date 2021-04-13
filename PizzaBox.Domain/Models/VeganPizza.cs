using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class VeganPizza : APizza
  {
    public VeganPizza()
    {
      Type = "Vegan Pizza";
    }
    public override void AddCrust()
    {
      Crust = new Crust("Cauliflower");
    }

    public override void AddSize()
    {
      Size = null;
    }

    public override void AddToppings()
    {
      Toppings.AddRange(new Topping[] { new Topping(), new Topping() });
    }
  }
}

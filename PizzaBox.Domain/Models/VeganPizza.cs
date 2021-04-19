using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary></summary>
  public class VeganPizza : APizza
  {
    public VeganPizza() : base()
    {
      Name = "Vegan Pizza";
      Crust = new Crust("Cauliflower", 3.00M);
      Size = new Size();
      Toppings = new List<Topping>();
      Toppings.Add(new Topping("Cheese", 1.00M));
      Toppings.Add(new Topping("Olives", 1.00M));
      Toppings.Add(new Topping("Pineapple", 1.00M));

    }
  }
}

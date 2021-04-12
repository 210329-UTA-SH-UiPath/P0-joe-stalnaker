using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  public abstract class APizza
  {
    public string Type { get; set; }
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public List<Topping> Toppings { get; set; }

    protected APizza()
    {
      Factory();
    }

    private void Factory()
    {
      Type = "Custom";
      Toppings = new List<Topping>();

      AddCrust();
      AddSize();
      AddToppings();
    }

    public virtual void AddCrust()
    {
      Crust = new Crust();
    }

    public virtual void AddSize()
    {
      Size = new Size();
    }

    public abstract void AddToppings();

    public override string ToString()
    {
      return $"{Type}";
    }
  }
}

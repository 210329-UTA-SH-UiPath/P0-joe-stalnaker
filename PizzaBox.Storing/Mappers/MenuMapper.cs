using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Mappers
{
  public class MenuMapper : IMapper<PizzaBox.Storing.Entities.Menu, PizzaBox.Domain.Models.Menu>
  {
    public Domain.Models.Menu Map(Entities.Menu model)
    {
      return new Domain.Models.Menu(model.ID, model.Text);
    }

    public Entities.Menu Map(Domain.Models.Menu model)
    {
      Entities.Menu menu = new Entities.Menu();
      menu.Text = model.Text;
      menu.ID = model.ID;
      return menu;
    }
  }
}
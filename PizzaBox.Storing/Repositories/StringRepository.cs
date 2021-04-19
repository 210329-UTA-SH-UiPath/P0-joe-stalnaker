using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;
using System.Linq;


namespace PizzaBox.Storing.Repositories
{
  public class StringRepository : IRepository<string>
  {
    private readonly PizzaBoxDbContext context;
    public StringRepository(PizzaBoxDbContext context)
    {
      this.context = context;
    }
    public void Add(string t)
    {
      context.Strings.Add(t);
      context.SaveChanges();
    }

    public List<string> GetList()
    {
      return context.Strings.AsEnumerable().ToList();
    }

    public void Remove(string t)
    {
      string s = context.Strings.ToList().Find(s => s.Equals(t));
      if (s is not null)
      {
        context.Strings.Remove(s);
        context.SaveChanges();
      }
    }

    public void Update(string existing, string updated)
    {
      string s = context.Strings.ToList().Find(s => s.Equals(existing));
      if (s is not null)
      {
        s = updated;
        context.SaveChanges();
      }
    }
  }
}
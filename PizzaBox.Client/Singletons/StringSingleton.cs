using System;
using System.Collections.Generic;
using System.IO;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary></summary>
  public class StringSingleton
  {
    private static StringSingleton _instance;
    private readonly StringRepository repository = null;
    public List<string> Strings { get; set; }
    public static StringSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StringSingleton();
        }
        return _instance;
      }
    }
    /// <summary></summary>
    private StringSingleton()
    {
      repository = new StringRepository(DbContextSingleton.Instance.Context);
      Strings = repository.GetList();
    }
  }
}

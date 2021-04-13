using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class StringSingleton
  {
    private static StringSingleton _instance;
    private static readonly FileRepository _fileRepository = new FileRepository();
    private const string _path = @"strings.xml";
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

    /// <summary>
    /// 
    /// </summary>
    private StringSingleton()
    {
      //     Strings = new List<string>();
      //     Strings.Add(@"Welcome To PizzaBox!
      // 1. List Stores
      // 2. List Previous Orders
      // 3. Start New Order
      // 4. Quit");
      //     Strings.Add(@"R. Return to Main Menu");
      //     Save();
      Strings = _fileRepository.ReadFromFile<string>(_path);
    }
    public bool Save()
    {
      return _fileRepository.WriteToFile<string>(_path, Strings);
    }
  }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PizzaBox.Storing.Repositories
{
  public class FileRepository
  {
    public bool WriteToFile<T>(string path, List<T> list)
    {
      try
      {
        var writer = new StreamWriter(path);
        var xml = new XmlSerializer(typeof(List<T>));

        xml.Serialize(writer, list);
        writer.Close();

        return true;
      }
      // catch (FileNotFoundException e)
      // {
      //   throw new Exception("you have wrong file", e);
      // }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return false;
      }
    }

    public List<T> ReadFromFile<T>(string path) where T : class
    {
      var reader = new StreamReader(path);
      var xml = new XmlSerializer(typeof(List<T>)); // POCO = plain old csharp object
      var list = xml.Deserialize(reader) as List<T>;
      reader.Close();

      return list; // if error => null
      // return (List<AStore>) xml.Deserialize(reader); // if error => exception
    }
  }
}

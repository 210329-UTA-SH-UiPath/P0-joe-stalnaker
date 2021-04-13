using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class FileRepositoryTests
  {
    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_ReadWriteToFile()
    {
      var sut = new FileRepository();
      var path = @"test.xml";
      List<string> list = new List<string>();
      list.Add(@"one");
      list.Add(@"two");
      list.Add(@"three");
      sut.WriteToFile<string>(path, list);

      var actual = sut.ReadFromFile<string>(path);

      Assert.False(list == actual);
      Assert.Equal(list, actual);
    }

  }
}
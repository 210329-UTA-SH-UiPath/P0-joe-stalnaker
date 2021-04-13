namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Customer
  {
    public string Name { get; set; }

    public Customer(string name)
    {
      Name = name;
    }
    public override string ToString()
    {
      return Name;
    }

  }
}

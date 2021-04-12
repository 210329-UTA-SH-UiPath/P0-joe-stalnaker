namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Customer
  {
    public string Name { get; set; }

    public Customer()
    {
      Name = "Customer";
    }
    public override string ToString()
    {
      return Name;
    }

  }
}

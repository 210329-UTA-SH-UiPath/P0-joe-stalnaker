using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{
  public class Menu
  {
    [Key]
    public int ID { get; set; }
    [Required]
    public string Text { get; set; }
  }
}
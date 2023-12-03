using System.ComponentModel.DataAnnotations;

namespace iii.Models;

public class Product
{
    [Key] public int ProductId { get; set; }
    [Required] public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string ImageURL { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreRoutingDemo.Models
{
  public class Book
  {
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public int Number { get; set; }

    public string Slug { get; set; }
  }
}

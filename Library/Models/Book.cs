using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public int BookId { get; set; }
    public string Title { get; set; }
    public List<Author> Authors { get; set; }
    public List<Copy> Copies { get; set; }

    public ApplicationUser User { get; set; }  

  }
}
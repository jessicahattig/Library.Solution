using System.Collections.Generic;

namespace Library.Models
{
  public class Author
  {
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public List<Book> Books { get; set; }
    public ApplicationUser User { get; set; }  

  }
}
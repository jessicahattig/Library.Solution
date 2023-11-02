using System.Collections.Generic;

namespace Library.Models
{
  public class Copy
  {
    public int CopyId { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public List<Checkout> JoinEntities { get; }

    public ApplicationUser User { get; set; }  


  }
}

//As a patron, I want to know how many copies of a book are on the shelf, so that I can see if any are available. (Hint: make a copies table; a book should have many copies.)


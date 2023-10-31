using System.Collections.Generic;

namespace Library.Models
{
  public class Copy
  {
    public int BookId { get; set; }
    public int NumCopies { get; set; }
    public List<PatronCopy> JoinEntities { get; }
  }
}

//As a patron, I want to know how many copies of a book are on the shelf, so that I can see if any are available. (Hint: make a copies table; a book should have many copies.)

//As a patron, I want to see a history of all the books I checked out, so that I can look up the name of that awesome sci-fi novel I read three years ago. (Hint: make a checkouts table that is a join table between patrons and copies.)
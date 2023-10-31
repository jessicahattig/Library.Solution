using System.Collections.Generic;

namespace Library.Models
{
  public class Patron
  {
    public int PatronId { get; set; }
    public List<Checkout> JoinEntities { get; }
  }
}

//As a patron, I want to see a history of all the books I checked out, so that I can look up the name of that awesome sci-fi novel I read three years ago. (Hint: make a checkouts table that is a join table between patrons and copies.)

//As a patron, I want to know when a book I checked out is due, so that I know when to return it.
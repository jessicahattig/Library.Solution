using System.Collections.Generic;
using System;

namespace Library.Models
{
  public class Checkout
  {
    public int CheckoutId { get; set; }
    public int CopyId { get; set; }
    public Copy Copy { get; set; }

    public int PatronId { get; set; }
    public Patron Patron { get; set; }

    public DateTime CheckoutDate { get; set; }
    public DateTime ReturnDate { get; set; }

  }
}


//As a patron, I want to check a book out, so that I can take it home with me. I should only be able to do this if I am logged in. // Add  public ApplicationUser { get; set; } where user needs to be logged in to view whatever.

//As a patron, I want to see a history of all the books I checked out, so that I can look up the name of that awesome sci-fi novel I read three years ago. (Hint: make a checkouts table that is a join table between patrons and copies.)
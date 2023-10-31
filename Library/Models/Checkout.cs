using System.Collections.Generic;

namespace Library.Models
{
  public class Checkout
  {
    public int BookCheckoutId { get; set; }
    public int CheckoutId { get; set; }
    public int Checkout Checkout { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; }
    public Date Checkout { get; set; }
    public Date Return { get; set; }
    public List<Book> Books { get; set; }
    public ApplicationUser { get; set; }
  }
}


//As a patron, I want to check a book out, so that I can take it home with me. I should only be able to do this if I am logged in. // Add  public ApplicationUser { get; set; } where user needs to be logged in to view whatever.
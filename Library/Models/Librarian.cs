using System.Collections.Generic;

namespace Library.Models
{
  public class Librarian
  {
    
  }
}

//As a librarian, I want to see a list of overdue books, so that I can call up the patron who checked them out and tell them to bring them back — OR ELSE!

//As a librarian, I want to create, read, update, delete, and list books in the catalog, so that we can keep track of our inventory.

//As a librarian, I should only be able to create, update and delete if I am logged in. All users should be able to have read functionality. (Hint: authorize CUD routes for books.)

//As a librarian, I want to search for a book by author or title, so that I can find a book when there are a lot of books in the library.

//As a librarian, I want to enter multiple authors for a book, so that I can include accurate information in my catalog. (Hint: make an authors table and a books table with a many-to-many relationship.)
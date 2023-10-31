using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Library.Models
{
  public class LibraryContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<Copy> Copies { get; set; }
    public DbSet<Librarian> Librarians { get; set; }
    public DbSet<Patron> Patrons { get; set; }

    public LibraryContext(DbContextOptions options) : base(options) { }
  }
}
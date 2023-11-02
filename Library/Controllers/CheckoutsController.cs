using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
    [Authorize]
    public class CheckoutsController : Controller
    {
        private readonly LibraryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckoutsController(UserManager<ApplicationUser> userManager, LibraryContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult AddBook(int id)
        {
            Book thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
            ViewBag.CheckoutId = new SelectList(_db.Checkouts, "CheckoutId", "PatronId");
            return View(thisCheckout);
        }
        [HttpPost]
        public ActionResult AddCheckout(Book book, int checkoutId)
        {
            #nullable enable
            Checkout? joinEntity = _db.Checkouts.FirstOrDefault(join => (join.CheckoutId && join.CheckoutId == Checkout.CheckoutId));
            #nullable disable
            if (joinEntity == null && checkoutId !=0)
            {
                _db.Checkouts.Add(new Checkout() { CheckoutId = checkoutId, CheckoutId = checkout.CheckoutId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = patron.CheckoutId });
        }
    }
}

//Remove available copy 
//Add to Patrons Checkout list

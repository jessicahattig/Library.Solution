using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
  [Authorize] 
  public class CopiesController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager; 

    public CopiesController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      List<Copy> userCopies = _db.Copies
                          .Where(entry => entry.User.Id == currentUser.Id)
                          .Include(copy => copy.Book)
                          .ToList();
      return View(userCopies);
    }

    public ActionResult Create()
    {
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Copy copy, int BookId)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.BookId = new SelectList(_db.Books, "BookId", "Name");
        return View(copy);
      }
      else
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        copy.User = currentUser;
        _db.Copies.Add(copy);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Copy thisCopy = _db.Copies
          .Include(copy => copy.Book)
          .Include(copy => copy.JoinEntities)
          .ThenInclude(join => join.Patron)
          .FirstOrDefault(copy => copy.CopyId == id);
      return View(thisCopy);
    }

    public ActionResult Edit(int id)
    {
      Copy thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == id);
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Name");
      return View(thisCopy);
    }

    [HttpPost]
    public ActionResult Edit(Copy copy)
    {
      _db.Copies.Update(copy);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Copy thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == id);
      return View(thisCopy);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Copy thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == id);
      _db.Copies.Remove(thisCopy);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCheckout(int id)
    {
      Copy thisCopy = _db.Copies.FirstOrDefault(copys => copys.CopyId == id);
      ViewBag.TagId = new SelectList(_db.Checkouts, "CheckoutId", "Title");
      return View(thisCopy);
    }

    [HttpPost]
    public ActionResult AddCheckout(Copy copy, int checkoutId)
    {
      #nullable enable
      Checkout? joinEntity = _db.Checkouts.FirstOrDefault(join => (join.CheckoutId == checkoutId && join.CopyId == copy.CopyId));
      #nullable disable
      if (joinEntity == null && checkoutId != 0)
      {
        _db.Checkouts.Add(new Checkout() { CheckoutId = checkoutId, CopyId = copy.CopyId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = copy.CopyId });
    }   

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      Checkout joinEntry = _db.Checkouts.FirstOrDefault(entry => entry.CheckoutId == joinId);
      _db.Checkouts.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    } 
}
}

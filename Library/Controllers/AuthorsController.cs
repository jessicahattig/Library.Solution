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
    public class AuthorsController : Controller
    {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthorsController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
        _userManager = userManager;
        _db = db;
    }

    public async Task<ActionResult> Index()
    {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);List<Author> userAuthors = _db.Authors
                        .Where(entry => entry.User.Id == currentUser.Id)
                        .Include(author => author.Books)
                        .ToList();
        return View(userAuthors);
    }

    public ActionResult Create()
    {
        ViewBag.AuthorId = new SelectList(_db.Books, "BookId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Author author, int BookId)
    {
        if (!ModelState.IsValid)
        {
        ViewBag.BookId = new SelectList(_db.Books, "BookId", "Name");
        return View(author);
        }
        else
        {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        author.User = currentUser;
        _db.Authors.Add(author);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
    }

    public ActionResult Details(int id)
    {
        Author thisAuthor = _db.Authors
        .Include(author => author.Books)
        // .Include(author => author.JoinEntities)
        // // .ThenInclude(join => join.Tag)
        .FirstOrDefault(author => author.AuthorId == id);
        return View(thisAuthor);
    }

    public ActionResult Edit(int id)
    {
        Author thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);ViewBag.BookId = new SelectList(_db.Books, "BooksId", "Name");
        return View(thisAuthor);
    }

    [HttpPost]
    public ActionResult Edit(Author author)
    {
        _db.Authors.Update(author);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Author thisAuthor= _db.Authors.FirstOrDefault(author => author.AuthorId == id);
        return View(thisAuthor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Author thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);_db.Authors.Remove(thisAuthor);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    // public ActionResult AddTag(int id)
    // {
    //   Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
    //   ViewBag.TagId = new SelectList(_db.Tags, "TagId", "Title");
    //   return View(thisItem);
    // }

    // [HttpPost]
    // public ActionResult AddTag(Item item, int tagId)
    // {
    //   #nullable enable
    //   ItemTag? joinEntity = _db.ItemTags.FirstOrDefault(join => (join.TagId == tagId && join.ItemId == item.ItemId));
    //   #nullable disable
    //   if (joinEntity == null && tagId != 0)
    //   {
    //     _db.ItemTags.Add(new ItemTag() { TagId = tagId, ItemId = item.ItemId });
    //     _db.SaveChanges();
    //   }
    //   return RedirectToAction("Details", new { id = item.ItemId });
    // }   

    // [HttpPost]
    // public ActionResult DeleteJoin(int joinId)
    // {
    //   ItemTag joinEntry = _db.ItemTags.FirstOrDefault(entry => entry.ItemTagId == joinId);
    //   _db.ItemTags.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // } 
    }
}
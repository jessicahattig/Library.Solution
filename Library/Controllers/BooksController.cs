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
    public class BooksController : Controller
    {
        private readonly LibraryContext _db;

        public BooksController(LibraryContext db)
        {

        _db = db;
        }

        public ActionResult Index()
        {
        List<Book> model = _db.Books.ToList();
        return View(model);
        }

        public ActionResult Create()
        {
        return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
        _db.Books.Add(book);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
        Book thisBook = _db.Books
                                    .Include(book => book.Authors)
                                    .Include(book => book.Copies)
                                    .ThenInclude(copy => copy.JoinEntities)
                                    .ThenInclude(join => join.Patron)
                                    .FirstOrDefault(book => book.BookId == id);
        return View(thisBook);
        }

        public ActionResult Edit(int id)
        {
        Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
        return View(thisBook);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
        _db.Books.Update(book);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
        Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
        return View(thisBook);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
        Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
        _db.Books.Remove(thisBook);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
    }
}
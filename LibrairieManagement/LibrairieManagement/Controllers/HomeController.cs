using LibrairieManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrairieManagement.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (Dal dal = new Dal())
            {
                List<Book> books = dal.getAllBooks();
                return View(books);
            }
        }

        public ActionResult ModifyBook(int? id)
        {
            if (id.HasValue)
            {
                using (Dal dal = new Dal())
                {
                    Book book = dal.getAllBooks().FirstOrDefault(b => b.Id == id.Value);
                    if (book == null)
                        return View("Error");
                    return View(book);
                }
            }
            else
                return View("Error");
        }

        [HttpPost]
        public ActionResult ModifyBook(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);
            using (Dal dal = new Dal())
            {
                dal.ModifyBook(book.Id, book.Title, book.Date, book.Author, book.Amount);
                return RedirectToAction("Index");
            }
        }
    }
}
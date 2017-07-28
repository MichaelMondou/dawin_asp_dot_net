using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrairieManagement.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        public void CreateAuthor(string name)
        {
            bdd.Authors.Add(new Author { Name = name });
            bdd.SaveChanges();
        }

        public void ModifyAuthor(int id, string name)
        {
            Author authorFound = bdd.Authors.FirstOrDefault(author => author.Id == id);
            if (authorFound != null)
            {
                authorFound.Name = name;
                bdd.SaveChanges();
            }
        }

        public List<Author> getAllAuthors()
        {
            return bdd.Authors.ToList();
        }

        public void CreateBook(string title, DateTime date, Author author, int amount)
        {
            bdd.Books.Add(new Book { Title = title, Date = date, Author = author, Amount = amount });
            bdd.SaveChanges();
        }

        public void ModifyBook(int id, string title, DateTime date, Author author, int amount)
        {
            Book bookFound = bdd.Books.FirstOrDefault(book => book.Id == id);
            if (bookFound != null)
            {
                bookFound.Title = title;
                bookFound.Date = date;
                bookFound.Author = author;
                bookFound.Amount = amount;
                bdd.SaveChanges();
            }
        }

        public List<Book> getAllBooks()
        {
            return bdd.Books.ToList();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}
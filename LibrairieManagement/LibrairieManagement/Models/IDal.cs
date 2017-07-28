using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrairieManagement.Models
{
    interface IDal : IDisposable
    {
        void CreateAuthor(string name);
        void ModifyAuthor(int id, string name);
        List<Author> getAllAuthors();

        void CreateBook(string title, DateTime date, Author author, int amount);
        void ModifyBook(int id, string title, DateTime date, Author author, int amount);
        List<Book> getAllBooks();
    }
}

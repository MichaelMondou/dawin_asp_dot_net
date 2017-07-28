using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibrairieManagement.Models
{
    public class InitLibrairie : DropCreateDatabaseAlways<BddContext>
    {
        protected override void Seed(BddContext context)
        {
            context.Books.Add(new Book { Id = 1, Title = "The Fellowship of The Ring", Date = new DateTime(2017, 07, 28), Author = new Author { Id = 1, Name = "Tolkien" }, Amount = 50 });
            context.Books.Add(new Book { Id = 2, Title = "The Two Towers", Date = new DateTime(2017, 07, 28), Author = new Author { Id = 2, Name = "Tolkien" }, Amount = 50 });
            context.Books.Add(new Book { Id = 3, Title = "The Return Of The King", Date = new DateTime(2017, 07, 28), Author = new Author { Id = 3, Name = "Tolkien" }, Amount = 50 });

            base.Seed(context);
        }
    }
}
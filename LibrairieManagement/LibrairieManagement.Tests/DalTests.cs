using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibrairieManagement.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LibrairieManagement.Tests
{
    [TestClass]
    public class DalTests
    {
        [TestInitialize]
        public void Init_AvantChaqueTest()
        {
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());
        }

        [TestMethod]
        public void TestCreateAuthor()
        {
            using (Dal dal = new Dal())
            {
                dal.CreateAuthor("Tolkien");
                List<Author> authors = dal.getAllAuthors();

                Assert.IsNotNull(authors);
                Assert.AreEqual(1, authors.Count);
                Assert.AreEqual("Tolkien", authors[0].Name);
            }
        }

        [TestMethod]
        public void TestCreateBook()
        {
            using (Dal dal = new Dal())
            {
                dal.CreateBook("The Lord Of The Rings", new DateTime(2017, 07, 28), new Author { Name = "Tokien" }, 50);
                List<Book> books = dal.getAllBooks();

                Assert.IsNotNull(books);
                Assert.AreEqual(1, books.Count);
                Assert.AreEqual("The Lord Of The Rings", books[0].Title);
                Assert.AreEqual("Tokien", books[0].Author.Name);
            }
        }

        [TestMethod]
        public void ModifyAuthor()
        {
            using (Dal dal = new Dal())
            {
                dal.CreateAuthor("Tolkien");
                List<Author> authors = dal.getAllAuthors();
                int id = authors.First(a => a.Name == "Tolkien").Id;

                dal.ModifyAuthor(id, "J.R.R Tolkien");

                Assert.IsNotNull(authors);
                Assert.AreEqual(1, authors.Count);
                Assert.AreEqual("J.R.R Tolkien", authors[0].Name);
            }
        }

        [TestMethod]
        public void ModifyBook()
        {
            using (Dal dal = new Dal())
            {
                dal.CreateBook("The Lord Of The Rings", new DateTime(2017, 07, 28), new Author { Name = "Tolkien" }, 50);
                List<Book> books = dal.getAllBooks();
                int id = books.First(a => a.Title == "The Lord Of The Rings").Id;

                dal.ModifyBook(id, "LOTR : The Return Of The King", new DateTime(1934, 06, 01), new Author { Name = "J.R.R Tolkien" }, 30);

                Assert.IsNotNull(books);
                Assert.AreEqual(1, books.Count);
                Assert.AreEqual("LOTR : The Return Of The King", books[0].Title);
                Assert.AreEqual(new DateTime(1934, 06, 01), books[0].Date);
                Assert.AreEqual("J.R.R Tolkien", books[0].Author.Name);
                Assert.AreEqual(30, books[0].Amount);
            }
        }
    }
}

using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;


namespace TestingLayer
{
    public class BookContextUnitTest
    {
        private BookLibraryContext dbContext;
        private BookContext bookContext;
        DbContextOptionsBuilder builder;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            

        }

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            dbContext = new BookLibraryContext(builder.Options);
            bookContext = new BookContext(dbContext);
        }

        [Test]
        public void TestCreateBook()
        {
            int booksBefore = bookContext.ReadAll().Count();

            bookContext.Create(new Books("100+ vkusni vegan recepti", 300, "Alis Kenedi"));

            int booksAfter = bookContext.ReadAll().Count();

            Assert.IsTrue(booksBefore != booksAfter);
        }

        [Test]
        public void TestReadBook()
        {
            bookContext.Create(new Books("100+ vkusni vegan recepti", 300, "Alis Kenedi"));

            Books book = bookContext.Read(1);

            Assert.That(book != null, "There is no record with id 1!");
        }

        [Test]
        public void TestUpdateBook()
        {
            bookContext.Create(new Books("100+ vkusni vegan recepti", 300, "Alis Kenedi"));

            Books book = bookContext.Read(1);

            book.Name = "Qj i tichai";

            bookContext.Update(book);

            Books book1 = bookContext.Read(1);

            Assert.IsTrue(book1.Name == "Qj i tichai", "Book Update() does not change name!");
        }

        [Test]
        public void TestDeleteBook()
        {
            bookContext.Create(new Books("Delete book", 300, "Alis Kenedi"));

            int booksBeforeDeletion = bookContext.ReadAll().Count();

            bookContext.Delete(1);

            int booksAfterDeletion = bookContext.ReadAll().Count();

            Assert.AreNotEqual(booksBeforeDeletion, booksAfterDeletion);
        }
    }
}

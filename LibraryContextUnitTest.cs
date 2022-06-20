using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingLayer
{
    public class LibraryContextUnitTest
    {
        private BookLibraryContext dbContext;
        private LibraryContext libraryContext;
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
            libraryContext = new LibraryContext(dbContext);
        }

        [Test]
        public void TestCreateLibrary()
        {
            int booksBefore = libraryContext.ReadAll().Count();

            libraryContext.Create(new Library("74383239", "Dick's Tea Library", "Rue du Parc des Sports"));

            int librariesAfter = libraryContext.ReadAll().Count();

            Assert.IsTrue(booksBefore != librariesAfter);
        }

        [Test]
        public void TestReadLibrary()
        {
            libraryContext.Create(new Library("74383239", "Dick's Tea Library", "Rue du Parc des Sports"));

            Library library = libraryContext.Read("74383239");

            Assert.That(library != null, "There is no record with id 1!");
        }

        [Test]
        public void TestUpdateLibrary()
        {
            libraryContext.Create(new Library("74383239", "Dick's Tea Library", "Rue du Parc des Sports"));

            Library library = libraryContext.Read("74383239");

            library.Name = "Dick's Sand Library";

            libraryContext.Update(library);

            Library library1 = libraryContext.Read("74383239");

            Assert.IsTrue(library1.Name == "Dick's Sand Library", "Library Update() does not change name!");
        }

        [Test]
        public void TestDeleteLibrary()
        {
            libraryContext.Create(new Library("74383239", "Delete library", "Rue de Parc des Sports"));

            int librariesBeforeDeletion = libraryContext.ReadAll().Count();

            libraryContext.Delete("74383239");

            int librariesAfterDeletion = libraryContext.ReadAll().Count();

            Assert.AreNotEqual(librariesBeforeDeletion, librariesAfterDeletion);
        }
    }
}

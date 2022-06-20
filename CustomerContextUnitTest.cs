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
    public class CustomerContextUnitTest
    {
        private BookLibraryContext dbContext;
        private CustomerContext customerContext;
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
            customerContext = new CustomerContext(dbContext);
        }

        [Test]
        public void TestCreateCustomer()
        {
            int customersBefore = customerContext.ReadAll().Count();

            customerContext.Create(new Customers("Meltem", "Topal", 17));

            int customersAfter = customerContext.ReadAll().Count();

            Assert.IsTrue(customersBefore != customersAfter);
        }

        [Test]
        public void TestReadCustomer()
        {
            customerContext.Create(new Customers("Meltem", "Topal", 17));

            Customers customer = customerContext.Read(1);

            Assert.That(customer != null, "There is no record with id 1!");
        }

        [Test]
        public void TestUpdateCustomer()
        {
            customerContext.Create(new Customers("Meltem", "Topal", 17));

            Customers customer = customerContext.Read(1);

            customer.FirstName = "Mel";

            customerContext.Update(customer);

            Customers customer1 = customerContext.Read(1);

            Assert.IsTrue(customer1.FirstName == "Mel", "Customer Update() does not change name!");
        }

        [Test]
        public void TestDeleteCustomer()
        {
            customerContext.Create(new Customers("Delete customer", "Topal", 17));

            int customersBeforeDeletion = customerContext.ReadAll().Count();

            customerContext.Delete(1);

            int customersAfterDeletion = customerContext.ReadAll().Count();

            Assert.AreNotEqual(customersBeforeDeletion, customersAfterDeletion);
        }
    }
}

using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class CustomerContext
    : IDB<Customers, int>
    {
        private BookLibraryContext ctx;

        public CustomerContext(BookLibraryContext pctx)
        {
            ctx = pctx;
        }
        public void Create(Customers item)
        {
            try
            {
                ctx.Customers.Add(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Customers Read(int key)
        {
            try
            {
                return ctx.Customers.Find(key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<Customers> ReadAll()
        {
            try
            {
                return ctx.Customers.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(Customers item)
        {
            try
            {
                Customers old = Read(item.ID);
                ctx.Entry(old).CurrentValues.SetValues(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Delete(int key)
        {
            try
            {
                Customers item = Read(key);
                ctx.Customers.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}

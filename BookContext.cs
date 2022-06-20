using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class BookContext
    : IDB<Books, int>
    {
        private BookLibraryContext ctx;

        public BookContext(BookLibraryContext pctx)
        {
            ctx = pctx;
        }
        public void Create(Books item)
        {
            try
            {
                ctx.Books.Add(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Books Read(int key)
        {
            try
            {
                return ctx.Books.Find(key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<Books> ReadAll()
        {
            try
            {
                return ctx.Books.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(Books item)
        {
            try
            {
                Books oldbook = Read(item.ID);
                ctx.Entry(oldbook).CurrentValues.SetValues(item);
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
                Books book = Read(key);
                ctx.Books.Remove(book);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}

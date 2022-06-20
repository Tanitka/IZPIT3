using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class LibraryContext
    : IDB<Library, string>
    {
        private BookLibraryContext ctx;

        public LibraryContext(BookLibraryContext pctx)
        {
            ctx = pctx;
        }
        public void Create(Library item)
        {
            try
            {
                ctx.Library.Add(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Library Read(string key)
        {
            try
            {
                return ctx.Library.Find(key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<Library> ReadAll()
        {
            try
            {
                return ctx.Library.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(Library item)
        {
            try
            {
                Library oldLibrary = Read(item.EIK);
                ctx.Entry(oldLibrary).CurrentValues.SetValues(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Delete(string key)
        {
            try
            {
                Library item = Read(key);
                ctx.Library.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}

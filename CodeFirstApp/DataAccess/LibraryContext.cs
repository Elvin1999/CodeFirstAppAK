using CodeFirstApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApp.DataAccess
{
    public class LibraryContext:DbContext
    {
        public LibraryContext()
            :base("MyLibraryDb")
        {
            //Configuration.LazyLoadingEnabled = true;
            //Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}

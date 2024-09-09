using Azure.Core.GeoJson;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Imaging;
using WebAPIDemo.Model.Entity;

namespace WebAPIDemo.DataAccess
{
    public class BooksContext: DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
        }
    }
}

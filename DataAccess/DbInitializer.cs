using WebAPIDemo.Model.Entity;

namespace WebAPIDemo.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(BooksContext context)
        {
            if (context.Book.Any())
            {
                return;   // DB has been seeded
            }
            var books = new Book[]
            {
                new Book{Title="Chemistry",Author="Kai"},
               
                new Book{Title="Phantom",Author="Loan"}
            };
            context.Book.AddRange(books);
            context.SaveChanges();
        }

    }
}

using Data;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BookStoreContext :DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
        {

        }

       public DbSet<Books> books { get; set; }
    }
}

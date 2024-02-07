using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _context.books.Select(x=>new BookModel()
            {
                Id = x.Id,
                Title = x.Title,    
                Description = x.Description,
            }).ToListAsync();
            return records;
        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            
            var records = await _context.books.Where(x => x.Id == bookId).Select(x=> new BookModel()
            {
                Id=x.Id, 
                Title = x.Title,
                Description = x.Description,
            }).FirstOrDefaultAsync();

            return records;

            
        }

        public async Task<int>AddBookAsync(BookModel bookmodel)
        {
            var book = new Books()
            {
                Title = bookmodel.Title,

                Description = bookmodel.Description,
            };
            _context.books.Add(book);
           await _context.SaveChangesAsync();

            return book.Id;

        }

        public async Task<List<BookModel>> DeleteBook(int bookId)
        {

            var records = await _context.books.FindAsync(bookId);
            if (records != null)
            {
                _context.books.Remove(records);
                await _context.SaveChangesAsync();
            }
            return await GetAllBooksAsync();
            
        }
    }
}

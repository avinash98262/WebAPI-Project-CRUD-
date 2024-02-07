using Models;


namespace Repository
{
    public interface IBookRepository
    {
       public Task<List<BookModel>> GetAllBooksAsync();
       public Task<BookModel> GetBookByIdAsync(int bookId);
        public Task<int> AddBookAsync(BookModel bookmodel);

        public Task<List<BookModel>> DeleteBook(int bookId);
    }
}

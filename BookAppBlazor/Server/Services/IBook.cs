using BookAppBlazor.Shared;

namespace BookAppBlazor.Server.Services
{
    public interface IBook
    {
        public Task<List<Book>> GetBooks();
        public Task<Book> GetBook(int id);
        public Task<Book> AddBook(Book book);
        public Task UpdateBook(Book book);
        public Task DeleteBook(int id);

    }
}

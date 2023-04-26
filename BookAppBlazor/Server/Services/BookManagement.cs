using BookAppBlazor.Server.Models;
using BookAppBlazor.Shared;
using Microsoft.EntityFrameworkCore;

namespace BookAppBlazor.Server.Services
{
    public class BookManagement : IBook
    {
        readonly BookDbContext dbContext = new BookDbContext();

        public BookManagement(BookDbContext db)
        {
            dbContext = db;
        }

        public async Task<Book> AddBook(Book book)
        {
            try
            {
                await dbContext.Books.AddAsync(book);
                await dbContext.SaveChangesAsync();
                return book;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteBook(int id)
        {
            try
            {
                Book? book = await dbContext.Books.FindAsync(id);
                if(book != null)
                {
                    await Task.Run(() => dbContext.Books.Remove(book));
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Book> GetBook(int id)
        {
            try
            {
                Book? book = await dbContext.Books.FindAsync(id);
                if (book == null)
                    throw new ArgumentNullException();

                return book;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Book>> GetBooks()
        {
            try
            {
                return await dbContext.Books.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateBook(Book book)
        {
            try
            {
                dbContext.Entry(book).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}

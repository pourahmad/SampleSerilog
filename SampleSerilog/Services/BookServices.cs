using SampleSerilog.Models;

namespace SampleSerilog.Services;

public class BookServices : IBookServices
{
    public async Task<List<BookVm>> GetAllListBook()
    {
        return new List<BookVm>();
    }

    public async Task<BookVm> GetBookById(int id)
    {
        return new BookVm();
    }

    public async Task<BookVm> AddBook(BookDto book)
    {
        return new BookVm();
    }

    public async Task<BookVm> UpdateBook(BookDto book)
    {
        return new BookVm();
    }

    public async Task DeleteBook(int book)
    {
        
    }
}
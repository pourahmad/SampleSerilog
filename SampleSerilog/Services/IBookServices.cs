using SampleSerilog.Models;

namespace SampleSerilog.Services
{
    public interface IBookServices
    {
        Task<List<BookVm>> GetAllListBook();
        Task<BookVm> GetBookById(int id);
        Task<BookVm> AddBook(BookDto book);
        Task<BookVm> UpdateBook(BookDto book);
        Task DeleteBook(int book);
    }
}

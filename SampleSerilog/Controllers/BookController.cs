using Microsoft.AspNetCore.Mvc;
using SampleSerilog.Models;
using SampleSerilog.Services;
using static System.Reflection.Metadata.BlobBuilder;

namespace SampleSerilog.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController(ILogger<BookController> logger, IBookServices bookServices) : ControllerBase
{
    private readonly ILogger<BookController> _logger = logger;
    private readonly IBookServices _bookServices = bookServices;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        var books = await _bookServices.GetAllListBook();
        if (books.Count() == 0)
        {
            _logger.LogInformation("کتاب یافت نشد");
            return NotFound();
        }            

        _logger.LogInformation("لیست کتاب ها دریافت شد");
        return Ok(books);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var book = await _bookServices.GetBookById(id);
        if (book is null)
        {
            _logger.LogInformation("کتاب با شناسه {BookId} یافت نشد", id);
            return NotFound();
        }

        _logger.LogInformation("جزئیات کتاب {BookId} - ({BookName}) دریافت شد", book.Id, book.Name);
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Post(BookDto bookDto)
    {
        var book = await _bookServices.AddBook(bookDto);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Put(BookDto bookDto)
    {
        var book = await _bookServices.UpdateBook(bookDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _bookServices.DeleteBook(id);
        return Ok();
    }
}
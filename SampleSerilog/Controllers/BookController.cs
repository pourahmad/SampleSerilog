using Microsoft.AspNetCore.Mvc;

namespace SampleSerilog.Controllers;

public class BookController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
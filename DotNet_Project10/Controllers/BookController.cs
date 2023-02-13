using DotNet_Project10.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNet_Project10.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        public readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookList = _context.Books.ToList();
            return Json(new { data = bookList });
        }
        public IActionResult Delete(int id)
        {
            var bookInDb = _context.Books.Find(id);
            if (bookInDb == null)
                return Json(new { success = false, message = "Error while delete data!!" });
            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
            return Json(new { success = true, message = "Data delete sucessfully" });

        }
    }
}
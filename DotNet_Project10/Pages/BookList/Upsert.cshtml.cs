using DotNet_Project10.Data;
using DotNet_Project10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DotNet_Project10.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            //Create
            if (id == null)
                return Page();
            //Edit
            Book = await _context.Books.FindAsync(id);
            if (Book == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPost(Book book)
        {
            if (book.Id == 0)
                await _context.Books.AddAsync(book);//save
            else
                _context.Update(book);//update

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}

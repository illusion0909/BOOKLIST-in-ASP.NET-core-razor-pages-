using DotNet_Project10.Data;
using DotNet_Project10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DotNet_Project10.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]

        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _context.Books.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (Book == null) return NotFound();
            if (!ModelState.IsValid) return Page();

            _context.Update(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}

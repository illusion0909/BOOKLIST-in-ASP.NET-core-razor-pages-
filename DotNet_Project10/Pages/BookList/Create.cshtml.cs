using DotNet_Project10.Data;
using DotNet_Project10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace DotNet_Project10.Pages.BookList
{
    public class CreateModel : PageModel
    {
        public readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Book Book { get; set; }
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(/*Book book*/)
        {
            ///*if (book == null) return NotFound();*/
            if (Book == null) return NotFound();

            if (ModelState.IsValid)
            {
                //await _context.Books.AddAsync(book);
                await _context.Books.AddAsync(Book);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using crudTortillas.Data;
using crudTortillas.Model;

namespace crudTortillas.Pages.Productos
{
    public class CreateModel : PageModel
    {
        private readonly crudTortillas.Data.crudTortillasContext _context;

        public CreateModel(crudTortillas.Data.crudTortillasContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public productos productos { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.productos == null || productos == null)
            {
                return Page();
            }

            _context.productos.Add(productos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

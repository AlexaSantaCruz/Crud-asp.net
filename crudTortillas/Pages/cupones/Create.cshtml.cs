using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using crudTortillas.Data;
using crudTortillas.Model;

namespace crudTortillas.Pages.cupones
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
        public cuponesDescuento cuponesDescuento { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.cuponesDescuento == null || cuponesDescuento == null)
            {
                return Page();
            }

            _context.cuponesDescuento.Add(cuponesDescuento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

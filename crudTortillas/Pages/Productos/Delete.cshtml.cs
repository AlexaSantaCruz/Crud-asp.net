using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crudTortillas.Data;
using crudTortillas.Model;

namespace crudTortillas.Pages.Productos
{
    public class DeleteModel : PageModel
    {
        private readonly crudTortillas.Data.crudTortillasContext _context;

        public DeleteModel(crudTortillas.Data.crudTortillasContext context)
        {
            _context = context;
        }

        [BindProperty]
      public productos productos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.productos == null)
            {
                return NotFound();
            }

            var productos = await _context.productos.FirstOrDefaultAsync(m => m.Id == id);

            if (productos == null)
            {
                return NotFound();
            }
            else 
            {
                productos = productos;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.productos == null)
            {
                return NotFound();
            }
            var productos = await _context.productos.FindAsync(id);

            if (productos != null)
            {
                productos = productos;
                _context.productos.Remove(productos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

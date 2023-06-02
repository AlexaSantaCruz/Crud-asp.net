using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudTortillas.Data;
using crudTortillas.Model;

namespace crudTortillas.Pages.Productos
{
    public class EditModel : PageModel
    {
        private readonly crudTortillas.Data.crudTortillasContext _context;

        public EditModel(crudTortillas.Data.crudTortillasContext context)
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

            var productos =  await _context.productos.FirstOrDefaultAsync(m => m.Id == id);
            if (productos == null)
            {
                return NotFound();
            }
            productos = productos;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productosExists(productos.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool productosExists(int id)
        {
          return (_context.productos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

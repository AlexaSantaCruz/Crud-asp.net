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

namespace crudTortillas.Pages.cupones
{
    public class EditModel : PageModel
    {
        private readonly crudTortillas.Data.crudTortillasContext _context;

        public EditModel(crudTortillas.Data.crudTortillasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public cuponesDescuento cuponesDescuento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.cuponesDescuento == null)
            {
                return NotFound();
            }

            var cuponesdescuento =  await _context.cuponesDescuento.FirstOrDefaultAsync(m => m.id == id);
            if (cuponesdescuento == null)
            {
                return NotFound();
            }
            cuponesDescuento = cuponesdescuento;
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

            _context.Attach(cuponesDescuento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cuponesDescuentoExists(cuponesDescuento.id))
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

        private bool cuponesDescuentoExists(int id)
        {
          return (_context.cuponesDescuento?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

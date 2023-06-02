using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crudTortillas.Data;
using crudTortillas.Model;

namespace crudTortillas.Pages.cupones
{
    public class DeleteModel : PageModel
    {
        private readonly crudTortillas.Data.crudTortillasContext _context;

        public DeleteModel(crudTortillas.Data.crudTortillasContext context)
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

            var cuponesdescuento = await _context.cuponesDescuento.FirstOrDefaultAsync(m => m.id == id);

            if (cuponesdescuento == null)
            {
                return NotFound();
            }
            else 
            {
                cuponesDescuento = cuponesdescuento;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.cuponesDescuento == null)
            {
                return NotFound();
            }
            var cuponesdescuento = await _context.cuponesDescuento.FindAsync(id);

            if (cuponesdescuento != null)
            {
                cuponesDescuento = cuponesdescuento;
                _context.cuponesDescuento.Remove(cuponesDescuento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly crudTortillas.Data.crudTortillasContext _context;

        public DetailsModel(crudTortillas.Data.crudTortillasContext context)
        {
            _context = context;
        }

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
    }
}

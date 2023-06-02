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
    public class IndexModel : PageModel
    {
        private readonly crudTortillas.Data.crudTortillasContext _context;

        public IndexModel(crudTortillas.Data.crudTortillasContext context)
        {
            _context = context;
        }

        public IList<cuponesDescuento> cuponesDescuento { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.cuponesDescuento != null)
            {
                cuponesDescuento = await _context.cuponesDescuento.ToListAsync();
            }
        }
    }
}

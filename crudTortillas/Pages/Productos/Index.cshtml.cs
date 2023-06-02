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
    public class IndexModel : PageModel
    {
        private readonly crudTortillas.Data.crudTortillasContext _context;

        public IndexModel(crudTortillas.Data.crudTortillasContext context)
        {
            _context = context;
        }

        public IList<productos> productos { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.productos != null)
            {
                productos = await _context.productos.ToListAsync();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crudTortillas.Model;

namespace crudTortillas.Data
{
    public class crudTortillasContext : DbContext
    {
        public crudTortillasContext (DbContextOptions<crudTortillasContext> options)
            : base(options)
        {
        }

        public DbSet<crudTortillas.Model.User> User { get; set; } = default!;

        public DbSet<crudTortillas.Model.products>? productos { get; set; }

        public DbSet<crudTortillas.Model.cuponesDescuento>? cuponesDescuento { get; set; }
    }
}

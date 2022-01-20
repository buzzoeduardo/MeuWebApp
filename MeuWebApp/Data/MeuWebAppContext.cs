using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeuWebApp.Models;

namespace MeuWebApp.Data
{
    public class MeuWebAppContext : DbContext
    {
        public MeuWebAppContext (DbContextOptions<MeuWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Oficial> Oficial { get; set; }
        public DbSet<Venda> Venda { get; set; }
    }
}

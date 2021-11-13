using JOBTIND21.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {


        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Anuncio> Anuncio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

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
        public DbSet<UserTrabajador> UserTrabajadors { get; set; }
        public DbSet<PerfilTrabajador> PerfilTrabajadors { get; set; }
        public DbSet<PerfilEmpresa> PerfilEmpresas { get; set; }
        public DbSet<InfoAnuncio> InfoAnuncio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

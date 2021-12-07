using JOBTIND21.Data;
using JOBTIND21.Data.Base;
using JOBTIND21.Data.ViewModels;
using JOBTIND21.Dominio;
using JOBTIND21.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Repositorio
{
    public class AnuncioRepositorio :EntityBaseRepository<Anuncio>, IAnuncio
    {
        private ApplicationDbContext bd;

        public AnuncioRepositorio(ApplicationDbContext bd) : base(bd)
        {
            this.bd = bd;
        }

        public new IEnumerable<Anuncio> GetAll()
        {
            var anuncio = bd.Anuncio.Include(n => n.Usuario).Include(s => s.Empresa).ToList();
            return anuncio;
        }

        public void AddAnuncio(AnuncioViewModel data)
        {
            var newAnuncio = new Anuncio()
            {
                Categoria = data.Categoria,
                UsuarioID = data.UsuarioID,
                EmpresaID = data.EmpresaID,
                Anuncios= data.Anuncios,
                Estado = data.Estado = true
            };
            bd.Anuncio.Add(newAnuncio);
            bd.SaveChanges();
        }

        public void DeleteAnuncio(AnuncioViewModel data)
        {
            var anuncio = bd.Anuncio.FirstOrDefault(e => e.Id == data.Id);
            if (anuncio != null)
            {
                anuncio.Categoria = data.Categoria;
                anuncio.UsuarioID = data.UsuarioID;
                anuncio.EmpresaID = data.EmpresaID;
                anuncio.Anuncios = data.Anuncios;
                anuncio.Estado = data.Estado = false;

                bd.SaveChanges();
            }
        }

        public Anuncio GetAnouncementById(int id)
        {
            var anuncio = bd.Anuncio
                .Include(e => e.Empresa)
                .Include(u => u.Usuario)
                .FirstOrDefault(e => e.Id == id);

            return anuncio;
        }

        public AnuncioDropDown GetNewAnouncementValues()
        {
            var values = new AnuncioDropDown()
            {
                Usuario = bd.Usuarios.OrderBy(u => u.Nombres).ToList(),
                Empresa = bd.Empresas.OrderBy(e => e.NombreEmpresa).ToList()
            };

            return values;
        }

        public void UpdateAnuncio(AnuncioViewModel data)
        {
            var anuncio = bd.Anuncio.FirstOrDefault(e => e.Id == data.Id);
            if (anuncio != null)
            {
                anuncio.Categoria = data.Categoria;
                anuncio.UsuarioID = data.UsuarioID;
                anuncio.EmpresaID = data.EmpresaID;
                anuncio.Anuncios = data.Anuncios;
                anuncio.Estado = data.Estado = true;

                bd.SaveChanges();
            }
        }
    }
    
}

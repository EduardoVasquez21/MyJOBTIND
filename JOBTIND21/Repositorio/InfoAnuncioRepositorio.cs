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
    public class InfoAnuncioRepositorio : EntityBaseRepository<InfoAnuncio>, IAnuncioInfo
    {
        private ApplicationDbContext bd;

        public InfoAnuncioRepositorio(ApplicationDbContext bd) : base(bd)
        {
            this.bd = bd;
        }

        public new IEnumerable<InfoAnuncio> GetAll()
        {
            var info = bd.InfoAnuncio.Include(n => n.Anuncio).ToList();
            return info;
        }
        public void AddInfo(InfoAnuncioViewModel data)
        {
            var Adinfo = new InfoAnuncio()
            {
                AnuncioID = data.AnuncioID,
                EdadRequerida = data.EdadRequerida,
                Requisitos = data.Requisitos,
                Horarios = data.Horarios,
                Salario = data.Salario,
                Lugar = data.Lugar,
                Stado = data.Stado = true
            };
            bd.InfoAnuncio.Add(Adinfo);
            bd.SaveChanges();
        }

        public void DeleteInfo(InfoAnuncioViewModel data)
        {
            var info = bd.InfoAnuncio.FirstOrDefault(i => i.Id == data.Id);
            if (info != null)
            {
                info.AnuncioID = data.AnuncioID;
                info.EdadRequerida = data.EdadRequerida;
                info.Requisitos = data.Requisitos;
                info.Horarios = data.Horarios;
                info.Salario = data.Salario;
                info.Lugar = data.Lugar;
                info.Stado = data.Stado = false;

                bd.SaveChanges();
            }
        }

        public InfoAnuncio GetinfoById(int id)
        {
            var infoAnun = bd.InfoAnuncio
                .Include(i => i.Anuncio)
                .FirstOrDefault(e => e.Id == id);

            return infoAnun;
        }

        public InfoDropDown GetNewInfoValues()
        {
            var valor = new InfoDropDown()
            {
                Anuncio = bd.Anuncio.OrderBy(x => x.Anuncios).ToList(),
            };

            return valor;
        }

        public void UpdateInfo(InfoAnuncioViewModel data)
        {
            var info = bd.InfoAnuncio.FirstOrDefault(i => i.Id == data.Id);
            if (info != null)
            {
                info.AnuncioID = data.AnuncioID;
                info.EdadRequerida = data.EdadRequerida;
                info.Requisitos = data.Requisitos;
                info.Horarios = data.Horarios;
                info.Salario = data.Salario;
                info.Lugar = data.Lugar;
                info.Stado = data.Stado = true;

                bd.SaveChanges();
            }
        }
    }
}

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
    public class PerfilTrabajadorRepositorio : EntityBaseRepository<PerfilTrabajador>, IPerfilTrabajador
    {
        private ApplicationDbContext bd;

        public PerfilTrabajadorRepositorio(ApplicationDbContext bd) : base(bd)
        {
            this.bd = bd;
        }

        public new IEnumerable<PerfilTrabajador> GetAll()
        {
            var perfil = bd.PerfilTrabajadors.Include(n => n.UserTrabajador).ToList();
            return perfil;
        }

        public void AddPerfil(PerfilTrabajadorViewModel data)
        {
            var newPerfil = new PerfilTrabajador()
            {
                UserTrabajadorID = data.UserTrabajadorID,
                DUI = data.DUI,
                Telephone = data.Telephone,
                CVLink = data.CVLink,
                Descripcion = data.Descripcion,
                State = data.State = true
            };
            bd.PerfilTrabajadors.Add(newPerfil);
            bd.SaveChanges();
        }

        public void DeletePerfil(PerfilTrabajadorViewModel data)
        {
            var perfil = bd.PerfilTrabajadors.FirstOrDefault(p => p.Id == data.Id);
            if (perfil != null)
            {
                perfil.UserTrabajadorID = data.UserTrabajadorID;
                perfil.DUI = data.DUI;
                perfil.Telephone = data.Telephone;
                perfil.CVLink = data.CVLink;
                perfil.Descripcion = data.Descripcion;
                perfil.State = data.State = false;

                bd.SaveChanges();
            }
        }

        public PerfilTrabajador GetPerfilById(int id)
        {
            var perfil = bd.PerfilTrabajadors
                .Include(e => e.UserTrabajador)
                .FirstOrDefault(e => e.Id == id);

            return perfil;
        }

        public void UpdatePerfil(PerfilTrabajadorViewModel data)
        {
            var perfil = bd.PerfilTrabajadors.FirstOrDefault(p => p.Id == data.Id);
            if (perfil != null)
            {
                perfil.UserTrabajadorID = data.UserTrabajadorID;
                perfil.DUI = data.DUI;
                perfil.Telephone = data.Telephone;
                perfil.CVLink = data.CVLink;
                perfil.Descripcion = data.Descripcion;
                perfil.State = data.State = true;

                bd.SaveChanges();
            }
        }

        public PerfilDropDown GetNewPerfilValues()
        {
            var values = new PerfilDropDown()
            {
                UserTrabajadors = bd.UserTrabajadors.OrderBy(u => u.Name).ToList(),
            };

            return values;
        }
    }
}

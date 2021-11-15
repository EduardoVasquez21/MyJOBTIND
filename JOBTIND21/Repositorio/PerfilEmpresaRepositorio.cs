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
    public class PerfilEmpresaRepositorio : EntityBaseRepository<PerfilEmpresa>, IPerfilEmpresa
    {
        private ApplicationDbContext bd;

        public PerfilEmpresaRepositorio(ApplicationDbContext bd) : base(bd)
        {
            this.bd = bd;
        }

        public void AddPerfilE(PerfilEmpresaViewModels data)
        {
            var newPerfilE = new PerfilEmpresa()
            {
                EmpresaID = data.EmpresaID,
                DepartamentoOperario = data.DepartamentoOperario,
                DescripcionEmpresa = data.DescripcionEmpresa,
                States = data.States = true
            };
            bd.PerfilEmpresas.Add(newPerfilE);
            bd.SaveChanges();
        }

        public void DeletePerfilE(PerfilEmpresaViewModels data)
        {
            var perfilE = bd.PerfilEmpresas.FirstOrDefault(e => e.Id == data.Id);
            if (perfilE != null)
            {
                perfilE.EmpresaID = data.EmpresaID;
                perfilE.DepartamentoOperario = data.DepartamentoOperario;
                perfilE.DescripcionEmpresa = data.DescripcionEmpresa;
                perfilE.States = data.States = false;

                bd.SaveChanges();
            }
        }

        public new IEnumerable<PerfilEmpresa> GetAll()
        {
            var perfil = bd.PerfilEmpresas.Include(n => n.Empresa).ToList();
            return perfil;
        }

        public PerfilEDropDown GetNewPerfilEValues()
        {
            var value = new PerfilEDropDown()
            {
                Empresa = bd.Empresas.OrderBy(x => x.NombreEmpresa).ToList(),
            };

            return value;
        }

        public PerfilEmpresa GetPerfilEById(int id)
        {
            var perfilEmp = bd.PerfilEmpresas
                .Include(e => e.Empresa)
                .FirstOrDefault(e => e.Id == id);

            return perfilEmp;
        }

        public void UpdatePerfilE(PerfilEmpresaViewModels data)
        {
            var perfilE = bd.PerfilEmpresas.FirstOrDefault(e => e.Id == data.Id);
            if (perfilE != null)
            {
                perfilE.EmpresaID = data.EmpresaID;
                perfilE.DepartamentoOperario = data.DepartamentoOperario;
                perfilE.DescripcionEmpresa = data.DescripcionEmpresa;
                perfilE.States = data.States = true;

                bd.SaveChanges();
            }
        }
    }
}
